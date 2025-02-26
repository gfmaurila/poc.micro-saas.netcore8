# 📚 Projeto: API.InventoryControl.Core

## 📖 Descrição
A **API.InventoryControl.Core** é uma solução para gerenciamento de estoque, permitindo o controle eficiente de produtos, fornecedores, pedidos e movimentações de estoque. 

A API possibilita que empresas mantenham um acompanhamento detalhado de seus produtos, evitando perdas e garantindo a otimização dos recursos.

## 🏗 Estrutura do Domínio
A API gerencia as seguintes entidades principais:

### 1️⃣ **Produto (`Product`)**
- Nome, descrição e código SKU
- Categoria e unidade de medida
- Quantidade disponível em estoque
- Preço de compra e venda
- Nível mínimo de estoque (para alertas)

### 2️⃣ **Categoria (`Category`)**
- Nome e descrição
- Lista de produtos associados

### 3️⃣ **Fornecedor (`Supplier`)**
- Nome da empresa
- Contato e endereço
- Lista de produtos fornecidos

### 4️⃣ **Pedido de Compra (`PurchaseOrder`)**
- Fornecedor associado
- Data do pedido
- Lista de itens e quantidades
- Status do pedido (Pendente, Aprovado, Recebido, Cancelado)

### 5️⃣ **Movimentação de Estoque (`StockMovement`)**
- Produto movimentado
- Tipo de movimentação (Entrada, Saída, Ajuste)
- Quantidade e data
- Motivo da movimentação

### 🔗 **Relacionamentos**
- Um **Produto** pertence a uma **Categoria**.
- Um **Produto** pode ser fornecido por múltiplos **Fornecedores**.
- Um **Fornecedor** pode fornecer múltiplos **Produtos**.
- Um **Pedido de Compra** está vinculado a um **Fornecedor** e contém vários **Produtos**.
- Uma **Movimentação de Estoque** está associada a um **Produto** e altera sua quantidade disponível.

## 🚀 Tecnologias e Arquitetura
📌 **Stack Tecnológico:**
- **.NET Core 8** para desenvolvimento da API.
- **Entity Framework Core** para persistência de dados.
- **PostgreSQL / SQL Server** como banco de dados relacional.
- **Swagger/OpenAPI** para documentação interativa.
- **Autenticação JWT** para segurança e controle de acesso.

## 🎯 Próximos Passos
1. **Definir a estrutura inicial do projeto.**
2. **Implementar a camada de domínio**, criando as entidades e relacionamentos.
3. **Desenvolver a camada de persistência com EF Core.**
4. **Criar os endpoints REST para gerenciamento de estoque, pedidos e fornecedores.**
5. **Implementar um sistema de notificações para alertas de estoque mínimo.**

## Estrutura de Pastas

### Projeto Principal
```
API.InventoryControl.Core
├── Connected Services
├── Dependências
├── Properties
├── Controllers
├── Extensions
├── Feature
│   ├── Domain
│   │   ├── Common
│   │   └── Exemple
│   ├── Exemple
│       ├── Commands
│       │   ├── Create
│       │   ├── Delete
│       │   └── Update
│       └── Queries
│           ├── Get
│           ├── GetById
│           └── GetPaginate
├── Infrastructure
│   ├── Auth
│   ├── Database
│   │   ├── Mappings
│   │   ├── Repositories
│   │   ├── ExempleAppDbContext.cs
│   │   └── UnitOfWork.cs
│   ├── Integration
│   ├── Messaging
│   └── Redis
├── Migrations
├── API.Exemple.Core.08.http
├── appsettings.json
├── Dockerfile
└── Program.cs
└── README.md
```


## Endpoints da API

### Autenticação
Gerar token de acesso:
```sh
curl --location 'http://localhost:5000/api-auth/api/v1/login' \
--header 'accept: application/json' \
--header 'Content-Type: application/json' \
--header 'X-API-Key: ••••••' \
--data-raw '{
  "email": "gfmaurila@gmail.com",
  "password": "@C23l10a1985"
}'
```

### Endpoints da API Exemple

#### Listar exemplos
```sh
curl --location 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Authorization: ••••••'
```

#### Paginação e filtro por nome
```sh
curl --location 'https://localhost:44387/api/v1/Exemple/exemple?FiltroFirstName=t&PageNumber=1&PageSize=1' \
--header 'Authorization: ••••••'
```

#### Buscar exemplo por ID
```sh
curl --location 'https://localhost:44387/api/v1/Exemple/92836fd8-8d5c-40af-a144-464b3749501b' \
--header 'Authorization: Bearer ••••••'
```

#### Criar um novo exemplo
```sh
curl --location 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data-raw '{
  "firstName": "string",
  "lastName": "string",
  "status": true,
  "gender": 1,
  "notification": "SMS",
  "email": "strings1@teste.com",
  "phone": "string",
  "role": [
    "Admin"
  ]
}'
```

#### Atualizar um exemplo existente
```sh
curl --location --request PUT 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data-raw '{
  "id": "92836fd8-8d5c-40af-a144-464b3749501b",
  "firstName": "Teste 01",
  "lastName": "teste 01",
  "gender": 1,
  "notification": 1,
  "email": "user1s@example.com",
  "phone": "51985623312",
  "role": [
    "EMPLOYEE_AUTH", "ADMIN_AUTH"
  ]
}'
```

#### Excluir um exemplo
```sh
curl --location --request DELETE 'https://localhost:44387/api/v1/Exemple/92836fd8-8d5c-40af-a144-464b3749501b' \
--header 'accept: text/plain' \
--header 'Authorization: ••••••'
```

### Notificações
Enviar notificação:
```sh
curl --location 'https://localhost:44387/api/v1/Notification' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data '{
  "notification": 1,
  "from": "teste from - Teste ",
  "body": "teste body - Teste ",
  "to": "teste to - teste "
}'
```

## Rodando a API
### Subindo os serviços com Docker
```sh
docker network create shared-network
docker-compose down
docker-compose up -d --build
```

### Aplicando migrações do banco de dados
```sh
dotnet new webapi -n AuthSystem
Add-Migration Inicial -Context ExempleAppDbContext 
Update-Database -Context ExempleAppDbContext 
```

### Ambientes
```sh
API: http://localhost:5002/swagger/index.html
Kafka: http://localhost:9100/
RabbitMQ: http://localhost:15672/#/
```

### Documentação
![Diagrama Exemple](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Exemple.jpg)
![Diagrama Notification](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Notification.jpg)
![Fluxo](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Fluxo-API.jpg)



## 📌 **Contribuições**
Sinta-se à vontade para abrir um Pull Request ou sugerir melhorias por meio de Issues!

---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


















