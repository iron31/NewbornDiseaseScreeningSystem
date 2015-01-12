using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Newborn_Disease_Screening_System.DA
{
    public class FBSqlHelper : FBDBHelp
    {
        private DataTable dt;
        private FbConnection conn;
        private FbCommand cmd;
        private FbDataAdapter Fbda;
        /// <summary>
        /// 数据库操作类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
       

        /// <summary>
        /// 获得GetDataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            DataSet ds = null;
            try
            {
                conn = GetCon();
                Fbda = new FbDataAdapter(sql, conn);//DataAdapter：网络适配器
                ds = new DataSet();
                Fbda.Fill(ds);//将结果填充到ds中
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// 获得datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataSet ds = null;
            try
            {
                conn = GetCon();
                conn.Open();
                Fbda = new FbDataAdapter(sql, conn);//DataAdapter：网络适配器
                ds = new DataSet();
                Fbda.Fill(ds);//将结果填充到ds中
                dt = ds.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        /// <summary>
        /// 返回记录总条数
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public int GetCount(string strTableName)
        {
            string strSql = "select count(*) from " + strTableName;
            int count = 0;
            DataTable dtCount = GetDataTable(strSql);
            count = int.Parse(dtCount.Rows[0][0].ToString());
            return count;
        }


        /// <summary>
        /// 生成SQL参数
        /// </summary>
        /// <param name="SqlParams"></param>
        /// <param name="cmd"></param>
        private void BuildParams(object[] SqlParams, FbCommand cmd)
        {
            if ((SqlParams == null) || (SqlParams.Length == 0)) return;

            foreach (object param in SqlParams)
            {
                FbParameter oraParam = new FbParameter();
                if (param == null || param.ToString().Length < 4000)
                {
                    oraParam.Size = 4000;
                }
                //else
                //{//clob
                //    oraParam.FbDbType = FbDbType.Clob;
                //    oraParam.Size = (int)Math.Pow(2.0, 31) - 1;
                //}
                if (param == null || param.ToString().Length == 0)
                    oraParam.Value = DBNull.Value;
                else
                    oraParam.Value = param;

                cmd.Parameters.Add(oraParam);
            }
        }


        /// <summary>
        /// 执行查询SQL
        /// </summary>
        /// <param name="dsResult">类型化数据集</param>
        /// <param name="TableName">表名</param>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        /// <returns>查询结果</returns>
        public DataTable Query(string TableName, string SqlText, object[] Params)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                using (FbCommand dbCmd = new FbCommand(SqlText, conn))
                {
                    dbCmd.CommandType = CommandType.Text;
                    BuildParams(Params, dbCmd);
                    using (FbDataAdapter dbAdapter = new FbDataAdapter(dbCmd))
                    {
                        if ((TableName != null) && (TableName.Length > 0))
                        {
                            dbAdapter.TableMappings.Add("Table", TableName);
                        }
                        DataSet dsResult = new DataSet();
                        dbAdapter.Fill(dsResult);
                        return dsResult.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行查询SQL
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        /// <param name="TableName">表名</param>
        /// <returns>数据集</returns>
        public DataSet Query(string SqlText, object[] Params, string TableName)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                using (FbCommand dbCmd = new FbCommand(SqlText, conn))
                {
                    dbCmd.CommandType = CommandType.Text;
                    BuildParams(Params, dbCmd);
                    using (FbDataAdapter dbAdapter = new FbDataAdapter(dbCmd))
                    {
                        if (!String.IsNullOrEmpty(TableName))
                            dbAdapter.TableMappings.Add("Table", TableName);
                        DataSet dsResult = new DataSet();
                        dbAdapter.Fill(dsResult);
                        return dsResult;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        #region Excute
        /// <summary>
        /// 执行非查询Sql
        /// </summary>
        public int ExecuteNonQuery(string sql)
        {
            int count = 0;
            try
            {
                conn = GetCon();
                conn.Open();
                //FbTransaction transaction = null;
                //transaction = conn.BeginTransaction();

                FbCommand command = new FbCommand(sql, conn);
                //command.Transaction = transaction;

                cmd = new FbCommand(sql, conn);
                count = cmd.ExecuteNonQuery();
                //count = count + 1; 
                //transaction.Commit();
            }
            catch (Exception)
            {
                throw;
                //transaction.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        /// <summary>
        /// 执行非查询Sql
        /// </summary>
        public int ExecuteNonQuery(FbTransaction ts,string sql)
        {
            int count = 0;
            count=ExecuteNonQuery(ts,new string []{sql});
            return count;
        }
        /// <summary>
        /// 执行非查询Sql
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        public int ExecuteNonQuery(FbTransaction ts, string[] SqlText)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                ts = conn.BeginTransaction();

                using (FbCommand dbCmd = new FbCommand("", conn))
                {
                    dbCmd.Transaction = ts;
                    dbCmd.CommandType = CommandType.Text;
                    int Result = 0;
                    if (SqlText.Length == 1)
                    {
                        dbCmd.CommandText = SqlText[0];
                        Result += dbCmd.ExecuteNonQuery();
                       
                    }
                    else
                    {
                        for (int i = 0; i <= SqlText.Length - 1; i++)
                        {
                            dbCmd.CommandText = SqlText[i];
                            if(!string.IsNullOrEmpty(dbCmd.CommandText))
                            {
                                Result += dbCmd.ExecuteNonQuery();
                            }
                            
                        }
                    }
                    ts.Commit();
                    return Result;
                }
            }
            catch (Exception)
            {
                ts.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行非查询Sql
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        public int ExecuteNonQuery(string SqlText, object[] Params)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                using (FbCommand dbCmd = new FbCommand(SqlText, conn))
                {
                    dbCmd.CommandType = CommandType.Text;
                    BuildParams(Params, dbCmd);
                    return dbCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行非查询Sql
        /// </summary>
        /// <param name="SqlText">SQL文本</param>
        /// <param name="Params">SQL参数</param>
        public int ExecuteNonQuery(FbTransaction ts,string[] SqlText, object[][] Params)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                ts = conn.BeginTransaction();
                
                using (FbCommand dbCmd = new FbCommand("", conn))
                {
                    dbCmd.Transaction = ts;
                    dbCmd.CommandType = CommandType.Text;
                    int Result = 0;
                    if (SqlText.Length == 1)
                    {
                        dbCmd.CommandText = SqlText[0];
                        foreach (object[] param in Params)
                        {
                            dbCmd.Parameters.Clear();
                            BuildParams(param, dbCmd);
                            Result += dbCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= SqlText.Length - 1; i++)
                        {
                            dbCmd.CommandText = SqlText[i];
                            dbCmd.Parameters.Clear();
                            BuildParams(Params[i], dbCmd);
                            Result += dbCmd.ExecuteNonQuery();
                        }
                    }
                    BuildParams(Params, dbCmd);
                    ts.Commit();
                    return Result;
                }
            }
            catch (Exception)
            {
                ts.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行DDL脚本
        /// </summary>
        /// <param name="DDLScript">DDL脚本</param>
        public void ExecuteDDL(string DDLScript)
        {
            try
            {
                conn = GetCon();
                conn.Open();
                using (FbCommand dbCmd = new FbCommand("", conn))
                {
                    dbCmd.CommandType = CommandType.Text;
                    DDLScript = DDLScript.Replace("\r", "");
                    DDLScript = DDLScript.Replace("\n", "").Trim();
                    string[] SqlText = DDLScript.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < SqlText.Length; i++)
                    {
                        dbCmd.CommandText = SqlText[i];
                        dbCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }

}
