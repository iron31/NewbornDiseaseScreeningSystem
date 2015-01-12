using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newborn_Disease_Screening_System.DA;

namespace Newborn_Disease_Screening_System.Entity
{
    public class NbDiseaseScreeningCard
    {
        FBSqlHelper _sqlhelp = new FBSqlHelper();

        #region 属性
        long card_Id;  // '流水号';
        string card_No;// '疾病卡卡号';
        string organization_Name;// '医疗机构名称';
        string health_Code; // '保健号';
        string illcase_No;// '住院号';
        string bed_No; // '床位号';
        string mother_Name;// '母亲姓名';
        string gestational_Weeks; // '孕周';
        string gestational_Days;
        string weight;// '体重';
        string gender; // '性别|0女|1男';
        string gender_Info;
        DateTime birthday; // '出生日期';
        string get_Blood_User_Name;// '采血人员姓名';
        string qualified;// '是否合格|0不合格|1合格';
        string qualified_Info;
        string reason; // '不合格原因';
        string reason_Info;
        DateTime received_Date;// '标本收到日期';
        DateTime send_Date;  // '标本寄出日期';
        string yield_Mode;// '生产方式';
        string yieldmode_Info;
        string apgar;// 'apgar值';
        string anamnesis;// '病史';
        string anamnesis_Info;
        string feeding_Times;// '哺乳次数';
        string antibiotic;// '是否使用抗生素|0未使用|1使用';
        string antibiotics_Info;
        string iodine;// '碘接触|0未接触|1接触';
        string iodine_Info;
        string transfusion;// '输血|0未输|1输了';
        string transfusion_Info;
        string phone_No; // '电话号码';
        string address;// '详细地址';
        string report;// '报表情况';
        string report_Info;
        DateTime get_Blood_Date;// '采血时间';
        string card_Code; // '标本编号';
        string lot_No;// '批号';
        int organization_Id;// '医疗组织ID';
        DateTime create_Date;
        int create_By;
        DateTime update_Date;
        int update_By;


        public long Card_Id
        {
            get { return card_Id; }
            set { card_Id = value; }
        }




        public string Card_No
        {
            get { return card_No; }
            set { card_No = value; }
        }


        public string Organization_Name
        {
            get { return organization_Name; }
            set { organization_Name = value; }
        }


        public string Health_Code
        {
            get { return health_Code; }
            set { health_Code = value; }
        }


        public string Illcase_No
        {
            get { return illcase_No; }
            set { illcase_No = value; }
        }


        public string Bed_No
        {
            get { return bed_No; }
            set { bed_No = value; }
        }


        public string Mother_Name
        {
            get { return mother_Name; }
            set { mother_Name = value; }
        }


        public string Gestational_Weeks
        {
            get { return gestational_Weeks; }
            set { gestational_Weeks = value; }
        }


        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }


        public string Get_Blood_User_Name
        {
            get { return get_Blood_User_Name; }
            set { get_Blood_User_Name = value; }
        }


        public string Qualified
        {
            get { return qualified; }
            set { qualified = value; }
        }


        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public DateTime Received_Date
        {
            get { return received_Date; }
            set { received_Date = value; }
        }


        public DateTime Send_Date
        {
            get { return send_Date; }
            set { send_Date = value; }
        }


        public string Yield_Mode
        {
            get { return yield_Mode; }
            set { yield_Mode = value; }
        }


        public string Apgar
        {
            get { return apgar; }
            set { apgar = value; }
        }


        public string Anamnesis
        {
            get { return anamnesis; }
            set { anamnesis = value; }
        }


        public string Feeding_Times
        {
            get { return feeding_Times; }
            set { feeding_Times = value; }
        }

        public string Antibiotic
        {
            get { return antibiotic; }
            set { antibiotic = value; }
        }


        public string Iodine
        {
            get { return iodine; }
            set { iodine = value; }
        }


        public string Transfusion
        {
            get { return transfusion; }
            set { transfusion = value; }
        }


        public string Phone_No
        {
            get { return phone_No; }
            set { phone_No = value; }
        }


        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public string Report
        {
            get { return report; }
            set { report = value; }
        }


        public DateTime Get_Blood_Date
        {
            get { return get_Blood_Date; }
            set { get_Blood_Date = value; }
        }


        public string Card_Code
        {
            get { return card_Code; }
            set { card_Code = value; }
        }

        public string Lot_No
        {
            get { return lot_No; }
            set { lot_No = value; }
        }


        public int Organization_Id
        {
            get { return organization_Id; }
            set { organization_Id = value; }
        }

        public DateTime Create_Date
        {
            get { return create_Date; }
            set { create_Date = value; }
        }

        public int Create_By
        {
            get { return create_By; }
            set { create_By = value; }
        }

        public DateTime Update_Date
        {
            get { return update_Date; }
            set { update_Date = value; }
        }


        public int Update_By
        {
            get { return update_By; }
            set { update_By = value; }
        }

        public string Gestational_Days
        {
            get { return gestational_Days; }
            set { gestational_Days = value; }
        }

        public string Gender_Info
        {
            get { return gender_Info; }
            set { gender_Info = value; }
        }

        public string Qualified_Info
        {
            get { return qualified_Info; }
            set { qualified_Info = value; }
        }

        public string Reason_Info
        {
            get { return reason_Info; }
            set { reason_Info = value; }
        }

        public string Yieldmode_Info
        {
            get { return yieldmode_Info; }
            set { yieldmode_Info = value; }
        }

        public string Anamnesis_Info
        {
            get { return anamnesis_Info; }
            set { anamnesis_Info = value; }
        }

        public string Antibiotics_Info
        {
            get { return antibiotics_Info; }
            set { antibiotics_Info = value; }
        }

        public string Iodine_Info
        {
            get { return iodine_Info; }
            set { iodine_Info = value; }
        }

        public string Transfusion_Info
        {
            get { return transfusion_Info; }
            set { transfusion_Info = value; }
        }


        public string Report_Info
        {
            get { return report_Info; }
            set { report_Info = value; }
        }
        #endregion

        public int addCard(NbDiseaseScreeningCard card)
        {
            int count = 0;
            string insert = DA.Sql.addNewCard;
            object[] sqlparams = {card.Card_No,card.Organization_Name,card.Health_Code,card.Illcase_No,card.Bed_No,card.Mother_Name, 
                                  card.Gestational_Weeks,card.Weight,card.Gender,card.Birthday,card.Get_Blood_User_Name,card.Qualified, 
                                  card.Reason,card.Received_Date,card.Send_Date,card.Yield_Mode,card.Apgar,card.Anamnesis,card.Feeding_Times, 
                                  card.Antibiotic,card.Iodine,card.Transfusion,card.Phone_No,card.Address,card.Report,card.Create_By, 
                                  card.Get_Blood_Date,card.Card_Code,card.Lot_No,card.Organization_Id};
            count = _sqlhelp.ExecuteNonQuery(insert, sqlparams);
            return count;
        }

        public int updateCard(NbDiseaseScreeningCard card)
        {
            int count = 0;
            string update = DA.Sql.updateOrganization;
            object[] sqlparams = { };
            count = _sqlhelp.ExecuteNonQuery(update, sqlparams);
            return count;
        }
    }
}
