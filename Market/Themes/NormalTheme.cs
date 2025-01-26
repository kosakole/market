using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Themes
{
    [Serializable]
    public class NormalTheme : Theme
    {
        public NormalTheme()
        {
            labelColor = Color.Black;
            backgroundColor = Color.White;
            buttonBackgroundColor = Color.LightGray;
            buttonForeColor = Color.Black;
            textBoxForeColor = Color.Black;
            textBoxBackColor = Color.White;

            dataGridViewBack = Color.White;
            dataGridViewGrid = Color.Black;

            dataGridViewHeaderFore = Color.Black;
            dataGridViewHeaderBack = Color.LightGray;

            dataGridViewSelectionBackColor = Color.LightBlue;
            dataGridViewSelectionForeColor = Color.White;
            dataGridViewForeColor = Color.Black;

            checkBoxFore = Color.Black;
            checkBoxBack = Color.White;
        }
    }
}