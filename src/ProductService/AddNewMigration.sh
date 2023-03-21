#!/bin/bash

read -p "Enter Migration Name: " migrationName

echo "Adding migration $migrationName..."
dotnet ef migrations add "$migrationName" --project Infrastructure --startup-project Api -o EntityFramework/Migrations

read -p "Press any key to exit..."