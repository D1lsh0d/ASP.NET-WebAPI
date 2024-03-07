# ASP.NET-WebAPI
WebAPI for CRUD operations of [library client app](https://github.com/D1lsh0d/WPF-Client-App) built with C# ASP.NET (.NET Framework 4.8).
This API interacts with library's database via Entity Framework.

## API Methods
# Books controller

| API                             | Description                              |
| ------------------------------- | ---------------------------------------- |
| [GET api/Books](/Help/Api/GET-api-Books)              | Gets list of Books from the server       |
| [GET api/Books/{id}](/Help/Api/GET-api-Books-id)      | Gets the book by Id from the server      |
| [POST api/Books](/Help/Api/POST-api-Books)            | Adds the book to the server               |
| [DELETE api/Books/{id}](/Help/Api/DELETE-api-Books-id) | Deletes the book by Id                  |
| [PUT api/Books](/Help/Api/PUT-api-Books)              | Updates the book data on the server      |

# Users controller

| API                             | Description                              |
| ------------------------------- | ---------------------------------------- |
| [GET api/Users](/Help/Api/GET-api-Users)              | Gets list of users from the server       |
| [GET api/Users/{id}](/Help/Api/GET-api-Users-id)      | Gets the user by Id                      |
| [POST api/Users](/Help/Api/POST-api-Users)            | Adds user to the server                  |
| [DELETE api/Users/{id}](/Help/Api/DELETE-api-Users-id) | Deletes user by Id                      |
| [PUT api/Users](/Help/Api/PUT-api-Users)              | Updates user's data                      |

# UserBooks controller

| API                               | Description                              |
| --------------------------------- | ---------------------------------------- |
| [GET api/UserBooks](/Help/Api/GET-api-UserBooks)    | Gets list of records (books that were taken by users) from the server |
| [POST api/UserBooks](/Help/Api/POST-api-UserBooks)  | Adds user-book record to the server      |
| [PUT api/UserBooks](/Help/Api/PUT-api-UserBooks)    | Updates user-book record                |
| [DELETE api/UserBooks/{id}](/Help/Api/DELETE-api-UserBooks-id) | Deletes user-book record by id       |

## Database
Database file is in [Database/](Database) folder.  
It has 3 tables:
1. Users
   ```SQL
   CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FullName]    NVARCHAR (50)  NOT NULL,
    [DateOfBirth] DATE           NULL,
    [Address]     NVARCHAR (255) NULL,
    [Email]       NVARCHAR (255) NOT NULL,
    [Phone]       NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) );
   ```
2. Books
   ```SQL
   CREATE TABLE [dbo].[Books] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Author]      NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [PrintDate]   DATE           NULL,
    [Quantity]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC) );
   ```
3. UserBooks - 
   ```SQL
   CREATE TABLE [dbo].[UserBooks] (
    [UserBookID]   INT  IDENTITY (1, 1) NOT NULL,
    [UserID]       INT  NOT NULL,
    [BookID]       INT  NOT NULL,
    [CheckoutDate] DATE NULL,
    [ReturnDate]   DATE NULL,
    PRIMARY KEY CLUSTERED ([UserBookID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([Id]) );
   ```

