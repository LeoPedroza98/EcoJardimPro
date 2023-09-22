using EcoJardimPro.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Domain.Entities
{
    public class Projects : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime InitialTerm { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal Cost { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }
}
