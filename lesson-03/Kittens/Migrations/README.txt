
-- Создание миграции
dotnet ef migrations add MigrationName -p MigrationProjectName

-- Применение миграции
dotnet ef database update -p MigrationProjectName

