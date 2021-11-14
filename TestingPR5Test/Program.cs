using System;
using Npgsql;
using System.Collections;
using System.Collections.Generic;

namespace TestingPR5Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            List<string> middle1 = program.TestType();
            List<string> middle2 = program.TestLength();
            List<string> expectedType = new List<string> { "character varying", "character" };
            List<string> expectedLength = new List<string> { "624", "234000" };
            for (int i = 0; i < expectedType.Count; i++)
            {

                if (expectedType[i] != middle1[i])
                {
                    Console.WriteLine("Types are not equal");
                    break;
                }
            }

            for (int i = 0; i < expectedType.Count; i++)
            {

                if (expectedLength[i] != middle2[i])
                {
                    Console.WriteLine("Length is not equal");
                    break;
                }
            }
        }


        public List<string> TestType()
        {
            List<string> list = new List<string>();

            var cs = "Host=localhost;Username=postgres;Password=2358;Database=Testing";
            var connection = new NpgsqlConnection(cs);
            connection.Open();
            //string sql = "select character_maximum_length from INFORMATION_SCHEMA.COLUMNS where table_name = 'typeofbd'";
            string sql = "select column_name, data_type from information_schema.columns where table_name = 'typeofbd';";
            var command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(1));
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            return list;
        }

        public List<string> TestLength()
        {
            List<string> list = new List<string>();

            var cs = "Host=localhost;Username=postgres;Password=2358;Database=Testing";
            var connection = new NpgsqlConnection(cs);
            connection.Open();
            string sql = "select character_maximum_length from INFORMATION_SCHEMA.COLUMNS where table_name = 'typeofbd'";
            //string sql = "select column_name, data_type from information_schema.columns where table_name = 'typeofbd';";
            var command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0).ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            return list;
        }

    }
}