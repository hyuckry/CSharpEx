using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirstDemo
{
    class DepartmentDemo
    {
        public int Did { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    class OrganizationContext:DbContext
    {
        public DbSet<DepartmentDemo> departments { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrganizationContext context = new OrganizationContext();
            var Depts = context.departments.ToList();
        }
    }
}
