using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Identity;
using E_Commerce.Application.Services.Contracts;


namespace E_Commerce.Application.Services.Classes
{
    public class AuthenticationService (IIdentityService identityService,ITokenService tokenService) : IAuthenticationService
    {
        public async Task<Result<UserDto>> LoginAsync(LoginDto loginDto, CancellationToken ct = default)
        {
            // Validate User Email and Password
            var userResult = await identityService.FindUserByEmailAsync(loginDto.Email, ct);
            if (!userResult.IsSuccess)
            {
                return Result<UserDto>.Fail(userResult.Errors);
            }

            var passwordResult = await identityService.CheckPasswordAsync(userResult.Data.Email, loginDto.Password, ct);
            if (!passwordResult.IsSuccess)
            {
                return Result<UserDto>.Fail(passwordResult.Errors);
            }

            // Return Response => userDto with Token 
            var user = userResult.Data;
            var roleResult = await identityService.GetUserRoleAsync(loginDto.Email, ct);
            var token = await tokenService.CreateTokenAsync(user.Id, user.Email, user.UserName, roleResult.Data, ct);

            return Result<UserDto>.OK(new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = token
            });


        }

        public async Task<Result<UserDto>> RegisterAsync(RegisterDto registerDto, CancellationToken ct = default)
        {
            var userResult = await identityService.CreateUserAsync(registerDto, ct);
            if (!userResult.IsSuccess)
            {
                return Result<UserDto>.Fail(userResult.Errors);
            }

            var user = userResult.Data;
            var roleResult = await identityService.GetUserRoleAsync(user.Email, ct);
            var token = await tokenService.CreateTokenAsync(user.Id, user.Email, user.UserName, roleResult.Data, ct);

            return Result<UserDto>.OK(new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = token   
            });

        }

        public async Task<Result<bool>> CheckEmailExistAsync(string email, CancellationToken ct = default)
            
            => await identityService.EmailExistAsync(email, ct);

        public async Task<Result<UserDto>> GetCurrentUserAsync(string email, CancellationToken ct = default)
        {
            var userResult = await identityService.FindUserByEmailAsync(email, ct);
            
            var user = userResult.Data;
            var roleResult = await identityService.GetUserRoleAsync(email, ct);
            var token = await tokenService.CreateTokenAsync(user.Id, user.Email, user.UserName, roleResult.Data, ct);
            return Result<UserDto>.OK(new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = token
            });


        }

        public Task<Result<AdressDto>> GetUserAddressAsync(string email, CancellationToken ct = default)
        {
            return identityService.GetUserAddressByEmailAsync(email, ct);
        }

        public Task<Result<AdressDto>> UpdsertUserAddressAsync(string email, AdressDto adressDto, CancellationToken ct = default)
        {
            return identityService.UpdateOrInsertUserAddressAsync(email, adressDto, ct);
        }
    }
}
