using FlowManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowManagement.Api.Data
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class FlowManagementDbContext : DbContext
    {
        public FlowManagementDbContext(DbContextOptions<FlowManagementDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 药品信息
        /// </summary>
        public DbSet<Medicine> Medicines { get; set; }

        /// <summary>
        /// 企业信息
        /// </summary>
        public DbSet<Enterprise> Enterprises { get; set; }

        /// <summary>
        /// 流向记录
        /// </summary>
        public DbSet<FlowRecord> FlowRecords { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置软删除过滤器
            modelBuilder.Entity<Medicine>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Enterprise>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<FlowRecord>().HasQueryFilter(f => !f.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

            // 配置 FlowRecord 的外键关系
            modelBuilder.Entity<FlowRecord>()
                .HasOne(f => f.Medicine)
                .WithMany()
                .HasForeignKey(f => f.MedicineId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlowRecord>()
                .HasOne(f => f.SourceEnterprise)
                .WithMany()
                .HasForeignKey(f => f.SourceEnterpriseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlowRecord>()
                .HasOne(f => f.TargetEnterprise)
                .WithMany()
                .HasForeignKey(f => f.TargetEnterpriseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
