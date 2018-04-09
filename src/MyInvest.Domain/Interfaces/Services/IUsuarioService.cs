using System.Collections.Generic;
using MyInvest.Domain.Entities;

namespace MyInvest.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetAll();

        Usuario GetById(string id);
    }
}