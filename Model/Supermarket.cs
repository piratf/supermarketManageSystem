using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Supermarket
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Supermarket()
        {
            name = string.Empty;
        }

        public Supermarket(string _name)
        {
            name = _name;
        }

        public Supermarket(Supermarket _supermarket)
        {
            name = _supermarket.name;
        }

        public Supermarket Clone(Supermarket _other)
        {
            name = _other.name;
            return this;
        }

    }
}
