using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_Class
    ///</summary>
    public class T_Class
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        public virtual int ClassID{get;set;}
        /// <summary>
        /// 班级名称
        /// </summary>
        public virtual string ClassName{get;set;}
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