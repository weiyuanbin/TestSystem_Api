using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.EnumType;
using Common.JWT;
using Common.Result;
using Common.Spring;
using Domain.Entity;
using IBLL;
using TestSystem_ApiCommon.Model.Admin;

namespace TestSystem_Api.Controllers.Admin
{
    public class AdminController : ApiController
    {
        public IAdminBLL AdminBLL
        {
            get { return SpringHelper.GetObject("AdminBLL") as IAdminBLL; }
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultMsg<object> Login([FromBody]LoginInfo loginInfo)
        {
            ResultMsg<object> result = new ResultMsg<object>();
            T_Administrator administrator = null;
            string msg = AdminBLL.AdminLogin(loginInfo, ref administrator);
            if (msg == "yes")
            {
                //签发凭证
                UserInfo userInfo = new UserInfo() { uid = administrator.AdministratorID };
                result.data = new { access_token = JWTHelper.GetToken(userInfo) };
            }
            else
            {
                result.code = (int)StatusCodeEnum.TipInfo;
                result.msg = msg;
            }
            return result;
        }
    }
}
