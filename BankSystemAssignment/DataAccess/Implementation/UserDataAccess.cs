using BankSystemAssignment.DataAccess.Interfaces;
using BankSystemAssignment.Helper;
using BankSystemAssignment.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BankSystemAssignment.DataAccess.Implementation
{
    public class UserDataAccess : IUserDataAccess
    {
        private MyMemoryCache _cache;
        public UserDataAccess(MyMemoryCache cache)
        {
            _cache = cache;
        }
        public List<UserAccount> userAccounts = new List<UserAccount>
        {
            new UserAccount
            {
                userId=1,
                accountId=1,
                money=10
            },
            new UserAccount
            {
                userId=2,
                accountId=2,
                money=100
            },
            new UserAccount
            {
                userId=1,
                accountId=3,
                money=1000
            },

        };

        public List<UserModel> userModels = new List<UserModel>
        {
            new UserModel
            {
                userId=1,
                userName = "test"
            },
             new UserModel
            {
                userId=2,
                userName = "test2"
            },
        };
        public async Task<bool> CreateAccount(int userId, double money)
        {
            if (userModels.Where(x => x.userId == userId).Count() <= 0)
                return false;

            userAccounts.Add(new UserAccount
            {
                userId = userId,
                money = money,
                accountId = userAccounts.Count() +1
            });

            List<UserAccount> liUserAccounts;
            if (_cache.Cache.TryGetValue("Accounts", out liUserAccounts))
            {
                _cache.Cache.Remove("Accounts");
                var cacheEntryOptions = new MemoryCacheEntryOptions()
 .SetSlidingExpiration(TimeSpan.FromSeconds(60))
 .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
 .SetPriority(CacheItemPriority.Normal)
 .SetSize(1024);
                _cache.Cache.Set("Accounts", userAccounts, cacheEntryOptions);
                _cache.Cache.TryGetValue("Accounts", out liUserAccounts);

            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
 .SetSlidingExpiration(TimeSpan.FromSeconds(60))
 .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
 .SetPriority(CacheItemPriority.Normal)
 .SetSize(1024);
                _cache.Cache.Set("Accounts", userAccounts,cacheEntryOptions);
                _cache.Cache.TryGetValue("Accounts", out liUserAccounts);
            }

            return true;

        }

        public async Task<bool> DeleteUserAccount(int accountId)
        {
            List<UserAccount> liUserAccounts;
            bool isFound = false;
            if (_cache.Cache.TryGetValue("Accounts", out liUserAccounts))
            {
               
            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
 .SetSlidingExpiration(TimeSpan.FromSeconds(60))
 .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
 .SetPriority(CacheItemPriority.Normal)
 .SetSize(1024);
                _cache.Cache.Set("Accounts", userAccounts, cacheEntryOptions);
                _cache.Cache.TryGetValue("Accounts", out liUserAccounts);
            }
            if (liUserAccounts.Where(x => x.accountId == accountId).Count() > 0)
            {
                for (int i = 0; i < liUserAccounts.Count; i++)
                {
                    if (liUserAccounts[i].accountId == accountId)
                    {
                        liUserAccounts.RemoveAt(i);
                        isFound = true;

                    }
                }
                _cache.Cache.Remove("Accounts");
                var cacheEntryOptions = new MemoryCacheEntryOptions()
.SetSlidingExpiration(TimeSpan.FromSeconds(60))
.SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
.SetPriority(CacheItemPriority.Normal)
.SetSize(1024);
                _cache.Cache.Set("Accounts", userAccounts, cacheEntryOptions);
                _cache.Cache.TryGetValue("Accounts", out liUserAccounts);
            }
            
            
            return isFound;
        }

        public async Task<List<UserAccount>> GetUserAccount(int userId)
        {
            List<UserAccount> liUserAccounts;
            if (_cache.Cache.TryGetValue("Accounts", out liUserAccounts))
            {

            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
 .SetSlidingExpiration(TimeSpan.FromSeconds(60))
 .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
 .SetPriority(CacheItemPriority.Normal)
 .SetSize(1024);
                _cache.Cache.Set("Accounts", userAccounts,cacheEntryOptions);
                _cache.Cache.TryGetValue("Accounts", out liUserAccounts);
            }
            var liuserAccounts = liUserAccounts.Where(x => x.userId == userId).ToList();


            return liuserAccounts;
        }
    }

}
