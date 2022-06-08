using System;
using System.Data.Entity;
using System.Linq;

namespace ModernUI_FontAw.Model
{
    public class Admin : DbContext
    {
        // Your context has been configured to use a 'Admin' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ModernUI_FontAw.Model.Admin' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Admin' 
        // connection string in the application configuration file.
        public Admin()
            : base("name=Admin")
        {
            Database.SetInitializer<Admin>(new CreateDB());
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SalaryEmployee> SalaryEmployees { get; set; }
        public virtual DbSet<UseComputerHistory> UseComputerHistorys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<HistoryAccountUser> HistoryAccountUsers { get; set; }

        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<StatusShift> StatusShifts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}