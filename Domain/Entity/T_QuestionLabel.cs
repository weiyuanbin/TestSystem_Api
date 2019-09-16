using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_QuestionLabel
    ///</summary>
    public class T_QuestionLabel
    {
        /// <summary>
        /// 题目标签ID
        /// </summary>
        public virtual int QuestionLabelID{get;set;}
        /// <summary>
        /// 标签名称
        /// </summary>
        public virtual string LabelName{get;set;}
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