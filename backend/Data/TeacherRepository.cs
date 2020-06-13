using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
      List<Teacher> teacherList = new List<Teacher>();

      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sql = "Select * from teacher";

      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sql, conn);
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
      }

      return teacherList;
    }

    // to get a teacher by id
    public Teacher GetTeacherById(int id)
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sql = "Select * from teacher where id = @id";

      Teacher teacher = new Teacher();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sql, conn);
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
      }

      return teacher;
    }
    public Task<Teacher> CreateTeacher()
    {
      throw new System.NotImplementedException();
    }

    public Task<Teacher> DeleteTeacher()
    {
      throw new System.NotImplementedException();
    }



    public Task<Teacher> UpdateTeacher()
    {
      throw new System.NotImplementedException();
    }
  }
}