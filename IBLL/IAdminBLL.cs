using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using TestSystem_ApiCommon.Model.Admin;

namespace IBLL
{
    public interface IAdminBLL
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="administrator"></param>
        /// <returns></returns>
        string AdminLogin(LoginInfo loginInfo, ref T_Administrator administrator);
    }
}
