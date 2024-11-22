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
    public class Product_SalesRepository : RepositoryBase<Product_Sale>, IProduct_SalesRepository
    {

        protected masterContext Db;
        protected DbSet<Product_Sale> Dbset;

        public Product_SalesRepository(masterContext context) : base(context)
        {
            Db = context;
            Dbset = Db.Set<Product_Sale>();
        }
    }
}
