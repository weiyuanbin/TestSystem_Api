using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSystem_ApiCommon.Enum;
using TestSystem_ApiCommon.Model.Question;
using TestSystem_ApiCommon.Model.QuestionManager;

namespace IBLL
{
    public interface IQuestionBLL
    {
        /// <summary>
        /// 保存题目
        /// </summary>
        /// <param name="questionTypeEnum"></param>
        /// <param name="saveQuestionModel"></param>
        /// <returns></returns>
        void SaveQuestion(QuestionTypeEnum questionTypeEnum, SaveQuestionModel saveQuestionModel);
    }
}
