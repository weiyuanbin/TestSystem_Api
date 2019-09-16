using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDAL
    {

        /// <summary>
        /// 强制加载
        /// </summary>
        /// <param name="obj"></param>
        void ForcedLoad(object obj);
        /// <summary>
        /// 用于添加一条记录
        /// </summary>
        /// <param name="t"></param>
        T Insert<T>(T t);

        /// <summary>
        /// 用于删除一记录
        /// </summary>
        /// <param name="t">要删除的实体对象</param>
        void Delete<T>(T t);

        /// <summary>
        /// 根据主键ID来进行删除操作
        /// </summary>
        /// <param name="id">主键ID</param>
        void Delete<T>(long id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sql"></param>
        void Delete(string sql);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="sql"></param>
        void Update(string sql);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t">要更新的数据实体</param>
        void Update<T>(T t);

        /// <summary>
        /// 根据主键ID来进行获取实体
        /// </summary>
        /// <param name="id">主健ID</param>
        /// <returns>获取的实体</returns>
        T Get<T>(long id);

        /// <summary>
        /// 用于获取所有的记录
        /// </summary>
        /// <returns></returns>
        IList<T> All<T>();

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
        IList<T> List<T>(String queryString, Object[] args, bool isSQL = false);

        /// <summary>
        /// 根据条件查询数据(重载+1)
        /// </summary>
        /// <param name="queryString">查询语句</param>
        /// <param name="isSQL">
        /// queryString是否是原生的SQL语句，true:代表是原生的SQL，
        /// false代表是Hql,默认为hql
        /// </param>
        /// <returns>查询的结果集</returns>
        IList<T> List<T>(String queryString, bool isSQL = false);

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
        IList<T> List<T>(String queryString, Object arg, bool isSQL = false);


        /// <summary>
        /// 根据查询语句和参数返回唯一对象
        /// </summary>
        /// <param name="queryString">sql语句或hql语句</param>
        /// <param name="code">用于查询的参数值</param>
        /// <param name="isSQL">true:代表是sql,为false代表的hql</param>
        /// <returns>返回的单一对象或null值</returns>
        T ListByCode<T>(String queryString, object code, bool isSQL = false);

        /// <summary>
        /// 根据查询语句和参数返回唯一值
        /// </summary>
        /// <param name="queryString">sql语句或hql语句</param>
        /// <param name="args">用于查询的参数值数组</param>
        /// <param name="isSQL">true:代表是sql,为false代表的hql</param>
        /// <returns>返回的单一值</returns>
        object ListSingle(String queryString, object[] args = null, bool isSQL = false);


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
        IList<T> ListByPage<T>(String[] queryStrings, int pageIndex, int pageSize, out long totalPage,
                               bool isSQL = false);

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
        IList<T> ListByPageRows<T>(String[] queryStrings, int pageIndex, int pageSize, out long countRows, bool isSQL = false);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryStrings">
        /// 是一个数组
        /// 第一个元素为：用于分页查询的SQL语句
        /// 第二个元素为：用于获得分页查询的源记录的总条数
        /// </param>
        /// <param name="args">代表SQL的参数值,如没有可以传null</param>
        /// <param name="pageIndex">从第几页开始取数据（索引从1开始）</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="totalPage">计算出来分页的总页数</param>
        /// <returns>返回分页查询的结果集</returns>
        IList<object> ListSqlByPage(String[] queryStrings, int pageIndex, int pageSize, out long totalPage);

        /// <summary>
        /// SQL分页
        /// </summary>
        /// <param name="queryStrings"></param>
        /// <param name="args"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>

        IList<object> ListSqlByPage(string[] queryStrings, object[] args, int pageIndex, int pageSize, out long totalPage);


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
        IList<object> ListSqlByPage(string[] queryStrings, object[] args, int pageIndex, int pageSize, out long totalPage, out long totalRecord);

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
        IList<T> ListByPage<T>(String[] queryStrings, object[] args, int pageIndex, int pageSize,
                               out long totalPage, bool isSQL = false);


        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        object GetSqlScalar(string sql);
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        object CreateSQLQuery(string sql);

        /// <summary>
        /// 取前N条数据
        /// </summary>
        /// <param name="queryString">查询的SQL或Hql</param>
        /// <param name="args">代表SQL或hql的参数值,如没有可以传null</param>
        /// <param name="n">取多少条记录</param>
        /// <param name="isSQL">true:代表queryString是SQL，false:代表querySring是Hql</param>
        /// <returns>返回结果集</returns>
        IList<T> ListTopN<T>(String queryString, object[] args, int n, bool isSQL = false);


    }
}
