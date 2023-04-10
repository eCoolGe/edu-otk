using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otk
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();

            textBoxPassword.Text = "Введите пароль!";
            textBoxPassword.ForeColor= Color.LightGray;

            textBoxLogin.Text = "Введите логин!";
            textBoxLogin.ForeColor = Color.LightGray;

            textBoxSurname.Text = "Введите фамилию!";
            textBoxSurname.ForeColor = Color.LightGray;

            textBoxName.Text = "Введите имя!";
            textBoxName.ForeColor = Color.LightGray;

        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Введите пароль!")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Введите пароль!";
                textBoxPassword.ForeColor = Color.LightGray;
            }
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Введите логин!")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.Black;
            }
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Введите логин!";
                textBoxLogin.ForeColor = Color.LightGray;
            }
        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Введите фамилию!")
            {
                textBoxSurname.Text = "";
                textBoxSurname.ForeColor = Color.Black;
            }
        }

        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Введите фамилию!";
                textBoxSurname.ForeColor = Color.LightGray;
            }
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Введите имя!")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.Black;
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Введите имя!";
                textBoxName.ForeColor = Color.LightGray;
            }
        }
    }
}
