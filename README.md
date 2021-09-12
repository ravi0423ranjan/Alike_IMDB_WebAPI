Following are the various URLs with their requests and responses:

1. Creating an actor(POST) - https://localhost:44326/api/Actor

   Sample Request -
       {
     "ActorName":"Kriti",
     "Actor_DOB":"2009-03-10",
     "ActorGender":"Female"
    }

    Sample Response-
    {
    "actorId": 4,
       "actorName": "Kriti",
   "actor_DOB": "2009-03-10T00:00:00",
       "actorGender": "Female"
}

2.Creating a Producer(POST) - https://localhost:44326/api/producer 

Sample Request -
      {  
   "ProducerName":"Anurag",
   "Producer_DOB":"2019-09-30",
   "Producer_CompanyName":"FM Productions",
   "ProducerGender":"Male"
}

    Sample Response-
   {
    "producerId": 4,
    "producerName": "Kapoor",
    "producer_DOB": "2011-09-27T00:00:00",
    "producer_CompanyName": "Daily Productions",
    "producerGender": "Male"
}

3.Get All Movies(GET) - https://localhost:44326/api/movie 
Sample Response-
[
    {
        "movieName": "3 Idiots",
        "releaseDate": "2020-01-11T00:00:00",
        "producer": "Jennifer",
        "actors": [
            "VBN",
            "SDF"
        ]
    },
    {
        "movieName": "YUIO",
        "releaseDate": "2020-11-23T00:00:00",
        "producer": "Jennifer",
        "actors": [
            "SDF"
        ]
    },
    {
        "movieName": "GHJJ",
        "releaseDate": "2020-01-10T00:00:00",
        "producer": "Sam",
        "actors": [
            "VBN",
            "SDF"
        ]
    }
]

4.Create a Movie(POST) - https://localhost:44326/api/movie 

Sample Request -
      {
    "MovieName":"SherShaah",
    "Movie_ReleaseDate":"2021-01-11",
    "ProducerId":4,
    "ActorsId":[2,3]
}

    Sample Response-
  {
    "movieId": 10,
    "movieName": "SherShaah",
    "movie_ReleaseDate": "2021-01-11T00:00:00",
    "producerId": 4,
    "actorsId": [
        2,
        3
    ]
}

5.Edit a Movie(PUT) - https://localhost:44326/api/movie/10 

Sample Request -
      {
    "MovieId":10,
    "MovieName":"SherShaah",
    "Movie_ReleaseDate":"2021-08-15",
    "ProducerId":3,
    "ActorsId":[4,3]
}

    Sample Response-
  {
    "movieId": 10,
    "movieName": "SherShaah",
    "movie_ReleaseDate": "2021-08-15T00:00:00",
    "producerId": 3,
    "actorsId": [
        4,
        3
    ]
}

6.Get Movie Details(GET) - https://localhost:44326/api/movie/1 

Sample Response-
  [
    {
        "movieName": "3 Idiots",
        "releaseDate": "2020-01-11T00:00:00",
        "producer": "Jennifer",
        "actors": [
            "VBN",
            "SDF"
        ]
    }
]






