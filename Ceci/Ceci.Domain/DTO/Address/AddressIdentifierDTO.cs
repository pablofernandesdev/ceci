using Microsoft.AspNetCore.Mvc;

namespace Ceci.Domain.DTO.Address
{
    public class AddressIdentifierDTO
    {
        /// <summary>
        /// Identifier address
        /// </summary>
        [BindProperty(Name = "addressId")]
        public int AddressId { get; set; }
    }
}
