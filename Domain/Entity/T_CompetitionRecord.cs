using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_CompetitionRecord
    ///</summary>
    public class T_CompetitionRecord
    {
        /// <summary>
        /// 竞赛记录ID
        /// </summary>
        public virtual int CompetitionRecordID{get;set;}
        /// <summary>
        /// 竞赛用户ID
        /// </summary>
        public virtual T_CompetitionUser CompetitionUser{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 题目ID
        /// </summary>
        public virtual T_Question Question{get;set;}
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