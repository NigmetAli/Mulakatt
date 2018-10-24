using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NigmetAli.Classes
{
    public class Answer
    {
        public Answer()
        {
            Comments = new List<Comment>();
        }


        public int Id { get; set; }
        public string Description { get; set; }
        public string CodeArea { get; set; }
        public int Score { get; set; }
        public int MemberId { get; set; }
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; }

        public Member Member { get; set; }
        public Question Question { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class AnswerMapping : EntityTypeConfiguration<Answer>
    {
        public AnswerMapping()
        {
            base.ToTable("Answers");
            HasKey(x => x.Id);
            Property(x => x.Description).HasColumnName("Description").IsRequired();
            Property(x => x.CodeArea).HasColumnName("CodeArea").IsOptional();
            Property(x => x.Score).HasColumnName("Score").IsRequired();
            Property(x => x.MemberId).HasColumnName("MemberId").IsRequired();
            Property(x => x.QuestionId).HasColumnName("QuestionId").IsRequired();
            Property(x => x.IsTrue).HasColumnName("IsTrue").IsRequired();


            base.HasRequired(x => x.Member)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.MemberId);

            base.HasRequired(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}