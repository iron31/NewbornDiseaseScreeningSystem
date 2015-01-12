using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newborn_Disease_Screening_System.DA
{
    public class Sql
    {
        #region 疾病筛查卡
        /// <summary>
        /// 添加疾病筛查卡
        /// </summary>
        public static string addNewCard = @"insert into nb_disease_screening_card (
                                          card_no, 
                                          organization_name, 
                                          health_code, 
                                          illcase_no, 
                                          bed_no, 
                                          mother_name, 
                                          gestational_weeks, 
                                          weight, 
                                          gender, 
                                          birthday, 
                                          get_blood_user_name, 
                                          qualified, 
                                          reason, 
                                          received_date, 
                                          send_date, 
                                          yield_mode, 
                                          apgar, 
                                          anamnesis, 
                                          feeding_times, 
                                          antibiotic, 
                                          iodine, 
                                          transfusion, 
                                          phone_no, 
                                          address, 
                                          report, 
                                          create_date, 
                                          create_by, 
                                          update_date, 
                                          update_by, 
                                          get_blood_date, 
                                          card_code, 
                                          lot_no,
                                          organization_id,
                                          Gestational_Days) 
                                         values (
                                         ?, 
                                          ?, 
                                          NULLIF(?,''), 
                                          ?, 
                                          ?, 
                                          ?, 
                                          NULLIF(?,''), 
                                          NULLIF(?,''), 
                                          ?, 
                                          ?, 
                                          NULLIF(?,''), 
                                          ?, 
                                          NULLIF(?,''), 
                                          NULLIF(?,'0001-01-01'),
                                          NULLIF(?,'0001-01-01'), 
                                          ?, 
                                          ?, 
                                          NULLIF(?,''),  
                                          NULLIF(?,''), 
                                          ?, 
                                          ?, 
                                          ?, 
                                          NULLIF(?,''), 
                                          NULLIF(?,''),
                                          ?, 
                                          ?, 
                                          ?, 
                                          NULLIF(?,''), 
                                          NULLIF(?,''), 
                                          ?, 
                                          NULLIF(?,''), 
                                          NULLIF(?,''), 
                                          ?,
                                          NULLIF(?,''))";

        #endregion

        #region 医疗机构管理
        public static string organizationView = @"select 
                                                  gon.*, 
                                                  (select 
                                                    gps.object_name 
                                                  from gm_params gps 
                                                  where
                                                    gps.types = 'ORGLEVEL' and gon.org_level = gps.type_value) level,
                                                     (select 
                                                    gps.object_name 
                                                  from gm_params gps 
                                                  where
                                                    gps.types = 'ORGBELONG' and gon.org_belong = gps.type_value) belong
                                                from gm_organization gon";

        public static string addOrganization = @" INSERT INTO GM_ORGANIZATION
                                                    (ORG_CODE, ORG_NAME, ORG_LEVEL, ORG_BELONG)
                                                VALUES
                                                    (?,?,?,?)";
        public static string updateOrganization = @"UPDATE
                                                      GM_ORGANIZATION
                                                    SET
                                                      ORG_CODE = ?,
                                                      ORG_NAME = ?,
                                                      ORG_LEVEL = ?,
                                                      ORG_BELONG = ?
                                                    WHERE
                                                      ORG_ID = ?";
        #endregion

        #region 静态参数管理
        public static string getParams = @"select * from gm_params gps
                                            where gps.types= ? and status='1'";
        #endregion

        #region 初检结果
        /// <summary>
        /// 添加第一次筛查记录
        /// </summary>
        public static string addFirstResult = @"INSERT INTO NB_FIRST_SCREENING
                                                ( CARD_NO, ITEM_NAME, VALUES1, FIRST_CHECKER, SECOND_CHECKER, CHECK_TIME, WASH, RESULT,VALUES2,CREATE_BY, UPDATE_BY,ITEM_TYPE,ITEM_VALUE)
                                            VALUES
                                                ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?);";

        /// <summary>
        /// 修改第一次筛查记录
        /// </summary>
        public static string UpdateFirstResult = @"UPDATE
                                                      NB_FIRST_SCREENING
                                                    SET
                                                      FIRST_CHECKER = ?,
                                                      SECOND_CHECKER = ?,
                                                      CHECK_TIME = ?,
                                                      WASH = ?,
                                                      RESULT = ?,
                                                      UPDATE_DATE = CURRENT_TIMESTAMP,
                                                      UPDATE_BY = ?,
                                                      VALUES1 = ?,
                                                      VALUES2 = ?,
                                                      ITEM_VALUE=?
                                                    WHERE
                                                      CARD_NO = ?
                                                      and ITEM_NAME = ?";
        //        public static string UpdateFirstResult = @"UPDATE
        //                                                      NB_FIRST_SCREENING
        //                                                    SET
        //                                                      ITEM_NAME = '{0}',
        //                                                      FIRST_CHECKER = '{0}',
        //                                                      SECOND_CHECKER = '{0}',
        //                                                      CHECK_TIME = '{0}',
        //                                                      WASH = '{0}',
        //                                                      RESULT = '{0}',
        //                                                      UPDATE_DATE = CURRENT_TIMESTAMP,
        //                                                      UPDATE_BY = '{0}',
        //                                                      VALUES1 = '{0}',
        //                                                      VALUES2 = '{0}',
        //                                                      ITEM_VALUE='{0}'
        //                                                    WHERE
        //                                                      CARD_NO = '{0}'
        //                                                      and ITEM_NAME = '{0}'";

        /// <summary>
        /// 是否存在该卡号的疾病卡
        /// </summary>
        public static string cardNoExists = @"select * from NB_DISEASE_SCREENING_CARD where card_no =?";


        /// <summary>
        /// 该卡号是否有对应的初检筛查记录
        /// </summary>
        public static string firstResultExists = @"select * from nb_first_screening nsg
                                              where nsg.CARD_NO=? and nsg.ITEM_NAME=?";

        //        public static string firstResultInfo = @"select c.*, ncd.GET_BLOOD_DATE,ncd.GET_BLOOD_USER_NAME from (
        //                                                    select 
        //                                                        b.card_no, 
        //                                                        sum(tsh) tsh, 
        //                                                        case 
        //                                                        when (SUM(b.TSH)>?) then '阳性'
        //                                                        else '阴性'
        //                                                        end TSH_RESULT,
        //                                                        sum(phe) phe,
        //                                                        case 
        //                                                        when (SUM(b.phe)>?) then '阳性'
        //                                                        else '阴性'
        //                                                        end PHE_RESULT,
        //                                                        sum(g6pd) g6pd,
        //                                                        case 
        //                                                        when (SUM(b.g6pd)>?) then '阳性'
        //                                                        else '阴性'
        //                                                        end G6PD_RESULT 
        //                                                    from (select 
        //                                                        card_no, 
        //                                                        case 
        //                                                        when (a.item_type = 'TSH') then a.item_name 
        //                                                        else 0 
        //                                                        end tsh, 
        //                                                        case 
        //                                                        when (a.item_type = 'PHE') then a.item_name 
        //                                                        else 0 
        //                                                        end phe, 
        //                                                        case 
        //                                                        when (a.item_type = 'G6PD') then a.item_name 
        //                                                        else 0 
        //                                                        end g6pd 
        //                                                    from (select 
        //                                                        ng.card_no , 
        //                                                        max(ng.values1) item_name, 
        //                                                        ng.item_type 
        //                                                    from nb_first_screening ng 
        //                                                    where (ng.create_date between ? and ? or ?='1')
        //                                                    and (ng.card_no between ? and ? or ?='1')
        //                                                    group by 
        //                                                        ng.card_no , 
        //                                                        ng.item_type) a) b 
        //                                                    group by 
        //                                                        b.card_no)c ,NB_DISEASE_SCREENING_CARD ncd
        //                                                        where c.card_no=ncd.card_no";

        /// <summary>
        /// 初检筛查结果信息
        /// </summary>
        public static string firstResultInfo = @"select 
                                                  c.*, 
                                                  ncd.get_blood_date, 
                                                  ncd.get_blood_user_name 
                                                from ( select 
                                                    a.card_no,
                                                    a.TSH,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     a.phe,
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     a.g6pd,
                                                     (SELECT 
                                                    case 
                                                     when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) g6pd 
                                                    from nb_first_screening ng 
                                                    where
                                                     (ng.create_date between ? and ? or ?=1)
                                                     and (ng.card_no between ? and ? or ?=1)
                                                    group by 
                                                      ng.card_no) a) c, nb_disease_screening_card ncd 
                                                    where
                                                        c.card_no = ncd.card_no
                                                     ";

        #endregion

        #region 复检结果
        /// <summary>
        /// 添加复检筛查结果
        /// </summary>
        public static string addSecondResult = @"insert into nb_second_screening (
                                                                    card_no, 
                                                                    card_code, 
                                                                    get_blood_date, 
                                                                    get_blood_user_name, 
                                                                    received_date, 
                                                                    send_date, 
                                                                    qualified, 
                                                                    reason, 
                                                                    first_sender, 
                                                                    second_sender, 
                                                                    check_time, 
                                                                    values1, 
                                                                    values2, 
                                                                    create_by, 
                                                                    item_name, 
                                                                    item_type, 
                                                                    values_avg, 
                                                                    finally_reason, 
                                                                    diagnose_remark,
                                                                    reason_info,
                                                                    RESULT) 
                                                                values (
                                                                    '{0}', 
                                                                    NULLIF('{1}',''), 
                                                                    NULLIF('{2}',''), 
                                                                    NULLIF('{3}',''), 
                                                                    '{4}', 
                                                                    NULLIF('{5}',''), 
                                                                    '{6}', 
                                                                    NULLIF('{7}',''), 
                                                                    '{8}', 
                                                                    NULLIF('{9}',''), 
                                                                    '{10}', 
                                                                    '{11}', 
                                                                    NULLIF('{12}',''),
                                                                    '{13}', 
                                                                    '{14}', 
                                                                    '{15}', 
                                                                    '{16}', 
                                                                    NULLIF('{17}',''), 
                                                                    NULLIF('{18}',''),
                                                                    NULLIF('{19}',''),
                                                                    NULLIF('{20}',''));
                                                                    ";
        /// <summary>
        /// 该卡号是否有对应的复检筛查记录
        /// </summary>
        public static string secondResultExists = @"select * from NB_SECOND_SCREENING nsg
                                              where nsg.CARD_NO=? and nsg.ITEM_NAME=?";

        public static string UpdateSecondResult = @"UPDATE
                                                      NB_SECOND_SCREENING
                                                    SET
                                                      CARD_CODE = NULLIF('{0}',''),
                                                      GET_BLOOD_DATE = NULLIF('{1}',''),
                                                      GET_BLOOD_USER_NAME =NULLIF('{2}',''),
                                                      RECEIVED_DATE = NULLIF('{3}',''),
                                                      SEND_DATE = NULLIF('{4}',''),
                                                      QUALIFIED = NULLIF('{5}',''),
                                                      REASON = NULLIF('{6}',''),
                                                      FIRST_SENDER = NULLIF('{7}',''),
                                                      SECOND_SENDER = NULLIF('{8}',''),
                                                      CHECK_TIME = NULLIF('{9}',''),
                                                      VALUES1 = NULLIF('{10}',''),
                                                      VALUES2 = NULLIF('{11}',''),
                                                      UPDATE_DATE = {12},
                                                      UPDATE_BY = NULLIF('{13}',''),
                                                      VALUES_AVG = NULLIF('{14}',''),
                                                      FINALLY_REASON =NULLIF('{15}',''),
                                                      DIAGNOSE_REMARK = NULLIF('{16}',''),
                                                      REASON_INFO = NULLIF('{17}',''),
                                                      RESULT = NULLIF('{18}','')
                                                    WHERE
                                                      SECOND_SCREENING_ID = '{19}'";


        /// <summary>
        /// 复检筛查结果信息
        /// </summary>
        public static string secondResultInfo = @"select 
                                                    a.card_no,
                                                    a.TSH,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     a.phe,
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     a.g6pd,
                                                     (SELECT 
                                                    case 
                                                     when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT,
                                                     GET_BLOOD_DATE
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.values_avg 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.values_avg 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.values_avg 
                                                        else 0 
                                                      end) g6pd,
                                                      max(ng.GET_BLOOD_DATE) GET_BLOOD_DATE
                                                    from nb_second_screening ng 
                                                    where (ng.card_no between ? and ? or ?=1)
                                                    group by 
                                                      ng.card_no) a
                                                     ";
        #endregion

        #region 指标参数
        /// <summary>
        /// 获取参数
        /// </summary>
        public static string getStandardValues = @"SELECT * FROM NB_STANDARD_VALUES nvs
                                                    where nvs.ITEM_NAME = ? ";
        #endregion

        #region 筛查初检报告单
        public static string firstResultReport = @"select 
                                                  c.*, 
                                                  ncd.card_code,
                                                  ncd.ORGANIZATION_NAME,
                                                  ncd.ILLCASE_NO,
                                                  ncd.BED_NO,
                                                  ncd.MOTHER_NAME,
                                                  ncd.BIRTHDAY,
                                                  ncd.RECEIVED_DATE,
                                                  ncd.SEND_DATE,
                                                  ncd.get_blood_date,
                                                  ncd.health_code,
                                                  case when ncd.gender ='1' then '男'
                                                       when ncd.gender = '0' then '女'
                                                       else '不详'
                                                  end gender_info, 
                                                  case when (ncd.print='0') then '×' 
                                                       when (ncd.print='1') then '√'
                                                  end print,
                                                  case when (ncd.print2='0') then '×' 
                                                       when (ncd.print2='1') then '√'
                                                  end print2
                                                from ( select 
                                                    a.card_no,
                                                    a.TSH,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     a.phe,
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     a.g6pd,
                                                     (SELECT 
                                                    case 
                                                     when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) g6pd 
                                                    from nb_first_screening ng 
                                                    where (ng.card_no between ? and ? or ?=1)
                                                    group by 
                                                      ng.card_no) a) c, nb_disease_screening_card ncd 
                                                    where
                                                        c.card_no = ncd.card_no
                                                        and ncd.received_date between ? and ?
                                                        and (c.TSHRESULT=? or c.PHERESULT=? or c.G6PDRESULT=? or ?=1)
                                                     ";

        public static string firstResultInform = @"select 
                                                  c.*, 
                                                  ncd.card_code,
                                                  ncd.ORGANIZATION_NAME,
                                                  ncd.ILLCASE_NO,
                                                  ncd.BED_NO,
                                                  ncd.MOTHER_NAME,
                                                  ncd.BIRTHDAY,
                                                  ncd.RECEIVED_DATE,
                                                  ncd.SEND_DATE,
                                                  ncd.get_blood_date, 
                                                  ncd.health_code,
                                                  case when ncd.gender ='1' then '男'
                                                       when ncd.gender = '0' then '女'
                                                       else '不详'
                                                  end gender_info,
                                                  case when (ncd.print='0') then '×' 
                                                       when (ncd.print='1') then '√'
                                                  end print,
                                                  case when (ncd.print2='0') then '×' 
                                                       when (ncd.print2='1') then '√'
                                                  end print2
                                                from ( select 
                                                    a.card_no,
                                                    a.TSH,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     a.phe,
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     a.g6pd,
                                                     (SELECT 
                                                    case 
                                                     when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.ITEM_VALUE 
                                                        else 0 
                                                      end) g6pd 
                                                    from nb_first_screening ng 
                                                    where (ng.card_no between '{0}' and '{1}' or '{2}'=1)
                                                    group by 
                                                      ng.card_no) a) c, nb_disease_screening_card ncd 
                                                    where
                                                        c.card_no = ncd.card_no
                                                        and ncd.received_date between '{3}' and '{4}'
                                                        and (c.TSHRESULT='{5}' or c.PHERESULT='{5}' or c.G6PDRESULT='{5}' ) ";

        #endregion


        #region 筛查复检报告单
        public static string secondResultReport = @" select c.*,ncd.card_code,
                                                  ncd.ORGANIZATION_NAME,
                                                  ncd.ILLCASE_NO,
                                                  ncd.BED_NO,
                                                  ncd.MOTHER_NAME,
                                                  ncd.BIRTHDAY,
                                                  ncd.get_blood_date, 
                                                  ncd.health_code,
                                                  case when ncd.gender ='1' then '男'
                                                       when ncd.gender = '0' then '女'
                                                       else '不详'
                                                  end gender_info
                                                   from(
                                                    select 
                                                    a.card_no,
                                                    a.TSH,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     a.phe,
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     a.g6pd,
                                                     (SELECT 
                                                    case 
                                                     when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT,
                                                     GET_BLOOD_DATE,
                                                     RECEIVED_DATE,
                                                     SEND_DATE,
                                                     print,
                                                     print2
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.values_avg 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.values_avg 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.values_avg 
                                                        else 0 
                                                      end) g6pd,
                                                      max(ng.GET_BLOOD_DATE) GET_BLOOD_DATE,
                                                      max (ng.RECEIVED_DATE) RECEIVED_DATE,
                                                      max(ng.SEND_DATE) SEND_DATE,
                                                      max(case when (ng.print='0') then '×' 
                                                           when (ng.print='1') then '√'
                                                      end) print,
                                                      max(case when (ng.print2='0') then '×' 
                                                           when (ng.print2='1') then '√'
                                                      end) print2
                                                    from nb_second_screening ng 
                                                   where (ng.card_no between ? and ? or ?=1)
                                                    group by 
                                                      ng.card_no) a)c, nb_disease_screening_card ncd 
                                                    where
                                                        c.card_no = ncd.card_no";



        public static string secondResultInform = @" select c.*,ncd.card_code,
                                                  ncd.ORGANIZATION_NAME,
                                                  ncd.ILLCASE_NO,
                                                  ncd.BED_NO,
                                                  ncd.MOTHER_NAME,
                                                  ncd.BIRTHDAY,
                                                  ncd.get_blood_date, 
                                                  ncd.health_code,
                                                  case when ncd.gender ='1' then '男'
                                                       when ncd.gender = '0' then '女'
                                                       else '不详'
                                                  end gender_info
                                                   from(
                                                    select 
                                                    a.card_no,
                                                    a.TSH,
                                                     TSHRESULT,
                                                     a.phe,
                                                     PHERESULT,
                                                     a.g6pd,
                                                     G6PDRESULT,
                                                     GET_BLOOD_DATE,
                                                     RECEIVED_DATE,
                                                     SEND_DATE,
                                                     print,
                                                     print2
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.values_avg 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.values_avg 
                                                        else 0 
                                                      end) phe, 
                                                      max(case 
                                                        when item_type = 'G6PD' then ng.values_avg 
                                                        else 0 
                                                      end) g6pd,
                                                       MAX(case 
                                                        when ng.item_type = 'TSH' then ng.result 
                                                      end) TSHRESULT,
                                                      max(case 
                                                        when ng.item_type = 'PHE' then ng.result 
                                                      end) PHERESULT ,
                                                      max(case 
                                                        when ng.item_type = 'G6PD' then ng.result 
                                                      end) G6PDRESULT , 
                                                      max(ng.GET_BLOOD_DATE) GET_BLOOD_DATE,
                                                      max (ng.RECEIVED_DATE) RECEIVED_DATE,
                                                      max(ng.SEND_DATE) SEND_DATE,
                                                      max(case when (ng.print='0') then '×' 
                                                       when (ng.print='1') then '√'
                                                       end) print,
                                                      max(case when (ng.print2='0') then '×' 
                                                           when (ng.print2='1') then '√'
                                                      end) print2
                                                    from nb_second_screening ng 
                                                   where (ng.card_no between ? and ? or ?=1)
                                                    group by 
                                                      ng.card_no) a)c, nb_disease_screening_card ncd 
                                                    where
                                                        c.card_no = ncd.card_no
                                                        and (c.TSHRESULT=? or c.PHERESULT=? or c.G6PDRESULT=?)";
        #endregion



        #region 筛查对象完全统计
        public static string objectQueryResultSecond = @"select 
                                                            a.card_no,
                                                            (SELECT SSG.VALUES_AVG  FROM NB_SECOND_SCREENING SSG
                                                               WHERE SSG.CARD_NO=a.CARD_NO
                                                                AND SSG.ITEM_NAME='TSH1')TSH1,
                                                            ( SELECT SSG.VALUES_AVG  FROM NB_SECOND_SCREENING SSG
                                                                WHERE SSG.CARD_NO=a.CARD_NO
                                                                AND SSG.ITEM_NAME='PHE1')PHE1,
                                                            ( SELECT SSG.VALUES_AVG  FROM NB_SECOND_SCREENING SSG
                                                                WHERE SSG.CARD_NO=a.CARD_NO
                                                                AND SSG.ITEM_NAME='G6PD1')G6PD1,
                                                            a.TSH,
                                                            a.PHE,
                                                            a.G6PD,
                                                            (SELECT 
                                                            case 
                                                             when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                             when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                             when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                             else null
                                                            end
                                                             FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                             a.phe,
                                                             (SELECT 
                                                            case 
                                                             when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                             when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                             when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                             else null
                                                            end
                                                             FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                             a.g6pd,
                                                             (SELECT 
                                                            case 
                                                             when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                             when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                             when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                             else null
                                                            end
                                                             FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT,
                                                             GET_BLOOD_DATE,
                                                             GET_BLOOD_USER_NAME,
                                                             RECEIVED_DATE,
                                                             SEND_DATE,
                                                            case when QUALIFIED='0' then '不合格'
                                                                 when QUALIFIED='1' then '合格'
                                                            end QUALIFIED
                                                            from
                                                            (select 
                                                              ng.card_no , 
                                                              max(case 
                                                                when item_type = 'TSH' then ng.values_avg 
                                                                else 0 
                                                              end) tsh, 
                                                              max(case 
                                                                when item_type = 'PHE' then ng.values_avg 
                                                                else 0 
                                                              end) phe, 
                                                              max(case 
                                                                when item_type = 'G6PD' then ng.values_avg 
                                                                else 0 
                                                              end) g6pd,
                                                              max(ng.GET_BLOOD_DATE) GET_BLOOD_DATE,
                                                              max(ng.GET_BLOOD_USER_NAME) GET_BLOOD_USER_NAME,
                                                              max(ng.RECEIVED_DATE) RECEIVED_DATE,
                                                              max(ng.SEND_DATE) SEND_DATE,
                                                              max(ng.QUALIFIED) QUALIFIED
                                                            from nb_second_screening ng 
                                                            where (ng.card_no =?)
                                                            group by 
                                                              ng.card_no) a";

        public static string objectQueryResultFirst = @"SELECT N.*,M.* FROM(
                                                    Select 
                                                        ncd.CARD_NO,
                                                        case when ncd.QUALIFIED='0' then '不合格'
                                                        when ncd.QUALIFIED='1' then '合格'
                                                        end QUALIFIED,
                                                        (select fsg.ITEM_VALUE TSH1 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'TSH1'),
                                                        (select fsg.ITEM_VALUE PHE1 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'PHE1'),
                                                        (select fsg.ITEM_VALUE G6PD1 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'G6PD1'),
                                                        (select fsg.ITEM_VALUE TSH2 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'TSH2'),
                                                        (select fsg.ITEM_VALUE PHE2 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'PHE2'),
                                                        (select fsg.ITEM_VALUE G6PD2 from nb_first_screening fsg
                                                        where fsg.CARD_NO=ncd.CARD_NO
                                                        and fsg.ITEM_NAME = 'G6PD2')
                                                    From 
                                                    nb_disease_screening_card ncd) N,(
                                                    select c.*
                                                    from ( select 
                                                        a.card_no,
                                                        a.TSH,
                                                        (SELECT 
                                                        case 
                                                            when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                            when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                            when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                            else null
                                                        end
                                                            FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                            a.phe,
                                                            (SELECT 
                                                        case 
                                                            when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                            when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                            when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                            else null
                                                        end
                                                            FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                            a.g6pd,
                                                            (SELECT 
                                                        case 
                                                            when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                            when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                            when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                            else null
                                                        end
                                                            FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                        from
                                                        (select 
                                                            ng.card_no , 
                                                            max(case 
                                                            when item_type = 'TSH' then ng.ITEM_VALUE 
                                                            else 0 
                                                            end) tsh, 
                                                            max(case 
                                                            when item_type = 'PHE' then ng.ITEM_VALUE 
                                                            else 0 
                                                            end) phe, 
                                                            max(case 
                                                            when item_type = 'G6PD' then ng.ITEM_VALUE 
                                                            else 0 
                                                            end) g6pd 
                                                        from nb_first_screening ng 
                                                  
                                                        group by 
                                                            ng.card_no) a) c, nb_disease_screening_card ncd 
                                                        where
                                                            c.card_no = ncd.card_no)M
                                                            WHERE N.CARD_NO =M.CARD_NO
                                                            and n.card_no = ?";
        #endregion

        #region 初检统计
        #region Gender
        public static string firstStatisticsGender = @"select 
                                                        organization_name,
                                                        sum(genderl) genderl,
                                                        sum(gendern) gendern,
                                                        sum(genderh) genderh
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                           case 
                                                            when vcd.gender = '0' then 1 
                                                            else 0 
                                                          end genderl, 
                                                          case 
                                                            when vcd.gender = '1' then 1 
                                                            else 0 
                                                          end gendern, 
                                                          case 
                                                            when vcd.gender = '2' then 1 
                                                            else 0 
                                                          end genderh
                                                        from vw_nb_disease_card vcd
                                                      where vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}')a
                                                      group by organization_name";  
        #endregion
        #region Weight
        public static string firstStatisticsWeight = @"select 
                                                        organization_name,
                                                        sum(weightl) weightl,
                                                        sum(weightn) weightn,
                                                        sum(weighth) weighth
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          case 
                                                            when vcd.weight between 0.00 and 2.49 then 1 
                                                            else 0 
                                                          end weightl, 
                                                          case 
                                                            when vcd.weight between 2.50 and 3.99 then 1 
                                                            else 0 
                                                          end weightn, 
                                                          case 
                                                            when vcd.weight between 4.00 and 999.9 then 1 
                                                            else 0 
                                                          end weighth
                                                        from vw_nb_disease_card vcd
                                                      where vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}')a
                                                      group by organization_name"; 
        #endregion

        #region Weeks
        public static string firstStatisticsWeeks = @"select 
                                                        organization_name,
                                                        sum(weeksl) weeksl,
                                                        sum(weeksn) weeksn,
                                                        sum(weeksh) weeksh
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                           case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 0.00 and 36.99 then 1 
                                                            else 0 
                                                          end weeksl, 
                                                          case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 37.00 and 41.99 then 1 
                                                            else 0 
                                                          end weeksn, 
                                                          case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 42.00 and 999.99 then 1 
                                                            else 0 
                                                          end weeksh
                                                        from vw_nb_disease_card vcd
                                                      where vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}')a
                                                      group by organization_name";
        #endregion

        #region Yield
        public static string firstStatisticsYield = @"select 
                                                        organization_name,
                                                         sum(yield1) yield1,
                                                        sum(yield2) yield2,
                                                        sum(yield3) yield3,
                                                        sum(yield4) yield4,
                                                        sum(yield5) yield5,
                                                        sum(yield6) yield6
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                           case 
                                                            when vcd.yield_mode = '0' then 1 
                                                            else 0 
                                                          end yield1, 
                                                          case 
                                                            when vcd.yield_mode = '1' then 1 
                                                            else 0 
                                                          end yield2, 
                                                          case 
                                                            when vcd.yield_mode = '2' then 1 
                                                            else 0 
                                                          end yield3, 
                                                          case 
                                                            when vcd.yield_mode = '3' then 1 
                                                            else 0 
                                                          end yield4, 
                                                          case 
                                                            when vcd.yield_mode = '4' then 1 
                                                            else 0 
                                                          end yield5, 
                                                          case 
                                                            when vcd.yield_mode = '5' then 1 
                                                            else 0 
                                                          end yield6
                                                        from vw_nb_disease_card vcd
                                                      where vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}')a
                                                      group by organization_name";
        #endregion

        #region Anamnesis
        public static string firstStatisticsAnamnesis = @"select 
                                                        organization_name,
                                                         sum(anamnesis1) anamnesis1,
                                                        sum(anamnesis2) anamnesis2,
                                                        sum(anamnesis3) anamnesis3,
                                                        sum(anamnesis4) anamnesis4,
                                                        sum(anamnesis5) anamnesis5
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          case 
                                                            when vcd.anamnesis = '0' then 1 
                                                            else 0 
                                                          end anamnesis1, 
                                                          case 
                                                            when vcd.anamnesis = '1' then 1 
                                                            else 0 
                                                          end anamnesis2, 
                                                          case 
                                                            when vcd.anamnesis = '2' then 1 
                                                            else 0 
                                                          end anamnesis3, 
                                                          case 
                                                            when vcd.anamnesis = '3' then 1 
                                                            else 0 
                                                          end anamnesis4, 
                                                          case 
                                                            when vcd.anamnesis = '4' then 1 
                                                            else 0 
                                                          end anamnesis5 
                                                        from vw_nb_disease_card vcd
                                                      where vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}')a
                                                      group by organization_name";
        #endregion

        #region TSH
        public static string firstStatisticsTsh = @"select 
                                                        d.organization_name,
                                                        sum(tshying) tsh1,
                                                        sum(tshryang) tsh2,
                                                        sum(tshyang) tsh3
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          c.tshying,
                                                           c.tshryang,
                                                             c.tshyang
                                                        from vw_nb_disease_card vcd,
                                                        (select b.card_no,
                                                        case when b.tshresult='阴性' then 1
                                                        else 0
                                                        end tshying,
                                                         case when b.tshresult='弱阳性' then 1
                                                        else 0
                                                        end tshryang,
                                                         case when b.tshresult='阳性' then 1
                                                        else 0
                                                        end tshyang,
                                                        case when b.pheresult='阴性' then 1
                                                        else 0
                                                        end pheying,
                                                         case when b.pheresult='弱阳性' then 1
                                                        else 0
                                                        end pheryang,
                                                         case when b.pheresult='阳性' then 1
                                                        else 0
                                                        end pheyang,
                                                        case when b.g6pdresult='阴性' then 1
                                                        else 0
                                                        end g6pdying,
                                                         case when b.g6pdresult='弱阳性' then 1
                                                        else 0
                                                        end g6pdryang,
                                                         case when b.g6pdresult='阳性' then 1
                                                        else 0
                                                        end g6pdyang
                                                         from (
                                                        select 
                                                        a.card_no,
                                                        a.TSH,
                                                        (SELECT 
                                                        case 
                                                         when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                         a.phe,
                                                         (SELECT 
                                                        case 
                                                         when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                         a.g6pd,
                                                         (SELECT 
                                                        case 
                                                         when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                        from
                                                        (select 
                                                          ng.card_no , 
                                                          max(case 
                                                            when item_type = 'TSH' then ng.item_value
                                                            else 0 
                                                          end) tsh, 
                                                          max(case 
                                                            when item_type = 'PHE' then ng.item_value
                                                            else 0 
                                                          end) phe, 
                                                          max(case 
                                                            when item_type = 'G6PD' then ng.item_value
                                                            else 0 
                                                          end) g6pd
                                                        from nb_first_screening ng
                                                        group by 
                                                          ng.card_no) a)b)c
                                                      where c.card_no=vcd.card_no
                                                          and vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}'
                                                    order by 
                                                      vcd.card_no) d
                                                      group by d.organization_name"; 
        #endregion
        #region PHE
        public static string firstStatisticsPhe = @"select 
                                                        d.organization_name,
                                                        sum(pheying) phe1,
                                                        sum(pheryang) phe2,
                                                        sum(pheyang) phe3
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          c.pheying,
                                                           c.pheryang,
                                                             c.pheyang
                                                        from vw_nb_disease_card vcd,
                                                        (select b.card_no,
                                                        case when b.tshresult='阴性' then 1
                                                        else 0
                                                        end tshying,
                                                         case when b.tshresult='弱阳性' then 1
                                                        else 0
                                                        end tshryang,
                                                         case when b.tshresult='阳性' then 1
                                                        else 0
                                                        end tshyang,
                                                        case when b.pheresult='阴性' then 1
                                                        else 0
                                                        end pheying,
                                                         case when b.pheresult='弱阳性' then 1
                                                        else 0
                                                        end pheryang,
                                                         case when b.pheresult='阳性' then 1
                                                        else 0
                                                        end pheyang,
                                                        case when b.g6pdresult='阴性' then 1
                                                        else 0
                                                        end g6pdying,
                                                         case when b.g6pdresult='弱阳性' then 1
                                                        else 0
                                                        end g6pdryang,
                                                         case when b.g6pdresult='阳性' then 1
                                                        else 0
                                                        end g6pdyang
                                                         from (
                                                        select 
                                                        a.card_no,
                                                        a.TSH,
                                                        (SELECT 
                                                        case 
                                                         when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                         a.phe,
                                                         (SELECT 
                                                        case 
                                                         when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                         a.g6pd,
                                                         (SELECT 
                                                        case 
                                                         when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                        from
                                                        (select 
                                                          ng.card_no , 
                                                          max(case 
                                                            when item_type = 'TSH' then ng.item_value
                                                            else 0 
                                                          end) tsh, 
                                                          max(case 
                                                            when item_type = 'PHE' then ng.item_value
                                                            else 0 
                                                          end) phe, 
                                                          max(case 
                                                            when item_type = 'G6PD' then ng.item_value
                                                            else 0 
                                                          end) g6pd
                                                        from nb_first_screening ng
                                                        group by 
                                                          ng.card_no) a)b)c
                                                      where c.card_no=vcd.card_no
                                                          and vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}'
                                                    order by 
                                                      vcd.card_no) d
                                                      group by d.organization_name";
        #endregion

        #region G6PD
        public static string firstStatisticsG6pd = @"select 
                                                        d.organization_name,
                                                        sum(g6pdying) g6pd1,
                                                        sum(g6pdryang) g6pd2,
                                                        sum(g6pdyang) g6pd3
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          c.g6pdying,
                                                           c.g6pdryang,
                                                             c.g6pdyang
                                                        from vw_nb_disease_card vcd,
                                                        (select b.card_no,
                                                        case when b.tshresult='阴性' then 1
                                                        else 0
                                                        end tshying,
                                                         case when b.tshresult='弱阳性' then 1
                                                        else 0
                                                        end tshryang,
                                                         case when b.tshresult='阳性' then 1
                                                        else 0
                                                        end tshyang,
                                                        case when b.pheresult='阴性' then 1
                                                        else 0
                                                        end pheying,
                                                         case when b.pheresult='弱阳性' then 1
                                                        else 0
                                                        end pheryang,
                                                         case when b.pheresult='阳性' then 1
                                                        else 0
                                                        end pheyang,
                                                        case when b.g6pdresult='阴性' then 1
                                                        else 0
                                                        end g6pdying,
                                                         case when b.g6pdresult='弱阳性' then 1
                                                        else 0
                                                        end g6pdryang,
                                                         case when b.g6pdresult='阳性' then 1
                                                        else 0
                                                        end g6pdyang
                                                         from (
                                                        select 
                                                        a.card_no,
                                                        a.TSH,
                                                        (SELECT 
                                                        case 
                                                         when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                         a.phe,
                                                         (SELECT 
                                                        case 
                                                         when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                         a.g6pd,
                                                         (SELECT 
                                                        case 
                                                         when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                        from
                                                        (select 
                                                          ng.card_no , 
                                                          max(case 
                                                            when item_type = 'TSH' then ng.item_value
                                                            else 0 
                                                          end) tsh, 
                                                          max(case 
                                                            when item_type = 'PHE' then ng.item_value
                                                            else 0 
                                                          end) phe, 
                                                          max(case 
                                                            when item_type = 'G6PD' then ng.item_value
                                                            else 0 
                                                          end) g6pd
                                                        from nb_first_screening ng
                                                        group by 
                                                          ng.card_no) a)b)c
                                                      where c.card_no=vcd.card_no
                                                          and vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}'
                                                    order by 
                                                      vcd.card_no) d
                                                      group by d.organization_name";
        #endregion

        public static string firstStatisticsResult = @"select 
                                                        d.organization_name,
                                                        sum(d.genderl) genderl,
                                                        sum(gendern) gendern,
                                                        sum(genderh) genderh,
                                                        sum(weightl) weightl,
                                                        sum(weightn) weightn,
                                                        sum(weighth) weighth,
                                                        sum(weeksl) weeksl,
                                                        sum(weeksn) weeksn,
                                                        sum(weeksh) weeksh,
                                                        sum(yield1) yield1,
                                                        sum(yield2) yield2,
                                                        sum(yield3) yield3,
                                                        sum(yield4) yield4,
                                                        sum(yield5) yield5,
                                                        sum(yield6) yield6,
                                                        sum(anamnesis1) anamnesis1,
                                                        sum(anamnesis2) anamnesis2,
                                                        sum(anamnesis3) anamnesis3,
                                                        sum(anamnesis4) anamnesis4,
                                                        sum(anamnesis5) anamnesis5,
                                                        sum(tshying) tsh1,
                                                        sum(tshryang) tsh2,
                                                        sum(tshyang) tsh3,
                                                        sum(pheying) phe1,
                                                        sum(pheryang) phe2,
                                                        sum(pheyang) phe3,
                                                        sum(g6pdying) g6pd1,
                                                        sum(g6pdryang) g6pd2,
                                                        sum(g6pdyang) g6pd3
                                                         from 
                                                        (
                                                        select 
                                                          vcd.organization_name, 
                                                          vcd.card_no , 
                                                          case 
                                                            when vcd.gender = '0' then 1 
                                                            else 0 
                                                          end genderl, 
                                                          case 
                                                            when vcd.gender = '1' then 1 
                                                            else 0 
                                                          end gendern, 
                                                          case 
                                                            when vcd.gender = '2' then 1 
                                                            else 0 
                                                          end genderh, 
                                                          case 
                                                            when vcd.weight between 0.00 and 2.49 then 1 
                                                            else 0 
                                                          end weightl, 
                                                          case 
                                                            when vcd.weight between 2.50 and 3.99 then 1 
                                                            else 0 
                                                          end weightn, 
                                                          case 
                                                            when vcd.weight between 4.00 and 999.9 then 1 
                                                            else 0 
                                                          end weighth, 
                                                          case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 0.00 and 36.99 then 1 
                                                            else 0 
                                                          end weeksl, 
                                                          case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 37.00 and 41.99 then 1 
                                                            else 0 
                                                          end weeksn, 
                                                          case 
                                                            when (cast(vcd.gestational_weeks as float)+cast(vcd.gestational_days as float)/7) between 42.00 and 999.99 then 1 
                                                            else 0 
                                                          end weeksh, 
                                                          case 
                                                            when vcd.yield_mode = '0' then 1 
                                                            else 0 
                                                          end yield1, 
                                                          case 
                                                            when vcd.yield_mode = '1' then 1 
                                                            else 0 
                                                          end yield2, 
                                                          case 
                                                            when vcd.yield_mode = '2' then 1 
                                                            else 0 
                                                          end yield3, 
                                                          case 
                                                            when vcd.yield_mode = '3' then 1 
                                                            else 0 
                                                          end yield4, 
                                                          case 
                                                            when vcd.yield_mode = '4' then 1 
                                                            else 0 
                                                          end yield5, 
                                                          case 
                                                            when vcd.yield_mode = '5' then 1 
                                                            else 0 
                                                          end yield6, 
                                                          case 
                                                            when vcd.anamnesis = '0' then 1 
                                                            else 0 
                                                          end anamnesis1, 
                                                          case 
                                                            when vcd.anamnesis = '1' then 1 
                                                            else 0 
                                                          end anamnesis2, 
                                                          case 
                                                            when vcd.anamnesis = '2' then 1 
                                                            else 0 
                                                          end anamnesis3, 
                                                          case 
                                                            when vcd.anamnesis = '3' then 1 
                                                            else 0 
                                                          end anamnesis4, 
                                                          case 
                                                            when vcd.anamnesis = '4' then 1 
                                                            else 0 
                                                          end anamnesis5 ,
                                                          c.tshying,
                                                           c.tshryang,
                                                             c.tshyang,
                                                              c.pheying,
                                                           c.pheryang,
                                                             c.pheyang,
                                                              c.g6pdying,
                                                           c.g6pdryang,
                                                             c.g6pdyang
                                                        from vw_nb_disease_card vcd,
                                                        (select b.card_no,
                                                        case when b.tshresult='阴性' then 1
                                                        else 0
                                                        end tshying,
                                                         case when b.tshresult='弱阳性' then 1
                                                        else 0
                                                        end tshryang,
                                                         case when b.tshresult='阳性' then 1
                                                        else 0
                                                        end tshyang,
                                                        case when b.pheresult='阴性' then 1
                                                        else 0
                                                        end pheying,
                                                         case when b.pheresult='弱阳性' then 1
                                                        else 0
                                                        end pheryang,
                                                         case when b.pheresult='阳性' then 1
                                                        else 0
                                                        end pheyang,
                                                        case when b.g6pdresult='阴性' then 1
                                                        else 0
                                                        end g6pdying,
                                                         case when b.g6pdresult='弱阳性' then 1
                                                        else 0
                                                        end g6pdryang,
                                                         case when b.g6pdresult='阳性' then 1
                                                        else 0
                                                        end g6pdyang
                                                         from (
                                                        select 
                                                        a.card_no,
                                                        a.TSH,
                                                        (SELECT 
                                                        case 
                                                         when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                         a.phe,
                                                         (SELECT 
                                                        case 
                                                         when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                         a.g6pd,
                                                         (SELECT 
                                                        case 
                                                         when (g6pd between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                         when (g6pd between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                         when (g6pd between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                         else null
                                                        end
                                                         FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='G6PD')G6PDRESULT
                                                        from
                                                        (select 
                                                          ng.card_no , 
                                                          max(case 
                                                            when item_type = 'TSH' then ng.item_value
                                                            else 0 
                                                          end) tsh, 
                                                          max(case 
                                                            when item_type = 'PHE' then ng.item_value
                                                            else 0 
                                                          end) phe, 
                                                          max(case 
                                                            when item_type = 'G6PD' then ng.item_value
                                                            else 0 
                                                          end) g6pd
                                                        from nb_first_screening ng
                                                        group by 
                                                          ng.card_no) a)b)c
                                                      where c.card_no=vcd.card_no
                                                          and vcd.received_date between '{0}' and '{1}'
                                                          and vcd.BIRTHDAY between '{2}' and '{3}'
                                                    order by 
                                                      vcd.card_no) d
                                                      group by d.organization_name";
        #endregion

        #region 复检统计
        public static string secondStatisticsResult = @"select 
                                                          nscd.ORGANIZATION_NAME,
                                                          
                                                          sum((select
                                                          case
                                                           when ( ssg.VALUES_AVG between  nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then 1
                                                           else 0
                                                           end  from  NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='{0}')) yang,
                                                          sum((select case
                                                           when ( ssg.VALUES_AVG between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then 1
                                                           else 0
                                                           end  from  NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='{1}'))ruoyang,
                                                           sum(0) fujian,
                                                         sum(case when ssg.RESULT ='排除' then 1
                                                         else 0
                                                         end ) paichu,
                                                           sum(case when ssg.RESULT ='待排' then 1
                                                         else 0
                                                         end ) daipai,
                                                         sum(case when ssg.RESULT ='确诊' then 1
                                                         else 0
                                                         end ) quezheng,
                                                         sum(case when ssg.RESULT ='终结' then 1
                                                         else 0
                                                         end )zhongjie
                                                        from nb_second_screening ssg, nb_disease_screening_card nscd 
                                                        where
                                                          ssg.card_no = nscd.card_no
                                                          and ssg.ITEM_TYPE= '{2}'
                                                          and nscd.BIRTHDAY between '{3}' and '{4}'
                                                          and nscd.GENDER in({5})
                                                          and nscd.RECEIVED_DATE between '{6}' and '{7}'
                                                        group by   nscd.ORGANIZATION_NAME;";
        #endregion


        #region 工作量统计表
        public static string workLoad = @"  select 
                                                   c.organization_name f01,
                                                   counts f02,
                                                   c.counts-c.resultT-c.resultP f03,
                                                   c.resultT+c.resultP f04,
                                                   (c.counts-c.resultT-c.resultP)/IIF(counts > 0, counts,1)*100  f05,
                                                   tshL f06,
                                                   pheL f07,
                                                   tshH f08,
                                                   pheH f09,
                                                   resultT f10,
                                                   resultP f11
                                                   from(
                                                   select 
                                                   b.organization_name,
                                                   count(*) counts,
                                                   sum(case when b.tshresult ='弱阳性' then 1.00
                                                   else 0
                                                   end) tshL,
                                                   sum(case when b.pheresult ='弱阳性' then 1.00
                                                    else 0
                                                   end) pheL,
                                                  sum( case when b.tshresult ='阳性' then 1.00
                                                   else 0
                                                   end) tshH,
                                                   sum(case when b.pheresult ='阳性' then 1.00
                                                    else 0
                                                   end) pheH,
                                                   sum(case when b.tresult ='确诊' then 1.00
                                                    else 0
                                                   end) resultT,
                                                   sum(case when b.presult ='确诊' then 1.00
                                                    else 0
                                                   end) resultP
                                                    from
                                                    (select 
                                                    ncd.organization_name,
                                                    (SELECT 
                                                    case 
                                                     when (tsh between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (tsh between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (tsh between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='TSH') TSHRESULT,
                                                     tresult,
                                                    
                                                     (SELECT 
                                                    case 
                                                     when (phe between nvs.NORMAL_LOW_VALUE and nvs.NORMAL_HIGH_VALUE) then '阴性'
                                                     when (phe between nvs.WEAK_POSITIVE_LOW_VALUE and nvs.WEAK_POSITIVE_HIGH_VALUE) then '弱阳性'
                                                     when (phe between nvs.POSITIVE_LOW_VALUE and nvs.POSITIVE_HIGH_VALUE) then '阳性'
                                                     else null
                                                    end
                                                     FROM NB_STANDARD_VALUES nvs where nvs.ITEM_NAME='PHE') PHERESULT,
                                                     presult,
                                                     a.RECEIVED_DATE
                                                    from
                                                    (select 
                                                      ng.card_no , 
                                                      max(case 
                                                        when item_type = 'TSH' then ng.values_avg 
                                                        else 0 
                                                      end) tsh, 
                                                      max(case 
                                                        when item_type = 'PHE' then ng.values_avg 
                                                        else 0 
                                                      end) phe, 
                                                       MAX(case 
                                                       when ng.item_type = 'TSH' then ng.result 
                                                       end) tresult,
                                                       max(case 
                                                       when ng.item_type = 'PHE' then ng.result 
                                                       end) presult ,
                                                      max (ng.RECEIVED_DATE) RECEIVED_DATE
                                                    from nb_second_screening ng 
                                                    group by ng.CARD_NO )a, NB_DISEASE_SCREENING_CARD ncd
                                                    where ncd.CARD_NO=a.card_no) b
                                                    where b.received_date between '{0}' and '{1}'
                                                    group by b.organization_name)c
                                                    ";
        #endregion

        #region 初检回报
        public static string firstRetrun = @" select
                                              c.card_no f01, 
                                              ncd.card_code f02, 
                                              ncd.illcase_no f03, 
                                              ncd.bed_no f04, 
                                              ncd.mother_name f05, 
                                              ncd.anamnesis_info f06,
                                              ncd.gestational_weeks f07,
                                              ncd.gender_info f08,
                                              ncd.weight f09, 
                                              ncd.birthday f10, 
                                              ncd.get_blood_date f12, 
                                              ncd.get_blood_user_name f13, 
                                              ncd.QUALIFIED_INFO f14,
                                              ncd.REASON_INFO f15,
                                              tsh f16, 
                                              phe f17, 
                                              g6pd f18
                                            from ( select 
                                              a.card_no, 
                                              a.tsh, 
                                              a.phe, 
                                              a.g6pd 
                                            from (select 
                                              ng.card_no , 
                                              max(case 
                                                when item_type = 'TSH' then ng.item_value 
                                                else 0 
                                              end) tsh, 
                                              max(case 
                                                when item_type = 'PHE' then ng.item_value 
                                                else 0 
                                              end) phe, 
                                              max(case 
                                                when item_type = 'G6PD' then ng.item_value 
                                                else 0 
                                              end) g6pd 
                                            from nb_first_screening ng 
                                            group by 
                                              ng.card_no) a) c, vw_nb_disease_card ncd 
                                            where
                                              c.card_no = ncd.card_no 
                                              and ncd.received_date between '{0}' and '{1}'
                                            ";
        #endregion
    }
}
