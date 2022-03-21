using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Student : Person, IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks = new List<Task>();

        public string Group { get; set; }

        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            this.tasks = tasks;
        }

        public Student(string name, int age, string group) : base(name, age)
        {
            this.group = group;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(taskName, taskStatus));
        }

        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index].Status = taskStatus;
        }

        public void RenderTask(string prefix = "\t")
        {

        }

        public override string ToString()
        {
            return $"Student: {name} ({age} y.o.) \nGroup: {group} \n" + "Tasks:\n" + " " + String.Join("\n ", tasks);
        }

        public bool Equals(Student? other)
        {
            if (other == this)
                return true;
            if (other == null)
                return false;
            return Object.Equals(this.name, other.name) && Object.Equals(this.tasks, other.tasks);
        }

        private bool SequenceEqual(List<Task> a, List<Task> b)
        {
            return Task.Equals(a, b);
        }
    }
}
