using Microsoft.AspNetCore.Identity;
using Proiect_final_DAW.Entities.DTOs;
using Split_IT.Entities;
using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<UserAuth> userManager;
        private readonly SignInManager<UserAuth> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<UserAuth> userManager, SignInManager<UserAuth> signInManager,
            ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }

        public async Task Signup(SignupUserModel signupUserModel)
        {
            var user = new UserAuth
            {
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email,
            };

            var result = await userManager.CreateAsync(user, signupUserModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, signupUserModel.RoleId);
            }
        }

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    //Create token
                    var token = await tokenManager.CreateToken(user); //new manager responsible with creating the token

                    return new TokenModel { Token = token };
                }
            }

            return null;
        }
    }
}
