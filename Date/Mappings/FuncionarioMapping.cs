using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Date.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(f => f.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Senha)
                .HasColumnType("varchar(50)");

            builder.ToTable("Funcionarios");
        }
    }
}
