using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using IDAL;

namespace DAL
{
    public class AdminDAL : BaseDAL, IAdminDAL
    {
        /// <summary>
        /// 获取管理员通过用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public T_Administrator GetAdministratorByUserName(string userName)
        {
            string hql = "from T_Administrator t where t.UserName=? and t.IsDeleted=0";
            return this.ListByCode<T_Administrator>(hql, userName);
        }
    }
}
