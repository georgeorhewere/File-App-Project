using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Data;

namespace FileManager.Repository
{

public interface ISubmissionRepository
{
        IEnumerable<Submission> GetSubmissions(int count=50);
        Submission GetSubmissionById(Guid transactionId);
        Task Save(Submission entity);
    }

}