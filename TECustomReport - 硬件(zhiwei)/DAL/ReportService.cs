using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using DBUtility;
using Models;

namespace DAL
{
   public class ReportService
    {

        #region 1- 第一个报表数据访问类

        /// <summary>
        /// 第一个报表数据访问类
        /// </summary>
        /// <param name="projectId">基础项目编号</param>
        /// <returns></returns>
        public static SqlDataReader GetReport1(string projectId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 2 Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName,DateCreated from Bug");
            sql.Append(" join Project on(Bug.ProjectID=Project.ProjectID)");
            sql.Append(" join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)");
            sql.Append(" where Bug.ProjectID=@ProjectID");

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",projectId)
            };
            SqlDataReader reportReader = null;
            try
            {
               reportReader= SQLHelper.GetResultByReader(sql.ToString(), param);
                return reportReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport1的时候出现sql异常:"+ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        #endregion

        #region 2- 第二个报表数据访问类
        /// <summary>
        /// 获取第二个报表点击下拉框所需要的数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetReport2_Project()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ProjectID,ProjectName from Project where ProjectID>0 AND ProjectTypeID in(1,41) AND IsActiveProject=1 and projectid>180");
            SqlDataReader reportReader = null;
            try
            {
                reportReader = SQLHelper.GetResultByReader(sql.ToString());
                return reportReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_Project的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  static SqlDataReader  GetReport2_ReportData(string multiSelectProjectChoice)
        {
            string sql = @"select  Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName from Bug
                        join Project on(Bug.ProjectID=Project.ProjectID)
                        join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)
                        where Bug.ProjectID in (";
            sql += multiSelectProjectChoice;
            sql += ")";

            SqlDataReader objReader = null;

            try
            {
                objReader = SQLHelper.GetResultByReader(sql.ToString());
                return objReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_ReportData的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 3-第三个报表数据访问类
        public SqlDataReader GetReport3_Project()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ProjectID,ProjectName from Project where ProjectID>0 AND ProjectTypeID=1 AND IsActiveProject=1 and projectid>180");
            SqlDataReader reportReader = null;
            try
            {
                reportReader = SQLHelper.GetResultByReader(sql.ToString());
                return reportReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_Project的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static SqlDataReader GetReport3_ReportData(string SingleSelectProjectChoice)
        {
            string sql = @"select Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName from Bug
                        join Project on(Bug.ProjectID=Project.ProjectID)
                        join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)
                        where Bug.ProjectID =";
            sql += SingleSelectProjectChoice;
           

            SqlDataReader objReader = null;

            try
            {
                objReader = SQLHelper.GetResultByReader(sql.ToString());
                return objReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_ReportData的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 4-第四个报表数据访问类
        /// <summary>
        /// 获取第四个报表所需的数据
        /// </summary>
        /// <param name="ProjectID">项目编号</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>返回报表数据所需的sqldatareader集合</returns>
        public static SqlDataReader GetReport4_Data(string ProjectID,DateTime startDate, DateTime endDate)
        {
            string sql = @"select  Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName from Bug
                        join Project on(Bug.ProjectID=Project.ProjectID)
                        join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)
                        where Bug.ProjectID=@ProjectID AND DATEDIFF(DD,@StartDate,Bug.DateCreated)>=0 AND DATEDIFF(DD,@EndDate,Bug.DateCreated)<=0";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProjectID",ProjectID),
                new SqlParameter("@StartDate",startDate),
                new SqlParameter("@EndDate",endDate)
            };

            SqlDataReader reportData = null;
            try
            {
                reportData = SQLHelper.GetResultByReader(sql,param);
                return reportData;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport4_Data的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 5，6-第五，六个报表数据访问类

        public SqlDataReader GetReport5_Project()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ProjectID,ProjectName from Project where ProjectID>0 AND ProjectTypeID=1 AND IsActiveProject=1 and projectid>180");
            SqlDataReader reportReader = null;
            try
            {
                reportReader = SQLHelper.GetResultByReader(sql.ToString());
                return reportReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_Project的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取第五个报表所需数据的datareader集合
        /// </summary>
        /// <param name="multiSelectProjectChoice">选中的ProjectId</param>
        /// <param name="startDate">开始</param>
        /// <param name="endDate">结束</param>
        /// <returns></returns>
        public static SqlDataReader GetReport5_Data(string multiSelectProjectChoice, DateTime startDate, DateTime endDate)
        {

            string sql = @"select Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName from Bug
                        join Project on(Bug.ProjectID=Project.ProjectID)
                        join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)
                        where Bug.ProjectID in (";
            sql += multiSelectProjectChoice;
            sql += ")";
            sql += " AND DATEDIFF(DD,@StartDate,Bug.DateCreated)>=0 AND DATEDIFF(DD,@EndDate,Bug.DateCreated)<=0";
            SqlParameter[] param = new SqlParameter[]
           {
               
                new SqlParameter("@StartDate",startDate),
                new SqlParameter("@EndDate",endDate)
           };

            SqlDataReader objReader = null;

            try
            {
                objReader = SQLHelper.GetResultByReader(sql, param);
                return objReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport5_Data的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 7-第七个报表数据访问类
        /// <summary>
        /// 获取报表7所需的数据
        /// </summary>
        /// <param name="param">参数实体</param>
        /// <returns></returns>
        public static SqlDataReader GetReport7_Data(Report7_Params param)
        {

            string sortStr = "";
            if (param.OrderBy == "0")
                sortStr = "ORDER BY Bug.ProjectID,Bug.BugID ASC";
            else
                sortStr = "ORDER BY Bug.ProjectID,Bug.BugID DESC";

          
            string sqlStr = string.Format(@"
                        select  Bug.ProjectID,Project.ProjectName,Bug.BugID,Bug.BugTitle,ProgressStatusTypes.ProgressStatusName from Bug
                        join Project on(Bug.ProjectID=Project.ProjectID)
                        join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)
                        where DATEDIFF(DD,@startDate,Bug.DateCreated)>=0 AND DATEDIFF(DD,@endDate,Bug.DateCreated)<=0 AND Bug.ProjectID IN(");
            sqlStr += param.selectProjectStr;
            sqlStr += ") " + sortStr;

            SqlParameter[] pms = new SqlParameter[]
            {
               new SqlParameter("@startDate",param.StartDate),
               new SqlParameter("@endDate",param.EndDate)
            };

            SqlDataReader reportData = null;
            try
            {
                reportData = SQLHelper.GetResultByReader(sqlStr, pms);
                return reportData;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport7_Data的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region 8- 第8个报表数据访问类（柱状图报表）
        /// <summary>
        /// 获取报表8需要的数据
        /// </summary>
        /// <returns>返回sqldatareader</returns>
        public SqlDataReader GetReport8()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Bug.CrntBugTypeID,IssueTypes.TypeName,COUNT(*) BugNo FROM Bug");
            sql.Append("  JOIN IssueTypes ON(Bug.ProjectID=IssueTypes.ProjectID AND Bug.CrntBugTypeID=IssueTypes.TypeID)");
            sql.Append("  WHERE Bug.ProjectID=502 GROUP BY Bug.CrntBugTypeID,IssueTypes.TypeName  order by BugNo desc");

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql.ToString());
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport8()的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region 9- 第9个报表数据访问类
        public SqlDataReader GetReport9()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Bug.CrntBugTypeID,IssueTypes.TypeName,COUNT(*) BugNo FROM Bug");
            sql.Append(" JOIN IssueTypes ON(Bug.ProjectID=IssueTypes.ProjectID AND Bug.CrntBugTypeID=IssueTypes.TypeID)");
            sql.Append(" WHERE Bug.ProjectID=502 GROUP BY Bug.CrntBugTypeID,IssueTypes.TypeName");

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql.ToString());
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport9()的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region 10 -第10个报表数据访问类
        public SqlDataReader GetReport10()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CONVERT(NVARCHAR(10),DateCreated,23) AS DateCreated,COUNT(*) AS BugCounts FROM Bug");
            sql.Append(" WHERE ProjectID=502 AND DATEDIFF(DD,'2018-11-01',DateCreated)>=0 AND DATEDIFF(DD,'2018-12-30',DateCreated)<=0");
            sql.Append(" GROUP BY CONVERT(NVARCHAR(10),DateCreated,23)");
            sql.Append(" ORDER BY CONVERT(NVARCHAR(10),DateCreated,23)");

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql.ToString());
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport10()的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region 11- 第11个报表数据访问类
        public SqlDataReader GetReport11()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Bug.CrntBugTypeID,IssueTypes.TypeName,COUNT(*) BugNo FROM Bug");
            sql.Append("  JOIN IssueTypes ON(Bug.ProjectID=IssueTypes.ProjectID AND Bug.CrntBugTypeID=IssueTypes.TypeID)");
            sql.Append("  WHERE Bug.ProjectID=502 ");
            sql.Append("  GROUP BY Bug.CrntBugTypeID,IssueTypes.TypeName");

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql.ToString());
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport11()的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 12- 第12个报表数据访问类
        public static SqlDataReader GetReport12(string multiSelectFieldChoice)
        {
            string sql = @"select Project.ProjectName,ProgressStatusTypes.ProgressStatusName,COUNT(*) AS BugNo from Bug";
            sql += " join Project on(Bug.ProjectID=Project.ProjectID)";
            sql += " join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)";
            sql += " where Bug.ProjectID in (";
                sql += @multiSelectFieldChoice;
            sql+=")  GROUP BY Project.ProjectName,ProgressStatusTypes.ProgressStatusName";
            sql += " ORDER BY Project.ProjectName";
         

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@multiSelectFieldChoice",multiSelectFieldChoice)
            };

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql,param);
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法public SqlDataReader GetReport12(string multiSelectFieldChoice)的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        #region 13-第13个报表数据访问类

        public static SqlDataReader GetReport13(string multiSelectFieldChoice)
        {
            //组合sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append("select Project.ProjectName,ProgressStatusTypes.ProgressStatusName,COUNT(*) AS BugNo,");
            sql.Append(" case when COUNT(*) - 3 < 0 then 0 else COUNT(*) - 3 end as SecondNo from Bug");
            sql.Append("  join Project on(Bug.ProjectID=Project.ProjectID)");
            sql.Append(" join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)");
            sql.Append("where Bug.ProjectID in (");
            sql.Append(@multiSelectFieldChoice);
            sql.Append(") GROUP BY Project.ProjectName, ProgressStatusTypes.ProgressStatusName");
            sql.Append(" ORDER BY Project.ProjectName");

            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@multiSelectFieldChoice",multiSelectFieldChoice)
            };

            //执行获取

            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (SqlException ex)
            {

                throw new Exception("执行SQLHelper.GetResultByReader出现数据库异常"+ex.Message); ;
            }
            catch(Exception ex){

                throw ex;
            }

        }

        #endregion

        #region 14-第14个报表数据访问类
        public static SqlDataReader GetReport14(string selectedProjectStr)
        {

            //组合sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append("select Project.ProjectName,ProgressStatusTypes.ProgressStatusName,COUNT(*) AS BugNo,");
            sql.Append(" case when COUNT(*) - 3 < 0 then 0 else COUNT(*) - 3 end as SecondNo from Bug");
            sql.Append("  join Project on(Bug.ProjectID=Project.ProjectID)");
            sql.Append(" join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)");
            sql.Append("where Bug.ProjectID in (");
            sql.Append(@selectedProjectStr);
            sql.Append(") GROUP BY Project.ProjectName, ProgressStatusTypes.ProgressStatusName");
            sql.Append(" ORDER BY Project.ProjectName");

            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectedProjectStr",selectedProjectStr)
            };

            //执行获取

            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(), param);
                return objReader;
            }
            catch (SqlException ex)
            {

                throw new Exception("执行SQLHelper.GetResultByReader出现数据库异常" + ex.Message); ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 15 -第15个报表数据访问类
        public static  SqlDataReader GetReport15(string selectProjectStr)
        {
            //组合sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT BugTypes.BugTypeName,COUNT(*) BugNo FROM Bug JOIN BugTypes ON(Bug.ProjectID=BugTypes.ProjectID AND Bug.CrntBugTypeID=BugTypes.BugTypeID)");
            sql.Append(" WHERE Bug.ProjectID in (");
            sql.Append(@selectProjectStr);
            sql.Append(") GROUP BY BugTypes.BugTypeName");
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };
            //执行通用数据访问类方法
            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 16-第16个报表数据访问类
       /// <summary>
       /// 获取报表16的sqldatareader数据
       /// </summary>
       /// <param name="selectProjectStr">指定的项目</param>
       /// <returns></returns>
        public static SqlDataReader GetReport16(string selectProjectStr)
        {
            //组合sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT BugTypes.BugTypeName,COUNT(*) BugNo, case when COUNT(*) - 3 < 0 then 0 else COUNT(*) - 3 end as SecondNo  FROM Bug");
            sql.Append("  JOIN BugTypes ON(Bug.ProjectID=BugTypes.ProjectID AND Bug.CrntBugTypeID=BugTypes.BugTypeID)");
            sql.Append(" WHERE Bug.ProjectID in (");
            sql.Append(@selectProjectStr);
            sql.Append(") GROUP BY BugTypes.BugTypeName");
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };
            //执行
            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw new Exception("执行报表16查询sqldatareader方法出错public static SqlDataReader GetReport16"+ex.Message) ;
            }
        }
        #endregion

        #region 17-第17个报表数据访问类
        /// <summary>
        /// 获取报表17所需的sqldatareader数据
        /// </summary>
        /// <param name="selectProjectStr">指定的项目</param>
        /// <returns></returns>
        public static SqlDataReader GetReport17(string selectProjectStr)
        {
            //组合sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT BugTypes.BugTypeName,COUNT(*) BugNo, case when COUNT(*) - 3 < 0 then 0 else COUNT(*) - 3 end as SecondNo FROM Bug ");
            sql.Append("   JOIN BugTypes ON(Bug.ProjectID=BugTypes.ProjectID AND Bug.CrntBugTypeID=BugTypes.BugTypeID)");
            sql.Append(" WHERE Bug.ProjectID in (");
            sql.Append(@selectProjectStr);
            sql.Append(") GROUP BY BugTypes.BugTypeName");
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };
            //执行
            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw new Exception("执行获取报表17的sqldatareader 方法 public static SqlDataReader GetReport17出错"+ex.Message);
            }
        }
        #endregion

        #region 18-第18个报表数据访问类
        public static SqlDataReader GetReport18(string selectProjectStr)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CONVERT(NVARCHAR(10),DateCreated,23) AS DateCreated,COUNT(*) AS BugCounts FROM Bug");
            sql.Append(" WHERE DATEDIFF(DD,'2018-12-01',DateCreated)>=0 AND DATEDIFF(DD,'2019-03-30',DateCreated)<=0");
            sql.Append("AND ProjectID IN (");
            sql.Append(@selectProjectStr);
            sql.Append(") GROUP BY CONVERT(NVARCHAR(10), DateCreated, 23) ORDER BY CONVERT(NVARCHAR(10), DateCreated, 23)");

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };

            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 19-第19个报表数据访问类
        public static SqlDataReader GetReport19(string selectProjectStr)
        {
            //组合sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CONVERT(NVARCHAR(10),DateCreated,23) AS DateCreated,COUNT(*) AS BugCounts,");
            sql.Append(" case when COUNT(*) - 2 < 0 then 0 else COUNT(*) - 2 end as SecondNo FROM Bug");
            sql.Append(" WHERE DATEDIFF(DD,'2018-11-01',DateCreated)>=0 AND DATEDIFF(DD,'2019-03-30',DateCreated)<=0 ");
            sql.Append(" AND ProjectID IN (");
            sql.Append(@selectProjectStr);
            sql.Append(")  GROUP BY CONVERT(NVARCHAR(10),DateCreated,23)  ORDER BY CONVERT(NVARCHAR(10),DateCreated,23)");
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };

            //执行
            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 20-第20个报表数据访问类
        public static SqlDataReader GetReport20(string selectProjectStr)
        {
            //封装sql
            StringBuilder sql = new StringBuilder();
            sql.Append("select Project.ProjectName,ProgressStatusTypes.ProgressStatusName,COUNT(*) AS BugNo,");
            sql.Append(" cast(cast(count(*)*100 as decimal(10,2))/(cast(count(*) + 50 as decimal(10,2))) as decimal(10,2)) AS BugPercent from Bug");
            sql.Append("  join Project on(Bug.ProjectID=Project.ProjectID)");
            sql.Append(" join ProgressStatusTypes on(Bug.ProjectID=ProgressStatusTypes.ProjectID and Bug.ProgressStatusID=ProgressStatusTypes.ProgressStatusID)");
            sql.Append(" where Bug.ProjectID in (");
            sql.Append(@selectProjectStr);
            sql.Append(")  GROUP BY Project.ProjectName,ProgressStatusTypes.ProgressStatusName  ORDER BY Project.ProjectName");

            //封装参数

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@selectProjectStr",selectProjectStr)
            };

            //执行
            try
            {
                SqlDataReader objReader = SQLHelper.GetResultByReader(sql.ToString(),param);
                return objReader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ---------------------以下为Echarts报表--------------------------------------------

        #endregion

        #region 21- 第21个报表数据访问类（销售漏斗报表）
        /// <summary>
        /// 获取报表8需要的数据
        /// </summary>
        /// <returns>返回sqldatareader</returns>
        public SqlDataReader GetReport21()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Bug.CrntBugTypeID,IssueTypes.TypeName,COUNT(*) BugNo FROM Bug");
            sql.Append("  JOIN IssueTypes ON(Bug.ProjectID=IssueTypes.ProjectID AND Bug.CrntBugTypeID=IssueTypes.TypeID)");
            sql.Append("  WHERE Bug.ProjectID=502 GROUP BY Bug.CrntBugTypeID,IssueTypes.TypeName  order by BugNo desc");

            SqlDataReader reader = null;
            try
            {
                reader = SQLHelper.GetResultByReader(sql.ToString());
                return reader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport21()的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region --------------------- 以下为luzhiwei所需报表------------------------

        #region 22-第三个报表数据访问类
        public SqlDataReader GetReport22_Project()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ProjectID,SubProjectID,Title from SubProject where ProjectID=563 and SubProjectID in (select ChildID from SubProjectTree where ProjectID=563 and ParentID=0)");
            SqlDataReader reportReader = null;
            try
            {
                reportReader = SQLHelper.GetResultByReader(sql.ToString());
                return reportReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport2_Project的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int DeleteTmpData()
        {
            string sql = @"delete from  TmpTable";
            try
            {
              return  SQLHelper.Update(sql);
            }
            catch(SqlException ex)
            {
                throw new Exception("执行获取方法DeleteTmpData的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void insertTmpData(string selectSpaceID)
        {
            string sql = "Insert Into TmpTable exec querytree @SpaceID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SpaceID",selectSpaceID)
            };
            SQLHelper.Update(sql, param);
        }

        public static SqlDataReader GetReport22_ReportData()
        {
            //string sql = @"select  ProjectID,SubProjectID,BugID,BugTitle,PlanedEndDate,IssueFinishDate from Bug where ProjectID=563 and TargetReleaseID=1  and SubProjectID in (";
            string sql = "select  ProjectID,SubProjectID,BugID,BugTitle,(CONVERT(varchar(4), PlanedEndDate, 120 )+N'年'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),6,2)+N'月'+substring(CONVERT(varchar(10), PlanedEndDate, 120 ),9,2)+N'日') as PlanedEndDate,";
            sql += " ((CONVERT(varchar(4), IssueFinishDate, 120 )+N'年'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),6,2)+N'月'+substring(CONVERT(varchar(10), IssueFinishDate, 120 ),9,2)+N'日')) AS IssueFinishDate from Bug where ProjectID=563 and TargetReleaseID=1  and SubProjectID in (";
            sql +="select subprojectid from TmpTable)";
          
            SqlDataReader objReader = null;

            try
            {
                objReader = SQLHelper.GetResultByReader(sql);
                return objReader;
            }
            catch (SqlException ex)
            {
                throw new Exception("执行获取方法GetReport22_ReportData的时候出现sql异常:" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion
        #endregion

    }
}
