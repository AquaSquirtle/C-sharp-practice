using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string GetSystemPassword()
    {
        const string sql = "SELECT password FROM admin";
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        var command = new NpgsqlCommand(sql, connection);
        NpgsqlDataReader result = command.ExecuteReader();
        return result.Read() ? result.GetString(0) : string.Empty;
    }

    public void SetSystemPassword(string password)
    {
        const string sql = "UPDATE admin SET password = @password WHERE id = TRUE";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
    }
}