using System.Data;
using System.Web;
using Common.DealWithExcel;
using Domain.Entity;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSystem_ApiCommon.Enum;
using TestSystem_ApiCommon.Model.Question;
using TestSystem_ApiCommon.Model.QuestionManager;

namespace BLL
{
    public class QuestionBLL : IQuestionBLL
    {
        private IQuestionDAL QuestionDAL { get; set; }
        /// <summary>
        /// 保存题目
        /// </summary>
        /// <param name="questionTypeEnum"></param>
        /// <param name="saveQuestionModel"></param>
        /// <returns></returns>
        public void SaveQuestion(QuestionTypeEnum questionTypeEnum, SaveQuestionModel saveQuestionModel)
        {
            string filePath = HttpContext.Current.Server.MapPath(saveQuestionModel.FilePath);
            DataTable dt = DealWithExcel.ExcelToTable(filePath);
            if (dt.Rows.Count > 0)
            {
                T_QuestionLabel questionLabel = QuestionDAL.GetQuestionLabelByName(saveQuestionModel.LabelName);
                if (questionLabel == null)
                {
                    questionLabel = new T_QuestionLabel();
                    questionLabel.LabelName = saveQuestionModel.LabelName;
                    QuestionDAL.Insert(questionLabel);
                }
                T_QuestionType questionType = QuestionDAL.Get<T_QuestionType>((int)questionTypeEnum);
                switch (questionTypeEnum)
                {
                    case QuestionTypeEnum.SingleSelectQuestion:
                        #region 单选题
                        foreach (DataRow row in dt.Rows)
                        {
                            T_Question question = new T_Question();
                            question.QuestionType = questionType;
                            question.Stem = row[0].ToString();
                            question.OptionA = row[1].ToString();
                            question.OptionB = row[2].ToString();
                            question.OptionC = row[3].ToString();
                            question.OptionD = row[4].ToString();
                            question.OptionE = row[5].ToString();
                            question.OptionF = row[6].ToString();
                            question.Answer = row[7].ToString().Trim().ToUpper();
                            QuestionDAL.Insert(question);
                        }
                        #endregion
                        break;
                    case QuestionTypeEnum.MultipleSelectQuestion:
                        #region 多选题
                        foreach (DataRow row in dt.Rows)
                        {
                            T_Question question = new T_Question();
                            question.QuestionType = questionType;
                            question.Stem = row[0].ToString();
                            question.OptionA = row[1].ToString();
                            question.OptionB = row[2].ToString();
                            question.OptionC = row[3].ToString();
                            question.OptionD = row[4].ToString();
                            question.OptionE = row[5].ToString();
                            question.OptionF = row[6].ToString();
                            question.Answer = row[7].ToString().Trim().ToUpper().Replace('，', ',');
                            QuestionDAL.Insert(question);
                        }
                        break;
                        #endregion
                    case QuestionTypeEnum.JudgeQuestion:
                        #region 判断题
                        foreach (DataRow row in dt.Rows)
                        {
                            T_Question question = new T_Question();
                            question.QuestionType = questionType;
                            question.Stem = row[0].ToString();
                            question.Answer = row[1].ToString().Trim();
                            QuestionDAL.Insert(question);
                        }
                        break;
                        #endregion
                    case QuestionTypeEnum.FillQuestion:
                        #region 填空题
                        foreach (DataRow row in dt.Rows)
                        {
                            T_Question question = new T_Question();
                            question.QuestionType = questionType;
                            question.Stem = row[0].ToString();
                            question.Answer = row[1].ToString().Trim().Replace('，', ',');
                            QuestionDAL.Insert(question);
                        }
                        break;
                        #endregion
                }
            }

        }
    }
}
