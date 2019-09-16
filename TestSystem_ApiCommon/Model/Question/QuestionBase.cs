using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem_ApiCommon.Model.Question
{
    public class QuestionBase
    {
        /// <summary>
        /// 题目ID
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// 题目类型ID
        /// </summary>
        public int QuestionTypeID { get; set; }
    }
}
