using EcoJardimPro.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Domain.Entities
{
    public class Manager : IEntity
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get;set; }
    }
}
