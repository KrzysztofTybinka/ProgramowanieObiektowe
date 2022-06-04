using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Events
    {
        public Events() { }

        public delegate void AddCategoryEventHandler();
        public event AddCategoryEventHandler? CategoryAdded;   

        protected virtual void OnAddCategory()
        {
            if (CategoryAdded != null)
                CategoryAdded();
        }
    }
}
