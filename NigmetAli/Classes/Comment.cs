using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NigmetAli.Classes
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public int MemberId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    }

    public class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            base.ToTable("Comments");
            HasKey(x => x.Id);
            Property(x => x.Description).HasColumnName("Description").IsRequired();
            Property(x => x.Score).HasColumnName("Score").IsRequired();
            Property(x => x.MemberId).HasColumnName("MemberId").IsRequired();
            Property(x => x.QuestionId).HasColumnName("QuestionId").IsOptional();
            Property(x => x.AnswerId).HasColumnName("AnswerId").IsOptional();

            base.HasRequired(x => x.Member)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.MemberId);

            base.HasOptional(x => x.Question)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.QuestionId).WillCascadeOnDelete(false);

            base.HasOptional(x => x.Answer)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AnswerId).WillCascadeOnDelete(false);
        }
    }
}