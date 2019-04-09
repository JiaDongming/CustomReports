using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 报表22所需的条目实体类
    /// </summary>
  public  class Report22_Bug
    {
        public string ProjectID { get; set; }
        public string SubProjectID { get; set; }
    
        public string BugID { get; set; }
        public string BugTitle { get; set; }

        public string PlanedEndDate { get; set; }
        public string IssueFinishDate { get; set; }

        public DateTime PlanedEndDate2 { get; set; }
        public DateTime IssueFinishDate2 { get; set; }
    }
}
