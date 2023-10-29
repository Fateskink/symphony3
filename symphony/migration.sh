#!/bin/bash
# Check the operating system
if [ "$(uname)" == "Darwin" ]; then
    # macOS
    MIGRATION_PATH="Database/Migrations"
else
    # Windows
    MIGRATION_PATH="Database\\Migrations"
fi

# Specify the migration name as an argument
MIGRATION_NAME=$1

# Use dotnet ef migrations add with the output parameter
dotnet ef migrations add $MIGRATION_NAME -o $MIGRATION_PATH
