using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universidade.Models;

namespace Universidade.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            /* Observe que a classe é estática. A criação da base de dados é dada pelo
             * método EnsureCreated(). Inicialmente é verificado se existe algum objeto
             * em Departamentos via LINQ.*/
            context.Database.EnsureCreated();

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Departamentos.Any())
            {
                return;
            }
            if (context.Instituicoes.Any())
            {
                return;
            }
            Departamento[] departamentos = new Departamento[]
            {
                new Departamento { Nome = "Ciência da Computação"},
                new Departamento { Nome = "Ciência de Alimentos"}
            };
            Instituicao[] instituicoes = new Instituicao[]
            {
                new Instituicao { Nome = "UNIMAR", Endereco = "Marília"},
                new Instituicao { Nome = "UNIVEM", Endereco = "Marília"}
            };
            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();
        }
    }
}
