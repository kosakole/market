using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Themes
{
    [Serializable]
    public abstract class Theme
    {
      
        protected Color labelColor  { get; set; } 
        protected Color backgroundColor { get; set; }
        protected Color buttonBackgroundColor { get; set; }
        protected Color buttonForeColor { get; set; }
        protected Color textBoxForeColor { get; set; }
        protected Color textBoxBackColor { get; set; }
        protected Color dataGridViewBack {  get; set; }
        protected Color dataGridViewGrid { get; set; }
        protected Color dataGridViewHeaderFore { get; set; }
        protected Color dataGridViewHeaderBack { get; set; }
        protected Color dataGridViewSelectionBackColor { get; set; }
        protected Color dataGridViewSelectionForeColor { get; set; }
        protected Color dataGridViewForeColor { get; set; }
        protected Color checkBoxFore { get; set; }
        protected Color checkBoxBack { get; set; }


        public Theme() { }

        public void set(Label label)
        {
            label.ForeColor = labelColor;
        }

        public void set(TextBox textBox)
        {
            textBox.ForeColor = textBoxForeColor;
            textBox.BackColor = textBoxBackColor;
        }

        public void set(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = dataGridViewBack;
            dataGridView.GridColor = dataGridViewGrid;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = dataGridViewHeaderBack;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = dataGridViewHeaderFore;

            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridViewSelectionBackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = dataGridViewSelectionForeColor;


            dataGridView.ForeColor = dataGridViewForeColor;
            
            dataGridView.EnableHeadersVisualStyles = false;
        }

        public void set(Button button)
        {
            button.BackColor = buttonBackgroundColor;
            button.ForeColor = buttonForeColor;
        }

        public void set(Form form)
        {
            form.BackColor = backgroundColor;
        }

        public void set(ComboBox comboBox)
        {
            comboBox.ForeColor = textBoxForeColor;
            comboBox.BackColor = textBoxBackColor;
        }

        public void set(CheckBox cb)
        {
            cb.BackColor = checkBoxBack;
            cb.ForeColor = checkBoxFore;
        }
    }
}
