using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperStore.Data.Interface;
using DeveloperStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Data.Repository
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {

        protected masterContext Db;
        protected DbSet<Sale> Dbset;

        public SaleRepository(masterContext context) : base(context)
        {
            Db = context;
            Dbset = Db.Set<Sale>();
        }
    }
}
