namespace Services.DAL;

using Services.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public interface IDbRepository
{
    int Add<T>(T newEntity) where T : class, IBaseDto;
    void AddRange<T>(IEnumerable<T> newEntities) where T : class, IBaseDto;
    void Delete<T>(int id) where T : class, IBaseDto;
    IQueryable<T> Get<T>() where T : class, IBaseDto;
    IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IBaseDto;
    IQueryable<T> GetAll<T>() where T : class, IBaseDto;
    void Remove<T>(T entity) where T : class, IBaseDto;
    void RemoveRange<T>(IEnumerable<T> entities) where T : class, IBaseDto;
    int SaveChangesAsync();
    void Update<T>(T entity) where T : class, IBaseDto;
    void UpdateRange<T>(IEnumerable<T> entities) where T : class, IBaseDto;
}