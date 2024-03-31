# StoredProcedureTask

# stored procedure script
Create Procedure spGetAllBooks
as
Begin
  Select Id, Publisher, Title, ContainerTitle, AuthorLastName, AuthorFirstName, Price, VolumeNumber, PublicationYear, PublicationMonth, PageStartNumber, 
PageEndNumber, URL, CreatedTime from books 
End

