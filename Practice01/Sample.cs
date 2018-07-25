using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Practice01
{
    public class Sample : BindableBase
    {
        public DelegateCommand command { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public ObservableCollection<Task> tasks { get; set; }

        public Sample()
        {
            tasks = new ObservableCollection<Task>
            {
                new Task{isCheck = false,ID=0,StartTime=DateTime.Now.ToString("HH:mm")}
            };

            this.command = new DelegateCommand(this.execute, this.canexecute);
            this.DeleteCommand = new DelegateCommand(this.DeleteExecute, this.CanDeleteExecute);
        }

        public void execute()
        {
            //ラストの行をとる。
            var last = tasks[tasks.Count - 1];
            //IDの最大値をとる
            //時間の計測をする。 
            last.EndTime = DateTime.Now.ToString("HH:mm");
            last.ManHour = DateTime.ParseExact(last.EndTime,"HH:mm",null) - DateTime.ParseExact(last.StartTime,"HH:mm",null);
            //行を追加する。
            tasks.Add(
                new Task {isCheck=false, ID=last.ID+1, StartTime=DateTime.Now.ToString("HH:mm") }
            );
        }
        public bool canexecute()
        {
            return true;
        }
        public void DeleteExecute()
        {
            for (int i = tasks.Count - 1; i >= 0; i--)
            {
                if (tasks[i].isCheck == true)
                {
                    tasks.RemoveAt(i);
                }
            }
        }
        public bool CanDeleteExecute()
        {
            for (int i = tasks.Count - 1; i >= 0; i--)
            {
                if (tasks[i].isCheck == true)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
