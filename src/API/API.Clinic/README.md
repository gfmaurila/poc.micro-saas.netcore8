# 📌 API.Clinic.Core

## 📖 Descrição
A **API.Clinic.Core** é responsável pelo gerenciamento de clínicas, profissionais de saúde, pacientes, consultas e controle de estoque de materiais médicos. 

A API facilita a organização de **agendamentos**, **pagamentos** e **mensagens automáticas** para confirmação de consultas, garantindo eficiência no atendimento e na administração da clínica.

## 🏗 Estrutura do Domínio
A API gerencia as seguintes entidades principais:

### 1️⃣ **Pessoa (`Person`)**
- Nome, e-mail, telefone
- Documento (CPF/CNPJ)
- Endereço

### 2️⃣ **Profissional de Saúde (`HealthcareProfessional`)**
- Nome, especialidade, CRM/registro profissional
- Valor da hora de atendimento
- Porcentagem do valor da consulta que o profissional recebe
- Histórico de consultas realizadas

### 3️⃣ **Paciente (`Patient`)**
- Nome, contato, informações médicas básicas
- Histórico de consultas realizadas

### 4️⃣ **Consulta (`Appointment`)**
- Paciente e profissional de saúde envolvidos
- Data, horário e duração da consulta
- Valor da consulta
- Status (Agendada, Confirmada, Cancelada, Concluída)
- Confirmação automática: **Se o paciente não confirmar um dia antes, assume-se que ele comparecerá**
- Notificações automáticas para lembrar o paciente

### 5️⃣ **Controle de Estoque (`InventoryItem`)**
- Nome do material médico
- Quantidade disponível
- Data de validade
- Fornecedor e histórico de movimentação

### 6️⃣ **Mensagens Automáticas (`Notification`)**
- Envio de lembretes de consulta um dia antes
- Confirmação de presença automática
- Mensagens via **E-mail, SMS ou WhatsApp**

### 🔗 **Relacionamentos**
- Uma **Consulta** envolve um **Profissional de Saúde** e um **Paciente**.
- Um **Profissional** pode atender múltiplos **Pacientes**.
- O **Controle de Estoque** gerencia o consumo de materiais médicos.
- As **Notificações** garantem que os pacientes sejam lembrados de suas consultas.

## 🚀 Tecnologias e Arquitetura
📌 **Stack Tecnológico:**
- **.NET Core 8** para desenvolvimento da API.
- **Entity Framework Core** para persistência de dados.
- **PostgreSQL / SQL Server** como banco de dados relacional.
- **Swagger/OpenAPI** para documentação interativa.
- **Autenticação JWT** para segurança e controle de acesso.
- **RabbitMQ** para envio assíncrono de notificações.

## 📋 Fluxo de Funcionamento
1. **Cadastro de Profissionais e Pacientes.**
2. **Agendamento de Consultas.**
3. **Envio Automático de Mensagem um dia antes da consulta.**
4. **Paciente pode confirmar ou não a presença.**
5. **Consulta é realizada e o profissional recebe sua porcentagem.**
6. **Estoque de materiais médicos é atualizado conforme uso.**

## 🎯 Próximos Passos
1. **Implementar os endpoints para CRUD de profissionais, pacientes e consultas.**
2. **Criar a lógica de envio de mensagens e confirmações automáticas.**
3. **Gerenciar pagamentos de consultas e repasse para profissionais.**
4. **Integrar com sistemas externos de notificações e pagamentos.**


## Estrutura de Pastas

### Projeto Principal
```
API.Exemple.Core.08
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



### 📌 **Contribuições**
Sinta-se à vontade para abrir um Pull Request ou sugerir melhorias por meio de Issues!


---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


















