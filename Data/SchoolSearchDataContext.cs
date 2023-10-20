using SchoolSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolSearch.Data;
public class SchoolSearchDataContext : DbContext
{
    public SchoolSearchDataContext(DbContextOptions<SchoolSearchDataContext>? options)
        : base(options)
    {
    }

    public DbSet<SchoolSearch.Models.School> School { get; } = default!;

}
