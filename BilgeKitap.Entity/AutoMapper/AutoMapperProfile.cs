using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BilgeKitap.Entity.DTOs;

namespace BilgeKitap.Entity.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Book, BookDetailDto>()
                .ForMember(dto => dto.CategoryName, src => src.MapFrom(s => s.BookCategories.CategoryName))
                .ForMember(dto => dto.Authorname, src => src.MapFrom(a => a.Author.Firstname));
                
              
        }
    }
}
