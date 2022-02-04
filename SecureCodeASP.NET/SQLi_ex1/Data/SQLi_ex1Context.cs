using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLi_ex1.Models;

namespace SQLi_ex1.Data
{
    public class SQLi_ex1Context : DbContext
    {
        public SQLi_ex1Context (DbContextOptions<SQLi_ex1Context> options)
            : base(options)
        {
        }

        public DbSet<SQLi_ex1.Models.Book> Book { get; set; }
    }
}
