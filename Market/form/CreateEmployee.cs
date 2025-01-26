using Market.DAOImplementation;
using Market.form;
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
using System.Xml.Linq;

namespace Market
{
    public partial class CreateEmployee : Form, ChangeSettings
    {

        private static int minLength = 0;
        private static int maxLength = 20;
        private List<UserDTO> users = new List<UserDTO>(); 
        public CreateEmployee()
        {
            InitializeComponent();
            init();
            
            chageSettings();
            FillGrid();
        }

        private void init()
        {
            buttons = new List<Button>();
            buttons.Add(buttonUpdate); 
            buttons.Add(buttonDelete);
            buttons.Add(buttonAdd);
            buttons.Add(buttonRefresh);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
     
            UserDTO selectedUser = new UserDTO();
            DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
            selectedUser.Id = row.Cells[0].Value.ToString();
            selectedUser.FirstName = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            selectedUser.LastName = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString(); ;
            selectedUser.Username = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString(); ;
            selectedUser.Employed = row.Cells[4].Value == null ? false : row.Cells[4].Value.ToString() == YES ? true : false; ;
            new UpdateEmployee(selectedUser).ShowDialog();
            FillGrid();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (users.Count == 0)
                return;
            UserDTO selectedUser = new UserDTO();
            DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
            if (row == null)
                return;
            selectedUser.Id = row.Cells[0].Value.ToString();
            new UserDAOImplementation().DeleteUser(selectedUser);
            FillGrid();
        }

       

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new AddEmployee().ShowDialog();
            FillGrid();
        }

        private void FillGrid()
        {
            dataGridViewUsers.Rows.Clear();
            users = new UserDAOImplementation().GetAll();
            foreach (UserDTO o in users)
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = o
                };
                row.CreateCells(dataGridViewUsers, o.Id, o.FirstName, o.LastName, o.Username, o.Employed ? YES : NO);
                dataGridViewUsers.Rows.Add(row);
            }
        }

        private void buttonUpdateAll_Click(object sender, EventArgs e)
        {
        }

        public void changeTheme(Theme theme)
        {
            foreach (Button button in buttons)
            {
                theme.set(button);
            }
            theme.set(dataGridViewUsers);
            theme.set(this);
            return;
        }

        private void setLanguage(Language language)
        {
            string key;


            key = "ID person";
            dataGridViewUsers.Columns["ID"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Name";
            dataGridViewUsers.Columns["NameC"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Surname";
            dataGridViewUsers.Columns["Surname"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Username";
            dataGridViewUsers.Columns["Username"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Employed";
            dataGridViewUsers.Columns["Employed"].HeaderText = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
           
            key = "Delete employee";
            buttonDelete.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Add employee";
            buttonAdd.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Update employee";
            buttonUpdate.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
            key = "Refresh";
            buttonRefresh.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Employees";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;

            key = "Yes";
            YES = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "No";
            NO = language.Words.ContainsKey(key) ? language.Words[key] : ""; ;
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
        }

        private string YES;
        private string NO;
        private List<Button> buttons;
    }
}
