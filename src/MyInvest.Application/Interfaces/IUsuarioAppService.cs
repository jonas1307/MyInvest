using System.Collections.Generic;
using MyInvest.Domain.Entities;

namespace MyInvest.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        List<Usuario> GetAll();

        Usuario GetById(string id);
    }
}