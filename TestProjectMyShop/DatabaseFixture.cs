using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Repositories;
using Microsoft.Extensions.Options;
namespace TestProjectMyShop
{
    public class DatabaseFixture: IDisposable
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
//using Microsoft.EntityFrameworkCore;
//using Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject
//{
//    public class DatabaseFixture
//    {
//        public _326774742WebApiContext Context { get; private set; }

//        public DatabaseFixture()
//        {
//            var options = new DbContextOptionsBuilder<_326774742WebApiContext>()
//                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;")
//                .Options;
//            Context = new _326774742WebApiContext(options);
//            Context.Database.EnsureCreated();

//        }
//        public void Dispose()
//        {
//            Context.Database.EnsureDeleted();
//            Context.Dispose();
//        }
//    }
