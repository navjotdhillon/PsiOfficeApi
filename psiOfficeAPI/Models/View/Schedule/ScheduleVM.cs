using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace psiOfficeAPI.Models.View.Schedule
{

    public class OpListSchRequestVM
    {
        public decimal? issue_no { get; set; }
        public string issue_subject { get; set; }
        public string customer { get; set; }
        public string owner { get; set; }
        public string owner_name { get; set; }
        public decimal? estimate_time { get; set; }
        public DateTime? due_date { get; set; }
        public decimal? invoice_flag { get; set; }
        public decimal? issue_priority { get; set; }
        public int? c_days_stage { get; set; }
        public decimal? seq_no { get; set; }
    }

    public class OpListScheduleVM
    {
        public decimal? issue_no { get; set; }
        public string issue_subject { get; set; }
        public string customer { get; set; }
        public string owner { get; set; }
        public string owner_name { get; set; }
        public decimal? estimate_time { get; set; }
        public DateTime? est_start_date { get; set; }
        public DateTime? est_end_date { get; set; }
        public DateTime? due_date { get; set; }
        public int? hard_alloc { get; set; }
        public string earmarked_for { get; set; }
        public string earmarked_name { get; set; }
        public string design_status { get; set; }
        public int? c_days_stage { get; set; }
        public int? c_days_early { get; set; }
        public int? c_ontime_status { get; set; }
        public decimal? seq_no { get; set; }
    }

    public class OpListProductionVM
    {
        public decimal? issue_no { get; set; }
        public string issue_subject { get; set; }
        public string customer { get; set; }
        public decimal? estimate_time { get; set; }
        public decimal? est_complete_pct { get; set; }
        public decimal? reported_hours { get; set; }
        public DateTime? due_date { get; set; }
        public int? c_days_stage { get; set; }
        public string production_stage { get; set; }
    }

}
