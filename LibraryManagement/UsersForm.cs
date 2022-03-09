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
        public UsersForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void UsersForm_Load(object sender, EventArgs e)
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
    }
}
