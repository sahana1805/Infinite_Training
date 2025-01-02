using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Q2.Repository
{
    public interface IMovieRepository<T> where T : class
    { 
        void Insert(T entity);   
        void Update(T entity);    
        void Save();        
    }
}