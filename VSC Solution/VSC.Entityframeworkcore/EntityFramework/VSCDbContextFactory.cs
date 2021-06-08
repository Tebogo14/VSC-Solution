using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VSC.Entityframeworkcore.Configuration;

namespace VSC.Entityframeworkcore.EntityFramework
{
    public class VSCDbContextFactory : IDesignTimeDbContextFactory<VSCDbContext>
    {
        public VSCDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VSCDbContext>();

            var configuration = AppConfigurations.Get(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("\\") + 1));

            VSCDbContextConfigurer.Configure(builder, configuration.GetConnectionString(VSCConts.ConnectionStringName));

            return new VSCDbContext(builder.Options);
        }
    }
}
