using AutoMapper;
using Datery.API.Controllers;
using Datery.API.DTOs;
using Datery.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datery.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoURL, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => opt.MapFrom(d => d.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailDTO>()
                .ForMember(dest => dest.PhotoURL, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => opt.MapFrom(d => d.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailDTO>();
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<Photo, PhotoForReturnDTO>();
            CreateMap<PhotoForCreationDTO, Photo>();
            CreateMap<UserForRegistrationDTO, User>();
            CreateMap<MessageForCreationDTO, Message>()
                .ReverseMap();
            CreateMap<Message, MessageToReturnDTO>()
                .ForMember(m => m.SenderPhotoUrl, 
                opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p=>p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, 
                opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}
