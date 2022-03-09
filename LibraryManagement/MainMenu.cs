using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class MainMenu : Form
    {
        private readonly PerpusDatabase _db;
        
        public MainMenu()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadData();
            labelName.Text = LoginForm.CurrentUser;
        }

        private void LoadData()
        {
            dgvLoanData.DataSource =
                (
                from brw in _db.Borrowings
                join usr in _db.Users
                on brw.UserId equals usr.Id
                join book in _db.Books
                on brw.BookId equals book.Id
                select new
                {
                    brw.Id,
                    brw.Date,
                    user = usr.Name,
                    book = book.Title
                }
                ).ToList();
        }

        private void EditData()
        {
            var id = _db.Borrowings.Find();
        }

        private void buttonUserData_Click(object sender, EventArgs e)
        {
            UsersForm u = new UsersForm();
            u.Show();
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            BooksForm bk = new BooksForm();
            bk.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
