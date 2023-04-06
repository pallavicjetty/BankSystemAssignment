using BankSystemAssignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystemAssignment.DataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        Task<bool> CreateAccount(int userId, double money);
        Task<List<UserAccount>> GetUserAccount(int userId);
        Task<bool> DeleteUserAccount(int accountId);
    }
}
