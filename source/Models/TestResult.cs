using System.Collections.Generic;

namespace WebAppStatus.Models
{
    public class TestResult
    {
        public string Name { get; set; }
        public bool Successful { get; set; }
        public List<LogEntry> Log { get; set; }
    }
}
