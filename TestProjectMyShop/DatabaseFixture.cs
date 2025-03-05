using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestProjectMyShop
{
    public class DatabaseFixture
    {
        public CatagoryContext Context { get; private set; }
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<CatagoryContext>()
                .UseSqlServer("Server=SRV2\\PUPILS;Database=Catagory;Trusted_Connection=True;TrustServerCertificate=True")
             
                .Options;
            Context = new CatagoryContext(options);
            Context.Database.EnsureCreated();

        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
