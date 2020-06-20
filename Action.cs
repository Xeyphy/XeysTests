using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Action
    {
        public string name;
        public string description;

        public Action(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
