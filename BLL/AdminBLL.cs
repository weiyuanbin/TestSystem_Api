using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using IBLL;
using IDAL;
using TestSystem_ApiCommon.Model.Admin;

namespace BLL
{
    public  class AdminBLL:IAdminBLL
    {
        IAdminDAL AdminDAL { get; set; }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="administrator"></param>
        /// <returns></returns>
        public string AdminLogin(LoginInfo loginInfo, ref T_Administrator administrator)
        {
            if (string.IsNullOrEmpty(loginInfo.username) || string.IsNullOrEmpty(loginInfo.password))
            {
                return "用户名或密码不能为空!";
            }
            else
            {
                string userName = loginInfo.username.Trim();
                string pwd = loginInfo.password.Trim();
                administrator = AdminDAL.GetAdministratorByUserName(userName);
                if (administrator == null)
                {
                    return "用户名或密码错误!";
                }
                else
                {
                    if (administrator.Password != pwd)
                    {
                        return "密码错误!";
                    }
                    else
                    {
                        return "yes";
                    }
                }
            }
        }
    }
}
