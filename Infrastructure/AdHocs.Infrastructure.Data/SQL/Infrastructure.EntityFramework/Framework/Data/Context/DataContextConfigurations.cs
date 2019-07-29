using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.EntityFramework.Framework.Data.Context
{
    public class DataContextConfigurations
    {
        #region Topics

        public class TopicConfiguration : EntityTypeConfiguration<Topic>
        {
            public TopicConfiguration()
            {
                #region table.

                ToTable("Topic")
                    .HasKey(x => x.Id);

                Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                #endregion

                #region props.

                // ...

                // common props.
                Ignore(x => x.IsActive);
                Property(x => x.Name).HasColumnName("TopicName").IsRequired();
                Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
                Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
                Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
                Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();

                #endregion

                #region relations.

                HasMany(e => e.Questions)
                    .WithRequired(e => e.Topic)
                    .WillCascadeOnDelete(false);

                #endregion
            }
        }

        #endregion
    }
}