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
    public partial class DataUploadForm : Form
    {
        private List<RowOfData> _data = new List<RowOfData>();
        private User user;

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
            //column4.DefaultCellStyle.Format = "yyyy-MM-dd";

            column4.CellTemplate = new DataGridViewTextBoxCell();
            

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);

            

            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.ReadOnly = true;
        }

        private void AddDataGrid(RowOfData row)
        {
            dataGridView1.Rows.Add(row.id, row.specification, row.information, DateTime.Parse($"{row.time_constraints}").ToString("yyyy-MM-dd"));
        }

        public DataUploadForm()
        {
            InitializeComponent();
        }

        private void DataUploadForm_Shown(object sender, EventArgs e)
        {
            HeaderOfTheTable();
            dataGridView1.Columns[0].ReadOnly = true;
            user = new User();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = Convert.ToInt32(numericUpDownForAdd.Value);
            dataGridView1.ReadOnly = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

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

                int i = Convert.ToInt32(numericUpDownForSelected.Value) - 1;

                if (i >= 0 && i < _data.Count)
                {
                    AddDataGrid(_data[i]);
                }
                else
                    MessageBox.Show("Выбран неправильный элемент", "Ошибка!");
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

        private void загрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _data.Clear();

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
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;
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

        private void выгрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseManager _databaseManager = new DatabaseManager();

                try
                {
                    bool add = true;

                    _databaseManager.OpenConnection();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToString(this.dataGridView1.Rows[i].Cells[1].Value) != "" && Convert.ToString(this.dataGridView1.Rows[i].Cells[2].Value) != "" && Convert.ToString(this.dataGridView1.Rows[i].Cells[3].Value) != "")
                        {
                            string _commandString = "INSERT INTO `projects` (`specification`, `information`, `time_constraints`) VALUES (@specification, @information, @time_constraints)";

                            MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                            _command.Parameters.Add("@specification", MySqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[1].Value;
                            _command.Parameters.Add("@information", MySqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[2].Value;
                            _command.Parameters.Add("@time_constraints", MySqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[3].Value;

                            if (_command.ExecuteNonQuery() != 1)
                                add = false;
                        }
                        else
                            MessageBox.Show("Не все поля были заполнены", "Ошибка!");
                    }

                    if (add)
                        MessageBox.Show("Данные добавлены", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
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

        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.userName == "admin" || user.userName == "editor" || user.userName == "love")
            {
                if (MessageBox.Show("Точно изменить данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        if (Convert.ToString(this.dataGridView1.Rows[0].Cells[1].Value) != "" && Convert.ToString(this.dataGridView1.Rows[0].Cells[2].Value) != "" && Convert.ToString(this.dataGridView1.Rows[0].Cells[3].Value) != "")
                        {
                            string id = Convert.ToString(this.dataGridView1.Rows[0].Cells[0].Value);
                            string specification = Convert.ToString(this.dataGridView1.Rows[0].Cells[1].Value);
                            string information = Convert.ToString(this.dataGridView1.Rows[0].Cells[2].Value);
                            string time_constraints = Convert.ToString(this.dataGridView1.Rows[0].Cells[3].Value);

                            DatabaseManager _databaseManager = new DatabaseManager();
                            string _commandString = $"UPDATE `projects` SET `id` = '{id}', " +
                                $"`specification` = '{specification}', " +
                                $"`information` = '{information}', " +
                                $"`time_constraints` = '{time_constraints}' " +
                                "WHERE projects.id = " + id + ";";
                            MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                            try
                            {
                                _databaseManager.OpenConnection();
                                _command.ExecuteNonQuery();
                                MessageBox.Show("Данные изменены!", "Внимание!");
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
                    else
                    {
                        DatabaseManager _databaseManager = new DatabaseManager();
                        _databaseManager.OpenConnection();
                        bool changed = true;

                        for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        {
                            if (Convert.ToString(this.dataGridView1.Rows[i].Cells[1].Value) != "" && Convert.ToString(this.dataGridView1.Rows[i].Cells[2].Value) != "" && Convert.ToString(this.dataGridView1.Rows[i].Cells[3].Value) != "")
                            {
                                string id = Convert.ToString(this.dataGridView1.Rows[0].Cells[0].Value);
                                string specification = Convert.ToString(this.dataGridView1.Rows[0].Cells[1].Value);
                                string information = Convert.ToString(this.dataGridView1.Rows[0].Cells[2].Value);
                                string time_constraints = Convert.ToString(this.dataGridView1.Rows[0].Cells[3].Value);

                                string _commandString = $"UPDATE `projects` SET `id` = '{id}', " +
                                $"`specification` = '{specification}', " +
                                $"`information` = '{information}', " +
                                $"`time_constraints` = '{time_constraints}' " +
                                "WHERE projects.id = " + id + ";";
                                MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                                try
                                {
                                    if (_command.ExecuteNonQuery() != 1)
                                        changed = false;
                                }
                                catch
                                {
                                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                                }
                            }
                            else
                                MessageBox.Show("Не все поля заполнены", "Внимание!");
                        }

                        if (changed)
                            MessageBox.Show("Данные изменены", "Внимание");
                        else
                            MessageBox.Show("Не все данные изменены", "Внимание!");
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Ошибка, у вас нет на это доступа!", "Ошибка!");
            }
        }

        private void выбранныйыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Точно удалить эти данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    int index = Convert.ToInt32(numericUpDownForSelected.Value);
                    if (index > 0 && index <= _data.Count)
                    {
                        DatabaseManager _databaseManager = new DatabaseManager();
                        string id = Convert.ToString(this.dataGridView1.Rows[0].Cells[0].Value);
                        string _commandString = "DELETE FROM `projects` WHERE `projects`.`id` = " + id;
                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                        try
                        {
                            _databaseManager.OpenConnection();
                            _command.ExecuteNonQuery();
                            MessageBox.Show("Данные удалены успешно", "Внимание!");
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
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
            else
            {
                DatabaseManager _databaseManager = new DatabaseManager();
                _databaseManager.OpenConnection();
                bool delete = true;

                foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string id = Convert.ToString(row.Cells[0].Value);
                    string _commandString = "DELETE FROM `projects` WHERE `project`.`id` = " + id;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        dataGridView1.Rows.Remove(row);
                        if (_command.ExecuteNonQuery() != 1)
                            delete = false;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                }

                if (delete)
                    MessageBox.Show("Выбранные данные успешно удалены", "Внимание!");
                else
                    MessageBox.Show("Не все выбранные данные были удалены", "Внимание!");

                _databaseManager.CloseConnection();
            }
        }

        private void всеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.userName == "admin" || user.userName == "love")
            {
                if (MessageBox.Show("Точно удалить ВСЕ данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DatabaseManager _databaseManager = new DatabaseManager();
                    MySqlCommand _command = new MySqlCommand("TRUNCATE TABLE `projects`", _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Все данные были успешно удалены", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
            }
            else
                MessageBox.Show("Ошибка, у вас нет на это доступа", "Ошибка!");
        }

        private void перейтиКПросмотруДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataForm form = new DataForm();
            this.Hide();
            form.Show();
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
    }
}
