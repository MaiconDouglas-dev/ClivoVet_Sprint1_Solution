# Clivo Vet - API de Gestão Preventiva Pet (Sprint 1)

Esta API foi desenvolvida para o ecossistema **Clivo Vet**, focando na jornada de saúde preventiva animal através de monitoramento IoT e gamificação.

## 🛠️ Tecnologias
- ASP.NET Core 8 (Web API Controllers)
- Entity Framework Core
- Oracle Database
- Swagger (OpenAPI)

## 📌 Endpoints (CRUD) — Recurso: Pets
Base URL: `/api/pets`

### GET (leituras)

- **GET `/api/pets`**: Lista todos os pets. *(200 OK)*
- **GET `/api/pets/{id}`**: Busca um pet por ID. *(200 OK | 404 NotFound)*
- **GET `/api/pets/especie/{especie}`**: Filtra pets por espécie. *(200 OK)*
- **GET `/api/pets/status/{status}`**: Filtra pets por status de atividade. *(200 OK)*
- **GET `/api/pets/peso/min/{min}/max/{max}`**: Filtra pets por intervalo de peso. *(200 OK | 400 BadRequest)*

### POST (criação)
- **POST `/api/pets`**: Cria um novo pet. *(201 Created | 400 BadRequest)*

### PUT (atualização)
- **PUT `/api/pets/{id}`**: Atualiza um pet existente. *(204 NoContent | 400 BadRequest | 404 NotFound)*

### DELETE (remoção)
- **DELETE `/api/pets/{id}`**: Remove um pet. *(204 NoContent | 404 NotFound)*

## 🚀 Como executar

### Pré-requisitos
- .NET SDK 8
- Acesso a uma instância Oracle (ex.: `oracle.fiap.com.br:1521/ORCL`)

### 1) Configurar ConnectionString
Edite o arquivo `appsettings.json` e configure a string em `ConnectionStrings:OracleConnection`.

> ```bash
> dotnet user-secrets init
> dotnet user-secrets set "ConnectionStrings:OracleConnection" "<SUA_CONNECTION_STRING>"
> ```

### 2) Rodar as migrations (EF Core)
```bash
dotnet ef database update
```

### 3) Executar a API
```bash
dotnet run
```

### 4) Testar via Swagger
Com a aplicação rodando, acesse:
- `/` (Swagger UI abre na raiz)

E teste todos os endpoints diretamente pela interface.
