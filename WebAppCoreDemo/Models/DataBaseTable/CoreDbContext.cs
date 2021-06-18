using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAppCoreDemo.Models.DataBaseTable
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 获取appsettings.json配置信息
            var config = new ConfigurationBuilder()
                            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            // 获取数据库连接字符串
            string conn = config.GetConnectionString("conn");
            //连接数据库
            optionsBuilder.UseSqlServer(conn);
        }

        public DbSet<Department> department { get; set; }
    }
}
