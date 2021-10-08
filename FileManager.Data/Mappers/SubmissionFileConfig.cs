using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FileManager.Data
{
    public class SubmissionFileConfig{
        
        public SubmissionFileConfig(EntityTypeBuilder<SubmissionFile> builder)
        {

            builder.ToTable("SubmissionFile");
            builder.Property(t=> t.SubmissionFileId);
            builder.Property(t=> t.Name);
            builder.Property(t=> t.TransactionId);
            builder.HasKey(t=> t.SubmissionFileId);            
            
        }
    }


}