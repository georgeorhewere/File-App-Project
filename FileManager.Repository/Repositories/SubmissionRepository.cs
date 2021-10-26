using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Submission> GetSubmissions(string search = "", int page = 1, int take = 30)
        {
            int skip = (page - 1) * take;

            return context.Submissions
                           .Include(s => s.SubmissionFiles)
                           .Where(s=> (string.IsNullOrEmpty(search) || 
                                                  s.VendorName.Contains(search) ||
                                                  s.SubjectMatter.Contains(search)))
                                                 .Skip(skip)
                                                 .Take(take)
                                                 .ToList();
        }
    }

}
