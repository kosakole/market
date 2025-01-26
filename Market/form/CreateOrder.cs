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
    public partial class CreateOrder : Form, ChangeSettings
    {
        private List<Article> articles;
        private List<Article> articlesOrder = new List<Article>();
        public CreateOrder()
        {
            InitializeComponent();
            articles = new ArticleDAOImplementation().GetAll();
            init();
            chageSettings();
            FillGrid();
        }

        private void init()
        {
            textBoxAmount.Text = "1";
            textBoxBarcode.Select();
            List<Deliverer> deliverers = new DelivererDAOImplementation().GetAll();
            foreach (Deliverer deliverer in deliverers)
            {
                comboBoxDeliverer.Items.Add(deliverer);
            }
            comboBoxDeliverer.SelectedIndex = 0;
            labels = new List<Label>();
            textBoxes = new List<TextBox>();
            buttons = new List<Button>();

            labels.Add(labelBarcode);
            labels.Add(labelDeliverer);
            labels.Add(labelTotal);
            labels.Add(labelTotalValue);
            labels.Add(labelAmount);

            textBoxes.Add(textBoxBarcode);
            textBoxes.Add(textBoxAmount);

            buttons.Add(buttonDelete);
            buttons.Add(buttonSave);
            buttons.Add(buttonAdd);

        }


        private void FillGrid()
        {
            
            articles = new ArticleDAOImplementation().GetAll();
            dataGridViewArticles.Rows.Clear();
            string filterString = @"^.*" + textBoxBarcode.Text + ".*$";
            Regex regex = new Regex(filterString);
            foreach (Article article in articles.Where(a => regex.IsMatch(a.Barcode) || regex.IsMatch(a.Name)))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = article
                };
                row.CreateCells(dataGridViewArticles, article.Barcode, article.Name, article.Price, article.Amount);
                dataGridViewArticles.Rows.Add(row);
            }
        }

        private void FillGridOrder()
        {
            dataGridViewArticlesOrder.Rows.Clear();
            decimal total = 0;
            foreach (Article article in articlesOrder)
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = article
                };
                row.CreateCells(dataGridViewArticlesOrder, article.Barcode, article.Name, article.Price, article.Amount, article.Price * article.Amount);
                dataGridViewArticlesOrder.Rows.Add(row);
                total += article.Amount * article.Price;
            }
            labelTotalValue.Text = total.ToString();
        }

        private void buttinAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticles.SelectedRows.Count == 0)
                return;
            string barcode = dataGridViewArticles.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridViewArticles.SelectedRows[0].Cells[1].Value.ToString();
            string price = dataGridViewArticles.SelectedRows[0].Cells[2].Value.ToString();
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(textBoxAmount.Text);
                if (amount <= 0)
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
            foreach (Article article in articlesOrder)
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
                articlesOrder.Add(article);
            }
            FillGridOrder();
            textBoxAmount.Text = "1";
            textBoxBarcode.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (articlesOrder.Count == 0)
            {
                MessageBox.Show(NOT_ARTICLES_ON_ORDER, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Article articleForDelete = articlesOrder.Find(x => x.Barcode == dataGridViewArticlesOrder.SelectedRows[0].Cells[0].Value);
            articlesOrder.Remove(articleForDelete);
            FillGridOrder();
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
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

            foreach (TextBox tx in textBoxes)
            {
                theme.set(tx);
            }
            theme.set(comboBoxDeliverer);
            theme.set(dataGridViewArticles);
            theme.set(dataGridViewArticlesOrder);
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
            dataGridViewArticles.Columns["barcode"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewArticles.Columns["name"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price";
            dataGridViewArticles.Columns["Price"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Amount";
            dataGridViewArticles.Columns["amount"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Barcode";
            dataGridViewArticlesOrder.Columns["barcodeOrder"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewArticlesOrder.Columns["nameOrder"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price x1";
            dataGridViewArticlesOrder.Columns["priceOrder"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Amount";
            dataGridViewArticlesOrder.Columns["amountOrder"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price total";
            dataGridViewArticlesOrder.Columns["total"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Deliverer";
            labelDeliverer.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Delete";
            buttonDelete.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Save";
            buttonSave.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Create order";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "No articles on order!";
            NOT_ARTICLES_ON_ORDER = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Order is empty!";
            ORDER_IS_EMPTY = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Order printed!";
            ORDER_PRINTED = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Order did not print!";
            ORDER_DIDNT_PRINT = language.Words.ContainsKey(key) ? language.Words[key] : "";

        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Articles = articlesOrder;
            Deliverer deliverer = (Deliverer)comboBoxDeliverer.SelectedItem; 
            if(order.Articles.Count == 0) 
            {
                MessageBox.Show(NOT_ARTICLES_ON_ORDER, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (new OrderDAOImplementation().create(order, deliverer))
            {
                MessageBox.Show(ORDER_PRINTED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGrid();
                articlesOrder.Clear();
                FillGridOrder();
            }
            else
            {
                MessageBox.Show(ORDER_DIDNT_PRINT, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }
        private List<Label> labels;
        private List<Button> buttons;
        private List<TextBox> textBoxes;

        private string NOT_ARTICLES_ON_ORDER;
        private string ORDER_IS_EMPTY;
        private string ORDER_PRINTED;
        private string ORDER_DIDNT_PRINT;
    }
}
