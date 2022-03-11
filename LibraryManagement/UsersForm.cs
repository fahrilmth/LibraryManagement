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
    public partial class UsersForm : Form
    {
        private readonly PerpusDatabase _db;
        private RegisterForm _registForm;
        public UsersForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource =
                (
                from user in _db.Users
                select new
                {
                    user.Id,
                    user.Name,
                    user.Class,
                    user.Nis,
                    user.Departement
                }
                ).ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            this.Hide();
            RegisterForm reg = new RegisterForm();
            reg.Show();
        }

        private void DeleteData(User u)
        {
            _db.Users.Remove(u);
            _db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var uuu = _db.Users.Find(id);
            var c = MessageBox.Show($"Are you sure want to delete {uuu.Name}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (c == DialogResult.No)
                return;

            DeleteData(uuu);

            LoadData();
        }
    }
}
