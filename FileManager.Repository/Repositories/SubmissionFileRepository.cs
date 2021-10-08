using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;

namespace FileManager.Repository
{

    public class SubmissionFileRepository: BaseRepository,ISubmissionFileRepository
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

        public async Task SaveList(IEnumerable<SubmissionFile> entities)
        {
            try
            {
                await context.SubmissionFiles.AddRangeAsync(entities);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                /// database level error handling 
                throw;
            }
        }
    }

}
