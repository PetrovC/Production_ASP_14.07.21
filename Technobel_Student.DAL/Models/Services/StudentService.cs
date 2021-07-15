using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Technobel_Student.DAL.Models.Entities;

namespace Technobel_Student.DAL.Models.Services
{
    public class StudentService
    {
        private SqlConnection _connection;
        public StudentService(SqlConnection connection)
        {
            _connection = connection;
        }
        public int Add(Student student)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Student(Nom,Prenom,Numero) OUTPUT inserted.StudentId VALUES (@p1, @p2, @p3)";
                cmd.Parameters.AddWithValue("p1", student.Nom);
                cmd.Parameters.AddWithValue("p2", student.Prenom);
                cmd.Parameters.AddWithValue("p3", (object)student.Numero ?? DBNull.Value);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
        public bool Delete(int StudentId)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Student WHERE StudentId = @p1";
                cmd.Parameters.AddWithValue("p1", StudentId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
        public void UpDateStudent(Student s)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = @"UPDATE Student
                                    SET Nom = @p2, Prenom = @p3, Numero = @p4
                                    WHERE StudentId = @p1";
                cmd.Parameters.AddWithValue("p1", s.StudentId);
                cmd.Parameters.AddWithValue("p2", s.Nom);
                cmd.Parameters.AddWithValue("p3", s.Prenom);
                cmd.Parameters.AddWithValue("p4", (object)s.Numero ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
        public List<Student> GetThemAll()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Student";
                SqlDataReader reader = cmd.ExecuteReader();
                List<Student> result = new List<Student>();
                while (reader.Read())
                {
                    result.Add(new Student
                    {
                        StudentId = (int)reader["StudentId"],
                        Nom = (string)reader["Nom"],
                        Prenom = (string)reader["Prenom"],
                        Numero = reader["Numero"] as string
                    });
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
