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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    public partial class UpdateEmployee : Form, ChangeSettings
    {
        private UserDTO user;
        private static int minLength = 0;
        private static int maxLength = 20;
        public UpdateEmployee()
        {
            user = new UserDTO();
            InitializeComponent();
            init();
            chageSettings();
        }

        internal UpdateEmployee(UserDTO user):this()
        {
            this.user = user;
            checkBoxEmployed.Checked = user.Employed;
            textBoxID.Text = user.Id.ToString();
            textBoxName.Text = user.FirstName.ToString();   
            textBoxSurname.Text = user.LastName.ToString(); 
            textBoxUsername.Text = user.Username.ToString();
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            new ChangePassword(user).ShowDialog();
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Employed";
            labelEmployed.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "ID person";
            labelID.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Name";
            labelName.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Surname";
            labelSurname.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Update";
            buttonUpdate.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "ID used already";
            ID_USED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Username used already";
            USERNAME_USED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Updated";
            UPDATED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Error";
            ERROR = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Change password";
            buttonPassword.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";


            key = "Update";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        private bool chechInput()
        {
            Regex reg = new Regex(@"[0-9]{13}");

            if (!reg.IsMatch(textBoxID.Text.Trim()))
            {
                MessageBox.Show(Setting.GetSettings().Language.notValidFild("ID person"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!checkLength(textBoxName.Text.Trim(), minLength, maxLength, "Name"))
            {
                return false;
            }



            if (!checkLength(textBoxSurname.Text.Trim(), minLength, maxLength, "Surname"))
            {
                return false;
            }

            if (checkLength(textBoxUsername.Text.Trim(), minLength, maxLength, "Username"))
            {
                if(textBoxUsername .Text != user.Username) 
                {
                    List<UserDTO> users = new UserDAOImplementation().GetAll();
                    foreach (UserDTO user in users)
                    {
                        if (user.Username == textBoxUsername.Text.Trim())
                        {
                            MessageBox.Show(USERNAME_USED, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                
            }
            else
            {
                return false;
            }

            if(textBoxID.Text != user.Id.ToString())
            {
                UserDTO user1 = new UserDAOImplementation().GetUser(textBoxID.Text.Trim());
                if (user1 != null)
                {
                    MessageBox.Show(ID_USED, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            
            return true;
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

        
       

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UserDTO userNew = new UserDTO();
            if (!chechInput())
                return;
            userNew.Id = textBoxID.Text.Trim();
            userNew.FirstName = textBoxName.Text.Trim();
            userNew.LastName = textBoxSurname.Text.Trim();
            userNew.Username = textBoxUsername.Text.Trim();
            userNew.Employed = checkBoxEmployed.Checked;
            if(!new UserDAOImplementation().UpdateUser(userNew, user.Id.ToString()))
            {
                MessageBox.Show(ERROR, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                MessageBox.Show(UPDATED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonUpdate);
            theme.set(buttonPassword);
            theme.set(checkBoxEmployed);
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
            labels = new List<Label>();
            labels.Add(labelID);
            labels.Add(labelName);
            labels.Add(labelSurname);
            labels.Add(labelUsername);
            labels.Add(labelEmployed);

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBoxName);
            textBoxes.Add(textBoxID);
            textBoxes.Add(textBoxSurname);
            textBoxes.Add(textBoxUsername);
        }
        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Label> labels;
        private List<TextBox> textBoxes;

        private string ID_USED;
        private string USERNAME_USED;
        private string UPDATED;
        private string ERROR;
    }
}
