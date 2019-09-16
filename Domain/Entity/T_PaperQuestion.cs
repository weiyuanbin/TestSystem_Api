using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_PaperQuestion
    ///</summary>
    public class T_PaperQuestion
    {
        /// <summary>
        /// 试卷题目ID
        /// </summary>
        public virtual int PaperQuestionID{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 题目ID
        /// </summary>
        public virtual T_Question Question{get;set;}
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