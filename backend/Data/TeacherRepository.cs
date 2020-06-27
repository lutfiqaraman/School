using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly IConfiguration _config;

    // Teacher Repository - Constructor
    public TeacherRepository(IConfiguration config)
    {
      _config = config;
    }

    // To get all teachers from database
    public List<Teacher> GetAllTeachers()
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "Select * from teacher";

      List<Teacher> teacherList = new List<Teacher>();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        SqlDataReader dataReader = cmd.ExecuteReader();

        using (dataReader)
        {
          while (dataReader.Read())
          {
            Teacher teacher = new Teacher();

            teacher.Id = Convert.ToInt32(dataReader["Id"]);
            teacher.Name = Convert.ToString(dataReader["Name"]);
            teacher.Skills = Convert.ToString(dataReader["Skills"]);
            teacher.Salary = Convert.ToDecimal(dataReader["Salary"]);
            teacher.AddedOn = Convert.ToDateTime(dataReader["AddedOn"]);

            teacherList.Add(teacher);
          }
        }

        cmd.Dispose();
      }

      return teacherList;
    }

    // to get a teacher by id from database
    public Teacher GetTeacherById(int id)
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "Select * from teacher where id = @id";

      Teacher teacher = new Teacher();
      List<Teacher> teacherList = new List<Teacher>();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("id", id);

        SqlDataReader dataReader = cmd.ExecuteReader();

        using (dataReader)
        {
          while (dataReader.Read())
          {
            teacher.Id = Convert.ToInt32(dataReader["Id"]);
            teacher.Name = Convert.ToString(dataReader["Name"]);
            teacher.Skills = Convert.ToString(dataReader["Skills"]);
            teacher.Salary = Convert.ToDecimal(dataReader["Salary"]);
            teacher.AddedOn = Convert.ToDateTime(dataReader["AddedOn"]);
          }
        }

        cmd.Dispose();
      }

      return teacher;
    }

    // to create a teacher
    public Teacher CreateTeacher(Teacher teacher)
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "INSERT INTO Teacher (Name, Skills, Salary, AddedOn) VALUES (@Name, @Skills, @Salary, @AddedOn)";

      DateTime CurrDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MMM-dd"));

      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

        cmd.Parameters.AddWithValue("@Name", teacher.Name);
        cmd.Parameters.AddWithValue("@Skills", teacher.Skills);
        cmd.Parameters.AddWithValue("@Salary", teacher.Salary);
        cmd.Parameters.AddWithValue("@AddedOn", CurrDate);

        conn.Open();
        cmd.ExecuteNonQuery();
      }
      
      return teacher;
    }

    // to update a teacher
    public Teacher UpdateTeacher(Teacher teacher, int id)
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery =
        "UPDATE Teacher set " +
        "Name = @Name, " +
        "Skills = @Skills, " +
        "Salary = @Salary, " +
        "AddedOn = @AddedOn " +
        "where id = @id";

      teacher.Id = id;

      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

        cmd.Parameters.AddWithValue("@id", teacher.Id);
        cmd.Parameters.AddWithValue("@Name", teacher.Name);
        cmd.Parameters.AddWithValue("@Skills", teacher.Skills);
        cmd.Parameters.AddWithValue("@Salary", teacher.Salary);
        cmd.Parameters.Add("@AddedOn", SqlDbType.DateTime2).Value = teacher.AddedOn;

        conn.Open();
        cmd.ExecuteNonQuery();
      }

      return teacher;
    }

    // to delete a teacher 
    public void DeleteTeacher(int id)
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "DELETE FROM teacher where id = @id";

      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("id", id);

        cmd.ExecuteNonQuery();
        cmd.Dispose();
      }
    }

  }
}