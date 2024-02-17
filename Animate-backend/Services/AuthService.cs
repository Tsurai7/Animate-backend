using Animate_backend.Data;
using Animate_backend.Dtos;
using Animate_backend.Models;

namespace Animate_backend.Services
{
    public class AuthService
    {
        private readonly DataContext _dataContext;

        private readonly TokenService _tokenService;

        public AuthService(DataContext dataContext, TokenService tokenService)
        {
            _dataContext = dataContext;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginRequestDto dto)
        {
            if (_dataContext.Users.Any(u => u.Email == dto.Email))
            {
                return _tokenService.BuildToken(dto.Email);
            }

            return string.Empty;          
        }


        public async Task<string> Register(RegisterRequestDto dto)
        {
            if (_dataContext.Users.Any(u => u.Email == dto.Email))
            {
                return string.Empty;
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return _tokenService.BuildToken(dto.Email);
        }
    }
}
