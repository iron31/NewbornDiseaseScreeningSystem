using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.Entity
{
    public class GmOrganization
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();

        #region 属性
        private int organization_id;
        private string organization_code;
        private string organization_name;
        private string organization_level;
        private string organization_belong;
        private string organization_levelName;
        private string organization_belongName;

        public string Organization_levelName
        {
            get { return organization_levelName; }
            set { organization_levelName = value; }
        }
       

        public string Organization_belongName
        {
            get { return organization_belongName; }
            set { organization_belongName = value; }
        }
        public int Organization_id
        {
            get { return organization_id; }
            set { organization_id = value; }
        }


        public string Organization_code
        {
            get { return organization_code; }
            set { organization_code = value; }
        }


        public string Organization_name
        {
            get { return organization_name; }
            set { organization_name = value; }
        }


        public string Organization_level
        {
            get { return organization_level; }
            set { organization_level = value; }
        }


        public string Organization_belong
        {
            get { return organization_belong; }
            set { organization_belong = value; }
        }
        #endregion


        public int addOrg( GmOrganization org)
        {
            int count = 0;
            string insert = DA.Sql.addOrganization;
            object[] sqlparams = { org.Organization_code,org.Organization_name,org.Organization_level,org.Organization_belong};
            count = _sqlhelp.ExecuteNonQuery(insert, sqlparams);
            return count;
        }

        public int updateOrg(GmOrganization org)
        {
            int count = 0;
            string update = DA.Sql.updateOrganization;
            object[] sqlparams = { org.Organization_code, org.Organization_name, org.Organization_level, org.Organization_belong,org.Organization_id };
            count = _sqlhelp.ExecuteNonQuery(update, sqlparams);
            return count;
        }
    }
}
