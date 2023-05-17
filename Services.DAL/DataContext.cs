namespace Services.DAL;

using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataContext : DbContext
{
    public DbSet<AppointmentsDto> Appointments { get; set; }
    public DbSet<CarDto> Cars { get; set; }
    public DbSet<DateDto> Dates { get; set; }
    public DbSet<FeedBackDto> FeedBacks { get; set; }
    public DbSet<RoleDto> Roles { get; set; }
    public DbSet<ServiceDto> Services { get; set; }
    public DbSet<StatusDto> Statuses { get; set; }
    public DbSet<TimeDto> Times { get; set; }
    public DbSet<UserDto> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<T> DbSet<T>() where T : class
    {
        return Set<T>();
    }

    public new IQueryable<T> Query<T>() where T : class
    {
        return Set<T>();
    }
}
