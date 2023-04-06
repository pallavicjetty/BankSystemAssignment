using BankSystemAssignment.Business.Interfaces;
using BankSystemAssignment.DataAccess.Interfaces;
using BankSystemAssignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankSystemAssignment.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _userDataAccess;
        public UserBusiness(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public async Task<bool> CreateAccount(int userId, double money)
        {
            return await _userDataAccess.CreateAccount(userId, money);
        }

        public async Task<bool> DeleteUserAccount(int accountId)
        {
            return await _userDataAccess.DeleteUserAccount(accountId);
        }

        public async Task<List<UserAccount>> GetUserAccount(int userId)
        {
            return await _userDataAccess.GetUserAccount(userId);
        }
    }
}
