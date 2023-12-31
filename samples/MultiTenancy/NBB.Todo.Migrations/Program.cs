﻿// Copyright (c) TotalSoft.
// This source code is licensed under the MIT license.

using System;

namespace NBB.Todo.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoicesMigrator = new TodoDatabaseMigrator();

            invoicesMigrator.EnsureDatabaseDeleted(args).Wait();
            Console.WriteLine("Database deleted");
            invoicesMigrator.MigrateDatabaseToLatestVersion(args).Wait();
            Console.WriteLine("Database created");
        }
    }
}
