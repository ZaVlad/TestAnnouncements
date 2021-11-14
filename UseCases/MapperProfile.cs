using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Models;

namespace UseCases
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<Announcement, AnnouncementDto>();
        }
    }
}
