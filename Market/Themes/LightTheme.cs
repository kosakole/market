using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Themes
{
    [Serializable]
    public class LightTheme : Theme
    {
        public LightTheme()
        {
            labelColor = Color.Orange;
            backgroundColor = Color.White;
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
            dataGridViewForeColor = Color.DarkRed;

            checkBoxFore = Color.DarkRed;
            checkBoxBack = Color.Orange;
        }
    }
}
