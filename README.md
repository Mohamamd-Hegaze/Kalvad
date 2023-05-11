# Kalvad API Test
This is a sample API built using ASP.NET that provides basic CRUD (Create, Read, Update, Delete) operations on customers and their addresses.

In the diagram below explain the relation between the customer and address:

![UMLDiagram](https://github.com/Mohammad-Hijazi/Kalvad/assets/35743486/7fee1b1d-c595-49c8-b0cb-55a5eda63cd1)



## Prerequisites
Before running this API, make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other preferred code editor
- [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

## Getting Started

To get started with this API, follow these steps:

1. Clone this repository to your local machine:
git clone https://github.com/Mohammad-Hijazi/Kalvad.git
2. Open the project in Visual Studio or your preferred code editor.

3. Restore the project dependencies by running the following command in the terminal: **dotnet restore**
4. Build the project: **dotnet build**
5. Create a new database named **kalvad**
6. Execute sql files into a DB folder in the order present
7. Run the project

## API Endpoints

The following endpoints are available in this API:

| Endpoint             | Description                                 |
| -------------------- | ------------------------------------------- |
| GET /customer   | Retrieves a list of all customers|
| GET /customer/{id} | Retrieves a specific customer by ID|
| POST /customer  | Creates a new customer|
| GET /customer/phone/{prefix} | Retrieves a list of all customers starting with the following prefix phone number|
| GET /customer/city/<name> | Retrieves a list of all customers from this city|
| POST /address/{customer_id}  | Create an address for this customer|
| DELETE /address/{customer_id}/address/{address_id} | Delete the address of the customer|

## Testing the API

You can test the API endpoints using tools like Swagger, Postman, or any other API testing tool of your choice.

## Contributing

Contributions to this sample API are welcome. If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.



