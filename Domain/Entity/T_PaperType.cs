using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_PaperType
    ///</summary>
    public class T_PaperType
    {
        /// <summary>
        /// 试卷类型ID
        /// </summary>
        public virtual int PaperTypeID{get;set;}
        /// <summary>
        /// 试卷类型描述
        /// </summary>
        public virtual string PaperTypeDes{get;set;}
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