using Service_Porcupine.Models;
using Service_Porcupine.ViewModels;
using System.Collections.Generic;

namespace Service_Porcupine.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        List<UserM> GetUsers();

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        UserM GetUserDetailsById(int uId);

        /// <summary>
        ///  add edit user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        ResponseModel SaveUser(UserM userModel);


        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        ResponseModel DeleteUser(int uId);
    }
}