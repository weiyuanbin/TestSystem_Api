using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem_ApiCommon.Model.Question
{
    public class SingleSelectQuestion : QuestionBase
    {
        /// <summary>
        /// 提干
        /// </summary>
        public  string Stem { get; set; }
        /// <summary>
        /// 选项A
        /// </summary>
        public  string OptionA { get; set; }
        /// <summary>
        /// 选项B
        /// </summary>
        public  string OptionB { get; set; }
        /// <summary>
        /// 选项C
        /// </summary>
        public  string OptionC { get; set; }
        /// <summary>
        /// 选项D
        /// </summary>
        public  string OptionD { get; set; }
        /// <summary>
        /// 选项E
        /// </summary>
        public  string OptionE { get; set; }
        /// <summary>
        /// 选项F
        /// </summary>
        public  string OptionF { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public  string Answer { get; set; }
    }
}
