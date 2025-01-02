using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC_Q2.Models;

namespace MVC_Q2.Repository
{
    public class MovieRepository<T> : IMovieRepository<T> where T : class
    {
        private readonly MoviesDbContext db;
        private readonly DbSet<T> dbset;

        public MovieRepository()
        {
            db = new MoviesDbContext();
            dbset = db.Set<T>();
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }
        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
