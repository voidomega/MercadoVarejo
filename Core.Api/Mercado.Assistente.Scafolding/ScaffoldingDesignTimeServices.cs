using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sa2s.Audit.Scafolding
{
    public class ScaffoldingDesignTimeServices : IDesignTimeServices
    {

        // ByteOn.FourFleet.Domain.Entities;
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            var options = ReverseEngineerOptions.DbContextAndEntities;
            services.AddHandlebarsScaffolding(options);
        }
    }
}
