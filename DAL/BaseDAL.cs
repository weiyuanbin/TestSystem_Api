using IDAL;
using NHibernate;
using Spring.Data.NHibernate.Generic.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL : HibernateDaoSupport, IBaseDAL
    {

        /// <summary>
        /// 强制加载
        /// </summary>
        /// <param name="obj"></param>
        public void ForcedLoad(object obj)
        {
            using (this.HibernateTemplate.SessionFactory.OpenSession())
            {
                NHibernateUtil.Initialize(obj);
            }
        }
        /// <summary>
        /// 用于添加一条记录
        /// </summary>
        /// <param name="t"></param>
        public T Insert<T>(T t)
        {
            this.HibernateTemplate.Save(t);
            this.HibernateTemplate.Flush();
            return t;
        }
        /// <summary>
        /// 用于删除一记录
        /// </summary>
        /// <param name="t">要删除的实体对象</param>
        public void Delete<T>(T t)
        {
            this.HibernateTemplate.Delete(t);
            this.HibernateTemplate.Flush();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sql"></param>
        public void Delete(string sql)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            IQuery query = session.CreateQuery(sql);
            query.ExecuteUpdate();
            session.Close();
        }

        /// <summary>
        /// 根据主键ID来进行删除操作
        /// </summary>
        /// <param name="id">主键ID</param>
        public void Delete<T>(long id)
        {
            var t = this.Get<T>(id);
            this.Delete(t);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="sql"></param>
        public void Update(string sql)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            IQuery query = session.CreateQuery(sql);
            query.ExecuteUpdate();
            session.Close();
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t">要更新的数据实体</param>
        public void Update<T>(T t)
        {
            this.HibernateTemplate.Update(t);
        }

        public void Merge<T>(T t)
        {
            this.HibernateTemplate.Merge(t);
        }

        /// <summary>
        /// 根据主键ID来进行获取实体
        /// </summary>
        /// <param name="id">主健ID</param>
        /// <returns>获取的实体</returns>
        public T Get<T>(long id)
        {
            T obj = this.HibernateTemplate.Get<T>(id);
            return obj;
        }
        /// <summary>
        /// 用于获取所有的记录
        /// </summary>
        /// <returns></returns>
        public IList<T> All<T>()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="queryString">查询语句</param>
        /// <param name="args">参数，是一个数组，也可以传递null</param>
        /// <param name="isSQL">
        /// queryString是否是原生的SQL语句，true:代表是原生的SQL，
        /// false代表是Hql,默认为hql
        /// </param>
        /// <returns>查询的结果集</returns>
        public IList<T> List<T>(String queryString, Object[] args, bool isSQL = false)
        {


            IQuery query = null;
            if (isSQL)
            {
                query = this.Session.CreateSQLQuery(queryString);
            }
            else
            {
                query = this.Session.CreateQuery(queryString);
            }
            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    query.SetParameter(i, args[i]);
                }
            }

            IList<T> list = query.List<T>();

            return list;
        }
        /// <summary>
        /// 根据条件查询数据(重载+1)
        /// </summary>
        /// <param name="queryString">查询语句</param>
        /// <param name="isSQL">
        /// queryString是否是原生的SQL语句，true:代表是原生的SQL，
        /// false代表是Hql,默认为hql
        /// </param>
        /// <returns>查询的结果集</returns>
        public IList<T> List<T>(String queryString, bool isSQL = false)
        {
            return this.List<T>(queryString, null, isSQL);
        }
        /// <summary>
        /// 根据条件查询数据(重载+2)
        /// </summary>
        /// <param name="queryString">查询语句</param>
        /// <param name="arg">代表的是只有一个查询条件的参数</param>
        /// <param name="isSQL">
        /// queryString是否是原生的SQL语句，true:代表是原生的SQL，
        /// false代表是Hql,默认为hql
        /// </param>
        /// <returns></returns>
        public IList<T> List<T>(String queryString, Object arg, bool isSQL = false)
        {
            return this.List<T>(queryString, new Object[] { arg }, isSQL);
        }

        /// <summary>
        /// 根据查询语句和参数返回唯一对象
        /// </summary>
        /// <param name="queryString">sql语句或hql语句</param>
        /// <param name="code">用于查询的参数值</param>
        /// <param name="isSQL">true:代表是sql,为false代表的hql</param>
        /// <returns>返回的单一对象或null值</returns>
        public T ListByCode<T>(String queryString, object code, bool isSQL = false)
        {

            var result = default(T);
            IList<T> results = this.List<T>(queryString, code, isSQL);
            if (results != null && results.Count > 0)
                return results[0];
            return result;
        }

        /// <summary>
        /// 根据查询语句和参数返回唯一值
        /// </summary>
        /// <param name="queryString">sql语句或hql语句</param>
        /// <param name="args">用于查询的参数值数组</param>
        /// <param name="isSQL">true:代表是sql,为false代表的hql</param>
        /// <returns>返回的单一值</returns>
        public object ListSingle(String queryString, object[] args = null, bool isSQL = false)
        {
            IQuery q = null;
            if (isSQL)
            {
                q = this.Session.CreateSQLQuery(queryString);
            }
            else
            {
                q = this.Session.CreateQuery(queryString);
            }

            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    q.SetParameter(i, args[i]);
                }
            }

            return q.UniqueResult();

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryString">查询的SQL或Hql</param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <param name="offset">起始记录数,从0开始</param>
        /// <param name="pageSize">取多少条记录</param>
        /// <param name="isSQL">true:代表queryString是SQL，false:代表querySring是Hql</param>
        /// <returns>返回结果集</returns>
        private IList<T> listPage<T>(String queryString, object[] args, int offset, int pageSize, bool isSQL = false)
        {
            IQuery q = null;
            if (isSQL)
            {
                q = this.Session.CreateSQLQuery(queryString);
            }
            else
            {
                q = this.Session.CreateQuery(queryString);
            }
            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    q.SetParameter(i, args[i]);
                }
            }
            q = q.SetFirstResult(offset).SetMaxResults(pageSize);

            IList<T> results = q.List<T>();

            return results;

        }
        /// <summary>
        /// 用于获取分页的总记录条数
        /// </summary>
        /// <param name="hql">Hql语句</param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <returns>代表返回的记录数</returns>
        private long listCount(String hql, object[] args)
        {
            IList<long> results = null;
            if (args != null && args.Length > 0)
            {
                results = this.HibernateTemplate.Find<long>(hql, args);
            }
            else
            {
                results = this.HibernateTemplate.Find<long>(hql);
            }

            if (results != null && results.Count > 0)
            {
                long result = results[0];
                return result;
            }

            return 0;

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryStrings">
        /// 是一个数组
        /// 第一个元素为：用于分页查询的SQL语句或Hql语句
        /// 第二个元素为：用于获得分页查询的源记录的总条数(这个元素一定为hql)
        /// 如：new String[]{"select * from memberType","count(*) from MemberType"}
        /// </param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <param name="pageIndex">从第几页开始取数据（索引从1开始）</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="totalPage">计算出来分页的总页数</param>
        /// <param name="isSQL">true:代表queryStrings[0]为SQL，false:代表queryStrings[0]为hql</param>
        /// <returns>返回分页查询的结果集</returns>
        public IList<T> ListByPage<T>(String[] queryStrings, int pageIndex, int pageSize, out long totalPage, bool isSQL = false)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];

            long totalRecords = 0;
            if (!isSQL)
                totalRecords = this.listCount(queryString2, null);
            else
                totalRecords = long.Parse(GetSqlScalar(queryString2).ToString());

            totalPage = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;

            return this.listPage<T>(queryString1, null, offset, pageSize, isSQL);

        }

        /// <summary>
        /// 分页查询 总行数
        /// </summary>
        /// <param name="queryStrings">
        /// 是一个数组
        /// 第一个元素为：用于分页查询的SQL语句或Hql语句
        /// 第二个元素为：用于获得分页查询的源记录的总条数(这个元素一定为hql)
        /// 如：new String[]{"select * from memberType","count(*) from MemberType"}
        /// </param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <param name="pageIndex">从第几页开始取数据（索引从1开始）</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="totalPage">计算出来分页的总行数</param>
        /// <param name="isSQL">true:代表queryStrings[0]为SQL，false:代表queryStrings[0]为hql</param>
        /// <returns>返回分页查询的结果集</returns>
        public IList<T> ListByPageRows<T>(String[] queryStrings, int pageIndex, int pageSize, out long countRows, bool isSQL = false)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];

            long totalRecords = this.listCount(queryString2, null);

            long totalPage = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;
            countRows = totalRecords;
            return this.listPage<T>(queryString1, null, offset, pageSize, isSQL);

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryStrings">
        /// 是一个数组
        /// 第一个元素为：用于分页查询的SQL语句或Hql语句
        /// 第二个元素为：用于获得分页查询的源记录的总条数(这个元素一定为hql)
        /// 如：new String[]{"select * from memberType","count(*) from MemberType"}
        /// </param>
        /// <param name="pageIndex">从第几页开始取数据（索引从1开始）</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="totalPage">计算出来分页的总页数</param>
        /// <param name="isSQL">true:代表queryStrings[0]为SQL，false:代表queryStrings[0]为hql</param>
        /// <returns>返回分页查询的结果集</returns>
        public IList<T> ListByPage<T>(String[] queryStrings, object[] args, int pageIndex, int pageSize,
            out long totalPage, bool isSQL = false)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];

            long totalRecords = this.listCount(queryString2, args);

            totalPage = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;

            return this.listPage<T>(queryString1, args, offset, pageSize, isSQL);

        }

        public IList<object> ListSqlByPage(string[] queryStrings, int pageIndex, int pageSize, out long totalPage)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];


            long totalRecords = Convert.ToInt64(List<object>(queryString2, true).FirstOrDefault());

            totalPage = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;

            return this.listPage<object>(queryString1, null, offset, pageSize, true);
        }

        /// <summary>
        /// SQL分页
        /// </summary>
        /// <param name="queryStrings"></param>
        /// <param name="args"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>

        public IList<object> ListSqlByPage(string[] queryStrings, object[] args, int pageIndex, int pageSize, out long totalPage)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];


            long totalRecords = Convert.ToInt64(List<object>(queryString2, args, true).FirstOrDefault());

            totalPage = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;

            return this.listPage<object>(queryString1, args, offset, pageSize, true);
        }


        /// <summary>
        /// SQL分页
        /// </summary>
        /// <param name="queryStrings"></param>
        /// <param name="args"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalPage">返回的总页数</param>
        /// <param name="totalRecord">返回的总行数</param>
        /// <returns></returns>
        public IList<object> ListSqlByPage(string[] queryStrings, object[] args, int pageIndex, int pageSize, out long totalPage, out long totalRecord)
        {
            String queryString1 = queryStrings[0];
            String queryString2 = queryStrings[1];


            totalRecord = Convert.ToInt64(List<object>(queryString2, args, true).FirstOrDefault());

            totalPage = totalRecord % pageSize == 0 ? totalRecord / pageSize : totalRecord / pageSize + 1;

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > totalPage)
            {
                pageIndex = (int)totalPage;
            }

            int offset = (pageIndex - 1) * pageSize;

            return this.listPage<object>(queryString1, args, offset, pageSize, true);
        }


        public object GetSqlScalar(string sql)
        {
            string strSql = string.Format(sql);
            object retObj = List<object>(strSql, true).FirstOrDefault();
            return retObj;
        }
        public object CreateSQLQuery(string sql)
        {
            return this.Session.CreateSQLQuery(sql).ExecuteUpdate();
        }

        /// <summary>
        /// 取前N条数据
        /// </summary>
        /// <param name="queryString">查询的SQL或Hql</param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <param name="n">取多少条记录</param>
        /// <param name="isSQL">true:代表queryString是SQL，false:代表querySring是Hql</param>
        /// <returns>返回结果集</returns>
        public IList<T> ListTopN<T>(String queryString, object[] args, int n, bool isSQL = false)
        {
            IQuery q = null;
            if (isSQL)
            {
                q = this.Session.CreateSQLQuery(queryString);
            }
            else
            {
                q = this.Session.CreateQuery(queryString);
            }
            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    q.SetParameter(i, args[i]);
                }
            }
            q = q.SetMaxResults(n);

            IList<T> results = q.List<T>();

            return results;

        }

    }
}
