using Market.interfaces;
using Market.Languages;
using Market.Settings;
using Market.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Market.form
{
    public partial class FirstForm : Form, ChangeSettings
    {
        public FirstForm()
        {
            InitializeComponent();
            chageSettings();
        }

        

        private void setLanguage(Language language)
        {
            string key;

            key = "Admin";
            buttonAdmin.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Employee";
            buttonEmployee.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            

            key = "Login";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            
            theme.set(buttonAdmin);
            theme.set(buttonEmployee);
            theme.set(buttonSttings);
            theme.set(this);
            return;
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private void buttonSttings_Click(object sender, EventArgs e)
        {
            new SettingsForme(this).Show();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(true).ShowDialog();
            this.Close();
        }
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(false).ShowDialog();
            this.Close();
        }

    }
}
