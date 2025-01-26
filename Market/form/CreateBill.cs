using Market.DAOImplementation;
using Market.DTO;
using Market.interfaces;
using Market.Languages;
using Market.model;
using Market.Settings;
using Market.Themes;
using System;
using System.Collections;
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
    public partial class CreateBill : Form, ChangeSettings
    {

        private CashDesk ChashDesk {  get; set; }
        private UserDTO Cashier { get; set; }

        private EmployeeCashDesk EmployeeCashDesk { get; set; }

        private List<Article> articles = new List<Article>();
        private List<Article> articlesOnBill = new List<Article>();

        private int ID;

        public CreateBill()
        {
            InitializeComponent();
            Cashier = new UserDTO();
            ChashDesk = new CashDesk();
            Cashier.Id = "3012999100010";
            Cashier.FirstName = "Hana";
            Cashier.LastName = "Budimlic";
            ChashDesk.Id = 2;
            EmployeeCashDesk = new EmployeeCashDeskDAOImplementation().getNext(Cashier, ChashDesk);
            articles = new ArticleDAOImplementation().GetAll();
            FillGrid();
            textBoxAmount.Text = "1";
            textBoxBarcode.Select();
            init();
            chageSettings();
        }

        internal CreateBill(EmployeeCashDesk ecd) : this()
        { 
            Cashier = ecd.User;
            ChashDesk = ecd.CashDesk;
            EmployeeCashDesk = new EmployeeCashDeskDAOImplementation().getNext(Cashier, ChashDesk);
        }


        private void init()
        {
            labels = new List<Label>();
            textBoxes = new List<TextBox>();
            buttons = new List<Button>();

            labels.Add(labelBarcode);
            labels.Add(labelTotal);
            labels.Add(labelAmount);
            labels.Add(labelBill);

            textBoxes.Add(textBoxAmount);
            textBoxes.Add(textBoxBarcode);

            buttons.Add(buttonSave);
            buttons.Add(buttonAdd);
            buttons.Add(buttonDelete);
            
        }
        private void FillGrid()
        {
            dataGridViewArticles.Rows.Clear();
            string filterString = @"^.*" + textBoxBarcode.Text  + ".*$"; 
            Regex regex = new Regex(filterString);
            foreach (Article article in articles.Where(a =>  regex.IsMatch(a.Barcode) || regex.IsMatch(a.Name)))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = article
                };
                row.CreateCells(dataGridViewArticles, article.Barcode, article.Name, article.Price);
                dataGridViewArticles.Rows.Add(row);
            }
        }
        private void FillGridForBill()
        {
            decimal total = 0;
            dataGridViewBill.Rows.Clear();
            foreach (Article article in articlesOnBill)
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = article
                };
                row.CreateCells(dataGridViewBill, article.Barcode, article.Name, article.Price, article.Amount, article.Price * article.Amount);
                dataGridViewBill.Rows.Add(row);
                total += article.Amount * article.Price;
            }
            labelBill.Text = total.ToString();

            if (articlesOnBill.Count > 0)
            {
                dataGridViewBill.Rows[0].Selected = false;
                dataGridViewBill.Rows[articlesOnBill.Count - 1].Selected = true;
            }
                
        }


        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string barcode;
            try
            {
                barcode = dataGridViewArticles.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
            string name = dataGridViewArticles.SelectedRows[0].Cells[1].Value.ToString();
            string price = dataGridViewArticles.SelectedRows[0].Cells[2].Value.ToString();
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(textBoxAmount.Text);
                if(amount <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                textBoxAmount.Text = "1";
                MessageBox.Show(Setting.GetSettings().Language.notNegativ("Amount"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool newArticle = true;
            foreach (Article article in articlesOnBill)
            {
                if (article.Barcode == barcode)
                {
                    newArticle = false;
                    article.Amount += amount;
                }
            }
            if (newArticle)
            {
                Article article = new Article(barcode, name, Convert.ToDecimal(price), amount);
                articlesOnBill.Add(article);
            }
            FillGridForBill();
            textBoxAmount.Text = "1";
            textBoxBarcode.Text = "";
        }

        private void textBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonAdd_Click(this, new EventArgs());
                
            }
        }

        private void textBoxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonAdd_Click(this, new EventArgs());
            }
        }

        private void dataGridViewArticles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonAdd_Click(this, new EventArgs());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (articlesOnBill.Count == 0)
            {
                MessageBox.Show(BILL_IS_EMPTY, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            Article articleForDelete = articlesOnBill.Find(x => x.Barcode == dataGridViewBill.SelectedRows[0].Cells[0].Value);
            articlesOnBill.Remove(articleForDelete);
            FillGridForBill();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Articles = articlesOnBill;
            bill.EmployeeCashDesk = EmployeeCashDesk;
            if(bill.Articles.Count == 0)
            {
                MessageBox.Show(NOT_ARTICLES_ON_BILL, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(new BillDAOImplementation().create(bill))
            {
                MessageBox.Show(BILL_PRINTED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                articlesOnBill.Clear();
                FillGridForBill();
            }
            else
            {
                MessageBox.Show(BILL_DIDNT_PRINT, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void changeTheme(Theme theme)
        {

            foreach (Label label in labels)
            {
                theme.set(label);
            }

            foreach (Button button in buttons)
            {
                theme.set(button);
            }

            foreach(TextBox tx in textBoxes)
            {
                theme.set(tx);
            }
            theme.set(dataGridViewArticles);
            theme.set(dataGridViewBill);
            theme.set(this);
            return;
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Barcode";
            labelBarcode.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Amount";
            labelAmount.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "From";
            

            key = "Barcode";
            dataGridViewArticles.Columns["Barcode"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewArticles.Columns["name"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price";
            dataGridViewArticles.Columns["Price"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
           
            key = "Barcode";
            dataGridViewBill.Columns["barcodeBill"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewBill.Columns["nameBill"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price x1";
            dataGridViewBill.Columns["priceOnBill"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Amount";
            dataGridViewBill.Columns["amountBill"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price total";
            dataGridViewBill.Columns["priceTotalOnBill"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Delete";
            buttonDelete.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Save";
            buttonSave.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Create bill";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "No articles on bill!";
            NOT_ARTICLES_ON_BILL = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Bill is empty!";
            BILL_IS_EMPTY = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Bill printed!";
            BILL_PRINTED = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Bill did not print!";
            BILL_DIDNT_PRINT = language.Words.ContainsKey(key) ? language.Words[key] : ""; 

        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Label> labels;
        private List<Button> buttons;
        private List<TextBox> textBoxes;

        private string NOT_ARTICLES_ON_BILL;
        private string BILL_IS_EMPTY;
        private string BILL_PRINTED;
        private string BILL_DIDNT_PRINT;
    }
}
