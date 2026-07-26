using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Identity;
using E_Commerce.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace E_Commerce.API.Controllers
{
    public class AuthenticationController(IAuthenticationService authenticationService) : APIBaseController
    {
        [HttpPost("login")] 
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto, CancellationToken ct = default)
             
             => ToActionResult(await authenticationService.LoginAsync(loginDto, ct)); 
        

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto, CancellationToken ct = default)
            
            => ToActionResult(await authenticationService.RegisterAsync(registerDto, ct));
        

        [HttpGet("emailexist")]
        public async Task<ActionResult<bool>> CheckEmailExist( [FromQuery] string email, CancellationToken ct = default)
        
        => ToActionResult( await authenticationService.CheckEmailExistAsync(email, ct));

        [Authorize]
        [HttpGet("currentuser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser( CancellationToken ct = default)

        
            => ToActionResult(await authenticationService.GetCurrentUserAsync(GetEmailFromClaimsPrincipal(), ct));
        

        [Authorize]
        [HttpGet("address")]

        public async Task<ActionResult<AdressDto>> GetCurrentUserAddress(CancellationToken ct = default)
        
            => ToActionResult(await authenticationService.GetUserAddressAsync( GetEmailFromClaimsPrincipal(), ct));

        [Authorize]
        [HttpPost("address")]

        public async Task <ActionResult<AdressDto>> UPdateOrAddUserAddress ( string email ,AdressDto adressDto , CancellationToken ct = default)
        
            => ToActionResult(await authenticationService.UpdsertUserAddressAsync(email, adressDto , ct));


        [Authorize]
        [HttpPut("address")]

        public async Task<ActionResult<AdressDto>> UpdateUserAddress(AdressDto adressDto, CancellationToken ct = default)

            => ToActionResult(await authenticationService.UpdsertUserAddressAsync(GetEmailFromClaimsPrincipal(), adressDto, ct));

    }
}

