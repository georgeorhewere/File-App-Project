using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;

namespace FileManager.Repository
{

    public class SubmissionRepository: BaseRepository, ISubmissionRepository
    {        

        public SubmissionRepository(FileManagerDbContext _context):base(_context)
        {
           
        }      

        public IEnumerable<Submission> GetSubmissions(int count=50){ 

            return context.Submissions.Take(50).ToList();

        }
        public Submission GetSubmissionById(Guid transactionId){
            return context.Submissions.Where(s=> s.TransactionId == transactionId).FirstOrDefault();
        }

        public async Task Save(Submission entity){
            try
            {
               
               context.Submissions.Add(entity);
               await context.SaveChangesAsync();
                

            }catch(Exception ex){
               /// database level error handling 
            }
        }


        

    }

}
