using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entity
{
    ///<summary>
    ///T_Paper
    ///</summary>
    public class T_Paper
    {
        /// <summary>
        /// 试卷ID
        /// </summary>
        public virtual int PaperID{get;set;}
        /// <summary>
        /// 试卷名称
        /// </summary>
        public virtual string PaperName{get;set;}
        /// <summary>
        /// 试卷类型ID
        /// </summary>
        public virtual T_PaperType PaperType{get;set;}
        /// <summary>
        /// 组卷方式(1-常规,2-随机,3-每人随机)
        /// </summary>
        public virtual int PaperMode{get;set;}
        /// <summary>
        /// 答题方式(1-整页,2-单题)
        /// </summary>
        public virtual int AnswerMode{get;set;}
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual System.DateTime StartTime{get;set;}
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual System.DateTime EndTime{get;set;}
        /// <summary>
        /// 时长
        /// </summary>
        public virtual int Duration{get;set;}
        /// <summary>
        /// 规则说明
        /// </summary>
        public virtual string RuleDes{get;set;}
        /// <summary>
        /// 操作说明
        /// </summary>
        public virtual string OperationDes{get;set;}
        /// <summary>
        /// 状态(0-关闭,1-开启)
        /// </summary>
        public virtual bool Status{get;set;}
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