using Market.DAOImplementation;
using Market.DTO;
using Market.interfaces;
using Market.Languages;
using Market.model;
using Market.Settings;
using Market.Themes;
using MySqlX.XDevAPI.Relational;
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
    public partial class UpdateArticleForm : Form, ChangeSettings
    {

        private const int MIN = 0;
        private const int MAX = 20;
        private Article orginalArticle;
        public UpdateArticleForm()
        {
            InitializeComponent();
            inint();
            chageSettings();
        }

        public UpdateArticleForm(Article article) : this()
        {
            orginalArticle = article;
            textBoxBarcode.Text = article.Barcode;
            textBoxName.Text = article.Name;
            textBoxPrice.Text = article.Price.ToString();
            textBoxAmount.Text = article.Amount.ToString();
        }

        private bool checkArticlForUpdate()
        {
            if (textBoxBarcode.Text.Length == 0)
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild("Barcode"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxName.Text.Length == 0)
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild("Name"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxPrice.Text.Length == 0)
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild("Name"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                decimal price = Convert.ToDecimal(textBoxPrice.Text);
                if (price < 0)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Setting.GetSettings().Language.notNegativ("Price"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                decimal amount = Convert.ToDecimal(textBoxAmount.Text);
                if (amount < 0)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Setting.GetSettings().Language.notNegativ("Amount"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Article article = new Article();
            string barcodeOld = orginalArticle.Barcode;
            article.Barcode = textBoxBarcode.Text;
            article.Name = textBoxName.Text;
            if(barcodeOld != textBoxBarcode.Text)
            {
                foreach(Article a in new ArticleDAOImplementation().GetAll())
                {
                    if(a.Barcode == article.Barcode)
                    {
                        MessageBox.Show(USED_BARCODE, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            try
            {
                article.Price = decimal.Parse(textBoxPrice.Text);
            }
            catch (Exception)
            {
                article.Price = 0;
                MessageBox.Show(Setting.GetSettings().Language.notNegativ("Price"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                article.Amount = decimal.Parse(textBoxAmount.Text);

            }
            catch (Exception)
            {
                article.Amount = 0;
                MessageBox.Show(Setting.GetSettings().Language.notNegativ("Amount"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkArticlForUpdate()) 
            {
                if (new ArticleDAOImplementation().UpdateArticle(article, barcodeOld))
                {
                    MessageBox.Show(UPDATED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show(ERROR, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                return;
            }
            this.Close();
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Barcode";
            labelBarcode.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Name";
            labelName.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Amount";
            labelAmount.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Price";
            labelPrice.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Update";
            buttonUpdate.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Update";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Barcode is used!";
            USED_BARCODE = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Error";
            ERROR = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Updated";
            UPDATED = language.Words.ContainsKey(key) ? language.Words[key] : "";

        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonUpdate);
            foreach (TextBox t in textBoxes)
            {
                theme.set(t);
            }
            theme.set(this);
            return;
        }

        private void inint()
        {
            labels = new List<Label>();
            labels.Add(labelBarcode);
            labels.Add(labelName);
            labels.Add(labelPrice);
            labels.Add(labelAmount);

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBoxBarcode);
            textBoxes.Add(textBoxName);
            textBoxes.Add(textBoxPrice);
            textBoxes.Add(textBoxAmount);
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Label> labels;
        private List<TextBox> textBoxes;

        private string USED_BARCODE;
        private string UPDATED;
        private string ERROR;
    }
}
