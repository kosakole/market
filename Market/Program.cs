using Market;
using Market.DAO;
using Market.DAOImplementation;
using Market.form;
using Market.model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    internal static class Program
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // string s = "";
            // string dt = DateTime.Now.ToString();
            // string[] dateTime = dt.Split(' ');
            // string[] date = dateTime[0].Split('/');
            // s = date[2] + "-" + date[1] + "-" + date[0] + " " + dateTime[1];
            // Console.WriteLine(s)

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new CreateEmployee());
            // Application.Run(new CreateOrder());
            // Application.Run(new CreateBill());
            // Application.Run(new UpdateArticleForm());
            // Application.Run(new UpdateEmployee());
            // Application.Run(new CreateArticle());
            // Application.Run(new AuditBills());
            // Application.Run(new AuditOrders());
            // Application.Run(new ChangePassword());
            // Application.Run(new AddArticle());
            // Application.Run(new AddEmployee());
            // Application.Run(new AuditLogin());
            // Application.Run(new ShowOrder());
            // Application.Run(new Login
            // Application.Run(new FirstForm());
             Application.Run(new FirstForm());
        }
    }
}

