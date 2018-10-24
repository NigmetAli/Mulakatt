using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NigmetAli.Classes
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Description { get; set; }
        public string CodeArea { get; set; }
        public string Tags { get; set; }
        public int Score { get; set; }
        public bool HasTrue { get; set; }

        public virtual Member Member { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }


    public class QuestionMapping : EntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            base.ToTable("Questions");
            HasKey(x => x.Id);
            Property(x => x.Description).HasColumnName("Description").IsRequired();
            Property(x => x.CodeArea).HasColumnName("CodeArea").IsOptional();
            Property(x => x.Score).HasColumnName("Score").IsRequired();
            Property(x => x.MemberId).HasColumnName("MemberId").IsRequired();
            Property(x => x.HasTrue).HasColumnName("HasTrue").IsRequired();

            base.HasRequired(x => x.Member)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.MemberId).WillCascadeOnDelete(false);
        }
    }
}