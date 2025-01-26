using Market.DAOImplementation;
using Market.DTO;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    public partial class AuditLogin : Form, ChangeSettings
    {
        private List<UserDTO> users;
        private List<CashDesk> cashDesks;
        public AuditLogin()
        {
            InitializeComponent();
            users = new UserDAOImplementation().GetAll();
            cashDesks = new CashDeskDAOImplementationcs().GetAll();
            init();
            chageSettings();
            FillGrid();
        }

        private void init()
        {
            string key = "All";
            ALL = Setting.GetSettings().Language.Words.ContainsKey(key) ? Setting.GetSettings().Language.Words[key] : "";
            comboBoxUsername.Items.Clear();
            comboBoxUsername.Items.Add(ALL);
            comboBoxUsername.SelectedIndex = 0;
            foreach(UserDTO user in users) 
            {
                comboBoxUsername.Items.Add((string)user.Username);
            }

            comboBoxCashDesk.Items.Clear();
            comboBoxCashDesk.Items.Add(ALL);
            comboBoxCashDesk.SelectedIndex = 0;
            foreach (CashDesk cs in cashDesks)
            {
                comboBoxCashDesk.Items.Add(cs.ToString());
            }

            labels = new List<Label>();
            labels.Add(labelUsername);
            labels.Add(labelCashDesk);
            labels.Add(labelFrom);
            labels.Add(labelTo);

            comboBox = new List<ComboBox>();
            comboBox.Add(comboBoxUsername);
            comboBox.Add(comboBoxCashDesk);
        }
        private void FillGrid()
        {
            List<EmployeeCashDesk> list = new EmployeeCashDeskDAOImplementation().GetAll();
            dataGridView.Rows.Clear();
            foreach (EmployeeCashDesk ecd in list.Where(a =>
            {
                if (!(a.Created >= dateTimePickerFrom.Value && a.Created <= dateTimePickerTo.Value))
                    return false;
                if (comboBoxUsername.SelectedItem != null && comboBoxUsername.SelectedItem.ToString() != ALL)
                {
                    if (comboBoxUsername.SelectedItem.ToString() != a.User.Username)
                        return false;
                }

                if (comboBoxCashDesk.SelectedItem != null && comboBoxCashDesk.SelectedItem.ToString() != ALL)
                {
                    if (comboBoxCashDesk.SelectedItem.ToString() != a.CashDesk.Id.ToString())
                        return false;
                }
                return true;
            }))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = ecd
                };
                row.CreateCells(dataGridView, ecd.User.Id, ecd.User.Username,  ecd.CashDesk.Id, getDateTimeString(ecd.Created));
                dataGridView.Rows.Add(row);
            }
        }

        private string getDateTimeString(DateTime datetime)
        {
            string date = datetime.ToString().Split(' ')[1];
            return datetime.ToString().Split(' ')[1] + " " + datetime.Day + "-" + datetime.Month + "-" + datetime.Year;
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void comboBoxCashDesk_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }

            foreach(ComboBox c in comboBox)
            {
                theme.set(c);
            }
            theme.set(dataGridView);
            theme.set(this);
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Cash desk ID";
            labelCashDesk.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "From";
            labelFrom.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "To";
            labelTo.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            
            key = "ID person";
            dataGridView.Columns["ID"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Username";
            dataGridView.Columns["UserName"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Cash desk";
            dataGridView.Columns["CashDesk"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Date time";
            dataGridView.Columns["Time"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            
            key = "All";
            ALL = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Audit login";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private string ALL = "All";
        private List<Label> labels;
        private List<ComboBox> comboBox;
    }
}
