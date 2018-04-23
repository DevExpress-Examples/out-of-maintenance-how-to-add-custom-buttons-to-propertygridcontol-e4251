using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridControlWithBar
{
    public class CustomButtonsEventArgs : EventArgs
    {
        public string Name { get; set; }
        public CustomButtonsEventArgs(string _name)
        {
            Name = _name;
        }
    }
}
