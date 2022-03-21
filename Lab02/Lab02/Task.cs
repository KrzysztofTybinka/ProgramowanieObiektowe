using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Task : IEquatable<Task>
    {
        private string name;
        private TaskStatus status;

        public string Name
        {
            get { return name; }
            set { name = Name; }
        }
        public TaskStatus Status
        {
            get { return status; }
            set { status = Status; }
        }

        public Task(string name, TaskStatus status)
        {
            this.name = name;
            this.status = status;
        }

        public override string ToString()
        {
            return $"Task: {name} [{status}]";
        }

        public bool Equals(Task other)
        {
            if (other == null) return false;
            if (other == this) return true;

            return Object.Equals(this.name, other.name) && Object.Equals(this.status, other.status);
        }
    }
}
