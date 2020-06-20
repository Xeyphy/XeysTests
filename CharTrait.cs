using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class CharTrait
    {

        string title;
        string desc;

        public CharTrait(string title, string desc)
        {
            this.title = title ?? "No Title";
            this.desc = desc ?? "No Description";
        }

        public override string ToString()
        {
            return title;
        }
        public string getTitle()
        {
            return title;
        }
        public string getDesc()
        {
            return desc;
        }
    }
}
