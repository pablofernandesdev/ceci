using Microsoft.AspNetCore.Mvc;

namespace Ceci.Domain.DTO.Address
{
    public class AddressZipCodeDTO
    {
        /// <summary>
        /// Zip code
        /// </summary>
        [BindProperty(Name = "zipCode")]
        public string ZipCode { get; set; }
    }
}
