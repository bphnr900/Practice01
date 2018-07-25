using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice01
{
    public class Task : BindableBase
    {
        private bool ischeck;
        public bool isCheck
        {
            get { return ischeck; }
            set { this.SetProperty(ref this.ischeck, value); }
        }

        public long ID { get; set; }

        public string TaskName { get; set; }
        public string StartTime { get; set; }

        private string endTime;
        public string EndTime
        {
            get { return endTime; }
            set { this.SetProperty(ref this.endTime, value); }
        }

        private TimeSpan manHour;
        public TimeSpan ManHour
        {
            get { return manHour; }
            set { this.SetProperty(ref this.manHour, value); }
        }
    }
}
