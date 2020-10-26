using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //se existir alguma coisa na base de dados não fazemos nada
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998,4,21),1000.0,d1);
            Seller s2 = new Seller(2,"Maria Green", "maria@gmail.com", new DateTime(1979,12,31),3500.0,d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000,1,9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alexp@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2020, 3, 12),5000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020,4,22), 3300.0,SaleStatus.Pending,s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 4, 23), 3500.0, SaleStatus.Billed,s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2020, 4, 25), 4600.0, SaleStatus.Canceled, s4);

            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4,s5,s6);
            _context.SalesRecord.AddRange(r1,r2,r3,r4);

            _context.SaveChanges();
        }
    }
}
