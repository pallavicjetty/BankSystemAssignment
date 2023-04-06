using BankSystemAssignment.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankSystemAssignment.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<bool> CreateAccount(int userId, double money);
        Task<List<UserAccount>> GetUserAccount(int userId);
       Task<bool> DeleteUserAccount(int accountId);
    }
}
