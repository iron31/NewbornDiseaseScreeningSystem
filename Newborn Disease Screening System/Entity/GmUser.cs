using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Newborn_Disease_Screening_System.Entity
{
    public static class GmUser
    {
        private static int user_id;

        public static int User_id
        {
            get { return GmUser.user_id; }
            set { GmUser.user_id = value; }
        }
        private static string user_code;

        public static string User_code
        {
            get { return GmUser.user_code; }
            set { GmUser.user_code = value; }
        }
        private static string user_name;

        public static string User_name
        {
            get { return GmUser.user_name; }
            set { GmUser.user_name = value; }
        }
        private static string user_password;

        public static string User_password
        {
            get { return GmUser.user_password; }
            set { GmUser.user_password = value; }
        }
        private static string user_type;

        public static string User_type
        {
            get { return GmUser.user_type; }
            set { GmUser.user_type = value; }
        }
        private static string beg_no;

        public static string Beg_no
        {
            get { return GmUser.beg_no; }
            set { GmUser.beg_no = value; }
        }
        private static string current_no;

        public static string Current_no
        {
            get { return GmUser.current_no; }
            set { GmUser.current_no = value; }
        }
        private static string end_no;

        public static string End_no
        {
            get { return GmUser.end_no; }
            set { GmUser.end_no = value; }
        }

        private static char status;

        public static char Status
        {
            get { return GmUser.status; }
            set { GmUser.status = value; }
        }
    }
}
