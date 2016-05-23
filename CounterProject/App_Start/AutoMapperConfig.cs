using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterProject.Models;
using CounterProject.Models.ViewModels;

namespace CounterProject.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Counter, CounterViewModel>();
            AutoMapper.Mapper.CreateMap<CounterViewModel, Counter>();
        }
    }
}
