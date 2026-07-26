using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Identity;

namespace E_Commerce.Application.Services.Contracts
{
    public interface IAuthenticationService
    {
        //login
        // Email and password req  => res =userDto (token,Email,DisplayName)

        Task <Result<UserDto>> LoginAsync(LoginDto loginDto , CancellationToken ct = default);
        Task<Result<UserDto>> RegisterAsync(RegisterDto registerDto, CancellationToken ct = default);

        Task<Result<bool>> CheckEmailExistAsync(string email, CancellationToken ct = default);

        Task <Result<UserDto>> GetCurrentUserAsync(string email, CancellationToken ct = default);

        Task <Result<AdressDto>> GetUserAddressAsync(string email, CancellationToken ct = default);
        
        Task<Result<AdressDto>> UpdsertUserAddressAsync(string email, AdressDto adressDto, CancellationToken ct = default);


    }
}
