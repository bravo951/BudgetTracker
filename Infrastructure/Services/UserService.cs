using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        public UserService(IUserRepository userRepository, 
            IIncomeRepository incomeRepository, 
            IExpenditureRepository expenditureRepository)
        {
            _userRepository = userRepository;
            _incomeRepository = incomeRepository;
            _expenditureRepository = expenditureRepository;
        }

        public async Task<int> AddUser(UserRequestModel requestModel)
        {
            var dbUser = _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)
            {
                throw new Exception("Email already exists!");
            }
            //var salt = GetSalt();
            //var hashedPassword = GetHashedPassword(requestModel.Password, salt);

            var user = new User
            {
                Email = requestModel.Email,
                Fullname = requestModel.Fullname,
                Password = requestModel.Password,
                JoinedOn = requestModel.JoinedOn
            };
            await _userRepository.Add(user);
            return 1;
        }

        public async Task<int> DeleteUser(UserRequestModel requestModel)
        {
            var user = new User
            {
                Email = requestModel.Email,
                Fullname = requestModel.Fullname,
                Password = requestModel.Password,
                JoinedOn = requestModel.JoinedOn
            };
            await _userRepository.Delete(user);
            return 1;
        }

        public async Task<UserDetailResponseModel> GetUserDetail(int id)
        {
            var user = await _userRepository.GetUserById(id);
            var incomes = await _incomeRepository.Get(i => i.UserId == id);
            var exps = await _expenditureRepository.Get(i => i.UserId == id);
            var transList = new List<TransferResponseModel>();
            foreach (var item in incomes)
            {
                transList.Add(new TransferResponseModel
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    TransDate = item.IncomeDate,
                    Remarks = item.Remarks
                });
            }
            //var expList = new List<ExpenditureResponseModel>();
            foreach (var item in exps)
            {
                transList.Add(new TransferResponseModel
                {
                    Amount = -item.Amount,
                    Description = item.Description,
                    TransDate = item.ExpDate,
                    Remarks = item.Remarks
                });
            }
            transList.Sort(new myComp());
            var userDetail = new UserDetailResponseModel
            {
                Email = user.Email,
                Fullname = user.Fullname,
                JoinedOn = user.JoinedOn,
                TransList = transList
            };
            return userDetail;
        }

        public async Task<List<UserResponseModel>> ListUser()
        {
            var users = await _userRepository.GetAll();
            var userList = new List<UserResponseModel>();
            foreach (var item in users)
            {
                userList.Add(new UserResponseModel { Id = item.Id, FullName = item.Fullname, JoinOn = item.JoinedOn.GetValueOrDefault() });
            }
            return userList;
        }


        public async Task<int> UpdateUser(UserRequestModel requestModel)
        {
            var user = new User
            {
                Email = requestModel.Email,
                Fullname = requestModel.Fullname,
                Password = requestModel.Password,
                JoinedOn = requestModel.JoinedOn
            };
            await _userRepository.Update(user);
            return 1;
        }

        
        //private string GetSalt()
        //{
        //    var randomBytes = new byte[128 / 8];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomBytes);
        //    }

        //    return Convert.ToBase64String(randomBytes);
        //}
        //private string GetHashedPassword(string password, string salt)
        //{
        //    var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password,
        //        Convert.FromBase64String(salt),
        //        KeyDerivationPrf.HMACSHA512,
        //        10000,
        //        256 / 8));
        //    return hashed;
        //}
    }

    internal class myComp : IComparer<TransferResponseModel>
    {
        public int Compare([AllowNull] TransferResponseModel x, [AllowNull] TransferResponseModel y)
        {
            return x.TransDate > y.TransDate ? -1 : 1;
            //return x.TransDate.CompareTo(y.TransDate);
        }
    }
}
