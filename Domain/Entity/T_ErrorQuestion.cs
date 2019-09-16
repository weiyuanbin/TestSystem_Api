using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_ErrorQuestion
    ///</summary>
    public class T_ErrorQuestion
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ErrorQuestionID{get;set;}
        /// <summary>
        /// 学生ID
        /// </summary>
        public virtual T_Student Student{get;set;}
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual T_Paper Paper{get;set;}
        /// <summary>
        /// 题号
        /// </summary>
        public virtual int TiHao { get; set; }

        /// <summary>
        /// 题目ID
        /// </summary>
        public virtual T_Question Question{get;set;}
        /// <summary>
        /// 移除状态(1-未移除,2-待移除3-已移除)
        /// </summary>
        public virtual int RemoveStatus{get;set;}
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