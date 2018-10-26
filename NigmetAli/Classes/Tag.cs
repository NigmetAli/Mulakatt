using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace NigmetAli.Classes
{
    public class Tag
    {
        public int Id { get; set; }
        public string QTags { get; set; }
    }

    public class TagMapping:EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            ToTable("Tags");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.QTags).HasColumnName("QTags").IsOptional();
        }
    }
}