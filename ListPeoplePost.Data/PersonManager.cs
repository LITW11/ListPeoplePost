using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ListPeoplePost.Data
{
    public class PersonManager
    {
        private readonly string _connectionString;

        public PersonManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            List<Person> ppl = new List<Person>();
            connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ppl.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }

            return ppl;
        }

        public void AddPeople(List<Person> ppl)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                              "VALUES (@firstName, @lastName, @age)";
            conn.Open();
            
            foreach (var person in ppl)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);

                cmd.ExecuteNonQuery();
            }

            //foreach (var person in ppl)
            //{
            //    AddPerson(person);
            //}
        }

        public void AddPerson(Person person)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                              "VALUES (@firstName, @lastName, @age)";
            conn.Open();
            cmd.Parameters.AddWithValue("@firstName", person.FirstName);
            cmd.Parameters.AddWithValue("@lastName", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            cmd.ExecuteNonQuery();
        }
    }
}