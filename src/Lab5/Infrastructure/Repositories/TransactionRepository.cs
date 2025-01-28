using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<string> GetLastTransactions()
    {
        const string sql = "SELECT number, transaction_type FROM transactions ORDER BY id DESC LIMIT 10";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();
        var transactions = new List<string>();

        while (reader.Read())
        {
            transactions.Add(reader.GetInt32(0).ToString() + " " + reader.GetString(1));
        }

        return transactions;
    }

    public void AddTransaction(int checkNumber, string transaction)
    {
        const string sql = "INSERT INTO transactions (check_number, transaction_type) VALUES (@checkNumber, @transaction)";
        using NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@checkNumber", checkNumber);
        command.Parameters.AddWithValue("@transaction", transaction);
        command.ExecuteNonQuery();
    }
}