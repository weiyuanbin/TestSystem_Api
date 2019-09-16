using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_PaperQestionRule
    ///</summary>
    public class T_PaperQestionRule
    {
        /// <summary>
        /// 试卷题目规则ID
        /// </summary>
        public virtual int PaperQestionRule{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 题目类型ID
        /// </summary>
        public virtual T_QuestionType QuestionType{get;set;}
        /// <summary>
        /// 题目个数
        /// </summary>
        public virtual int QuestionCount{get;set;}
        /// <summary>
        /// 每题分数
        /// </summary>
        public virtual decimal QuestionScore{get;set;}
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