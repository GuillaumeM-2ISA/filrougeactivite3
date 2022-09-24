using DAL.UOW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALExtension
    {
        public static void AddDALExtension(this IServiceCollection services)
        {
            services.AddScoped<IDBSession, DBSession>();
        }
    }
}
