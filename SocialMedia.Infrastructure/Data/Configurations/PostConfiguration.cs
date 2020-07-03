using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Data;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Posts_Users");
        }
    }
}
