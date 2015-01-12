using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newborn_Disease_Screening_System.Entity
{
    class NbFirstScreening
    {
       
        private long first_screening_id;
        private string card_no;
        private string item_name;
        private float item_value;
        private string first_checker;
        private string second_checker;
        private DateTime check_time;
        private string wash_avg;
        private string result;
        private float item_value2;
        string card_code;
        string mother_name;
        string organization_name;
        string gender;
        string illcase_no;
        string health_no;
        string receive_date;
        string send_date;

        public string Card_code
        {
            get { return card_code; }
            set { card_code = value; }
        }

        public string Mother_name
        {
            get { return mother_name; }
            set { mother_name = value; }
        }

        public string Organization_name
        {
            get { return organization_name; }
            set { organization_name = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Illcase_no
        {
            get { return illcase_no; }
            set { illcase_no = value; }
        }

        public string Health_no
        {
            get { return health_no; }
            set { health_no = value; }
        }

        public string Receive_date
        {
            get { return receive_date; }
            set { receive_date = value; }
        }


        public string Send_date
        {
            get { return send_date; }
            set { send_date = value; }
        }

        public long First_screening_id
        {
            get { return first_screening_id; }
            set { first_screening_id = value; }
        }


        public string Card_no
        {
            get { return card_no; }
            set { card_no = value; }
        }


        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }


        public float Item_value
        {
            get { return item_value; }
            set { item_value = value; }
        }

        public string Wash_avg
        {
            get { return wash_avg; }
            set { wash_avg = value; }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }


        public float Item_value2
        {
            get { return item_value2; }
            set { item_value2 = value; }
        }


        public string First_checker
        {
            get { return first_checker; }
            set { first_checker = value; }
        }
        public string Second_checker
        {
            get { return second_checker; }
            set { second_checker = value; }
        }
        public DateTime Check_time
        {
            get { return check_time; }
            set { check_time = value; }
        }
    }
}
