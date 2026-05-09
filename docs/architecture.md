# Architecture Design - Online Tech Store

## Project Overview

Online Tech Store is a scalable e-commerce backend for selling technology products such as laptops, smartphones, monitors, headphones, and accessories.

The system is designed using a **microservices-based architecture**, where each service is responsible for a specific business capability.

---

## High-Level Architecture

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

The **API Gateway** is the main entry point for client requests.  
Each microservice is independent and can be developed, deployed, and scaled separately.

---

## Services

### API Gateway

Handles incoming client requests and will route them to the correct service.

### Product Service

Manages technology products, categories, brands, and prices.

### Inventory Service

Manages product stock and availability.

### Order Service

Manages customer orders and order statuses.

### Payment Service

Manages payment information and payment statuses.

### Notification Service

Handles order and payment notifications.

---

## Communication Patterns

The system uses two communication approaches:

### Synchronous Communication

REST APIs are used when an immediate response is needed.

Example:

```text
Client -> API Gateway -> Product Service
```

### Asynchronous Communication

RabbitMQ is planned for future event-driven communication.

Example planned flow:

```text
Order Service -> OrderCreatedEvent -> RabbitMQ
RabbitMQ -> Inventory Service
RabbitMQ -> Notification Service
```

This reduces direct dependencies between services.

---

## Database Design

The system is planned to follow the **database-per-service** pattern.

```text
Product Service        -> Product Database
Inventory Service      -> Inventory Database
Order Service          -> Order Database
Payment Service        -> Payment Database
Notification Service   -> Notification Database
```

Each service will own its own data, which keeps the system loosely coupled.

---

## Scalability Approach

The architecture supports scalability through:

- Independent microservices
- Stateless services
- Horizontal scaling
- API Gateway
- Planned RabbitMQ messaging
- Planned Redis caching
- Database-per-service design

For example, if product browsing receives more traffic, only the **Product Service** can be scaled without scaling the whole system.

---

## CI/CD

GitHub Actions is used for Continuous Integration.

The pipeline:

```text
1. Checks out the repository
2. Sets up .NET 9
3. Restores dependencies
4. Builds the solution
```

Workflow file:

```text
.github/workflows/dotnet-ci.yml
```

---

## Current Week 2 Status

Completed for Week 2:

- Basic project structure
- API Gateway project
- Product Service
- Inventory Service
- Order Service
- Payment Service
- Notification Service
- Basic health/demo endpoints
- Git repository
- GitHub Actions CI pipeline
- Architecture documentation

---

## Future Improvements

Planned next steps:

- Database schema design
- Real CRUD operations
- RabbitMQ integration
- Docker support
- Redis caching
- Unit and integration tests
- Scalability testing
- Cloud deployment