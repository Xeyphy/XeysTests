using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Note
    {
        [JsonProperty]
        string title;
        [JsonProperty]
        string text;

        public Note(string title, string text)
        {
            this.title = title ?? "No Title";
            this.text = text ?? "No Text";
        }

        public override string ToString()
        {
            return title;
        }
        public string getText()
        {
            return text;
        }
        public void saveText(string text)
        {
            this.text = text;
        }
    }
}
