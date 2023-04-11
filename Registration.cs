using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace otk
{
    public partial class Registration : Form
    {
        private bool IsUser
        {
            get
            {
                bool been = false;

                string loginUser = textBoxLogin.Text;
                string nameUser = textBoxName.Text;
                string surnameUser = textBoxSurname.Text;

                DatabaseManager _databaseManager = new DatabaseManager();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UserLogin AND `name` = @UserName AND `surname` = @UserSurname", _databaseManager.GetConnection);

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = nameUser;
                _mySqlCommand.Parameters.Add("@UserSurname", MySqlDbType.VarChar).Value = surnameUser;

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;
                    if(MessageBox.Show("Такой пользователь уже есть!\nПерейти на форму входа?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Autorization form = new Autorization();
                        this.Hide();
                        form.Show();
                    }
                }

                return been;
            }
        }

        private bool IsLogin
        {
            get
            {
                bool been = false;

                string loginUser = textBoxLogin.Text;
                string passwordUser = textBoxPassword.Text;

                DatabaseManager _databaseManager = new DatabaseManager();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UserLogin AND `password` = @UserPassword", _databaseManager.GetConnection);

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = passwordUser;

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;
                    MessageBox.Show("Такой логин уже есть!\nПопробуйте другой логин", "Внимание"); 
                }

                return been;
            }
        }

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

        private void labelGoToAutorization_Click(object sender, EventArgs e)
        {
            Autorization form = new Autorization();
            this.Hide();
            form.Show();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Введите имя!" || textBoxSurname.Text == "Введите фамилию!" || textBoxLogin.Text == "Введите логин!" || textBoxPassword.Text == "Введите пароль!")
            {
                MessageBox.Show("Поля пусты либо введены неверно", "Внимание!");
                return;
            }
            if (!IsUser)
            {
                if (!IsLogin) 
                {
                    DatabaseManager _databaseManager = new DatabaseManager();
                    MySqlCommand _mySqlCommand = new MySqlCommand("INSERT INTO `users`(`login`, `password`, `name`, `surname`) VALUES (@login, @password, @name, @surname)", _databaseManager.GetConnection);

                    try
                    {
                        _mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text;
                        _mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBoxPassword.Text;
                        _mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text;
                        _mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text;

                        _databaseManager.OpenConnection();

                        if(_mySqlCommand.ExecuteNonQuery() == 1) 
                        {
                            MessageBox.Show("Аккаунт создан", "Внимание!");
                            DataForm form = new DataForm();
                            this.Hide();
                            form.Show();

                            User user = new User(textBoxLogin.Text);
                        }
                        else
                            MessageBox.Show("Ошибка создания аккаунта", "Ошибка!");
                    } 
                    catch 
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally 
                    { 
                        _databaseManager.CloseConnection(); 
                    }
                }
            }
        }
    }
}
