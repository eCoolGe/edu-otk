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
    public partial class DataForm : Form
    {
        private User user;

        public DataForm()
        {
            InitializeComponent();
        }

        private void HeaderOfTheTable()
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер";
            column1.Width = 100;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Спецификация";
            column2.Width = 100;
            column2.Name = "specification";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Информация";
            column3.Width = 400;
            column3.Name = "information";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Сроки";
            column4.Width = 120;
            column4.Name = "time_constraints";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);

            dataGridView1.AllowUserToAddRows= false;
            dataGridView1.ReadOnly = true;
        }

        private void AddDataGrid(RowOfData row) 
        {
            dataGridView1.Rows.Add(row.id, row.specification, row.information, row.time_constraints);
        }

        private void DataForm_Shown(object sender, EventArgs e)
        {
            user = new User();

            HeaderOfTheTable();
            List<RowOfData> _data = new List<RowOfData>();

            DatabaseManager _databaseManager = new DatabaseManager();
            MySqlCommand _command = new MySqlCommand("SELECT * FROM `projects`", _databaseManager.GetConnection);
            MySqlDataReader _reader;

            try
            {
                _databaseManager.OpenConnection();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    RowOfData row = new RowOfData(_reader["id"], _reader["specification"], _reader["information"], _reader["time_constraints"]);
                    _data.Add(row);
                }

                for (int i = 0; i < _data.Count; i++)
                {
                    AddDataGrid(_data[i]);
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа демонстрирует возможности работы с WindowsForms, C# и MySQL. \n" +
                "А так же пример создания базы данных на основе этих инструментов. \n" +
                "Данное окно показывает возможность отображения данных, загруженных с сервера", "Информация о программе");
        }

        private void выходИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходВОкноРегистрацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            this.Hide();
            form.Show();
        }

        private void выходВОкноВходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autorization form = new Autorization();
            this.Hide();
            form.Show();
        }

        private void редактироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.userName == "admin" || user.userName == "editor" || user.userName == "love")
            {
                if (MessageBox.Show("Перейти в окно редактированния данных?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataUploadForm form = new DataUploadForm();
                    this.Hide();
                    form.Show();
                }
            }
            else
                MessageBox.Show("У вас нет доступа, чтобы совершить это действие", "Ошибка!");
        }

        private void обновитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RowOfData> _data = new List<RowOfData>();

            DatabaseManager _databaseManager = new DatabaseManager();
            MySqlCommand _command = new MySqlCommand("SELECT * FROM `projects`", _databaseManager.GetConnection);
            MySqlDataReader _reader;

            _databaseManager.OpenConnection();
            _reader = _command.ExecuteReader();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            try
            {
                while (_reader.Read())
                {
                    RowOfData row = new RowOfData(_reader["id"], _reader["specification"], _reader["information"], _reader["time_constraints"]);
                    _data.Add(row);
                }

                for (int i = 0; i < _data.Count; i++)
                {
                    AddDataGrid(_data[i]);
                }

                MessageBox.Show("Данные успешно обновлены", "Внимание!");
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
