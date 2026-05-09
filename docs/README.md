# Online Tech Store - Scalable E-Commerce Backend

Online Tech Store is a microservices-based backend for an e-commerce platform that sells technology products such as laptops, smartphones, headphones, monitors, and accessories.

This project is developed for the course **Software Engineering for Scalable Applications**.

## Services

The system is divided into the following microservices:

- **API Gateway** - main entry point for client requests
- **Product Service** - manages tech products
- **Inventory Service** - manages product stock
- **Order Service** - manages customer orders
- **Payment Service** - manages payment information
- **Notification Service** - manages order and payment notifications

## Architecture

The project follows a microservices architecture.

```text
Client
  |
  v
API Gateway
  |
  |--> Product Service
  |--> Inventory Service
  |--> Order Service
  |--> Payment Service
  |--> Notification Service
```

Services communicate synchronously through REST APIs.  
RabbitMQ is planned for asynchronous event-driven communication in future phases.

## Technology Stack

- ASP.NET Core Web API
- .NET 9
- REST API
- Swagger / OpenAPI
- GitHub Actions
- RabbitMQ planned
- Database-per-service planned

## Current Endpoints

### Product Service

```text
GET /health
GET /api/products
```

### Inventory Service

```text
GET /health
GET /api/inventory
```

### Order Service

```text
GET /health
GET /api/orders
```

### Payment Service

```text
GET /health
GET /api/payments
```

### Notification Service

```text
GET /health
GET /api/notifications
```

### API Gateway

```text
GET /health
```

## Project Structure

```text
OnlineTechStore/
├── .github/
│   └── workflows/
│       └── dotnet-ci.yml
├── src/
│   ├── ApiGateway/
│   └── Services/
│       ├── OnlineTechStore.ProductService/
│       ├── OnlineTechStore.InventoryService/
│       ├── OnlineTechStore.OrderService/
│       ├── OnlineTechStore.PaymentService/
│       └── OnlineTechStore.NotificationService/
├── docs/
├── .gitignore
├── OnlineTechStore.sln
└── README.md
```

## Build

Run the project build from the root folder:

```bash
dotnet build
```

## Run a Service

Example for Product Service:

```bash
cd src/Services/OnlineTechStore.ProductService
dotnet run
```

Then open:

```text
http://localhost:5080/swagger
```

## CI/CD

GitHub Actions is configured for Continuous Integration.

The pipeline runs on push or pull request and performs:

- Checkout repository
- Setup .NET 9
- Restore dependencies
- Build solution

## Week 2 Status

Completed:

- Basic project setup
- Microservices structure
- API Gateway project
- Basic service endpoints
- Git repository
- GitHub Actions CI pipeline
- Architecture documentation