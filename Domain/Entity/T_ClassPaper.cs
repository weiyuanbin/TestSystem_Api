using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_ClassPaper
    ///</summary>
    public class T_ClassPaper
    {
        /// <summary>
        /// 班级试卷ID
        /// </summary>
        public virtual int ClassPaperID{get;set;}
        /// <summary>
        /// 班级ID
        /// </summary>
        public virtual T_Class Class{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
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