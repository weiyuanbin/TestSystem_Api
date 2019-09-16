using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace IDAL
{
    public interface IQuestionDAL:IBaseDAL
    {
        /// <summary>
        /// 根据标签名称获取题目标签
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        T_QuestionLabel GetQuestionLabelByName(string labelName);
    }
}
