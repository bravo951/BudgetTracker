using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> AddUser(UserRequestModel requestModel);
        Task<int> DeleteUser(UserRequestModel requestModel);
        Task<int> UpdateUser(UserRequestModel requestModel);
        Task<List<UserResponseModel>> ListUser();

        Task<UserDetailResponseModel> GetUserDetail(int id);

    }

}
