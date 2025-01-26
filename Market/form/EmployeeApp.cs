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
    public partial class EmployeeApp : Form, ChangeSettings
    {
        private EmployeeCashDesk EmployeeCashDesk;
        private const string FILE_CASH_DESK_ID = @"cashDesk.txt";
        private UserDTO user;
        public EmployeeApp()
        {
            changeSettings.Add(this);
            InitializeComponent();
            init();
        }
        internal EmployeeApp(UserDTO user) : this()
        {
            EmployeeCashDesk = new EmployeeCashDesk();
            EmployeeCashDesk.CashDesk.Id = 3;
            EmployeeCashDesk.User = user;
            this.user = user;
            load();
            chageSettings();
        }

        private void load()
        {
            if(File.Exists(FILE_CASH_DESK_ID))
            {
                StreamReader sr = new StreamReader(FILE_CASH_DESK_ID);
                int id;
                try
                {
                    id = Int32.Parse(sr.ReadLine());
                }
                catch (Exception ex) 
                {
                    id = 0;
                }
                EmployeeCashDesk.CashDesk.Id = id;
            }
            else
            {
                int id = new CashDeskDAOImplementationcs().getNextID();
                EmployeeCashDesk.CashDesk.Id = id;
                StreamWriter sw = new StreamWriter(FILE_CASH_DESK_ID);
                sw.Write(id); 
                sw.Close();
            }
            Setting.load(user);
        }

        private void init()
        {
            buttons.Add(buttonCreateBill);
            buttons.Add(buttonAuditBills);
            buttons.Add(buttonChangePassword);
            buttons.Add(buttonSettings);

        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Create bill";
            buttonCreateBill.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Audit bills";
            buttonAuditBills.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Change password";
            buttonChangePassword.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Emp app";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
        }

        public void changeTheme(Theme theme)
        {
            foreach (Button b in buttons)
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

        private List<Button> buttons = new List<Button>();

        private void buttonCreateBill_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateBill(EmployeeCashDesk).ShowDialog();
            this.Show();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChangePassword(EmployeeCashDesk.User).ShowDialog();
            this.Show();
        }

        private void buttonAuditBills_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AuditBills(EmployeeCashDesk.User).ShowDialog();
            this.Show();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            new SettingsForme(changeSettings).ShowDialog();
            Setting.save(user);
        }
        private List<ChangeSettings> changeSettings = new List<ChangeSettings>();

    }
}
