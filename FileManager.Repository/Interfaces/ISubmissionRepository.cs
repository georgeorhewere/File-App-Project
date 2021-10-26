using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;

namespace FileManager.Repository
{

public interface ISubmissionRepository
{
        IEnumerable<Submission> GetSubmissions(string search = "", int page = 1, int take = 30);
        Submission GetSubmissionById(Guid transactionId);
        Task Save(Submission entity);
    }

}