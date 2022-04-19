using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Helper;
using Itravels_v1.Model.User;
using Itravels_v1.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class UserRepository
    {

        //private readonly Itravels_v1Context DBContext;

        //public UserRepository(Itravels_v1Context _DBContext)
        //{
        //    DBContext = _DBContext;

        //}



        public async Task<string> CreateUserAsync(UserModel userModel)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    User user = new User();

                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;

                    var users_with_email = await DBContext.User.FirstOrDefaultAsync(c => c.Email == userModel.Email);

                    if(users_with_email != null)
                    {
                        return "This email is already entered";
                    }

                    var users_with_phone = await DBContext.User.FirstOrDefaultAsync(c => c.Phone == userModel.Phone);

                    if (users_with_phone != null)
                    {
                        return "This phone number is already entered";
                    }


                    user.Email = userModel.Email;
                    user.AddressLine1 = userModel.AddressLine1;
                    user.AddressLine2 = userModel.AddressLine2;
                    user.City = userModel.City;
                    user.PostCode = userModel.PostCode;
                    user.Country = userModel.Country;
                    user.Phone = userModel.Phone;
                    user.Password = userModel.Password;

                    string regNumgenerated = GenerateClass.GenerateRandomRegNumber();

                    var users_with_reg_number = await DBContext.User.FirstOrDefaultAsync(c => c.UserRegNumber == regNumgenerated);

                    if (users_with_reg_number != null)
                    {
                        regNumgenerated = GenerateClass.GenerateRandomRegNumber();

                        while(users_with_reg_number == null)
                        {
                            regNumgenerated = GenerateClass.GenerateRandomRegNumber();
                        }
                    }

                    user.UserRegNumber = regNumgenerated;
                    user.BirthDate = userModel.BirthDate;



                    await DBContext.User.AddAsync(user);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }

                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                List<User> user = new List<User>();

                using(Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    user = await DBContext.User.OrderByDescending(c => c.UserId).ToListAsync();
                    if (user.Count != 0)
                    {
                        return user;
                    }

                    return user;
                }

               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<User> GetUserDetailsById(int id)
        {
            try
            {
                User user = new User();
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    user = await DBContext.User.FirstOrDefaultAsync(c => c.UserId == id);

                    if(user != null)
                    {
                        return user;
                    }

                    return user;
                }


               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateUserDetails(UserUpdateModel updateUser)
        {
            try
            {
                using (Itravels_v1Context context=  new Itravels_v1Context())
                {
                    if(updateUser == null)
                    {
                        return false;
                    }

                    User user = await GetUserDetailsById(updateUser.UserId);

                    if(user == null)
                    {
                        return false;
                    }

                    var config = new MapperConfiguration(
                        m => m.CreateMap<UserUpdateModel, User>()
                        );

                    var mapper = new Mapper(config);

                    user = mapper.Map<UserUpdateModel, User>(updateUser);

                    // Update entity in DbSet
                    context.User.Update(user);

                    // Save changes in database
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> ValidateLoginUserAsync(string email, string password)
        {
            //0 - successfull
            //1 email not valid
            //2  password incorrect
            //3 other error
            try
            {
                using (Itravels_v1Context context = new Itravels_v1Context())
                {
                    if (String.IsNullOrEmpty(email))
                    {
                        return 1;
                    }
                    if (String.IsNullOrEmpty(password))
                    {
                        return 2;
                    }

                    var user = await context.User.FirstOrDefaultAsync(c => c.Email == email);

                    if(user== null)
                    {
                        return 1;
                    }
                    else
                    {
                        if(user.Password != password)
                        {
                            return 2;
                        }
                        else
                        {
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return 3;
            }

        }
    }
}
