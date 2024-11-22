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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        protected masterContext Db;
        protected DbSet<Product> Dbset;

        public ProductRepository(masterContext context) : base(context)
        {
            Db = context;
            Dbset = Db.Set<Product>();
        }
    }
}