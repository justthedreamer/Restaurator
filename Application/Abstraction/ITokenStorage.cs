using Application.DTO;

namespace Application.Abstraction;

public interface ITokenStorage
{
    void Set(JwtDto jwtDto);
    JwtDto Get();
}