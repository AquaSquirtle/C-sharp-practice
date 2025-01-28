using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class CheckRepository : ICheckRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CheckRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Check? FindCheckByNumber(int number)
    {
        const string sql = "SELECT * FROM checks WHERE check_number = @number";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@number", number);
        NpgsqlDataReader result = command.ExecuteReader();
        return result.Read() ? new Check(
            result.GetInt32(0),
            result.GetInt32(1),
            result.GetDecimal(2)) : null;
    }

    public void CreateCheck(int number, int pin)
    {
        const string sql = "INSERT INTO checks (check_number, pin) VALUES (@number, @pin)";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@number", number);
        command.Parameters.AddWithValue("@pin", pin);
        command.ExecuteNonQuery();
    }

    public void UpdateCheckMoney(int checkNumber, decimal money)
    {
        const string sql = "UPDATE checks SET balance = @balance WHERE check_number = @number";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@balance", money);
        command.Parameters.AddWithValue("@number", checkNumber);
        command.ExecuteNonQuery();
    }
}