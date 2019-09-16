using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_QuestionType
    ///</summary>
    public class T_QuestionType
    {
        /// <summary>
        /// 题目类型ID
        /// </summary>
        public virtual int QuestionTypeID{get;set;}
        /// <summary>
        /// 题目类型描述
        /// </summary>
        public virtual string QuestionTypeDes{get;set;}
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