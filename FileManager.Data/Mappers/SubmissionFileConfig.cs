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
            builder.Property(t=> t.Name).IsRequired();
            builder.Property(t => t.UniqueName).IsRequired();
            builder.Property(t=> t.TransactionId).IsRequired();
            builder.Property(t => t.DateCreated).IsRequired();
            builder.Property(t => t.DateModified).IsRequired();
            builder.HasKey(t=> t.SubmissionFileId);            
            
        }
    }


}