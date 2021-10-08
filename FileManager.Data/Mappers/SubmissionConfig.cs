using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManager.Data
{
    public class SubmissionConfig{

        public SubmissionConfig(EntityTypeBuilder<Submission> builder)
        {

            builder.ToTable("Submissions");
            builder.Property(t=> t.TransactionId);
            builder.Property(t=> t.SubjectMatter);
            builder.Property(t=> t.VendorName);
            builder.HasKey(t=> t.TransactionId);
            builder.HasMany(t=> t.SubmissionFiles).WithOne().HasForeignKey(t=> t.TransactionId);
            
        }
    }


}