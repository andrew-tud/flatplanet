using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterProject.Models.Abstracts
{
    public interface ICounterRepository
    {
        Counter AddToCounterByID(int val, int counterID);
        Counter GetCounterByID(int counterID);
    }
}
