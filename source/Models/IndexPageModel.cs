using System.Collections.Generic;

namespace WebAppStatus.Models
{
    public class IndexPageModel
    {
        public string PageTitle { get; set; }
        public string OwnerName { get; set; }
        public List<TestResult> TestResults { get; set; }

        public IndexPageModel()
        {
            TestResults = new List<TestResult>();
        }
    }
}
