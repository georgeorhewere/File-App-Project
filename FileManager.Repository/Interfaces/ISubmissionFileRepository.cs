using System;
using System.Collections.Generic;
using System.Linq;
using FileManager.Data;

namespace FileManager.Repository
{

public interface ISubmissionFileRepository
{        
    IEnumerable<SubmissionFile> GetSubmissionFiles(Guid transactionId, int count=50); 
    SubmissionFile GetSubmissionFileById(Guid submissionFileId); 

}

}