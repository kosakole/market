using Market.DAOImplementation;
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
    public partial class AddEmployee : Form, ChangeSettings
    {

        private static int minLength = 0;
        private static int maxLength = 20;
        private List<UserDTO> users;
        public AddEmployee()
        {
            InitializeComponent();
            init();
            chageSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.Id = textBoxID.Text.Trim();
            newUser.FirstName = textBoxFirstName.Text.Trim();
            newUser.LastName = textBoxLastName.Text.Trim();
            newUser.Username = textBoxUsername.Text.Trim();
            newUser.Password = textBoxPassword.Text.Trim();
            if (chechInput())
            {
                if (new UserDAOImplementation().AddUser(newUser))
                {
                    MessageBox.Show(ADDED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTextFields();
                }
                else
                {
                    MessageBox.Show(ERROR, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool chechInput()
        {
            Regex reg = new Regex(@"[0-9]{13}");
            
            // if (textBoxID.Text.Trim().Length != 13)
            if(!reg.IsMatch(textBoxID.Text.Trim()))
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild("ID person"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
      
            if (!checkLength(textBoxFirstName.Text.Trim(), minLength, maxLength, "Name"))
            {
                return false;
            }



            if (!checkLength(textBoxLastName.Text.Trim(), minLength, maxLength, "Surname"))
            {
                return false;
            }

            if (checkLength(textBoxUsername.Text.Trim(), minLength, maxLength, "Username"))
            {
                foreach (UserDTO user in users)
                {
                    if (user.Username == textBoxUsername.Text.Trim())
                    {
                        MessageBox.Show(USED_USERNAME, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            if (!checkLength(textBoxPassword.Text.Trim(), minLength, maxLength, "Password"))
            {
                return false;
            }

            if (textBoxPassword.Text.Trim() != textBoxConPassword.Text.Trim())
            {
                MessageBox.Show(PASSWORD, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            UserDTO user1 = new UserDAOImplementation().GetUser(textBoxID.Text.Trim());
            if (user1 != null)
            {
                MessageBox.Show(USED_ID, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void clearTextFields()
        {
            textBoxID.Text = string.Empty;
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxConPassword.Text = string.Empty;
        }

        private bool checkLength(string input, int min, int max, string name)
        {
            if (input.Length == 0)
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild(name), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool checkUser(UserDTO user)
        {
            if (!checkLength(user.FirstName, minLength, maxLength, "Name"))
            {
                return false;
            }

            if (!checkLength(user.LastName, minLength, maxLength, "Surname"))
            {
                return false;
            }

            if (!checkLength(user.Username, minLength, maxLength, "Username"))
            {
                return false;
            }
            return true;
        }

        private void textBoxConPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AddEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AddEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "ID person";
            labelID.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Name";
            labelFirstName.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Surname";
            labelLastName.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Password";
            labelPassword.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Confirm password";
            labelConPassword.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Save";
            buttonSave.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Add";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Added";
            ADDED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Error";
            ERROR = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Username used already";
            USED_USERNAME = language.Words.ContainsKey(key) ? language.Words[key] : "";
            
            key = "ID used already";
            USED_ID = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Password is not same";
            PASSWORD = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonSave);
            foreach (TextBox t in textBoxes)
            {
                theme.set(t);
            }
            theme.set(this);
            return;

            return;
        }

        private void init()
        {
            users = new UserDAOImplementation().GetAll();

            labels = new List<Label>();
            labels.Add(labelID);
            labels.Add(labelFirstName);
            labels.Add(labelLastName);
            labels.Add(labelUsername);
            labels.Add(labelPassword);
            labels.Add(labelConPassword);

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBoxConPassword);
            textBoxes.Add(textBoxID); 
            textBoxes.Add(textBoxFirstName); 
            textBoxes.Add(textBoxLastName);
            textBoxes.Add(textBoxUsername);
            textBoxes.Add(textBoxPassword);

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
        private string USED_ID;
        private string USED_USERNAME;
        private string PASSWORD;
    }
}
