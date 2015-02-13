using psiOfficeAPI.Models.Chart.View;
using psiOfficeAPI.Models.Core.Service;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace psiOfficeAPI.Models.Report.Service
{
    public class ReportService : RootService
    {
        public List<ChartVM> WorkloadPerWeek(int pLongTerm) 
        {
            string sql = "select week as category,";
            sql += "invoice_flag as series,";
            sql += "sum(c_pct) as value ";
            sql += "from br_op_workload_by_week( ? ) group by week, invoice_flag order by week asc, invoice_flag desc";

            List<ChartVM> vm = new List<ChartVM>();
            string category = "";
            string series = "";
            decimal value = 0;

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;
                        DbCommandRead.Parameters.Add(new OdbcParameter("pLongTerm", pLongTerm));

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                category = DbReader.GetString(0).PadLeft(2, '0');
                                series = DbReader.GetString(1).PadLeft(2, '0');
                                value = DbReader.GetDecimal(2);

                                vm.Add(new ChartVM()
                                {
                                    category = category,
                                    series = series,
                                    value = value
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

            return vm.OrderByDescending(x => x.series).ThenBy(x => x.category).ToList();
        }

        public List<ChartVM> Sales() 
        {
            //select * from bc_sales_forecast_prog()
            //order by category asc;

            string sql = "select category, series, value ";
            sql += "from bc_sales_forecast_prog() order by series, category";

            List<ChartVM> vm = new List<ChartVM>();
            string category = "";
            string series = "";
            decimal value = 0;

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
                                category = DbReader.GetString(0);
                                series = DbReader.GetString(1);
                                value = DbReader.GetDecimal(2);

                                vm.Add(new ChartVM()
                                {
                                    category = category,
                                    series = series,
                                    value = value
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

            return vm;
        }

        public List<ChartVM> WorkloadPerCustomer(int pLongTerm) 
        {

            string sql = "select v.customer as category, ";
            sql += "sum(sp.remain_hours) as value ";
            sql += "from    br_op_workload(?) sp, v_op_issue_list v where   sp.issue_no = v.issue_no ";
            sql += "group by category order by category asc;";

            List<ChartVM> vm = new List<ChartVM>();
            string category = "";
            string series = "";
            decimal value = 0;

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;
                        DbCommandRead.Parameters.Add(new OdbcParameter("pLongTerm", pLongTerm));

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                category = DbReader.GetString(0).PadLeft(2, '0');
                                //series = DbReader.GetString(1).PadLeft(2, '0');
                                value = DbReader.GetDecimal(1);

                                vm.Add(new ChartVM()
                                {
                                    category = category,
                                    series = series,
                                    value = value
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

            return vm.OrderByDescending(x => x.value).ToList();

        }

        public List<ChartVM> WorkloadPerCustomerDollar(int pLongTerm) 
        {

            string sql = "select v.customer as category, ";
            sql += "sum(sp.c_dollar_total) as value ";
            sql += "from    br_op_workload_by_day(?) sp, v_op_issue_list v where   sp.issue_no = v.issue_no ";
            sql += "group by category order by category asc;";

            List<ChartVM> vm = new List<ChartVM>();
            string category = "";
            string series = "";
            decimal value = 0;

            using (var DbConnection = new OdbcConnection(this.ODBC))
            {
                DbConnection.Open();
                try
                {
                    using (var DbCommandRead = DbConnection.CreateCommand())
                    {
                        DbCommandRead.CommandText = sql;
                        DbCommandRead.Parameters.Add(new OdbcParameter("pLongTerm", pLongTerm));

                        using (var DbReader = DbCommandRead.ExecuteReader())
                        {
                            while (DbReader.Read())
                            {
                                category = DbReader.GetString(0).PadLeft(2, '0');
                                //series = DbReader.GetString(1).PadLeft(2, '0');
                                value = DbReader.GetDecimal(1);

                                vm.Add(new ChartVM()
                                {
                                    category = category,
                                    series = series,
                                    value = value
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

            return vm.Where( x => x.value > 0 ).OrderByDescending(x => x.value).ToList();

        }
    }
}