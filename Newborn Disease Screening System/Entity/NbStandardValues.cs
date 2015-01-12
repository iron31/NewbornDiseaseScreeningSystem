using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newborn_Disease_Screening_System.Entity
{
    class NbStandardValues
    {
        long standard_Values_Id;
        string item_Name;
        string disease_Name;
        string units;
        double normal_Low_Value;
        double normal_High_Value;
        double weak_Positive_Low_Value;
        double weak_Positive_High_Value;
        double positive_Low_Value;
        double positive_High_Value;
        DateTime create_Date;
        int create_By;
        DateTime update_Date;
        int update_By;

        public long Standard_Values_Id
        {
            get { return standard_Values_Id; }
            set { standard_Values_Id = value; }
        }

        public string Item_Name
        {
            get { return item_Name; }
            set { item_Name = value; }
        }

        public string Disease_Name
        {
            get { return disease_Name; }
            set { disease_Name = value; }
        }

        public string Units
        {
            get { return units; }
            set { units = value; }
        }

        public double Normal_Low_Value
        {
            get { return normal_Low_Value; }
            set { normal_Low_Value = value; }
        }

        public double Normal_High_Value
        {
            get { return normal_High_Value; }
            set { normal_High_Value = value; }
        }

        public double Weak_Positive_Low_Value
        {
            get { return weak_Positive_Low_Value; }
            set { weak_Positive_Low_Value = value; }
        }

        public double Weak_Positive_High_Value
        {
            get { return weak_Positive_High_Value; }
            set { weak_Positive_High_Value = value; }
        }

        public double Positive_Low_Value
        {
            get { return positive_Low_Value; }
            set { positive_Low_Value = value; }
        }

        public double Positive_High_Value
        {
            get { return positive_High_Value; }
            set { positive_High_Value = value; }
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

    }
}
