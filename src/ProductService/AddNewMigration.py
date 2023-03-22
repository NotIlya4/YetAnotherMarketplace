import os

migration_name = input("Enter Migration Name: ")

print(f"Adding migration {migration_name}...")
os.system(f"dotnet ef migrations add \"{migration_name}\" --project Infrastructure --startup-project Api -o EntityFramework/Migrations")

input("Press any key to exit...")
