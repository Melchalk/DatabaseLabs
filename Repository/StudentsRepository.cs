using DTOs;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Data.Odbc;
using System.Data.OleDb;

using Microsoft.Data.SqlClient;

namespace Repository;

public class StudentsRepository : IStudentsRepository
{
    public DbSet<StudentDto> Students { get; set; }

    private string CONNECTION_STRING = "Host=localhost;Port=5432;Database=StudentRepository;Username=postgres;Password=пароль_от_postgres";

    public async Task SaveAsync()
    {
    }

    public void Get()
    {
        OleDbConnection con = new()
        {
            ConnectionString = CONNECTION_STRING
        };

        OleDbCommand command = new("select * from Tablename", con);

        command.ExecuteNonQuery();
        con.Close();
    }

    public void Delete()
    {
        SqlConnection db = new(CONNECTION_STRING);
        StudentDto cust = new()
        {
            Name = "Peter",
            University = "Moscow"
        };
    }

    public void Add()
    {
        OdbcConnection con = new(CONNECTION_STRING);
        con.Open();

        string sql = "insert into TablelnDBNAME(column1, column2) values(val1, val2)";
        var cm = new OdbcCommand(sql, con);

        cm.ExecuteNonQuery();

        con.Close();
    }

}
