//
//类    名：DBVisit（数据库访问类）
//基本功能：提供数据库访问接口
//开发时间：
//开发人员：罗鑫
//附加说明：无
//更新记录：
/*
 * 更新目的：实现该类的重复使用
 * 更新思想：在用户使用前清空上次的参数列表
 * 更新时间：
 * 更新内容：修改属性CommandStr的set操作方法
 */
/*
     * 更新目的：使用线程不安全的单例模式构造对象
     * 更新思想：单例模式
     * 更新时间：
     * 更新内容：构造函数
     */
//

using System;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
namespace ContributeOnlineSystem.DAL.DBHelper
{
    /// <summary>
    /// 用于数据库访问
    /// </summary>
    public class DBVisit
    {
        #region 字段
        /// <summary>
        /// 连接对象s
        /// </summary>
        private SqlConnection objConnection;
        /// <summary>
        /// 命令对象
        /// </summary>
        private SqlCommand objCommand;
        /// <summary>
        /// 适配器对象
        /// </summary>
        private SqlDataAdapter objDataAdapter;
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string connectionStr;
        /// <summary>
        /// 命令字符串
        /// </summary>
        private string commandStr;
        #endregion 字段

        #region 属性
        /// <summary>
        /// 读取或设置命令字符串
        /// </summary>
        public string CommandStr
        {
            get { return commandStr; }
            set
            {
                CmdParas.Clear();                           //清空上次使用的参数列表
                commandStr = value;
            }
        }
        /// <summary>
        /// 获取objCommand对象的参数列表
        /// </summary>
        public SqlParameterCollection CmdParas
        {
            get { return objCommand.Parameters; }
        }
        #endregion 属性

        #region 单例模式实现
        /// <summary>
        /// 构造函数
        /// </summary>
        private DBVisit()
            : this(ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="?"></param>
        private DBVisit(string connStr)
        {
            this.connectionStr = connStr;                           //初始化连接字符串
            objConnection = new SqlConnection(connectionStr);       //创建连接对象
            objCommand = new SqlCommand();                          //定义命令对象
        }
        /// <summary>
        /// 保存本类对象的静态引用
        /// </summary>
        private static DBVisit objDBAccess;
        /// <summary>
        /// 实现单例模式的属性
        /// </summary>
        public static DBVisit ObjDBAccess
        {
            get
            {
                if (objDBAccess == null)
                {
                    DBVisit.objDBAccess = new DBVisit();
                }
                return DBVisit.objDBAccess;
            }
        }
        #endregion 单例模式实现

        #region 操作方法
        /// <summary>
        /// 执行一条非查询语句并返回响应行数
        /// </summary>
        /// <returns>响应行数</returns>
        public int ExecuteUnSelectSqlCommand()
        {
            int result = -1;                                        //定义返回值

            objCommand.CommandText = CommandStr;                    //设置命令字符串
            objCommand.Connection = objConnection;                  //设置连接
            objCommand.CommandType = CommandType.Text;

            try
            {
                objConnection.Open();                               //打开连接
                result = objCommand.ExecuteNonQuery();              //执行命令

            }
            catch (SqlException ex)
            {
                result = -1;
                throw new Exception(ex.Message);

            }
            finally
            {
                objConnection.Close();                              //关闭连接
            }

            return result;                                          //返回结果
        }
        /// <summary>
        /// 执行一条非查询语句并返回响应上一个字增列的值
        /// </summary>
        /// <returns>上一个字增列的值</returns>
        public int ExecuteInsertSqlCommandAndReturnIdentity()
        {
            int indentityValue = -1;

            objCommand.CommandText = CommandStr + ";Select @@IDENTITY";                    //设置命令字符串
            objCommand.Connection = objConnection;                  //设置连接
            objCommand.CommandType = CommandType.Text;
            try
            {
                objConnection.Open();                               //打开连接
                indentityValue = Convert.ToInt32(objCommand.ExecuteScalar().ToString());              //执行命令

            }
            catch (SqlException ex)
            {
                indentityValue = -1;
                throw new Exception(ex.Message);

            }
            finally
            {
                objConnection.Close();                              //关闭连接
            }

            return indentityValue;                                          //返回结果
        }
        /// <summary>
        /// 执行一条查询语句并返回结果集
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <returns>查询的结果集</returns>
        public DataSet ExecuteSelectSqlCommand()
        {
            DataSet ds = new DataSet();                                 //定义结果集

            objCommand.CommandText = CommandStr;                        //设置命令字符串
            objCommand.Connection = objConnection;                      //设置连接
            objCommand.CommandType = CommandType.Text;

            objDataAdapter = new SqlDataAdapter(objCommand);            //初始化适配器
            objDataAdapter.Fill(ds, "result");                           //填充结果集
            return ds;                                                  //返回结果集
        }
        /// <summary>
        /// 执行事务并返回
        /// </summary>
        /// <param name="cmdArray">事务所要执行的命令集合</param>
        /// <returns>事务是否执行成功</returns>
        public bool ExecuteTransaction(string cmdArray)
        {
            bool isSuccess = false;         //操作成功的标识
            //拆分命令数组
            string[] UserCmdArray = cmdArray.Split(';');

            objConnection.Open();           //打开连接

            //开启一个事务
            SqlTransaction tarn = objConnection.BeginTransaction();
            objCommand.Transaction = tarn;              //设置命令对象的事务

            objCommand.Connection = objConnection;      //设置连接

            try
            {
                //执行事务
                for (int i = 0; i < UserCmdArray.Length; i++)
                {
                    objCommand.CommandText = UserCmdArray[i];   //设置命令对的命令文本
                    if (objCommand.CommandText.Length != 0)
                    {
                        objCommand.ExecuteNonQuery();
                    }
                }

                tarn.Commit();                                  //提交事务
                isSuccess = true;                               //修改标识
            }
            catch (SqlException ex)
            {
                tarn.Rollback();                                //回滚事务
                isSuccess = false;                              //修改标识
                throw new Exception(ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return isSuccess;                                   //返回结果
        }
        /// <summary>
        /// 判断是否存在所要的信息
        /// </summary>
        /// <returns>是否存在</returns>
        public bool IsExist()
        {
            objCommand.CommandText = CommandStr;                //读取命令字符串
            objCommand.Connection = objConnection;              //设置连接
            objCommand.CommandType = CommandType.Text;

            objConnection.Open();                               //打开连接
            int result = Convert.ToInt32(objCommand.ExecuteScalar());
            objConnection.Close();                              //关闭连接

            //查看结果并返回
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 执行一个返回结果集的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回的结果集</returns>
        public DataSet ExecuteProc(string procName)
        {
            //设置命令对象
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = procName;

            //执行存储过程
            DataSet ds = new DataSet();
            objDataAdapter = new SqlDataAdapter(objCommand);
            objDataAdapter.Fill(ds, "result");

            objCommand.CommandType = CommandType.Text;
            //返回结果集
            return ds;
        }

        /// <summary>
        /// 执行一个返回受影响行数的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回的结果集</returns>
        public int ExcuteProcReturnInt(string procName)
        {

            //设置命令对象
            objCommand.Connection = objConnection;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = procName;

            

            int result = 0;
            try
            {
                objCommand.Connection.Open();           //打开连接
                result = objCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            { 
                objCommand.Connection.Close();
            }

            
            objCommand.CommandType = CommandType.Text;
           
            return result;
        }
        #endregion 方法
    }
}
