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
    public partial class AddArticle : Form, ChangeSettings
    {
        
        public AddArticle()
        {
            InitializeComponent();
            inint();
            chageSettings();
        }

        private bool checkArtiklAdd()
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
            key = "Add";
            buttonAdd.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Added";
            ADDED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Error";
            ERROR = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Barcode is used!";
            USED_BARCODE = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Add";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!checkArtiklAdd())
                return;
            
            Article newArticl = new Article();
            newArticl.Barcode = textBoxBarcode.Text;
            newArticl.Name = textBoxName.Text; ;
            newArticl.Price = Convert.ToDecimal(textBoxPrice.Text);
            newArticl.Amount = Convert.ToDecimal(textBoxAmount.Text);
            foreach(Article a in new ArticleDAOImplementation().GetAll())
            {
                if(a.Barcode == textBoxBarcode.Text)
                {
                    MessageBox.Show(USED_BARCODE, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            bool isAdded = new ArticleDAOImplementation().AddArticle(newArticl);
            
            if (isAdded)
            {
                MessageBox.Show(ADDED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(ERROR, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (TextBox t in textBoxes)
            {
                t.Text = "";
            }
        }

        public void changeTheme(Theme theme)
        {
            foreach(Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonAdd);
            foreach(TextBox t in textBoxes)
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

        private string ADDED;
        private string ERROR;
        private string USED_BARCODE;
    }
}
