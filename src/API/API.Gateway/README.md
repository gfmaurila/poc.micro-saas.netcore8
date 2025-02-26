# 📚 Projeto: API.Gateway - Sistema de Integração e Gerenciamento

## API.Gateway

### Visão Geral
A API.Gateway é um gateway de integração que conecta múltiplos serviços de backend em um único ponto de acesso, facilitando a comunicação entre diferentes módulos do sistema. Implementada com **ASP.NET Core 8**, a API centraliza a autenticação, roteamento e monitoramento de várias APIs específicas de domínio, além de oferecer suporte para caching e banco de dados SQL Server.

### Principais Funcionalidades
- Integração centralizada entre APIs.
- Suporte a comandos **POST**, **PUT**, **DELETE** e consultas **GET** com redistribuição eficiente para diferentes serviços.
- Uso de **Redis** para caching e otimização de consultas.
- Conexão a um banco de dados **SQL Server** para persistência de dados.

### Arquitetura
A arquitetura da API.Gateway está estruturada para gerenciar chamadas de usuários, roteando-as para os serviços backend apropriados:

#### Componentes Principais
1. **APIs Conectadas**:
   - API.Exemple.Core.08
   - API.Customer.Core.08
   - API.HR.Core.08
   - API.Freelancer.Core.08
   - API.Clinic.Core.08
   - API.InventoryControl.Core.08

2. **Redis**: Utilizado para caching de respostas de consultas **GET**.

3. **SQL Server**: Banco de dados principal para operações de persistência e consulta.

4. **Domain Model**:
   - Command API para operações de escrita (**POST**, **PUT**, **DELETE**).
   - Query API para operações de leitura (**GET**).

5. **Sync**: Sincronização entre o cache e o banco de dados para otimização.

### Diagramas

#### Fluxo Geral da API Gateway
![Fluxo Geral](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/02%20-%20API.Gateway/02%20-%20API.Gateway.jpg)

#### Comunicação com os Backends
- **POST/PUT/DELETE**: Enviam comandos para o banco de dados SQL Server.
- **GET**: Consulta o cache Redis antes de acessar o banco de dados, garantindo alta performance.

#### Arquitetura do Servidor
- **Comandos**:
  - Recebidos do cliente e processados pelo Domain Model, com persistência no banco de dados SQL Server.
- **Consultas**:
  - Processadas pelo Read API e retornadas do cache Redis.

### Tecnologias Utilizadas
- **ASP.NET Core 8**
- **Swagger**: Documentação interativa da API.
- **Redis**: Sistema de caching.
- **SQL Server**: Banco de dados relacional.
- **Docker**: Conteinerização dos serviços.
- **Serilog**: Logging centralizado.

### Endpoints Disponíveis
#### Autenticação - API.External.Auth

Projeto: https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/External/API.External.Auth

- **Gerar token de acesso**:
```sh
curl --location 'http://localhost:5000/api-auth/api/v1/login' \
--header 'accept: application/json' \
--header 'Content-Type: application/json' \
--data-raw '{
  "email": "usuario@example.com",
  "password": "senha123"
}'
```

#### Rotas da API.Exemple.Core.08 
Projeto: (https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Exemple.Core.08
- **Consultar dados de exemplo**:
```sh
curl --location 'http://localhost:5002/api/v1/exemplo' \
--header 'Authorization: Bearer <seu_token>'
```

- **Criar novo registro**:
```sh
curl --location --request POST 'http://localhost:5002/api/v1/exemplo' \
--header 'Content-Type: application/json' \
--data-raw '{
  "campo1": "valor1",
  "campo2": "valor2"
}'
```

### Rodando a API
#### Subindo os Serviços com Docker
```sh
docker network create shared-network
docker-compose down
docker-compose up -d --build
```

#### Configuração do Banco de Dados
```sh
Add-Migration InitialMigration -Context GatewayDbContext
Update-Database -Context GatewayDbContext
```

### Contribuições
Contribuições são bem-vindas! Caso identifique melhorias ou novos recursos, envie um pull request. 🚀

---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)
