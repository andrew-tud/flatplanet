using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CounterProject.Models.Abstracts;

namespace CounterProject.Models.Concretes
{
    public class CounterRepository : ICounterRepository
    {
        public Counter AddToCounterByID(int increment, int counterID)
        {
            using (var db = new CounterEntities())
            {
                Counter result = db.Counters.SingleOrDefault(u => u.CounterID == counterID);
                if (result != null)
                {
                    result.Counter1 = result.Counter1 + increment;
                    db.SaveChanges();
                }
                return result;
            }
        }

        public Counter GetCounterByID(int counterID)
        {
            using (var db = new CounterEntities())
            {
                Counter result = db.Counters.SingleOrDefault(u => u.CounterID == counterID);
                return result;
            }
        }
    }
}