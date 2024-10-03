# SitemaDeComandas

# Configurando o banco de dados
## dotnet ef migrations add InitialCreate (Não necessário, já existe)
## dotnet ef database update

# Resetanto o banco de dados
dotnet ef database update 0
dotnet ef migrations remove
dotnet ef migrations add InitialCreate 
dotnet ef database update