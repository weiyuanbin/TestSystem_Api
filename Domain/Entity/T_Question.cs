using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_Question
    ///</summary>
    public class T_Question
    {
        /// <summary>
        /// 题目ID
        /// </summary>
        public virtual int QuestionID{get;set;}
        /// <summary>
        /// 题目标签ID
        /// </summary>
        public virtual T_QuestionLabel QuestionLabel{get;set;}
        /// <summary>
        /// 题目类型ID
        /// </summary>
        public virtual T_QuestionType QuestionType{get;set;}
        /// <summary>
        /// 提干
        /// </summary>
        public virtual string Stem{get;set;}
        /// <summary>
        /// 选项A
        /// </summary>
        public virtual string OptionA{get;set;}
        /// <summary>
        /// 选项B
        /// </summary>
        public virtual string OptionB{get;set;}
        /// <summary>
        /// 选项C
        /// </summary>
        public virtual string OptionC{get;set;}
        /// <summary>
        /// 选项D
        /// </summary>
        public virtual string OptionD{get;set;}
        /// <summary>
        /// 选项E
        /// </summary>
        public virtual string OptionE{get;set;}
        /// <summary>
        /// 选项F
        /// </summary>
        public virtual string OptionF{get;set;}
        /// <summary>
        /// 答案
        /// </summary>
        public virtual string Answer{get;set;}
        /// <summary>
        /// 管理员ID
        /// </summary>
        public virtual T_Administrator Administrator{get;set;}
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