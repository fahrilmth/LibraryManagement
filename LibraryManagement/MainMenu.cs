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
using System.Data.OleDb;

namespace LibraryManagement
{
    public partial class MainMenu : Form
    {
        private readonly PerpusDatabase _db;
        public string status = "OnGoing";
        private enum Mode {None, Add, Edit }
        private Mode _mode;
        private Borrowing _br;

        public MainMenu()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
            _mode = Mode.None;
            _br = new Borrowing();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadData();
            labelName.Text = LoginForm.CurrentUser;

            comboBoxUser.DataSource = (from u in _db.Users select u.Name).ToList();
            comboBoxUser.SelectedItem = null;

            comboBoxBook.DataSource = (from b in _db.Books select b.Title).ToList();
            comboBoxBook.SelectedItem = null;

            dgvLoanData.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = status,
                HeaderText = "Status",
                UseColumnTextForButtonValue = true
            });
        }

        private void LoadData()
        {
            dgvLoanData.DataSource =
                (
                from brw in _db.Borrowings
                select new
                {
                    brw.Id,
                    brw.Date,
                    user = brw.User.Name,
                    book = brw.Book.Title,
                }
                ).ToList();

            
        }

        private void AddButton()
        {
            dgvLoanData.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = status,
                HeaderText = "Status",
                UseColumnTextForButtonValue = true
            });
        }

/*        private void EditData()
        {
            var b = _db.Borrowings.Find(textBoxID.Text);

            b.Id = textBoxID.Text;
            b.Date = Convert.ToDateTime(dateTimePicker1. Text);
            b.Book = _db.Books.First(b => b.Title == comboBoxBook.Text);
            b.User = _db.Users.First(u => u.Name == comboBoxUser.Text);

            _db.Borrowings.Update(b);
            _db.SaveChanges();
        }*/

        private void AddData()
        {
            var bo = new Borrowing
            {
                Id = textBoxID.Text,
                Date = Convert.ToDateTime(dateTimePicker1.Text),
                User = _db.Users.First(us => us.Name == comboBoxUser.Text),
                Book = _db.Books.First(bu => bu.Title == comboBoxBook.Text)
            };
            _db.Borrowings.Add(bo);
            _db.SaveChanges();
        }

        private void Clear()
        {
            textBoxID.Text = dateTimePicker1.Text = String.Empty;
            comboBoxUser.SelectedItem = comboBoxUser.SelectedItem = null;
        }

        private void DeleteData(Borrowing brw)
        {
            _db.Borrowings.Remove(brw);
            _db.SaveChanges();
        }

        private bool Validate()
        {
            var problem = string.Empty;

            if (dateTimePicker1.Text == string.Empty)
                problem += "Pick a date";
            if (problem != string.Empty)
            {
                MessageBox.Show(problem, "Invalid data!");
                return false;
            }
            return true;
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

        private void buttonCat_Click(object sender, EventArgs e)
        {
            CategoryForm c = new CategoryForm();
            c.Show();
        }

        private void dgvLoanData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
                return;
            if (e.RowIndex < 0)
                return;
            status = "Completed";   
            
        }

        private void buttonNewBorr_Click(object sender, EventArgs e)
        {
            buttonNewBorr.Enabled = buttonDelete.Enabled = false;
            groupBox1.Enabled = true;

            var id = _db.Borrowings.OrderByDescending(bor => bor).FirstOrDefault()?.Id[2..];
            textBoxID.Text = id == null ? "BR01" : $"BR{(int.Parse(id) + 1):D2}";

            _mode = Mode.Add;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dgvLoanData.SelectedRows[0].Cells[0].Value.ToString();
            var bro = _db.Borrowings.Find(id);
            var c = MessageBox.Show("Are you sure want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (c == DialogResult.No)
                return;

            DeleteData(bro);
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonNewBorr.Enabled = buttonDelete.Enabled = true;
            groupBox1.Enabled = false;

            if (!Validate())
                return;
            if (_mode == Mode.Add)
                AddData();
            if (_mode == Mode.None)
                return;

            AddButton();
            Clear();
            LoadData();
        }
    }
}
