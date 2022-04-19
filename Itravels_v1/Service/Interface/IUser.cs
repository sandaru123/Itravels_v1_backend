using Itravels_v1.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service.Interface
{
    public interface IUser
    {
        Task<bool> CreateUserAsync(UserModel userModel);
    }
}
