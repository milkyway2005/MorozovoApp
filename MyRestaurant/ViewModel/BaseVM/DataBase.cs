using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MyRestaurant.ViewModel.BaseVM
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=COMPUTER\SQLEXPRESS;Database=Restaurant;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
        public DataTable SqlSelect(String s)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(s);
            sqlCommand.Connection = GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }
        public void SqlQuery(String s)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(s);
            sqlCommand.Connection = GetConnection();
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
