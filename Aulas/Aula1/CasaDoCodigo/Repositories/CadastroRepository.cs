﻿using CasaDoCodigo.Models;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
           var cadastroDb = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();
            if (cadastroDb == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDb.Update(novoCadastro);
            contexto.SaveChanges();

            return cadastroDb;

        }
    }
}
