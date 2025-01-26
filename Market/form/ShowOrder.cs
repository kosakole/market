using Market.DTO;
using Market.interfaces;
using Market.Languages;
using Market.model;
using Market.Settings;
using Market.Themes;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class ShowOrder : Form, ChangeSettings
    {
        public ShowOrder()
        {
            InitializeComponent();
            
        }

        internal ShowOrder(Order order) : this()
        {
            this.order = order;
            labelIDValue.Text = order.Id.ToString();
            labelDelivererValue.Text = order.Deliverer.Name.ToString();
            labelDateValue.Text = getStringDateFromDateTime(order.DateTime);
            init();
            chageSettings();
        }

        private void init()
        {
            dataGridView.Rows.Clear();
            decimal total = 0;
            foreach (Article ar in order.Articles)
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
            labels = new List<Label>();
            labels.Add(labelID);
            labels.Add(labelIDValue);
            labels.Add(labelDate);
            labels.Add(labelDateValue);
            labels.Add(labelTotalValue);
            labels.Add(labelTotal);
            labels.Add(labelDateValue);
            labels.Add(labelDeliverer);
            labels.Add(labelDelivererValue);
            labels.Add(labelDate);
        }
        private void setLanguage(Language language)
        {
            string key;

            key = "ID";
            labelID.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Date";
            labelDate.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Deliverer";
            labelDeliverer.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

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
            
            key = "Show order";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

        }

        private string getStringDateFromDateTime(DateTime dateTime)
        {
            string date = dateTime.ToString().Split(' ')[0];
            string[] arr = date.Split('/');
            return arr[1] + "-" + arr[0] + "-" + arr[2];
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


        private Order order;
    }
}
