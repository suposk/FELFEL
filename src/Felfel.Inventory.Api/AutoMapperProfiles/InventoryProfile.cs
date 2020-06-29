using AutoMapper;
using Felfel.Inventory.Domain;
using Felfel.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Felfel.Inventory.Api.AutoMapperProfiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<BatchDto, Batch>()
                .ReverseMap();
        }       
    }
}
