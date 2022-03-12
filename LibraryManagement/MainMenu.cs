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

            labelName.Text = LoginForm.CurrentName;
            labelClass.Text = LoginForm.CurrentClass;
            labelDepartement.Text = LoginForm.CurrentDepart;

            groupBox1.Enabled = false;

            comboBoxUser.DataSource = (from u in _db.Users select u.Name).ToList();
            comboBoxUser.SelectedItem = null;

            comboBoxBook.DataSource = (from b in _db.Books select b.Title).ToList();
            comboBoxBook.SelectedItem = null;
           

            //dgvLoanData.Columns.Add(new DataGridViewCheckBoxColumn()
            //{
            //    HeaderText = "Status",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            //});
        }

        private void LoadData()
        {
            dgvLoanData.DataSource =
                (
                from brw in _db.Borrowings
                where brw.Book.Title.Contains(textBox1.Text) || brw.User.Name.Contains(textBox1.Text)
                select new
                {
                    brw.Id,
                    brw.Date,
                    user = brw.User.Name,
                    book = brw.Book.Title,
                }
                ).ToList();

            /*var a = dgvLoanData.Rows[0];
            
            foreach (DataGridViewRow item in dgvLoanData.Rows)
            {
                var colValue = item.Cells[0].Value as string;

                if (colValue.ToString().Contains("5"))
                {
                    a.DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.Red
                    };
                }
            }*/

            /*dgvLoanData.DataSource =
                (
                from b in _db.Borrowings
                from u in _db.Users
                from bu in _db.Books
                orderby b.Id
                select new
                {
                    b.Id,
                    b.Book,
                    u.Name,
                    u.Class,
                    u.Nis,
                    u.Departement,
                    u.Borrowings,
                    bu.Title,
                    bu.Category
                }
                ).ToList();
            */


        }

        /*private void EditData()
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
            comboBoxUser.SelectedItem = comboBoxBook.SelectedItem = null;
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
                problem += " Pick a date";
            if (comboBoxUser.SelectedItem == null)
                problem += " Select a user";
            if (comboBoxBook.SelectedItem == null)
                problem += " Select a book to be borrowed";
            if (problem != string.Empty)
            {
                MessageBox.Show(problem, "Invalid data!");
                return false;
            }
            return true;
        }

        private void buttonUserData_Click(object sender, EventArgs e)
        {
            Hide();
            UsersForm u = new UsersForm();
            u.Show();
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            Hide();
            BooksForm bk = new BooksForm();
            bk.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonCat_Click(object sender, EventArgs e)
        {
            Hide();
            CategoryForm c = new CategoryForm();
            c.Show();
        }

        private void dgvLoanData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4 || e.RowIndex < 0)
                return;

            dgvLoanData.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //ganti warna kolom 
            /*DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.Green;
            dgvLoanData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = cellStyle;*/
        }

        private void buttonNewBorr_Click(object sender, EventArgs e)
        {
            buttonNewBorr.Enabled = buttonDelete.Enabled = false;
            groupBox1.Enabled = true;

            var id = _db.Borrowings.OrderByDescending(bor => bor).FirstOrDefault()?.Id[2..];
            textBoxID.Text = id == null ? "BR01" : $"BR{(int.Parse(id) + 1):D2}";

            _mode = Mode.Add;

            //<--- perulangan --->//
            /*foreach (DataGridViewRow row in dgvLoanData.Rows)
            {
                MessageBox.Show(row.Cells[0].Value.ToString());
            }
            for (int i = 0; i < dgvLoanData.Rows.Count; i++)
            {
                var row = dgvLoanData.Rows[i];
                MessageBox.Show(row.Cells[0].Value.ToString());
            }*/
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
            buttonNewBorr.Enabled = buttonDelete.Enabled = buttonEdit.Enabled = true;
            groupBox1.Enabled = false;

            if (!Validate())
            {
                Clear();
                return;
            }
            if (_mode == Mode.Add)
            {
                AddData();
                Clear();
            }
            if (_mode == Mode.Edit)
            {
                EditData();
                Clear();
            }
            if (_mode == Mode.None)
            {
                return;
            }

            Clear();
            LoadData();
        }

        private void dgvLoanData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvLoanData.RowCount <= 0)
                return;

            if (e.ColumnIndex==4)*/
                MessageBox.Show(dgvLoanData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void EditData()
        {
            var borrow = _db.Borrowings.Find(textBoxID.Text);

            borrow.Date = dateTimePicker1.Value.Date;
            borrow.User = _db.Users.First(us => us.Name == comboBoxUser.Text);
            borrow.Book = _db.Books.First(buk => buk.Title == comboBoxBook.Text);

            _db.Borrowings.Update(borrow);
            _db.SaveChanges();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            buttonNewBorr.Enabled = buttonEdit.Enabled = false;

            var id = dgvLoanData.SelectedRows[0].Cells[0].Value.ToString();
            var b = _db.Borrowings.Find(id);
            b.Book = _db.Books.Find(b.BookId);
            b.User = _db.Users.Find(b.UserId);

            textBoxID.Text = b.Id;
            dateTimePicker1.Value = b.Date;
            comboBoxBook.SelectedItem = b.Book.Title;
            comboBoxUser.SelectedItem = b.User.Name;

            _mode = Mode.Edit;
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
