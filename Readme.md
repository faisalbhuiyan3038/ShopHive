### This is the backend for ShopHive E-Commerce Project. [Click to go to the frontend.](https://github.com/faisalbhuiyan3038/ShopHiveClient)

## Tech Stack (for Backend)

- .Net Core Web Api
- Microsoft SQL Server

## Tech Stack (for Frontend)

- Angular JS
- Node JS
- Bootstrap
- Redis

## Gettng Started

To get started with the backend, follow these steps:

1. Clone this repository.

   ```bash
   git clone https://github.com/faisalbhuiyan3038/ShopHive.git

   cd ShopHive
   ```

2. Open the project folder in Visual Studio (not Visual Studio Code)
3. Install the missing dependencies.
4. Open the NuGet Package Manager Console and add the first Migration to create the database.

   ```shell
   Add-Migration "Initial Migration" -Context ShopHiveDbContext
   Update-Database

   Add-Migration "Initial Migration" -Context AuthDbContext
   Update-Database
   ```

5. That's it for the backend.

## Features

| Feature                                               |  Coded?  | Description                                |
| ----------------------------------------------------- | :------: | :----------------------------------------- |
| Add a Product                                         | &#10004; | Ability of Add a Product on the System     |
| List Products                                         | &#10004; | Ability of List Products                   |
| Edit a Product                                        | &#10004; | Ability of Edit a Product                  |
| Delete a Product                                      | &#10004; | Ability of Delete a Product                |
| Add Item to Cart                                      | &#10004; | Ability to Add Item to Cart                |
| Delete Items in Cart                                  | &#10004; | Ability to delete the items in Cart        |
| Modify Quantity in Cart                               | &#10004; | Ability to modify quantity of item in Cart |
| Checkout                                              | &#10004; | Ability to Checkout with the items in cart |
| Login/Register Users                                  | &#10004; | Create new users or sign in existing ones  |
| Generate JsonWebTokens on Login                       | &#10004; | Generate web tokens for security           |
| Filter Products by Price, Category and Alphabetically | &#10004; | Filter the products                        |

## Website Preview

![Home Page](/Screenshots/1.jpg)

<p align="center">Home Page</p>
<br>

![Products Page](/Screenshots/2.jpg)

<p align="center">Products Page</p>
<br>

![Single Product Page](/Screenshots/3.jpg)

<p align="center">Single Product Page</p>
<br>

![Cart Page](/Screenshots/4.jpg)

<p align="center">Cart Page</p>
<br>

![Login Page](/Screenshots/5.jpg)

<p align="center">Login Page</p>
<br>

![Register Page](/Screenshots/6.jpg)

<p align="center">Register Page</p>
<br>
