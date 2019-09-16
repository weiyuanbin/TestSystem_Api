using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem_ApiCommon.Enum
{
    public enum QuestionTypeEnum
    {
        /// <summary>
        /// 单选题
        /// </summary>
        SingleSelectQuestion=1,
        /// <summary>
        /// 多选题
        /// </summary>
        MultipleSelectQuestion=2,
        /// <summary>
        /// 判断题
        /// </summary>
        JudgeQuestion=3,
        /// <summary>
        /// 填空题
        /// </summary>
        FillQuestion=4
    }
}
