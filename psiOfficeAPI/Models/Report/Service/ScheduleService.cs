using psiOfficeAPI.Models.Chart.View;
using psiOfficeAPI.Models.Core.Service;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using psiOfficeAPI.Models.View.Schedule;

namespace psiOfficeAPI.Models.Report.Service
{
    public class ScheduleService : RootService
    {
        public List<OpListSchRequestVM> OpRequest()
        {
            string sql = "SELECT issue_no, issue_subject, customer, owner, owner_name, estimate_time, due_date, ";
            sql += "invoice_flag, issue_priority, c_days_stage, seq_no ";
            sql += "FROM br_op_list_sch_request() ORDER BY seq_no ASC;";

            List<OpListSchRequestVM> vm = new List<OpListSchRequestVM>();

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                vm.Add(new OpListSchRequestVM()
                                {
                                    issue_no = (!DbReader.IsDBNull(0)) ? DbReader.GetDecimal(0) : 0,
                                    issue_subject = (!DbReader.IsDBNull(1)) ? DbReader.GetString(1) : string.Empty,
                                    customer = (!DbReader.IsDBNull(2)) ? DbReader.GetString(2) : string.Empty,
                                    owner = (!DbReader.IsDBNull(3)) ? DbReader.GetString(3) : string.Empty,
                                    owner_name = (!DbReader.IsDBNull(4)) ? DbReader.GetString(4) : string.Empty,
                                    estimate_time = (!DbReader.IsDBNull(5)) ? DbReader.GetDecimal(5) : 0,
                                    due_date = (!DbReader.IsDBNull(6)) ? DbReader.GetDateTime(6) : DateTime.Now,
                                    invoice_flag = (!DbReader.IsDBNull(7)) ? DbReader.GetDecimal(7) : 0,
                                    issue_priority = (!DbReader.IsDBNull(8)) ? DbReader.GetDecimal(8) : 0,
                                    c_days_stage = (!DbReader.IsDBNull(9)) ? DbReader.GetInt32(9) : 0,
                                    seq_no = (!DbReader.IsDBNull(10)) ? DbReader.GetDecimal(10) : 0
                                });
                            }
                            DbReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    DbConnection.Close();
                }
            }

            return vm.OrderBy(x => x.seq_no).ToList();
        }

        public List<OpListScheduleVM> OpSchedule()
        {
            string sql = "SELECT issue_no, issue_subject, customer, owner, owner_name, estimate_time, est_start_date, ";
            sql += "est_end_date, due_date, hard_alloc, earmarked_for, earmarked_name, design_status, ";
            sql += "c_days_stage, c_days_early, c_ontime_status, seq_no ";
            sql += "FROM br_op_list_schedule() ORDER BY seq_no ASC;";

            List<OpListScheduleVM> vm = new List<OpListScheduleVM>();

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                vm.Add(new OpListScheduleVM()
                                {
                                    issue_no = (!DbReader.IsDBNull(0)) ? DbReader.GetDecimal(0) : 0,
                                    issue_subject = (!DbReader.IsDBNull(1)) ? DbReader.GetString(1) : string.Empty,
                                    customer = (!DbReader.IsDBNull(2)) ? DbReader.GetString(2) : string.Empty,
                                    owner = (!DbReader.IsDBNull(3)) ? DbReader.GetString(3) : string.Empty,
                                    owner_name = (!DbReader.IsDBNull(4)) ? DbReader.GetString(4) : string.Empty,
                                    estimate_time = (!DbReader.IsDBNull(5)) ? DbReader.GetDecimal(5) : 0,
                                    est_start_date = (!DbReader.IsDBNull(6)) ? DbReader.GetDateTime(6) : DateTime.Now,
                                    est_end_date = (!DbReader.IsDBNull(7)) ? DbReader.GetDateTime(7) : DateTime.Now,
                                    due_date = (!DbReader.IsDBNull(8)) ? DbReader.GetDateTime(8) : DateTime.Now,
                                    hard_alloc = (!DbReader.IsDBNull(9)) ? DbReader.GetInt16(9) : 0,
                                    earmarked_for = (!DbReader.IsDBNull(10)) ? DbReader.GetString(10) : string.Empty,
                                    earmarked_name = (!DbReader.IsDBNull(11)) ? DbReader.GetString(11) : string.Empty,
                                    design_status = (!DbReader.IsDBNull(12)) ? DbReader.GetString(12) : string.Empty,
                                    c_days_stage = (!DbReader.IsDBNull(13)) ? DbReader.GetInt32(13) : 0,
                                    c_days_early = (!DbReader.IsDBNull(14)) ? DbReader.GetInt32(14) : 0,
                                    c_ontime_status = (!DbReader.IsDBNull(15)) ? DbReader.GetInt16(15) : 0
                                });
                            }
                            DbReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    DbConnection.Close();
                }
            }

            return vm.OrderBy(x => x.seq_no).ToList();
        }

        public List<OpListProductionVM> OpProduction()
        {
            string sql = "SELECT issue_no, issue_subject, customer, estimate_time, reported_hours, ";
            sql += "est_complete_pct, due_date, c_days_stage, production_stage ";
            sql += "FROM br_op_list_production();";

            List<OpListProductionVM> vm = new List<OpListProductionVM>();

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                vm.Add(new OpListProductionVM()
                                {
                                    issue_no = (!DbReader.IsDBNull(0)) ? DbReader.GetDecimal(0) : 0,
                                    issue_subject = (!DbReader.IsDBNull(1)) ? DbReader.GetString(1) : string.Empty,
                                    customer = (!DbReader.IsDBNull(2)) ? DbReader.GetString(2) : string.Empty,
                                    estimate_time = (!DbReader.IsDBNull(3)) ? DbReader.GetDecimal(3) : 0,
                                    reported_hours = (!DbReader.IsDBNull(4)) ? DbReader.GetDecimal(4) : 0,
                                    est_complete_pct = (!DbReader.IsDBNull(5)) ? DbReader.GetDecimal(5) : 0,
                                    due_date = (!DbReader.IsDBNull(6)) ? DbReader.GetDateTime(6) : DateTime.Now,
                                    c_days_stage = (!DbReader.IsDBNull(7)) ? DbReader.GetInt32(7) : 0,
                                    production_stage = (!DbReader.IsDBNull(8)) ? DbReader.GetString(8) : string.Empty,
                                });
                            }
                            DbReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    DbConnection.Close();
                }
            }
            return vm.ToList();
        }
    }
}