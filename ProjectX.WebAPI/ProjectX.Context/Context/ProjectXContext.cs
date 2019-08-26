using Microsoft.EntityFrameworkCore;
using ProjectX.Context.Interface;
using ProjectX.Models.Models;

namespace ProjectX.Context.Context
{
    public class ProjectXContext: DbContext, IContext
    {

        public ProjectXContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-CLDPRBE\SQLEXPRESS;DataBase=HR;Trusted_Connection=True");

            // the use of lazy loading proxies and the virtual keyword will call the collection information outside of the master object
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapping to Tables
            modelBuilder.Entity<Employee>().ToTable("Employee", "emp");
            modelBuilder.Entity<Person>().ToTable("Person", "emp");
            modelBuilder.Entity<Profile>().ToTable("Account", "core");
            #endregion

            #region Employee mappings for fields and relationships
            modelBuilder.Entity<Employee>(Employee => 
            {
                Employee.HasKey(x => x.EmployeeId);
                Employee.Property(x => x.EmployeeId).HasColumnName("EmployeeId");
                Employee.Property(x => x.PartitionId).HasColumnName("PartitionId");

                //relationships for the employee Object
                Employee.HasOne(x => x.Person).WithOne(x => x.Employee).HasForeignKey<Person>(x => x.PersonId);
                Employee.HasOne(x => x.Profile).WithOne(x => x.Employee).HasForeignKey<Profile>(x => x.EmployeeId);
            });
            #endregion

            #region Person mappings 
            modelBuilder.Entity<Person>(Person => 
            {
                Person.HasKey(x => x.PersonId);
                Person.Property(x => x.PersonId).HasColumnName("PersonId");
                Person.Property(x => x.FirstName).HasColumnName("FirstName");
                Person.Property(x => x.LastName).HasColumnName("LastName");
            });
            #endregion

            #region Account mappings
            modelBuilder.Entity<Profile>(Account => 
            {
                Account.HasKey(x => x.EmployeeId);
                Account.Property(x => x.EmployeeId).HasColumnName("EmployeeId");
                Account.Property(x => x.Username).HasColumnName("Username");
                Account.Property(x => x.Password).HasColumnName("Password");
            });
            #endregion

        }

        public virtual DbSet<IEntity> SetEntity<IEntity>() where IEntity : class
        {
            //throw new NotImplementedException();
            return Set<IEntity>();
        }
    }
}
