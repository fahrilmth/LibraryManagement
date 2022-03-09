using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class LoginForm : Form
    {
        private readonly PerpusDatabase _db;
        public LoginForm()
        {
            InitializeComponent();
            _db = new PerpusDatabase();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterForm rr = new RegisterForm();
            rr.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var u = _db.Users.FirstOrDefault(u => u.Name == textBoxEmail.Text && u.Nis == int.Parse(textBoxNIS.Text));

            if (u.Name != textBoxEmail.Text)
            {
                MessageBox.Show("Name not registered as member", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (u == null)
            {
                MessageBox.Show("Invalid account", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm reg = new RegisterForm();
            reg.Show();
        }
    }
}