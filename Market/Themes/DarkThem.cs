using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Themes
{
    [Serializable]
    public class DarkThem : Theme
    {
        public DarkThem() 
        {
            labelColor = Color.Orange;
            backgroundColor = Color.Black;
            buttonBackgroundColor = Color.Orange;
            buttonForeColor = Color.DarkRed;
            textBoxForeColor = Color.DarkRed;
            textBoxBackColor = Color.Orange;

            dataGridViewBack = Color.Orange;
            dataGridViewGrid = Color.DarkRed;

            dataGridViewHeaderFore = Color.DarkRed;
            dataGridViewHeaderBack = Color.Orange;

            dataGridViewSelectionBackColor = Color.Orange;
            dataGridViewSelectionForeColor = Color.White;

            checkBoxFore = Color.DarkRed;
            checkBoxBack = Color.Orange;
        }

        
    }
}
