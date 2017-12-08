using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4box
{
    public class BindingListItem<T>
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public T Value { get; set; }

        public BindingListItem(string name, string displayName, T value)
        {
            Name = name;
            DisplayName = displayName;
            Value = value;
        }

        public BindingListItem()
        { }
    }
}
