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
    public partial class BooksForm : Form
    {
        private readonly PerpusDatabase _db;
        public BooksForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource =
                (
                from book in _db.Books
                join cat in _db.Categories
                on book.CategoryId equals cat.Id
                select new
                {
                    book.Id,
                    book.Title,
                    category = cat.Name
                }
                ).ToList();
        }
    }
}
