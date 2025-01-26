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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    public partial class Login : Form, ChangeSettings
    {
        private bool isAdmin;
        public Login()
        {
            InitializeComponent();
            init();
            chageSettings();
        }

        internal Login(bool isAdmin): this()
        {
            this.isAdmin = isAdmin;
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Password";
            labelPassword.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "New password";
            
            key = "Login";
            buttonLogin.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Login";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Error";
            ERROR = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Mesage for login";
            MESSAGE_CAN_NOT_LOG = language.Words.ContainsKey(key) ? language.Words[key] : "";


        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonLogin);
            foreach (TextBox t in textBoxes)
            {
                theme.set(t);
            }
            theme.set(this);
            return;
        }

        private void init()
        {
            labels = new List<Label>();
            labels.Add(labelUsername);
            labels.Add(labelPassword);
            
            textBoxes = new List<TextBox>();
            textBoxes.Add(textBoxPassword);
            textBoxes.Add(textBoxUsername);
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Label> labels;
        private List<TextBox> textBoxes;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                if(new AdminDAOImplemetation().check(textBoxUsername.Text, textBoxPassword.Text)) 
                {
                    UserDTO user = new UserDTO();
                    user.Username = textBoxUsername.Text;
                    this.Hide();
                    new AdminApp(user).ShowDialog();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show(MESSAGE_CAN_NOT_LOG, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                UserDTO user = new UserDAOImplementation().GetUser(textBoxUsername.Text, textBoxPassword.Text);
                if (user == null)
                {
                    MessageBox.Show(MESSAGE_CAN_NOT_LOG, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    new EmployeeApp(user).ShowDialog();
                    this.Close();
                }    
                
            }


        }
        private string ERROR;
        private string MESSAGE_CAN_NOT_LOG;
    }
}
