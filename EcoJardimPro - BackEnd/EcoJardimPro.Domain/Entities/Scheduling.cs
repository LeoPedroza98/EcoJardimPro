using EcoJardimPro.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Domain.Entities
{
    public class Scheduling : IEntity
    {
        public long Id { get; set; }
        ICollection<Customer> Customers { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? LastDate { get; set; }
        public string StatusScheduling { get; set; }
    }
}
