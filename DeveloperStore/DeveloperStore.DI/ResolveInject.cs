using DeveloperStore.Application.Interface;
using DeveloperStore.Application.Services;
using DeveloperStore.Data;
using DeveloperStore.Data.Interface;
using DeveloperStore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperStore.DI
{
    public static class ResolveInject
    {
        public static void RegisterServices(IServiceCollection services, string strConnectMice)
        {

            services.AddDbContext<masterContext>(
                options => options.UseSqlServer(strConnectMice));

            #region Repositorio

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IProduct_SalesRepository, Product_SalesRepository>();

            #endregion

            #region Services

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<IProduct_SalesService, Product_SalesService>();

            #endregion


        }
    }
}