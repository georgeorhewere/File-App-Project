using System;
using System.Collections.Generic;
using System.Linq;
using FileManager.Data;

namespace FileManager.Repository
{

    public class BaseRepository
    {
        protected readonly FileManagerDbContext context;

        public BaseRepository(FileManagerDbContext _context){
            context = _context;
        }
        


        public void LogError(string errorMessage){

        }

    }

}
