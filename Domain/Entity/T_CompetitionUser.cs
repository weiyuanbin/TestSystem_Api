using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_CompetitionUser
    ///</summary>
    public class T_CompetitionUser
    {
        /// <summary>
        /// 竞赛用户ID
        /// </summary>
        public virtual int CompetitionUserID{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 序号
        /// </summary>
        public virtual int Num{get;set;}
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string UserName{get;set;}
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Pwd{get;set;}
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