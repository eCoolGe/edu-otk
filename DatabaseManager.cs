using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace otk
{
    internal class DatabaseManager
    {
        // Создаем поле данных для соединения с БД
        MySqlConnection connection = new MySqlConnection("server = localhost;" +
            "port = 3306;" + 
            "username = root;" +
            "password = ;" +
            "database = db");

        // Метод, который открывает соединение, если оно закрыто
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        // Метод, который закрывает соединение, если оно открыто
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        // Возвращаем значение объекта соединения
        public MySqlConnection GetConnection { get { return connection; } }
    }
}
