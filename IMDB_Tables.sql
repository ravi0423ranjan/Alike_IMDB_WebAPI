/****** Script for SelectTopNRows command from SSMS  ******/

--Contains all the producers(ProducerId-primary key)
  SELECT TOP (1000) [ProducerId]
      ,[ProducerName]
      ,[Producer_DOB]
      ,[Producer_CompanyName]
      ,[ProducerGender]
  FROM [IMDB].[dbo].[Producers]

  --Contains all the movies with (MovieId-primary key,ProducerId-foreign key)
  SELECT TOP (1000) [MovieId]
      ,[MovieName]
      ,[Movie_ReleaseDate]
      ,[ProducerId]
  FROM [IMDB].[dbo].[Movies]

  --Contains all the actors(ActorId-primary key)
  SELECT TOP (1000) [ActorId]
      ,[ActorName]
      ,[Actor_DOB]
      ,[ActorGender]
  FROM [IMDB].[dbo].[Actors]

  --Containing the Actors and Movies relationed data(ActorId,MovieId-both are primary as well as foreign key)
  SELECT TOP (1000) [ActorId]
      ,[MovieId]
  FROM [IMDB].[dbo].[ActorMovies]