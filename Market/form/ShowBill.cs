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
    public partial class ShowBill : Form, ChangeSettings
    {
        public ShowBill()
        {
            InitializeComponent();
            init();
            chageSettings();
        }

        internal ShowBill(Bill bill) : this()
        {
            UserDTO user = bill.EmployeeCashDesk.User;
            labelIDValue.Text = bill.Id.ToString();
            labelEmployeeValue.Text = user.Username;
            labelDateValue.Text = getDateTimeString(bill.DateTime);
            labelCashDeskValue.Text = bill.EmployeeCashDesk.CashDesk.Id.ToString();
            decimal total = 0;
            dataGridView.Rows.Clear();
            foreach (Article ar in bill.Articles)
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = ar
                };
                decimal ta = ar.Price * ar.Amount;
                total += ta;
                row.CreateCells(dataGridView, ar.Barcode, ar.Name, ar.Price, ar.Amount, ta);
                dataGridView.Rows.Add(row);
            }
            labelTotalValue.Text = total.ToString();
            
        }

        private void init()
        {
            labels = new List<Label>();
            labels.Add(labelID);
            labels.Add(labelIDValue);
            labels.Add(labelEmployeeValue);
            labels.Add(labelEmployee);
            labels.Add(labelCashDeskValue);
            labels.Add(labelTotalValue);
            labels.Add(labelTotal);
            labels.Add(labelDateValue);
            labels.Add(labelCashDesk);
            labels.Add(labelDateTime);
        }

        private string getDateTimeString(DateTime datetime)
        {
            return datetime.ToString().Split(' ')[1] + " " + datetime.Day + "-" + datetime.Month + "-" + datetime.Year;
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "ID";
            labelID.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Date";
            labelDateTime.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Employee";
            labelEmployee.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Cash desk";
            labelCashDesk.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
           
            key = "Barcode";
            dataGridView.Columns["Barcode"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridView.Columns["NameC"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price";
            dataGridView.Columns["Price"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Amount";
            dataGridView.Columns["Amount"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Total";
            dataGridView.Columns["Total"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Total";
            labelTotal.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Show bill";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }

            theme.set(dataGridView);
            theme.set(this);
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private string ALL = "";
        private List<Label> labels;
        
    }
}
