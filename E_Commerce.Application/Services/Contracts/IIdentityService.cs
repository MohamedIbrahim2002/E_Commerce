using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Contracts
{
    public interface IIdentityService
    {
        // interface in Application layer && implementation in infrastructure layer external service  (user management)
        Task<Result<IdentityUserResult>> FindUserByEmailAsync(string email, CancellationToken ct = default);
        Task<Result<bool>> CheckPasswordAsync(string email, string password, CancellationToken ct = default);
        Task<Result<IdentityUserResult>> CreateUserAsync(RegisterDto registerDto, CancellationToken ct = default);
        Task<Result<IReadOnlyList<string>>> GetUserRoleAsync(string email, CancellationToken ct = default);

        Task<Result<bool>> EmailExistAsync(string email,  CancellationToken ct = default);

        Task <Result<AdressDto>> GetUserAddressByEmailAsync(string email, CancellationToken ct = default);

        Task<Result<AdressDto>> UpdateOrInsertUserAddressAsync(string email, AdressDto adress, CancellationToken ct = default);
    }
}
