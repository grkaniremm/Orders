using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
namespace ServerApp.Data
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext>options):base(options)
        {

        }

        public DbSet<Order> Orders {get; set;}
        public DbSet<Material> Materials {get; set;}
        public DbSet<StatuLog> StatuLogs {get; set;}
        public DbSet<AgirlikBirim> AgirlikBirim {get; set;}

        public DbSet<MiktarBirim> MiktarBirim {get; set;}

        public DbSet<Statu> Statu {get; set;}




    }
}
