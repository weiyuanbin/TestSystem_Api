using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem_ApiCommon.Model.Question
{
    public class FillQuestion : QuestionBase
    {
        /// <summary>
        /// 提干
        /// </summary>
        public  string Stem { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        public  string Answer { get; set; }
    }
}
