using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_PaparStudent
    ///</summary>
    public class T_PaperStudent
    {
        /// <summary>
        /// 试卷学生ID
        /// </summary>
        public virtual int PaperStudentID{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 学生ID
        /// </summary>
        public virtual T_Student Student{get;set;}
        /// <summary>
        /// 回答次数
        /// </summary>
        public virtual int AnswerCount{get;set;}
        /// <summary>
        /// 开始答题时间
        /// </summary>
        public virtual System.DateTime StartAnswerTime{get;set;}
        /// <summary>
        /// 结束答题时间
        /// </summary>
        public virtual System.DateTime EndAnswerTime{get;set;}
        /// <summary>
        /// 状态(1-未开始,2-进行中,3-完成)
        /// </summary>
        public virtual int Status{get;set;}
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