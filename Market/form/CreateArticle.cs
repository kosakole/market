using Market.DAOImplementation;
using Market.DTO;
using Market.interfaces;
using Market.Languages;
using Market.model;
using Market.Settings;
using Market.Themes;
using MySqlX.XDevAPI.Relational;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Market.form
{
    public partial class CreateArticle : Form, ChangeSettings
    {
        private const int MIN = 0;
        private const int MAX = 20;

        private List<Article> articles = new List<Article>();
        public CreateArticle()
        {
            InitializeComponent();
            init();
            FillGrid();
            chageSettings();
        }

        private void init()
        {
            buttons = new List<Button>();
            buttons.Add(buttonUpdate);
            buttons.Add(buttonDelete);
            buttons.Add(buttonAdd);
            buttons.Add(buttonRefresh);
        }
        private void FillGrid()
        {
            articles = new ArticleDAOImplementation().GetAll();
            dataGridViewArticles.Rows.Clear();
            foreach (Article art in articles)
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = art
                };
                row.CreateCells(dataGridViewArticles, art.Barcode, art.Name, art.Price.ToString(), art.Amount.ToString());
                dataGridViewArticles.Rows.Add(row);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new AddArticle().ShowDialog();
            FillGrid();
        }
 
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Article article = new Article();
            DataGridViewRow row = dataGridViewArticles.SelectedRows[0];
            article.Barcode = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
            article.Name = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();

            try
            { 
                article.Price = decimal.Parse(row.Cells[2].Value == null ? "0" : row.Cells[2].Value.ToString());
            }
            catch (Exception)
            {
                article.Price = 0;
                MessageBox.Show("Price is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            try
            {
                article.Amount = decimal.Parse(row.Cells[3].Value == null ? "0" : row.Cells[3].Value.ToString());

            }
            catch (Exception)
            {
                article.Amount = 0;
                article.Price = 0;
                MessageBox.Show("Amount is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new UpdateArticleForm(article).ShowDialog();
            FillGrid();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Article article = new Article();
            if (articles.Count == 0)
                return;
            DataGridViewRow row = dataGridViewArticles.SelectedRows[0];
            if (row == null)
                return;
            article.Barcode = row.Cells[0].Value.ToString();
            if(new ArticleDAOImplementation().DeleteArticle(article))
            {
                MessageBox.Show(DELETED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(NOT_DELETED, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            FillGrid();
        }

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Barcode";
            dataGridViewArticles.Columns["Barcode"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewArticles.Columns["NameC"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Price";
            dataGridViewArticles.Columns["Price"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Amount";
            dataGridViewArticles.Columns["Amount"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Articles";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Add";
            buttonAdd.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Update";
            buttonUpdate.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Delete";
            buttonDelete.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Refresh";
            buttonRefresh.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Deleted";
            DELETED = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Not deleted";
            NOT_DELETED = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
        }

        public void changeTheme(Theme theme)
        {
            foreach(Button button in buttons)
            {
                theme.set(button);
            }
            theme.set(dataGridViewArticles);
            theme.set(this);
            return;
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Button> buttons;
        private string DELETED;
        private string NOT_DELETED;
    }
}
