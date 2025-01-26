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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    public partial class AuditBills : Form, ChangeSettings
    {
        private List<Bill> Bills;
        private List<UserDTO> Users;
        private List<CashDesk> CashDesks;
        private List<Label> labels;
        private List<ComboBox> combo;
        private List<DateTimePicker> dateTimePicker;
        public AuditBills()
        {
            InitializeComponent();
            Bills = new BillDAOImplementation().GetAll();
            Users = new UserDAOImplementation().GetAll();
            CashDesks = new CashDeskDAOImplementationcs().GetAll();
            init();
            FillGrid();
            chageSettings();
        }

        internal AuditBills(UserDTO user) : this()
        {
            comboBoxUsername.SelectedIndex = comboBoxUsername.FindStringExact(user.ToString());
            comboBoxUsername.Visible = false;
            labelUsername.Visible = false;
            FillGrid();
        }

        private void init()
        {
            string key = "All";
            ALL = Setting.GetSettings().Language.Words.ContainsKey(key) ? Setting.GetSettings().Language.Words[key] : "";

            comboBoxUsername.Items.Add(ALL);
            comboBoxUsername.SelectedIndex = 0;
            foreach (UserDTO user in Users)
            {
                comboBoxUsername.Items.Add(user.Username);
            }

            comboBoxCashDesk.Items.Add(ALL);
            comboBoxCashDesk.SelectedIndex = 0;
            foreach (CashDesk cd in CashDesks)
            {
                comboBoxCashDesk.Items.Add(cd.Id.ToString());
            }
            labels = new List<Label>();
            labels.Add(labelUsername);
            labels.Add(labelFrom);
            labels.Add(labelCashDeskID);
            labels.Add(labelTo);

            combo = new List<ComboBox>();
            combo.Add(comboBoxUsername);
            combo.Add(comboBoxCashDesk);

            dateTimePicker = new List<DateTimePicker>();
            dateTimePicker.Add(dateTimePickerStart);
            dateTimePicker.Add(dateTimePickerEnd);
        }

        private void FillGrid()
        {
            
            dataGridView.Rows.Clear();
            foreach (Bill bill in Bills.Where(a =>
                {
                    if (!(a.DateTime >= dateTimePickerStart.Value && a.DateTime <= dateTimePickerEnd.Value))
                        return false;
                    if (comboBoxUsername.SelectedItem != null && comboBoxUsername.SelectedItem.ToString() != ALL)
                    {
                        if (comboBoxUsername.SelectedItem.ToString() != a.EmployeeCashDesk.User.Username)
                            return false;
                    }

                    if (comboBoxCashDesk.SelectedItem != null && comboBoxCashDesk.SelectedItem.ToString() != ALL)
                    {
                        if (comboBoxCashDesk.SelectedItem.ToString() != a.EmployeeCashDesk.CashDesk.Id.ToString())
                            return false;
                    }
                    return true;
                }))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = bill
                };
                row.CreateCells(dataGridView, bill.Id, getDateTimeString(bill.DateTime), bill.EmployeeCashDesk.User.Id, 
                    bill.EmployeeCashDesk.User.Username, bill.EmployeeCashDesk.CashDesk.Id);
                dataGridView.Rows.Add(row);
            }
        }

        private string getDateTimeString(DateTime datetime)
        {
            return datetime.ToString().Split(' ')[1] + " " + datetime.Day + "-" + datetime.Month + "-" + datetime.Year;
        }

       

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void comboBoxCashDesk_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void buttonShowBill_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            try
            {
                row = dataGridView.SelectedRows[0];
            }
            catch (Exception ex) 
            {
                return;
            }
            if (row.Cells[0].Value == null)
                return;
            Bill bill = new BillDAOImplementation().GetBill(Int32.Parse(row.Cells[0].Value.ToString()));
            new ShowBill(bill).Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView.SelectedRows[0];
            if (row.Cells[0].Value == null)
                return;
            bool delete = new BillDAOImplementation().delete(Int32.Parse(row.Cells[0].Value.ToString()));
            if(delete)
            {
                MessageBox.Show("Bill is deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bills = new BillDAOImplementation().GetAll();
                FillGrid();
            } else
                MessageBox.Show("Bill is not deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }

            foreach(ComboBox c in combo)
            {
                theme.set(c);
            }

            theme.set(dataGridView);
            theme.set(buttonShowBill);
            theme.set(this);
            theme.set(this);
        }



        private void setLanguage(Language language)
        {
            string key;

            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Cash desk ID";
            labelCashDeskID.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "From";
            labelFrom.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "To";
            labelTo.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Show bill";
            buttonShowBill.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "ID";
            dataGridView.Columns["Id"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Date time";
            dataGridView.Columns["DateTime"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Employee ID";
            dataGridView.Columns["EmployeeID"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Employee username";
            dataGridView.Columns["EmployeeName"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Cash desk ID";
            dataGridView.Columns["CashDeskId"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "All";
            ALL = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Audit bills";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }
        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private string ALL = "";
    }
}
