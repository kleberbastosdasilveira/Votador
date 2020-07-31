using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Date.Mappings
{
    public class RecursoMapping : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.TituloRecurso)
                   .HasColumnType("varchar(200)");

            builder.Property(r => r.DescricaoRecurso)
                .HasColumnType("varchar(999)");

            builder.ToTable("Recursos");
        }
    }
}
