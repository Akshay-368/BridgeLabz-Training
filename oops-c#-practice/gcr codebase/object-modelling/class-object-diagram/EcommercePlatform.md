# E-commerce Platform with Orders, Customers, and Products Diagram
```mermaid
classDiagram
    class Customer{
        +String customerId
        +String name
        +String email
        +String shippingAddress
        +List~Order~ orders
        +placeOrder() Order
        +viewOrderHistory() List~Order~
        +viewOrderStatus(orderId: String) String
        +addToCart(product: Product, quantity: int)
    }
    class Order{
        +String orderId
        +Date orderDate
        +String status
        +double totalAmount
        +Customer customer
        +List~OrderItem~ items
        +calculateTotal() double
        +confirmOrder()
        +updateStatus(newStatus: String)
    }
    class Product{
        +String productId
        +String name
        +double price
        +int stockQuantity
        +String description
    }
    class OrderItem{
        +int quantity
        +double subtotal
        +Product product
    }

    Customer "1" -- "*" Order : places / has placed
    Order "1" o-- "*" OrderItem : contains
    OrderItem "1" -- "1" Product : references
