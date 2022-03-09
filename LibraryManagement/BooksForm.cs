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
        private enum Mode { None, Add, Edit}
        private Mode _m;
        public BooksForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            LoadData();

            comboBox1.DataSource = (from cu in _db.Categories select cu.Name).ToList();
            comboBox1.SelectedItem = null;
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

        private void EditData()
        {
            var usi = _db.Books.Find(textBoxID.Text);
            usi.Title = textBoxTit.Text;
            usi.Category = _db.Categories.First(c => c.Name == comboBox1.Text);

            _db.Books.Update(usi);
            _db.SaveChanges();
        }

        private void Clear()
        {
            textBoxID.Text = textBoxTit.Text = string.Empty;
            comboBox1.SelectedItem = null;
        }

        private void DeleteData(Book bu)
        {
            _db.Books.Remove(bu);
            _db.SaveChanges();
        }

        private bool Validate()
        {
            var probe = string.Empty;

            if (textBoxTit.Text == string.Empty)
                probe += "Add book title please";
            if (comboBox1.SelectedItem == null)
                probe += "Select the category please!";
            if (probe != string.Empty)
            {
                MessageBox.Show(probe, "Invalid data!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void AddData()
        {
            var b = new Book
            {
                Id = textBoxID.Text,
                Title = textBoxTit.Text,
                Category = _db.Categories.First(cat => cat.Name == comboBox1.Text)
            };

            _db.Books.Add(b);
            _db.SaveChanges();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = buttonDel.Enabled = false;
            groupBox1.Enabled = true;

            var id = _db.Books.OrderByDescending(buu => buu).FirstOrDefault()?.Id[2..];
            textBoxID.Text = id == null ? "BK0001" : $"BK{(int.Parse(id) + 1):D4}";

            _m = Mode.Add;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            buttonAdd.Enabled = buttonEdit.Enabled = buttonDel.Enabled = false;

            var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var buk = _db.Books.Find(id);
            buk.Category = _db.Categories.Find(buk.CategoryId);

            textBoxID.Text = buk.Id;
            textBoxTit.Text = buk.Title;
            comboBox1.SelectedItem = buk.Category.Name;

            _m = Mode.Edit;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var bbbb = _db.Books.Find(id);
            var tanya = MessageBox.Show($"Areyou sure want to delete {bbbb.Title} from list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (tanya == DialogResult.No)
                return;

            DeleteData(bbbb);
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            buttonAdd.Enabled = buttonEdit.Enabled = buttonDel.Enabled = true;

            if (!Validate())
            {
                return;
            }
            if (_m == Mode.Add)
            {
                AddData();
            }
            if (_m == Mode.Edit)
            {
                EditData();
            }
            if (_m == Mode.None)
                return;

            Clear();
            LoadData();
        }

        private void buttonCncl_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            buttonAdd.Enabled = buttonEdit.Enabled = buttonDel.Enabled = true;
            Clear();
        }
    }
}
