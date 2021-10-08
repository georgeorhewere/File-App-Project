using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;

namespace FileManager.Repository
{

    public class SubmissionFileRepository: BaseRepository,IRepository<SubmissionFile>,ISubmissionFileRepository
    {        

        public SubmissionFileRepository(FileManagerDbContext _context):base(_context)
        {
           
        }      

          public IEnumerable<SubmissionFile> GetSubmissionFiles(Guid transactionId, int count = 50)
          {
              // refactor to a generic search
                
                return context.SubmissionFiles.Where(sf=> sf.TransactionId == transactionId).Take(count).ToList();

          } 
            
         public SubmissionFile GetSubmissionFileById(Guid submissionFileId){
             return context.SubmissionFiles.Where(sf=> sf.SubmissionFileId == submissionFileId).FirstOrDefault();

         } 

        public void Save(SubmissionFile entity){
            try
            {
               
               context.SubmissionFiles.Add(entity);
               context.SaveChanges();
                

            }catch(Exception ex){
               /// database level error handling 
            }
        }


        

    }

}
