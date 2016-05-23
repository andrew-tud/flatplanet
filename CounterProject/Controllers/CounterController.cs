using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CounterProject.Models;
using CounterProject.Models.Abstracts;
using CounterProject.Models.ViewModels;

namespace CounterProject.Controllers
{
    public class CounterController : ApiController
    {
        ICounterRepository _counterRepository;

        public CounterController(ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }

        public CounterViewModel Get()
        {
            Counter counter = _counterRepository.GetCounterByID(1);
            CounterViewModel counterVM = Mapper.Map<Counter, CounterViewModel>(counter);
            return counterVM;
        }

        public CounterViewModel Get(int id)
        {
            Counter counter = _counterRepository.GetCounterByID(1);
            if (counter.Counter1 < 10)
            {
                counter = _counterRepository.AddToCounterByID(1, id);
            }
            CounterViewModel counterVM = Mapper.Map<Counter, CounterViewModel>(counter);
            return counterVM;
        }
    }
}
