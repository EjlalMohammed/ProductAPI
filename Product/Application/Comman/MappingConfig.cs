using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comman
{
    public class MappingConfig
    {
        public static IMapper Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                // Add your AutoMapper mappings here
                //cfg.CreateMap<SourceClass, DestinationClass>();
            });

            return configuration.CreateMapper();
        }
    }
}
