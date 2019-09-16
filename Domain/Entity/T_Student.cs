using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_Student
    ///</summary>
    public class T_Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public virtual int StudentID{get;set;}
        /// <summary>
        /// 班级ID
        /// </summary>
        public virtual T_Class Class{get;set;}
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string UserName{get;set;}
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Pwd{get;set;}
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName{get;set;}
        /// <summary>
        /// 性别(0-男,1-女)
        /// </summary>
        public virtual int Sex{get;set;}
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