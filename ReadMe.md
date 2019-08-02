After opening the solution in VisualStudio 2017 Start the webapi in the Visual Studio
Use the follwoing request to see the response

FindMovie  Reuqest:
http://localhost:1054/MovieApi/FindMovies?title=Lion

GetTopMoviesByRating:
http://localhost:1054/MovieApi/GetTopMoviesByRating

GetTopMoviesByUserRating:
http://localhost:1054/MovieApi/GetTopMoviesByUserRating?userId=82296457-c267-4c88-b009-ec7092aa11e3

Updating the Rating:
PUT http://localhost:1054/MovieApi/EditRating?userId=2e8b43bb-5e5b-4243-8e30-8be8254bf7d1&MovieId=8006122c-3893-4a91-bd5e-a20c9dd54369 HTTP/1.1
User-Agent: Fiddler
Content-Type: application/json
Host: localhost:1054
Content-Length: 3

"4"
