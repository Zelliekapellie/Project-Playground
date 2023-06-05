using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Service_Porcupine.Models;
using Service_Porcupine.ViewModels;

namespace Service_Porcupine.Services
{
    public class UserService : IUserService
    {
        private ProjectContext _projectContext;
        public UserService(ProjectContext context) {
            _projectContext = context;
        }

       public List<UserM> GetUsers()
        {
            List<UserM> userList = new List<UserM>();
            try
            {
                var test = _projectContext.Set<UserM>();
                userList = _projectContext.Users.ToList();
            }catch(Exception) {
                throw;
            }
            return userList;
        }

        public UserM GetUserDetailsById(int uId)
        {
            UserM user = new UserM();
            try
            {
                user = _projectContext.Users.Find(uId);
            } catch(Exception)
            {
                throw;
            }
            return user;
        }

        public ResponseModel SaveUser(UserM userModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                UserM _temp = GetUserDetailsById(userModel.ID);
                if (_temp != null)
                {
                    _temp.Name = userModel.Name;
                    _temp.Surname = userModel.Surname;
                    _temp.Email = userModel.Email;
                    _projectContext.Update<UserM>(_temp);
                    model.Message = "User Update Successfully";
                }
                else
                {
                    _projectContext.Add<UserM>(userModel);
                    model.Message = "User Inserted Successfully";
                }
                _projectContext.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteUser(int uId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                UserM _temp = GetUserDetailsById(uId);
                if (_temp != null)
                {
                    _projectContext.Remove<UserM>(_temp);
                    _projectContext.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
