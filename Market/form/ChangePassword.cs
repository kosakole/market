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
    public partial class ChangePassword : Form, ChangeSettings
    {
        private static int minLength = 0;
        private static int maxLength = 20;
        private UserDTO user;
        public ChangePassword()
        {
            InitializeComponent();
            init();
            chageSettings();
        }

        internal ChangePassword(UserDTO user) : this()
        {
            this.user = user;
            labelIDValue.Text = user.Id.ToString();
            labelUsernameValue.Text = user.Username.ToString();
            //setLanguage(new Language("srb1"));
        }

        private void init()
        {
            labels = new List<Label>();
            labels.Add(labelId);
            labels.Add(labelIDValue);
            labels.Add(labelNewPass1);
            labels.Add(labelUsername);
            labels.Add(labelNewPass2);
            labels.Add(labelUsernameValue);

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBoxNewPass1);
            textBoxes.Add(textBoxNewPass2);
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }
            theme.set(buttonChange);
            foreach (TextBox t in textBoxes)
            {
                theme.set(t);
            }
            theme.set(this);
            return;
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "ID person";
            labelId.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Username";
            labelUsername.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "New password";
            labelNewPass1.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Confirm";
            labelNewPass2.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Confirm";
            buttonChange.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Password is not same";
            PASS_IS_NOT_SAME = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Changed";
            CHANGED = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Change password";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (!checkLength(textBoxNewPass1.Text.Trim(), minLength, maxLength, "Password"))
            {
                return ;
            }

            if (textBoxNewPass1.Text.Trim() != textBoxNewPass2.Text.Trim())
            {
                MessageBox.Show(PASS_IS_NOT_SAME, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            if (new UserDAOImplementation().changePassword(user, textBoxNewPass1.Text))
            {
                MessageBox.Show(CHANGED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(ERROR, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private List<Label> labels;
        private List<TextBox> textBoxes;

        private string ERROR;
        private string PASS_IS_NOT_SAME;
        private string CHANGED;
    }
}
