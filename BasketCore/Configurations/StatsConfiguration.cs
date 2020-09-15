using BasketCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BasketCore.Configurations
{
    public class StatsConfiguration : IEntityTypeConfiguration<Stats>
    {
        public void Configure(EntityTypeBuilder<Stats> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
                .HasOne(x => x.Game)
                .WithMany(y => y.Stats);

            builder
                .HasOne(x => x.Player)
                .WithMany(y => y.Stats);

            builder
                .ToTable("Stats");
        }
    }
}
