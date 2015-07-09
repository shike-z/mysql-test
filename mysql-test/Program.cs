using System;
using System.Configuration;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace mysql_test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("输入1测试 TestUser1(primary key id,unique key uuid):");
                Console.WriteLine("输入2测试 TestUser2(primary key uuid,,unique key id):");
                Console.WriteLine("输入3测试 TestUser3(primary key id):");
                Console.WriteLine("输入4测试 TestUser4(primary key uuid):");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TestUser1();
                        break;
                    case "2":
                        TestUser2();
                        break;
                    case "3":
                        TestUser3();
                        break;
                    case "4":
                        TestUser4();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void TestUser1()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 100000; i++)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "insert into t_user1(uuid,name,city) values (@uuid,@name,@city);";
                    command.Parameters.AddWithValue("@uuid", Guid.NewGuid());
                    command.Parameters.AddWithValue("@name", "name" + i);
                    command.Parameters.AddWithValue("@city", "beijing");
                    command.ExecuteNonQuery();
                }

                stopwatch.Stop();
                connection.Close();

                Console.WriteLine("总运行时间:" + stopwatch.ElapsedMilliseconds);
                Console.WriteLine("");
            }
        }

        private static void TestUser2()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 100000; i++)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "insert into t_user2(uuid,name,city) values (@uuid,@name,@city);";
                    command.Parameters.AddWithValue("@uuid", Guid.NewGuid());
                    command.Parameters.AddWithValue("@name", "name" + i);
                    command.Parameters.AddWithValue("@city", "beijing");
                    command.ExecuteNonQuery();
                }

                stopwatch.Stop();
                connection.Close();

                Console.WriteLine("总运行时间:" + stopwatch.ElapsedMilliseconds);
                Console.WriteLine("");
            }
        }

        private static void TestUser3()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 100000; i++)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "insert into t_user3(uuid,name,city) values (@uuid,@name,@city);";
                    command.Parameters.AddWithValue("@uuid", Guid.NewGuid());
                    command.Parameters.AddWithValue("@name", "name" + i);
                    command.Parameters.AddWithValue("@city", "beijing");
                    command.ExecuteNonQuery();
                }

                stopwatch.Stop();
                connection.Close();

                Console.WriteLine("总运行时间:" + stopwatch.ElapsedMilliseconds);
                Console.WriteLine("");
            }
        }

        private static void TestUser4()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 100000; i++)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "insert into t_user4(uuid,id,name,city) values (@uuid,@id,@name,@city);";
                    command.Parameters.AddWithValue("@uuid", Guid.NewGuid());
                    command.Parameters.AddWithValue("@id", i);
                    command.Parameters.AddWithValue("@name", "name" + i);
                    command.Parameters.AddWithValue("@city", "beijing");
                    command.ExecuteNonQuery();
                }

                stopwatch.Stop();
                connection.Close();

                Console.WriteLine("总运行时间:" + stopwatch.ElapsedMilliseconds);
                Console.WriteLine("");
            }
        }
    }
}