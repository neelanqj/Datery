using Microsoft.AspNetCore.Http;
using System;

namespace Datery.API.Controllers
{
    public class PhotoForCreationDTO
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string PublicId { get; set; }
    }
}