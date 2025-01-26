using Market.DAOImplementation;
using Market.interfaces;
using Market.Languages;
using Market.model;
using Market.Settings;
using Market.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    
    public partial class AdminApp : Form, ChangeSettings
    {
        
        private UserDTO user;
        public AdminApp()
        {
            InitializeComponent();
            init();
            changeSettings.Add(this);
        }
        internal AdminApp(UserDTO user) : this()
        {
            this.user = user;
            load();
            chageSettings();
        }

        private void load()
        {
            Setting.load(user);
        }

        private void init()
        {
            buttons.Add(buttonWorkBills);
            buttons.Add(buttonAuditBills);
            buttons.Add(buttonWorkArticles);
            buttons.Add(buttonAuditOrders);
            buttons.Add(buttonWorkEmployees);
            buttons.Add(buttonAuditLogin);
            buttons.Add(buttonSettings);
            buttons.Add(buttonWorkOrders);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AuditLogin().ShowDialog();
            this.Show();
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Work with bills";
            buttonWorkBills.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Employees";
            buttonWorkEmployees.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Audit bills";
            buttonAuditBills.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Audit orders";
            buttonAuditOrders.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Audit login";
            buttonAuditLogin.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Work with orders";
            buttonWorkOrders.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Work with articles";
            buttonWorkArticles.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Admin application";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            foreach(Button b in buttons)
            {
                theme.set(b);
            }
            theme.set(this);
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }


        private void buttonSettings_Click(object sender, EventArgs e)
        {
            new SettingsForme(changeSettings).ShowDialog();
            Setting.save(user);
        }

        private List<Button> buttons = new List<Button>();
        private List<ChangeSettings> changeSettings = new List<ChangeSettings>();

        private void buttonWorkBills_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateBill().ShowDialog();
            this.Show();
        }

        private void buttonAuditBills_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AuditBills().ShowDialog();
            this.Show();
        }

        private void buttonWorkArticles_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateArticle().ShowDialog();
            this.Show();
        }

        private void buttonAuditArticles_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AuditOrders().ShowDialog();
            this.Show();
        }

        private void buttonWorkEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateEmployee().ShowDialog();
            this.Show();
        }

        private void buttonWorkOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateOrder().ShowDialog();
            this.Show();
        }
    }
}
