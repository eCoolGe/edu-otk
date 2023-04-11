using MySql.Data.MySqlClient;
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
    public partial class Autorization : Form
    {
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
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UserLogin", _databaseManager.GetConnection);

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;
                }

                return been;
            }
        }

        public Autorization()
        {
            InitializeComponent();
        }

        private void labelGoToRegistration_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            this.Hide();
            form.Show();
        }

        private void buttonAutorization_Click(object sender, EventArgs e)
        {
            string loginUser = textBoxLogin.Text;
            string passwordUser = textBoxPassword.Text;

            DatabaseManager _databaseManager = new DatabaseManager();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UserLogin AND `password` = @UserPassword", _databaseManager.GetConnection);


            try
            {
                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = passwordUser;

                _databaseManager.OpenConnection();

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    DataForm form = new DataForm();
                    this.Hide();
                    form.Show();

                    User user = new User(loginUser);
                }
                else
                {
                    if (IsLogin)
                        MessageBox.Show("Неправильный пароль", "Внимание!");
                    else
                    {
                        if(MessageBox.Show("Вы у нас впервые\nНеобходимо зарегистрироваться!\nЗарегистрироваться сейчас?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Registration form = new Registration();
                            this.Hide();
                            form.Show();
                        }
                    }
                }
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
