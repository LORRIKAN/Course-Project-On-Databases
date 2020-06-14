using LogisticsCenter.Model;
using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Presenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace LogisticsCenter.Repository
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(RepositoryHandler handler)
        {
            var listener = this.GetService<DiagnosticSource>();
            (listener as DiagnosticListener).SubscribeWithAdapter(handler);

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TransferOrder> TransferOrders { get; set; }
        public DbSet<TransferRoute> TransferRoutes { get; set; }
        public DbSet<TransferOrderContent> TransferOrderContents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<StationaryStock> StationaryStocks { get; set; }
        public DbSet<StationaryWarehouse> StationaryWarehouses { get; set; }
        public DbSet<ProductOrMaterial> ProductsAndMaterials { get; set; }
        public DbSet<TransitWarehouse> TransitWarehouses { get; set; }
        public DbSet<ProductionStep> ProductionSteps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        public bool CheckIfEntityHasChanges<T>() where T : class, IModel
        {
            return ChangeTracker.Entries<T>().Any(e => e.State == EntityState.Modified
            || e.State == EntityState.Added || e.State == EntityState.Deleted);
        }

        public void TrySave(bool abortLastChangeifFailed = true)
        {
            using (var transaction = Database.BeginTransaction())
            {
                try { SaveChanges(false); }
                catch (Exception e)
                {
                    if (abortLastChangeifFailed)
                    {
                        ChangeTracker.Entries().Last().State = EntityState.Detached;
                    }
                    throw e;
                }
                finally { transaction.Rollback(); }
            }
        }

        public void UpdateDb()
        {
            UpdateTransferOrdersStatuses();
            SaveChanges();
        }

        private void UpdateTransferOrdersStatuses()
        {
            var transferOrders = TransferOrders.ToList();
            foreach (var order in transferOrders)
            {
                var status = order.Status;
                var transferRoute = order.TransferRoute;
                var sendingDate = order.SendingDate;
                var receivingDate = order.ReceivingDate;
                var transitWarehouse = order.TransferRoute.TransitWarehouse;

                if (status == OrderStatuses.AwaitingSendingDate && DateTime.Now >= sendingDate)
                    status = OrderStatuses.AwaitingToBeSent;

                if (status == OrderStatuses.AwaitingToBeSent && !transferRoute.InitialWarehouseID.StartsWith("С"))
                {
                    status = OrderStatuses.InTransit;
                    transitWarehouse.Status = TransitWarehouseStatuses.Busy;
                }

                if (status == OrderStatuses.InTransit && DateTime.Now >= receivingDate)
                {
                    status = OrderStatuses.AwaitingToBeReceived;

                    if (!TransferOrders.Any(to => to.Status == OrderStatuses.InTransit
                    && to.TransferRoute.TransitWarehouseID == transferRoute.TransitWarehouseID))
                        transitWarehouse.Status = TransitWarehouseStatuses.NotBusy;
                }

                if (status == OrderStatuses.AwaitingToBeReceived && !transferRoute.FinalWarehouseID.StartsWith("С"))
                {
                    status = OrderStatuses.Closed;
                }

                if (status == OrderStatuses.AwaitingToBeSent && DateTime.Now >= receivingDate)
                    status = OrderStatuses.Outdated;
                order.Status = status;

                TransferOrders.Update(order);
                TransitWarehouses.Update(transitWarehouse);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransferOrder>(entity =>
            {
                entity.HasIndex(e => e.TransferRouteID)
                    .HasName("IX_Relationship10");

                entity.HasIndex(e => e.LogisticianLogin)
                    .HasName("IX_Relationship2");

                entity.Property(e => e.OrderID).ValueGeneratedOnAdd();

                entity.HasOne(d => d.TransferRoute)
                    .WithMany(p => p.TransferOrders)
                    .HasForeignKey(d => d.TransferRouteID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Logistician)
                    .WithMany(p => p.TransferOrders)
                    .HasForeignKey(d => d.LogisticianLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransferRoute>(entity =>
            {
                entity.HasIndex(e => e.FinalWarehouseID)
                    .HasName("IX_Конец маршрута");

                entity.HasIndex(e => e.InitialWarehouseID)
                    .HasName("IX_Начало маршрута");

                entity.HasIndex(e => e.TransitWarehouseID)
                    .HasName("IX_Промежуточный пункт");

                entity.Property(e => e.RouteID).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FinalWarehouse)
                    .WithMany(p => p.TransferRoutesAsFinal)
                    .HasForeignKey(d => d.FinalWarehouseID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.InitialWarehouse)
                    .WithMany(p => p.TransferRoutesAsInitial)
                    .HasForeignKey(d => d.InitialWarehouseID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TransitWarehouse)
                    .WithMany(p => p.TransferRoutes)
                    .HasForeignKey(d => d.TransitWarehouseID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransferOrderContent>(entity =>
            {
                entity.HasKey(e => new { e.ResourceID, e.TransferOrderID });

                entity.HasOne(d => d.TransferOrder)
                    .WithMany(p => p.OrderContent)
                    .HasForeignKey(d => d.TransferOrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TransferOrderContents)
                    .HasForeignKey(d => d.ResourceID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.SpecialityID)
                    .HasName("IX_Relationship1");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SpecialityID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.Property(e => e.SpecialityID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => new { e.OutputOrInputResourceID, e.ProductionStepID });

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.OutputOrInputResourceID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductionStep)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.ProductionStepID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StationaryStock>(entity =>
            {
                entity.HasKey(e => new { e.ResourceID, e.WarehouseID });

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.StationaryStocks)
                    .HasForeignKey(d => d.ResourceID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.StationaryStocks)
                    .HasForeignKey(d => d.WarehouseID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StationaryWarehouse>(entity =>
            {
                entity.HasIndex(e => e.WarehousemanID)
                    .HasName("IX_Заведует");

                entity.HasOne(d => d.Warehouseman)
                    .WithMany(p => p.StationaryWarehouses)
                    .HasForeignKey(d => d.WarehousemanID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransitWarehouse>(entity =>
            {
                entity.Property(e => e.WarehouseID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProductionStep>(entity =>
            {
                entity.HasIndex(e => e.NextStepID)
                    .HasName("IX_Relationship7");

                entity.Property(e => e.StepID).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
