using AutoMapper;
using BlogTask.Models;
using BlogTaskDB.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask
{
    public class DomianProfile:Profile
    {
        public DomianProfile()
        {
            CreateMap<Group,GroupVM>().ReverseMap();
            CreateMap<GroupVM, Post>().ReverseMap();


            //CreateMap<List<Group>, List<GroupVM>>();
            //CreateMap< List<GroupVM>, List<Group>>();
            //Mapper.AssertConfigurationIsValid();
        }
    }
}
