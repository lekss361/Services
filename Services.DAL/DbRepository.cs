namespace Services.DAL;

using Microsoft.EntityFrameworkCore;
using Services.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

public class DbRepository : IDbRepository
{
    private readonly DataContext _context;

    public DbRepository(DataContext context)
    {
        _context = context;
    }

    public IQueryable<T> Get<T>() where T : class, IBaseDto
    {
        return _context.Set<T>().Where(x => x.IsActive).AsQueryable();
    }

    public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IBaseDto
    {
        return _context.Set<T>().Where(selector).Where(x => x.IsActive).AsQueryable();
    }

    public int Add<T>(T newEntity) where T : class, IBaseDto
    {
        var c = _context.Set<T>().Add(newEntity);
        return c.Entity.Id;
    }

    public void AddRange<T>(IEnumerable<T> newEntities) where T : class, IBaseDto
    {
        _context.Set<T>().AddRangeAsync(newEntities);
    }

    public void Delete<T>(int id) where T : class, IBaseDto
    {
        var activeEntity = _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        activeEntity.Result.IsActive = false;
        _context.Update(activeEntity);
    }

    public void Remove<T>(T entity) where T : class, IBaseDto
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange<T>(IEnumerable<T> entities) where T : class, IBaseDto
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Update<T>(T entity) where T : class, IBaseDto
    {
        _context.Set<T>().Update(entity);
    }

    public void UpdateRange<T>(IEnumerable<T> entities) where T : class, IBaseDto
    {
        _context.Set<T>().UpdateRange(entities);
    }

    public int SaveChangesAsync()
    {
        return _context.SaveChanges();
    }

    public IQueryable<T> GetAll<T>() where T : class, IBaseDto
    {
        return _context.Set<T>().AsQueryable();
    }

}
