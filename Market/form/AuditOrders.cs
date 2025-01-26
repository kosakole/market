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
    public partial class AuditOrders : Form, ChangeSettings
    {
        private List<Order> Orders;
        private List<Deliverer> Deliveryers;
        public AuditOrders()
        {
            InitializeComponent();
            Orders = new OrderDAOImplementation().GetAll();
            Deliveryers = new DelivererDAOImplementation().GetAll();
            init();
            FillGrid();
            chageSettings();
        }

        private void init()
        {
            string key = "All";
            ALL = Setting.GetSettings().Language.Words.ContainsKey(key) ? Setting.GetSettings().Language.Words[key] : "";

            comboBoxDeliverer.Items.Clear();
            comboBoxDeliverer.Items.Add(ALL);
            comboBoxDeliverer.SelectedIndex = 0;
            foreach (Deliverer del in Deliveryers) 
            {
                comboBoxDeliverer.Items.Add(del);
            }

            labels = new List<Label>();
            labels.Add(labelDeliverer);
            labels.Add(labelFrom);
            labels.Add(labelTo);

            comboBoxes = new List<ComboBox>();
            comboBoxes.Add(comboBoxDeliverer);
        }

        private void FillGrid()
        {
            string selectedItem = comboBoxDeliverer.SelectedItem.ToString();
            dataGridView.Rows.Clear();
            foreach (Order o in Orders.Where(a => {

                if (!(a.DateTime >= dateTimePickerStart.Value && a.DateTime <= dateTimePickerEnd.Value))
                    return false;

                if (comboBoxDeliverer.SelectedItem != null && selectedItem != ALL)
                {
                    Deliverer deliverer = (Deliverer)comboBoxDeliverer.SelectedItem;
                    string id = deliverer.Id.ToString();
                    if (id != a.Deliverer.Id.ToString())
                        return false;

                }
                return true;
            }))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = o
                };
                row.CreateCells(dataGridView,o.Id, o.Deliverer.Name, getStringDateFromDateTime(o.DateTime));
                dataGridView.Rows.Add(row);
            }
        }

        private string getStringDateFromDateTime(DateTime dateTime)
        {
            string date = dateTime.ToString().Split(' ')[0];
            string[] arr = date.Split('/');
            return arr[1] + "-" + arr[0] + "-" + arr[2];
        }

        private void comboBoxDeliverer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        

        private void setLanguage(Language language)
        {
            string key;

            key = "Deliverer";
            labelDeliverer.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "From";
            labelFrom.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "To";
            labelTo.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "ID";
            dataGridView.Columns["Id"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Date";
            dataGridView.Columns["Date"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
           
            key = "Deliverer name";
            dataGridView.Columns["DelivererName"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Show audit";
            buttonShowAudit.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "All";
            ALL = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Audit orders";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }

            foreach (ComboBox c in comboBoxes)
            {
                theme.set(c);
            }

            theme.set(dataGridView);
            theme.set(buttonShowAudit);
            // this.BackColor = theme.backgroundColor;
            theme.set(this);
        }

        private string ALL = "";
        private List<Label> labels;
        private List<ComboBox> comboBoxes;

        private void buttonShowAudit_Click(object sender, EventArgs e)
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
            
            int id = Int32.Parse(row.Cells[0].Value.ToString());
            Order order = Orders.Where(a => id == a.Id).First();

            foreach (Article ar in order.Articles)
            {
                Console.WriteLine($"{ar.Name}");
            }
            new ShowOrder(order).Show();
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }
    }
}
