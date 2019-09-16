using Domain.Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuestionDAL:BaseDAL,IQuestionDAL
    {
        /// <summary>
        /// 根据标签名称获取题目标签
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public T_QuestionLabel GetQuestionLabelByName(string labelName)
        {
            string hql = "from T_QuestionLabel t where t.LabelName=? and t.IsDeleted=0";
            return this.ListByCode<T_QuestionLabel>(hql, labelName);
        }
    }
}
