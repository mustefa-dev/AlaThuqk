using AlaThuqk.DATA.DTOs;
using AlaThuqk.Entities;

namespace e_parliament.Interface
{
    public interface ITokenService
    {
        string CreateToken(TokenDTO user);
    }
}