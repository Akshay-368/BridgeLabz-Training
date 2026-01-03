# Library and Books Aggregation Diagram

```mermaid
classDiagram
    class Library{
        +String name
        +List~Book~ books
        +addBook(book: Book)
        +removeBook(book: Book)
    }
    class Book{
        +String title
        +String author
        +int yearPublished
        +String isbn
    }
    Library o-- "*" Book : contains
