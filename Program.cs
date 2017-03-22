using System;
using MySql.Data.MySqlClient;
using System.Data;
using Mysql_test;

public class Test
{
    static Test()
    {
        Resolver.RegisterDependencyResolver();
    }
    public static void Main(string[] args)
    {
        string connectionString;
        connectionString = "Server=localhost;" +
                           "Database=test;" +
                           "User ID=root;" +
                           "Password=1234;" +
                           "Pooling=false";
        IDbConnection dbcon;
        dbcon = new MySqlConnection(connectionString);
        dbcon.Open();
        IDbCommand dbcmd = dbcon.CreateCommand();
        string sql =
            "SELECT id " +
            "FROM test";

        int i = 1000;
        string sql2 = "";
        while (i > 0)
        {
            sql2 = "INSERT INTO test SET fullname=" + i.ToString();
            dbcmd.CommandText = sql2;
            dbcmd.ExecuteNonQuery();
            i--;
        }
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int ID = (int) reader["id"];
            Console.WriteLine("ID: " +
                              ID.ToString() + " ");
        }
        Console.ReadLine();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }
}