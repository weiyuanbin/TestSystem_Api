using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Common.Result;
using Common.Spring;
using Common.Upload;
using Swashbuckle.Swagger;
using TestSystem_Api.Filters;
using TestSystem_ApiCommon.Enum;
using TestSystem_ApiCommon.Model.QuestionManager;
using IBLL;

namespace TestSystem_Api.Controllers.Admin
{
    
    /// <summary>
    /// 题目管理
    /// </summary>
    [AdminAuthFilter]
    public class QuestionManagerController : ApiController
    {
        public IQuestionBLL QuestionBLL
        {
            get { return SpringHelper.GetObject("QuestionBLL") as IQuestionBLL; }
        }

        /// <summary>
        /// 下载单选题模板
        /// </summary>
        [HttpGet]
        public void DownLoadSingleSelectQuestionTemp()
        {
            string fileName = "单选题模板.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("/QuestionTemp/SingleSelectQuestionTemp.xlsx");
            DownLoadQuestionTemp(fileName, filePath);
 
        }
        /// <summary>
        /// 下载多选题模板
        /// </summary>
        [HttpGet]
        public void DownLoadMultipleSelectQuestionTemp()
        {
            string fileName = "多选题模板.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("/QuestionTemp/MultipleSelectQuestionTemp.xlsx");
            DownLoadQuestionTemp(fileName, filePath);
        }
        /// <summary>
        /// 下载判断题模板
        /// </summary>
        [HttpGet]
        public void DownLoadJudgeQuestionTemp()
        {
            string fileName = "判断题模板.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("/QuestionTemp/MultipleSelectQuestionTemp.xlsx");
            DownLoadQuestionTemp(fileName, filePath);
        }
        /// <summary>
        /// 下载填空题模板
        /// </summary>
        [HttpGet]
        public void DownLoadFillQuestionTemp()
        {
            string fileName = "填空题模板.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("/QuestionTemp/FillQuestionTemp.xlsx");
            DownLoadQuestionTemp(fileName, filePath);
        }

        /// <summary>
        /// 下载题目模板
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        private void DownLoadQuestionTemp(string fileName,string filePath)
        {
            HttpResponse Response = HttpContext.Current.Response;
            //以字符流的形式下载文件 
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End(); 
        }


        /// <summary>
        /// 单选题上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultMsg<UploadFileResult> SingleSelectUpload()
        {
            return UploadQuestionExcel();
        }

        /// <summary>
        /// 上传题目
        /// </summary>
        /// <returns></returns>
        private ResultMsg<UploadFileResult> UploadQuestionExcel()
        {
            ResultMsg<UploadFileResult> result = new ResultMsg<UploadFileResult>();
            string moduleName = "Question";
            UploadFileResult uploadFileResult = UploadFile.FileUpload(HttpContext.Current, moduleName).First();
            result.data = uploadFileResult;
            return result;
        }

        /// <summary>
        /// 保存单选题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultMsg<string> SaveSingleSelect([FromBody]SaveQuestionModel model)
        {
            QuestionBLL.SaveQuestion(QuestionTypeEnum.SingleSelectQuestion,model);
            ResultMsg<string> result = new ResultMsg<string>();
            return result;
        }
    }
}
