using Datery.API.DTOs;
using System;

namespace Datery.API.Controllers
{
    internal class PhotoForReturnDTO
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}