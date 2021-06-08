using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VSC.Entityframeworkcore.EntityFramework
{
    public static class VSCDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VSCDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }
    }
}
