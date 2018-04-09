using System.Collections.Generic;
using MyInvest.Application.Interfaces;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public List<Usuario> GetAll()
        {
            return _usuarioService.GetAll();
        }

        public Usuario GetById(string id)
        {
            return _usuarioService.GetById(id);
        }
    }
}