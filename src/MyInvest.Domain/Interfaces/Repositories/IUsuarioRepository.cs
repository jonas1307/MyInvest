using System;
using System.Collections.Generic;
using MyInvest.Domain.Entities;

namespace MyInvest.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        List<Usuario> GetAll();

        Usuario GetById(string id);
    }
}