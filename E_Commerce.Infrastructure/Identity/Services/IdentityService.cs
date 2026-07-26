using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Identity;
using E_Commerce.Application.Services.Contracts;
using E_Commerce.Doamin.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Infrastructure.Identity.Services
{
    public class IdentityService(UserManager<ApplicationUser> userManager) : IIdentityService
    {
        public async Task<Result<IdentityUserResult>> FindUserByEmailAsync(string email, CancellationToken ct = default)
        {
             var user = await userManager.FindByEmailAsync(email);
             if (user is null)
             
                 return Result<IdentityUserResult>.Fail(Error.NotFound("User not found") );

             return Result<IdentityUserResult>.OK(new IdentityUserResult(user.Id, user.DisplayName, user.Email, user.UserName)); 

        }
        public async Task<Result<bool>> CheckPasswordAsync(string email, string password, CancellationToken ct = default)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)

                return Result<bool>.Fail(Error.InValidCredential("Email or password is invalid"));

            var result = await userManager.CheckPasswordAsync(user, password);

            return result ?
                 Result<bool>.OK(result) : Result<bool>.Fail(Error.InValidCredential("Invalid credentials"));

        }
        public  async  Task<Result<IdentityUserResult>> CreateUserAsync(RegisterDto registerDto, CancellationToken ct = default)
        {
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber
            };
            var createResult = await userManager.CreateAsync(user, registerDto.Password);

          if(!createResult.Succeeded)
            {
               var errors = createResult.Errors.Select(e =>new Error (e.Code, e.Description)).ToList();

                return Result<IdentityUserResult>.Fail(errors);

            }

            return Result<IdentityUserResult>.OK(new IdentityUserResult(user.Id, user.DisplayName, user.Email, user.UserName));


        }

        public async Task<Result<IReadOnlyList<string>>> GetUserRoleAsync(string email, CancellationToken ct = default)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return Result<IReadOnlyList<string>>.Fail(Error.NotFound("User not found"));
            var roles = await userManager.GetRolesAsync(user);
            return Result<IReadOnlyList<string>>.OK(roles.ToList());
        }

        public async Task<Result<bool>> EmailExistAsync(string email, CancellationToken ct = default)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return Result<bool>.Fail(Error.NotFound($" User withEmail {email} not found"));
            return Result<bool>.OK(true);
        }


        public async Task<Result<AdressDto>> GetUserAddressByEmailAsync(string email, CancellationToken ct = default)
        {
            var user =await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email, ct);

            if ( user?.Address is null)
                return  Result<AdressDto>.Fail(Error.NotFound($"Address Of user withEmail {email} not found"));

            var address = user.Address;
            return  Result<AdressDto>.OK(new AdressDto
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                Street = address.Street,
                City = address.City,
                Country=address.Country
            });
        }

        public async Task<Result<AdressDto>> UpdateOrInsertUserAddressAsync(string email, AdressDto adress, CancellationToken ct = default)
        {

            var user = await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email, ct);

            if (user?.Address == null)
            {
                // insert
                user.Address = new Address()
                {
                    FirstName = adress.FirstName,
                    LastName = adress.LastName,
                    Street = adress.Street,
                    City = adress.City,
                    Country = adress.Country

                };

            }
            else
            {
                // update
                user.Address.FirstName = adress.FirstName;
                user.Address.LastName = adress.LastName;
                user.Address.Street = adress.Street;
                user.Address.City = adress.City;
                user.Address.Country = adress.Country;
            }


            var result = await userManager.UpdateAsync(user);

           if(result.Succeeded)
            {
                return Result<AdressDto>.OK( new AdressDto ());
            }
            else
            {
                return Result<AdressDto>.Fail(Error.Failure("Failure" , "Cannot update "));
            }



        }
                  
    }
}
