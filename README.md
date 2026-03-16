# 📋 Desafio Back - Gestão de Atas de Workshops

Este projeto é uma API REST desenvolvida em **.NET 8** para gerenciar Atas de Workshops. A aplicação permite o cadastro de Workshops, Colaboradores e a geração de Atas vinculando esses elementos, utilizando **PostgreSQL** como banco de dados.

---

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET 8.0
* **Banco de Dados:** PostgreSQL
* **ORM:** Entity Framework Core
* **Documentação:** Swagger (Swashbuckle)
* **Deploy:** Render (Docker)

---

## 🚀 Como Executar o Projeto Localmente

### 1. Pré-requisitos
* SDK do .NET 8 instalado.
* PostgreSQL rodando localmente ou uma connection string válida.

### 2. Configuração do Banco
No arquivo `appsettings.json`, ajuste a sua connection string:
json
`"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=DesafioWorkshop;Username=seu_usuario;Password=sua_senha"
}`
3. Rodar Migrations
Abra o terminal na pasta do projeto e execute:

  `dotnet ef database update`

4. Iniciar a API
   
`dotnet run`

Acesse a documentação em:` https://localhost:7150/` (ou a porta configurada no seu VS).

📌 Endpoints Principais
Workshops
GET /api/Workshop - Lista todos os workshops.

POST /api/Workshop - Cria um novo workshop.

Colaboradores
GET /api/Colaborador - Lista todos os colaboradores.

POST /api/Colaborador - Cadastra um colaborador.

Atas
GET /api/Ata - Lista atas com Workshop e Colaboradores incluídos.

POST /api/Ata - Cria uma ata associando IDs de Workshop e Colaboradores.

PUT /api/Ata/{ataId}/colaboradores/{colaboradorId} - atualizar colaboradores

Exemplo de JSON para criar Ata:

`{
  "workshopId": 1,
  "colaboradoresIds": [1, 2]
}`

🐳 Deploy no Render (Docker)

O projeto está configurado para deploy automático via Docker no Render.

URL da API: `https://desafio-workshop-back.onrender.com/swagger/index.html`

👤 Autor
JF_KING_083

