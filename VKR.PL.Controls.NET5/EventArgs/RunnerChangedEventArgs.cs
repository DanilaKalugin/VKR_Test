using VKR.EF.Entities;

namespace VKR.PL.Controls.NET5.EventArgs
{
    public class RunnerChangedEventArgs: System.EventArgs
    {
        public Runner Runner { get; set; }

        public RunnerChangedEventArgs(Runner runner)
        {
            Runner = runner;
        }
    }
}