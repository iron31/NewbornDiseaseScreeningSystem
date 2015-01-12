using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using System.Windows.Forms;

namespace Newborn_Disease_Screening_System.DA
{
    public class FBDBHelp
    {
        public FbConnection GetCon()
        {
            ////调用的时候取连接字符串：
            //string cn = ConfigurationManager.ConnectionStrings["connString"].ToString();
            ////取变量的值：
            //string MaxNum = ConfigurationManager.AppSettings["SqlMaxNum"].ToString();

            ///firebird
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            //cs.DataSource = "192.168.2.100";//本地数据库(embed)可不理会
            ////  cs.ServerType = FbServerType.Embedded;//embed模式,
            //cs.ServerType = FbServerType.Default;// sever模式
            //cs.Database = @"G:\Newborn Disease Screening System\DataBase\NEWBORNDISEASESCREENINGSYSTEM.FDB";
            //cs.UserID = "SYSDBA";
            //cs.Password = "masterkey";
            //cs.Charset = "NONE";
            //cs.Pooling = false;//这个看需要了,这里只读测试所以为false
            //cs.DataSource = ConfigurationManager.AppSettings["DataSource"].ToString();


            cs.ServerType = ConfigurationManager.AppSettings["ServerType"].ToString() == "0" ? FbServerType.Default : FbServerType.Embedded;
            if (ConfigurationManager.AppSettings["ServerType"].ToString() == "1")
            {
                cs.Database = Application.StartupPath + ConfigurationManager.AppSettings["Database"].ToString();
            }
            else
            {
                cs.Database = ConfigurationManager.AppSettings["Database"].ToString();
            }
            cs.UserID = ConfigurationManager.AppSettings["UserID"].ToString();
            cs.Password = ConfigurationManager.AppSettings["Password"].ToString();
            cs.Charset = ConfigurationManager.AppSettings["Charset"].ToString();
            cs.Pooling = ConfigurationManager.AppSettings["Pooling"].ToString() == "0" ? false : true;
            FbConnection sqliteCon = new FbConnection(cs.ToString());
            return sqliteCon;
        }
    }
}
