using AutoMapper;
using Core.Domain.User;
using Core.Shared.ModelViews;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Manager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementations
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IMapper _mapper;
        private readonly IJWTService _jwtService;
        private readonly IUsuarioRepository _repository;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper, IJWTService jwtService)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _repository = repository;
        }

        public async Task DeleteUsuarioAsync(string login)
        {
            await _repository.DeleteUsuarioAsync(login);
        }

        public async Task<UsuarioView> GetUsuarioAsync(string login)
        {
            return _mapper.Map<UsuarioView>(await _repository.GetUsuarioAsync(login));
        }

        public async Task<IEnumerable<UsuarioView>> GetUsuariosAsync()
        {
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await _repository.GetUsuariosAsync());
        }

        public async Task<UsuarioView> InsertUsuarioAsync(NovoUsuario novoUsuario)
        {
            var usuario = _mapper.Map<Usuario>(novoUsuario);
            ConverteSenhaEmHash(usuario);
            return _mapper.Map<UsuarioView>(await _repository.InsertUsuarioAsync(usuario));
        }

        public async Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
        {
            ConverteSenhaEmHash(usuario);
            return _mapper.Map<UsuarioView>(await _repository.UpdateUsuarioAsync(usuario));
        }

        public async Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario)
        {
            var usuarioConsultado = await _repository.GetUsuarioAsync(usuario.Login);
            if (usuarioConsultado == null)
                return null;

            if (await ValidaEAtualizaHashAsync(usuario, usuarioConsultado))
            {
                var usuarioLogado = _mapper.Map<UsuarioLogado>(usuarioConsultado);
                usuarioLogado.Token = _jwtService.GerarToken(usuarioConsultado);
                return usuarioLogado;
            }

            return null;
        }

        private async Task<bool> ValidaEAtualizaHashAsync(Usuario usuario, Usuario usuarioConsultado)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(usuario, usuarioConsultado.Senha, usuario.Senha);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUsuarioAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }
    }
}
