using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Date.Mappings
{
    public class RegistroVotacaoMapping : IEntityTypeConfiguration<RegistroVotacao>
    {
        public void Configure(EntityTypeBuilder<RegistroVotacao> builder)
        {
            builder.HasKey(r => new { r.FuncionarioId, r.RecursoId });

            builder.Property(r => r.FuncionarioId)
                .IsRequired()
                .HasColumnName("FuncionarioId");

            builder.Property(r => r.RecursoId)
                .IsRequired()
                .HasColumnName("RecursoId");

            builder.Property(r => r.DataVotacaoRecurso)
                .IsRequired();

            builder.Property(r => r.ComentarioRecurso)
                .IsRequired()
                .HasColumnType("varchar(999)");


            builder.HasOne<Funcionario>(f => f.Funcionario)
                .WithMany(r => r.RegistroVotacoes)
                .HasForeignKey(f => f.FuncionarioId);

            builder.HasOne<Recurso>(f => f.Recurso)
                 .WithMany(r => r.RegistroVotacoes)
                 .HasForeignKey(f => f.RecursoId);

            builder.ToTable("RegistroVotacoes");
        }
    }
}
