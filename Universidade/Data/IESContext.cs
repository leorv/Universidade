using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universidade.Models;

namespace Universidade.Data
{
    public class IESContext : DbContext
    {
        // O contexto representa nossa conexão com o banco de dados.
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {

        }

        /* Quando já houver uma base de dados e tabelas com nomes diferentes das que
         * seriam definidas aqui pelo EF Core, é possível usar a sobrescrita abaixo:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
        }

        **** Outro método que podemos sobrescrever é o OnConfiguring(), que nos permite configurar o acesso
        ao banco de dados. Então aqui abaixo é apenas para saber como configurar o acesso ao banco
        de dados diretamente pela classe de contexto.

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            // O pacote Nuget deve ser instalado: Microsoft.EntityFrameworkCore.SqlServer
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESUtfpr;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        Estes métodos devem estar no nível do construtor.
        */
    }
}
