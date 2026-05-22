# Clivo Vet - API de Gestão Preventiva Pet (Sprint 1)

Esta API foi desenvolvida para o ecossistema Clivo Vet, focando na jornada de saúde preventiva animal através de monitoramento IoT e gamificação.

## 🛠️ Tecnologias
- ASP.NET Core 8
- Entity Framework Core
- Oracle Database
- Swagger (Open API)

## 📌 Endpoints (CRUD)
- **GET /api/pets**: Lista todos os pets.
- **GET /api/pets/{id}**: Busca por ID.
- **GET /api/pets/especie/{especie}**: Filtra por espécie.
- **POST /api/pets**: Cria um novo recurso.
- **PUT /api/pets/{id}**: Atualiza dados.
- **DELETE /api/pets/{id}**: Remove um pet.

## 🚀 Como Executar
1. Configure sua ConnectionString no `appsettings.json`.
2. Execute `dotnet ef database update` para rodar as Migrations no Oracle.
3. Execute `dotnet run` e acesse `/swagger`.
