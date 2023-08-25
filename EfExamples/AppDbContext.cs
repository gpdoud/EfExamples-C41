using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfExamples;

public class AppDbContext : DbContext { 

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Orderline> Orderlines { get; set; }

    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var connStr = "server=localhost\\sqlexpress;" +
                        "database=SalesDb;" +
                        "trusted_connection=true;" +
                        "trustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connStr);
    }
}
