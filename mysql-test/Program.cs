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
                Console.WriteLine("输入1测试 向主键为自增INT类型的表插入万条数据的总时长:");
                Console.WriteLine("输入2测试 向主键为UUID类型的表插入万条数据的总时长:");

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

                for (int i = 0; i < 10000; i++)
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

                for (int i = 0; i < 10000; i++)
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
    }
}