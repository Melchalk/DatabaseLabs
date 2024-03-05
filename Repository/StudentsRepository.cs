using DTOs;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Data.Odbc;
using System.Data.OleDb;

using Microsoft.Data.SqlClient;
using DTOs.Response;

namespace Repository;

public class StudentsRepository : IStudentsRepository
{
    public DbSet<StudentDto> Students { get; set; }

    private string CONNECTION_STRING = "Host=localhost;Port=5432;Database=StudentRepository;Username=postgres;Password=";

    public async Task SaveAsync()
    {
    }

    public async Task<GetStudentResponse?> Get(Guid id)
    {
        var student = new GetStudentResponse();

        OleDbConnection con = new()
        {
            ConnectionString = CONNECTION_STRING
        };

        OleDbCommand command = new($"select * from Students where Id = '{id}'", con);
        var reader = command.ExecuteReader();

        while (await reader.ReadAsync())
        {
            student.Name =reader["Name"].ToString();
            student.University = reader["University"].ToString();
            student.Course = (int)reader["Course"];
        }

        con.Close();

        return student;
    }

    public void Delete(Guid id)
    {
        SqlConnection db = new(CONNECTION_STRING);

        Students.Remove(Students.First(x => x.Id == id));
    }

    public void Add(StudentDto student)
    {
        OdbcConnection con = new(CONNECTION_STRING);
        con.Open();

        string sql = $"insert into Students(Id, Name) values({student.Id}, {student.Name})";
        var cm = new OdbcCommand(sql, con);

        cm.ExecuteNonQuery();

        con.Close();
    }

}
