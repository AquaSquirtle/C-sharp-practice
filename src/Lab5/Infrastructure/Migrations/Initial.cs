using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        CREATE TABLE checks (
            check_number BIGINT PRIMARY KEY,
            pin BIGINT NOT NULL,
            balance MONEY NOT NULL DEFAULT 0
        );
        
        CREATE TABLE admin (
            id SERIAL PRIMARY KEY,
            password TEXT NOT NULL
        );
        
        INSERT INTO admin (password)
        VALUES ('jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=')
        ON CONFLICT (id) DO NOTHING;
        
        CREATE TABLE transactions (
            id SERIAL PRIMARY KEY,
            check_number BIGINT NOT NULL,
            transaction_type TEXT NOT NULL,
            FOREIGN KEY (check_number) REFERENCES checks (check_number)
        );

        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        DROP TABLE Transactions;
        DROP TABLE Admin;
        DROP TABLE Check;
        """;
}