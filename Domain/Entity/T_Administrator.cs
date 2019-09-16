using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_Administrator
    ///</summary>
    public class T_Administrator
    {
        /// <summary>
        /// 管理员ID
        /// </summary>
        public virtual int AdministratorID{get;set;}
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName{get;set;}
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password{get;set;}
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDeleted{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public virtual System.DateTime CreateDate{get;set;}
    }
}