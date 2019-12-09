using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappers
{
    public class BLLMapperConfig
    {
        internal static IMapper mapper;
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            mapper = config.CreateMapper();

            return mapper;
        }
    }
}
