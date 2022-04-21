using Ceci.Domain.Entities;
using Ceci.Domain.Interfaces.Repository;
using Ceci.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ceci.Domain.DTO.Commons;
using AutoMapper;
using Ceci.Domain.DTO.User;
using Ceci.Infra.CrossCutting.Extensions;
using Ceci.Domain.DTO.Email;
using Hangfire;
using Microsoft.AspNetCore.Http;

namespace Ceci.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IBackgroundJobClient _jobClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork uow,
            IMapper mapper,
            IEmailService emailService,
            IBackgroundJobClient jobClient,
            IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _emailService = emailService;
            _jobClient = jobClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultDataResponse<IEnumerable<UserResultDTO>>> GetAsync(UserFilterDTO filter)
        {
            var response = new ResultDataResponse<IEnumerable<UserResultDTO>>();

            try
            {
                response.Data = _mapper.Map<IEnumerable<UserResultDTO>>(await _uow.User.GetByFilterAsync(filter));
                response.TotalItems = await _uow.User.GetTotalByFilterAsync(filter);
                response.TotalPages = (int)Math.Ceiling((double)response.TotalItems / filter.PerPage);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse<UserResultDTO>> GetLoggedInUserAsync()
        {
            var response = new ResultResponse<UserResultDTO>();

            try
            {
                var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId();

                response.Data = _mapper.Map<UserResultDTO>(await _uow.User.GetUserByIdAsync(Convert.ToInt32(userId)));
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> AddAsync(UserAddDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                obj.Password = PasswordExtension.EncryptPassword(obj.Password);
                await _uow.User.AddAsync(_mapper.Map<User>(obj));
                await _uow.CommitAsync();

                response.Message = "User successfully added.";

                _jobClient.Enqueue(() => _emailService.SendEmailAsync(new EmailRequestDTO
                {
                    Body = "User successfully added.",
                    Subject = obj.Name,
                    ToEmail = obj.Email
                }));
            }
            catch (Exception ex)
            {
                response.Message = "Could not add user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> SelfRegistrationAsync(UserSelfRegistrationDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var basicProfile = await _uow.Role.GetBasicProfile();

                obj.Password = PasswordExtension.EncryptPassword(obj.Password);

                var newUser = _mapper.Map<User>(obj);
                newUser.RoleId = basicProfile.Id;

                await _uow.User.AddAsync(newUser);
                await _uow.CommitAsync();

                response.Message = "User successfully added.";

                _jobClient.Enqueue(() => _emailService.SendEmailAsync(new EmailRequestDTO
                {
                    Body = "User successfully added.",
                    Subject = obj.Name,
                    ToEmail = obj.Email
                }));
            }
            catch (Exception ex)
            {
                response.Message = "Could not add user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> DeleteAsync(UserDeleteDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var user = await _uow.User.GetFirstOrDefaultAsync(c => c.Id == obj.UserId);

                _uow.User.Delete(user);
                await _uow.CommitAsync();

                response.Message = "User successfully deleted.";
            }
            catch (Exception ex)
            {
                response.Message = "Could not deleted user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> UpdateAsync(UserUpdateDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var emailRegistered = await _uow.User
                    .GetFirstOrDefaultAsync(c => c.Email == obj.Email && c.Id != obj.UserId);

                if (emailRegistered != null)
                {
                    return new ResultResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "E-mail already registered"
                    };
                }

                var user = await _uow.User.GetFirstOrDefaultAsync(c => c.Id == obj.UserId);

                user = _mapper.Map(obj, user);

                _uow.User.Update(user);
                await _uow.CommitAsync();

                response.Message = "User successfully updated.";
            }
            catch (Exception ex)
            {
                response.Message = "Could not updated user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> UpdateLoggedUserAsync(UserLoggedUpdateDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId();

                var emailRegistered = await _uow.User
                    .GetFirstOrDefaultNoTrackingAsync(c => c.Email == obj.Email && c.Id != Convert.ToInt32(userId));

                if (emailRegistered != null)
                {
                    return new ResultResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "E-mail already registered"
                    };
                }

                var user = await _uow.User.GetFirstOrDefaultAsync(c => c.Id == Convert.ToInt32(userId));

                user = _mapper.Map(obj, user);

                _uow.User.Update(user);
                await _uow.CommitAsync();

                response.Message = "User successfully updated.";
            }
            catch (Exception ex)
            {
                response.Message = "Could not updated user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> UpdateRoleAsync(UserUpdateRoleDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var user = await _uow.User.GetFirstOrDefaultAsync(c => c.Id == obj.UserId);

                user = _mapper.Map(obj, user);

                _uow.User.Update(user);
                await _uow.CommitAsync();

                response.Message = "User role updated successfully.";
            }
            catch (Exception ex)
            {
                response.Message = "Could not updated user role.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse<UserResultDTO>> GetByIdAsync(int id)
        {
            var response = new ResultResponse<UserResultDTO>();

            try
            {
                response.Data = _mapper.Map<UserResultDTO>(await _uow.User.GetUserByIdAsync(id));
            }
            catch (Exception ex)
            {
                response.Message = "It was not possible to search the user.";
                response.Exception = ex;
            }

            return response;
        }

        public async Task<ResultResponse> RedefinePasswordAsync(UserRedefinePasswordDTO obj)
        {
            var response = new ResultResponse();

            try
            {
                var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId();

                var user = await _uow.User
                    .GetFirstOrDefaultAsync(c => c.Id.Equals(Convert.ToInt32(userId)));

                if (!PasswordExtension.DecryptPassword(user.Password).Equals(obj.CurrentPassword))
                {
                    response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                    response.Message = "Password incorret.";
                    return response;
                };

                user.Password = PasswordExtension.EncryptPassword(obj.NewPassword);

                _uow.User.Update(user);
                await _uow.CommitAsync();

                response.Message = "Password user successfully updated.";
            }
            catch (Exception ex)
            {
                response.Message = "Could not updated password user.";
                response.Exception = ex;
            }

            return response;
        }
    }
}
