using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_PaperRecord
    ///</summary>
    public class T_PaperRecord
    {
        /// <summary>
        /// 试卷记录ID
        /// </summary>
        public virtual int PaperRecordID{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 学生ID
        /// </summary>
        public virtual T_Student Student{get;set;}
        /// <summary>
        /// 题目ID
        /// </summary>
        public virtual T_Question Question{get;set;}
        /// <summary>
        /// 回答次数
        /// </summary>
        public virtual int AnswerCount{get;set;}
        /// <summary>
        /// 答案
        /// </summary>
        public virtual string Answer{get;set;}
        /// <summary>
        /// 得分
        /// </summary>
        public virtual decimal Score{get;set;}
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