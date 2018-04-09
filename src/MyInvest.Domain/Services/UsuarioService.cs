using System.Collections.Generic;
using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Repositories;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(string id)
        {
            return _usuarioRepository.GetById(id);
        }
    }
}