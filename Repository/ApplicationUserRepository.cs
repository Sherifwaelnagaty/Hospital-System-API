﻿using Core.Domain;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(ApplicationContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        #region Authentication 
        public override async Task<IActionResult> Add(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded ? new OkResult() : new BadRequestObjectResult(result.Errors);
        }

        public async Task AddSignInCookie(ApplicationUser user, bool rememberMe)
        {
            /// await  _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, rememberMe, false);
            
            await _signInManager.SignInAsync(user, rememberMe);
        }

        public async Task AssignRoleToUser(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SignInUser(ApplicationUser User, bool RememberMe, List<Claim> Claims)
        {
             //await _signInManager.SignInWithClaimsAsync(User, RememberMe, Claims);
        }

        public async Task<bool> CheckUserPassword(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        #endregion

        #region GetOperations
        public Task<bool> IsInRole(ApplicationUser user, string role)
        {
            return _userManager.IsInRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByEmail(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public string GetFullName(string id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id)?.FullName;
        }

        public async Task<IActionResult> GetUsersCountInRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return new NotFoundObjectResult($"There is no Role called {roleName}");
            }

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
            int userCount = usersInRole.Count;

            return new OkObjectResult(userCount);
        }

        public async Task<ApplicationUser> GetUser(string UserId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(UserId);
            return user;
        }
        #endregion


        public async Task<IActionResult> Update(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? new OkResult() : new BadRequestObjectResult(result.Errors);
        }
        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }



    }
}
