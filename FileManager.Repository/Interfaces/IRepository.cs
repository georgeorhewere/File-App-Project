
using System;


namespace FileManager.Repository
{

    public interface IRepository<T>
    {

        void Save(T entity);

    }

}