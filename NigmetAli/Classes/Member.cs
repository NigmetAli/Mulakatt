using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NigmetAli.Classes
{
    public class Member
    {
        public Member()
        {
            Comments = new List<Comment>();
            Answers = new List<Answer>();
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }

    public class MemberMapping : EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            base.ToTable("Members");
            HasKey(x => x.Id);
            Property(x => x.userName).HasColumnName("UserName").IsRequired();
            Property(x => x.Password).HasColumnName("Password").IsRequired();
            Property(x => x.EMail).HasColumnName("EMail").IsRequired();
            Property(x => x.Picture).HasColumnName("Picture").IsRequired();
        }
    }
}