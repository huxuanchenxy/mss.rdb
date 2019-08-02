using Microsoft.EntityFrameworkCore;
using rdbMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Repository
{
    public class EssDbContext : DbContext
    {
        public EssDbContext(DbContextOptions<EssDbContext> options) : base(options)
        {
        }

        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Event> Events { get; set; }

        //自定义DbContext实体属性名与数据库表对应名称（默认 表名与属性名对应是 User与Users）
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alarm>().ToTable("e_alarm").HasKey(a=>a.PID);
            modelBuilder.Entity<Event>().ToTable("e_log").HasKey(e => new {e.ETime,e.ETime_MS,e.PID }); 

        }
        

    }
}
