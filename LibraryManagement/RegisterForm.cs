using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class RegisterForm : Form
    {
        private readonly PerpusDatabase _db;
        public RegisterForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            var id = _db.Users.OrderByDescending(us => us).FirstOrDefault()?.Id[1..];
            textBoxID.Text = id == null ? "U000001" : $"U{(int.Parse(id) + 1):D6}";
        }

        private bool ValidateData()
        {
            var errors = string.Empty;

            if (textBoxName.Text == string.Empty)
                errors += "Name can not be empty!";
            if (textBoxClass.Text == string.Empty)
                errors += "Class can be empty!";
            if (textBoxNIS.Text == string.Empty)
                errors += "NIS can not be empty";
            else if (!int.TryParse(textBoxNIS.Text, out int nis) || nis < 0 )
                errors += "Write your valid NIS";
            if (comboBoxDepart == null)
                errors += "Select your departement";
            if (pictureBox1 == null)
                errors += "You have to change your profile picture";
            if (errors != string.Empty)
            {
                MessageBox.Show(errors, "Registration Failed");
                return false;
            }
            return true;
        }

        private void AddDatabase()
        {
            var users = new User
            {
                Id = textBoxID.Text,
                Name = textBoxName.Text,
                Class = textBoxClass.Text,
                Nis = int.Parse(textBoxNIS.Text),
                Departement = comboBoxDepart.SelectedItem.ToString()
            };

            _db.Users.Add(users);
            _db.SaveChanges();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            AddDatabase();

            this.Hide();
            LoginForm l = new LoginForm();
            l.Show();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            string path = "";

            try
            {
                OpenFileDialog pict = new OpenFileDialog();
                pict.Filter = "Picture (*.jpg)|*.jpg|*.png|*.jpeg";

                if (pict.ShowDialog() == DialogResult.OK)
                {
                    path = pict.FileName;

                    pictureBox1.ImageLocation = path;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured when trying to upload picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
