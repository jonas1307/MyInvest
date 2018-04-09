using System;
using System.Collections.Generic;
using System.Linq;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Infrastructure.Data.Context;

namespace MyInvest.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyInvestContext _db;

        public UsuarioRepository()
        {
            _db = new MyInvestContext();
        }

        public List<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario GetById(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}