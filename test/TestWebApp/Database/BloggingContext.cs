﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Database.Models;
using E;

namespace TestWebApp.Database
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbQuery<TestView> TestView { get; set; }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region 自定义校验器

            //// DbSet Check
            //E.EntityFrameworkCoreTableViewExtensions.DbSetCheck = (info) =>
            //{
            //    // 你的校验逻辑
            //    return true;// or false
            //};
            //// DbQuery Check
            //E.EntityFrameworkCoreTableViewExtensions.DbQueryCheck = (info) =>
            //{
            //    // 你的校验逻辑
            //    return true;// or false
            //};
            //// Column Chcek
            //E.EntityFrameworkCoreTableViewExtensions.ColumnCheck = (info) =>
            //{
            //    // 你的校验逻辑
            //    return true;// or false
            //}; 

            #endregion


            // 配置... [configurations...]

            // 禁用 使用DbSet/DbQuery名称作为表名和视图名称,优先读Table标记,其次类名
            E.EntityFrameworkCoreTableViewExtensions.UseDbSetNameToTableName = false;
            E.EntityFrameworkCoreTableViewExtensions.UseDbQueryNameToViewName = false;


            #region 如果使用 postgre_sql  [if use postgre_sql ]

            E.EntityFrameworkCoreTableViewExtensions.UseUpperCase = false;


            // 添加映射字段类型 [Adds a string of mapped field types]

            E.EntityFrameworkCoreTableViewExtensions.DbMapTypes.Add("System.String[]");
            E.EntityFrameworkCoreTableViewExtensions.DbMapTypes.Add("System.Boolean[]");
            E.EntityFrameworkCoreTableViewExtensions.DbMapTypes.Add("System.Int32[]");

            // 添加更多 [add more...]

            #endregion

            #region 如果使用 oracle [if use oracle]

            //E.EntityFrameworkCoreTableViewExtensions.UseUpperCase = true;


            //E.EntityFrameworkCoreTableViewExtensions.UseColumnNameMaxLength = true;
            //E.EntityFrameworkCoreTableViewExtensions.ColumnNameMaxLength = 30;

            //E.EntityFrameworkCoreTableViewExtensions.UseDefaultStringMaxLength = true;
            //E.EntityFrameworkCoreTableViewExtensions.DefaultStringMaxLength = 256;
            // 自定义 字符串列数据长度 是否设置默认长度 校验函数
            //E.EntityFrameworkCoreTableViewExtensions.CheckUseDefaultStringMaxLength = (type, prop) =>
            //{
            //    // 如果实体的命名空间为 TestWebApp.Database.Models 则设置长度
            //    return type.Namespace.StartsWith("TestWebApp.Database.Models");
            //};

            #endregion


            #region 如果使用postgresql 或者 oracle  [if use postgre_sql or oracle]

            modelBuilder.SetAllDbSetTableNameAndColumnName<BloggingContext>(true);
            modelBuilder.SetAllDbQueryViewNameAndColumnName<BloggingContext>(true);

            #endregion

        }


    }
}
