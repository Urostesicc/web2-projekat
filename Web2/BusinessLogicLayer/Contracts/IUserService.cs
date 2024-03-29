﻿using Common.Models.Database;
using Common.Models.Inbound;
using Common.Models.Outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IUserService
    {
        Task<UserModel> CreateUser(RegisterUser user);
        Task<LogedInUser> UpdateUser(UpdateUser user);
        Task<LogedInUser> Login(string username, string password);
        Task<string> Verify(VerifyUserModel user);
        Task<List<SellerView>> GetSellers();
        Task<LogedInUser> FacebookLogin(FacebookLoginUser facebookUser);
    }
}
