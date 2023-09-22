using EcoJardimPro.Data.Common;
using EcoJardimPro.Data.Context;
using EcoJardimPro.Data.Interfaces;
using EcoJardimPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimPro.Data.Repositories
{
    public class CustomerRepository : CrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EcoJardimProContext context) : base(context)
        {
        }
    }
}
