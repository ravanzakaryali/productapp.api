# ProductApp

ProductApp is a .NET 8.0-based project designed for product management. It offers CRUD functionality through RESTful APIs and is built using a clean architecture approach. The application integrates with MongoDB for data storage and utilizes popular libraries like MediatR, FluentValidation, and Swashbuckle for an enhanced developer experience.

---

## **Technologies Used**
- **.NET 8.0**: Framework for application development.
- **MongoDB.Driver**: Library for MongoDB operations.
- **FluentValidation**: For input validation.
- **MediatR**: Implements CQRS and mediator patterns.
- **Swashbuckle.AspNetCore**: Adds Swagger UI for API documentation.
- **Microsoft.AspNetCore.OpenApi**: Enables OpenAPI support.

---

## **Project Structure**
The project follows the **Clean Architecture** pattern with the following layers:

1. **Api**: Hosts the API controllers and middleware.
2. **Application**: Contains business logic and CQRS implementations.
3. **Domain**: Defines the core domain models and abstractions.
4. **Infrastructure**: Handles database integration and persistence.

---


# API Endpoints

## Product Controller: `ProductsController`

### POST /api/products
- **Description**: Creates a new product.
- **Request Body**:
  ```json
  {
    "title": "string",
    "description": "string",
    "price": "decimal"
  }
  ```
- **Response**:
  - **201 Created**: Returns the created product.

---

### GET /api/products
- **Description**: Retrieves all products.
- **Response**:
  - **200 OK**: Returns a list of products.

---

### GET /api/products/{id}
- **Description**: Retrieves a product by its ID.
- **Response**:
  - **200 OK**: Returns the product object.

---

### PUT /api/products/{id}
- **Description**: Updates an existing product by ID.
- **Request Body**:
  ```json
  {
    "title": "string",
    "description": "string",
    "price": "decimal"
  }
  ```
- **Response**:
  - **200 OK**: Returns the updated product.

---

### DELETE /api/products/{id}
- **Description**: Deletes a product by ID.
- **Response**:
  - **204 No Content**: Confirms deletion.
