using AutoMapper;
using RoomManagement.Data;
using RoomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Mappings
{
    public class Maps : Profile 
    {
        public Maps()
        {
            CreateMap<RoomType, RoomTypeViewModel>().ReverseMap(); 
            CreateMap<Employee, EmployeeViewModel>().ReverseMap(); 
            CreateMap<Booking, BookingViewModel>().ReverseMap(); 
            CreateMap<Booking, EditBookingViewModel>().ReverseMap(); 
            CreateMap<BookingRequest, BookingRequestViewModel>().ReverseMap(); 
            CreateMap<BookedRoom, BookedRoomViewModel>().ReverseMap(); 

        }

    }
}
