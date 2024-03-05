# ASP.NET-WebAPI
WebAPI for CRUD operations of [library client app](https://github.com/D1lsh0d/WPF-Client-App) built with C# ASP.NET (.NET Framework 4.8).
This API interacts with library's database via Entity Framework.

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


