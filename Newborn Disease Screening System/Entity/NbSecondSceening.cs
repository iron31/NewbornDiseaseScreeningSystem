using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newborn_Disease_Screening_System.Entity
{
    class NbSecondSceening
    {
        long second_screening_id;

        public long Second_screening_id
        {
            get { return second_screening_id; }
            set { second_screening_id = value; }
        }
        string card_no;

        public string Card_no
        {
            get { return card_no; }
            set { card_no = value; }
        }
        string card_code;

        public string Card_code
        {
            get { return card_code; }
            set { card_code = value; }
        }
        DateTime get_blood_date;

        public DateTime Get_blood_date
        {
            get { return get_blood_date; }
            set { get_blood_date = value; }
        }
        string get_blood_user_name;

        public string Get_blood_user_name
        {
            get { return get_blood_user_name; }
            set { get_blood_user_name = value; }
        }
        DateTime received_date;

        public DateTime Received_date
        {
            get { return received_date; }
            set { received_date = value; }
        }
        DateTime send_date;

        public DateTime Send_date
        {
            get { return send_date; }
            set { send_date = value; }
        }
        string qualified;

        public string Qualified
        {
            get { return qualified; }
            set { qualified = value; }
        }
        string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        string firest_sender;

        public string Firest_sender
        {
            get { return firest_sender; }
            set { firest_sender = value; }
        }
        string second_sender;

        public string Second_sender
        {
            get { return second_sender; }
            set { second_sender = value; }
        }
        DateTime check_time;

        public DateTime Check_time
        {
            get { return check_time; }
            set { check_time = value; }
        }
        float values1;

        public float Values1
        {
            get { return values1; }
            set { values1 = value; }
        }
        float values2;

        public float Values2
        {
            get { return values2; }
            set { values2 = value; }
        }
        DateTime create_date;

        public DateTime Create_date
        {
            get { return create_date; }
            set { create_date = value; }
        }
        DateTime update_date;

        public DateTime Update_date
        {
            get { return update_date; }
            set { update_date = value; }
        }
        int create_by;

        public int Create_by
        {
            get { return create_by; }
            set { create_by = value; }
        }
        int update_by;

        public int Update_by
        {
            get { return update_by; }
            set { update_by = value; }
        }
        string item_name;

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        string item_type;

        public string Item_type
        {
            get { return item_type; }
            set { item_type = value; }
        }
        float values_avg;

        public float Values_avg
        {
            get { return values_avg; }
            set { values_avg = value; }
        }
        string finally_reason;

        public string Finally_reason
        {
            get { return finally_reason; }
            set { finally_reason = value; }
        }
        string diagnose_remark;

        public string Diagnose_remark
        {
            get { return diagnose_remark; }
            set { diagnose_remark = value; }
        }

        string reason_info;

        public string Reason_info
        {
            get { return reason_info; }
            set { reason_info = value; }
        }
        string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
