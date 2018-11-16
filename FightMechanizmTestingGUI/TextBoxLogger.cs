using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Loggers;
using System.Windows.Forms;

namespace FightMechanizmTestingGUI
{
    public class TextBoxLogger : Logger
    {
        private RichTextBox _richTextBox;

        public TextBoxLogger(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
        }

        public void LogLine(string line)
        {
            _richTextBox.AppendText(line + Environment.NewLine);
        }
    }
}
