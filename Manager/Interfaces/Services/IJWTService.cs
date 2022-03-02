using Core.Domain.User;

namespace Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}
