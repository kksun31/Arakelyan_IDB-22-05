using Microsoft.EntityFrameworkCore;
using Laba3.Models;

namespace Laba3.Data
{
    public class AppDbContext : DbContext //класс базы данных
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated(); //создает табличку (бд) если ее нет
        }
        //какие таблички у нас есть в базе данных
        public DbSet<Laba3.Models.Employee> Employee { get; set; }
        public DbSet<Laba3.Models.Profession> Profession { get; set; }
        public DbSet<Laba3.Models.Emp_Prof> Emp_Prof { get; set; }
        public DbSet<Laba3.Models.PhoneNumber> PhoneNumber { get; set; }

    }
}
