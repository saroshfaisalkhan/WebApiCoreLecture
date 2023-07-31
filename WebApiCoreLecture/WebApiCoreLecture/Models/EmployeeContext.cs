using Microsoft.EntityFrameworkCore;

namespace WebApiCoreLecture.Models
{
    public class EmployeeContext:DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<TblEmployee> tblEmployees { get; set; }
        public DbSet<TblDesignation> tblDesignations { get; set; }
    }
}
