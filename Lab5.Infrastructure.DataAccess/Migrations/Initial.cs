using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        CREATE TABLE checks (
            id SERIAL PRIMARY KEY,
            number BIGINT UNIQUE NOT NULL,
            pin BIGINT NOT NULL,
            balance MONEY NOT NULL DEFAULT 0
        );
        
        CREATE TABLE admin (
            id BOOLEAN PRIMARY KEY DEFAULT TRUE,
            password TEXT NOT NULL
        );
        
        INSERT INTO Admin (id, password)
        VALUES (TRUE, 'admin')
        ON CONFLICT (id) DO NOTHING;
        
        CREATE TABLE transactions (
            id SERIAL PRIMARY KEY,
            number BIGINT NOT NULL,
            transaction_type TEXT NOT NULL
        );

        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        DROP TABLE Transactions;
        DROP TYPE transaction_type;
        DROP TABLE Admin;
        DROP TABLE Check;
        """;
}