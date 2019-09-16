using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace IDAL
{
    public  interface IAdminDAL:IBaseDAL
    {
        /// <summary>
        /// 获取管理员通过用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        T_Administrator GetAdministratorByUserName(string userName);
    }
}
