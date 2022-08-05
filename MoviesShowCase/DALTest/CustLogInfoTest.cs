using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using DAL.Models;
using System.Collections;

namespace DALTest
{

    [TestFixture]
    internal class MovieDALTest
    {
        [Test]
        public void AddMovieTest()
        {
            Mock<IMoviesDAL<Movie>> mockObject = new Mock<IMoviesDAL<Movie>>();
            var flag = false;
            Movie movie = new Movie { MovieId = 1, Title = "3 Idiots", Genere = Genre.Drama, OverAllRating = 9, DirectorID = 1, Country = "India", ProductionYear = 2009 };
            if (movie.MovieId> 0)
            {
                flag = true;
            }          
            mockObject.Setup(m=>m.AddMovie(movie)).Returns(flag);
            Mock.Verify();
            var result = mockObject.Object;
            //Actual Result
            var movieDALResult = result.AddMovie(movie);

            //Expected Result
            Assert.True(movieDALResult);
        }

        [Test]
        public void GetAllMoviesTest()
        {
            ArrayList codes = new ArrayList {1,2 };
            Mock<IMoviesDAL<Movie>> mockObject = new Mock<IMoviesDAL<Movie>>();
            mockObject.Setup(m => m.GetallMovies()).Returns(new List<Movie> { new Movie { MovieId = 1, Title = "3 Idiots", Genere = Genre.Drama, OverAllRating = 9, DirectorID = 2, Country = "India", ProductionYear = 2009 }, new Movie { MovieId = 2, Title = "Swades", Genere = Genre.Drama, OverAllRating = 7, DirectorID = 2, Country = "India", ProductionYear = 2004 } });

            var flag = false;
            var actualMovies = mockObject.Object;
            var expectedMovies = actualMovies.GetallMovies();
            expectedMovies = expectedMovies.ToList();
            foreach (var movie in expectedMovies)
            {
                if (codes.Contains( movie.MovieId))
                {
                    flag= true;
                }
            }
            Assert.True(flag);
        }

        [Test]
        [TestCase(1)]
        public void GetMovieById(int id)
        {
            var flag = false;
            Mock<IMoviesDAL<Movie>> mockObject = new Mock<IMoviesDAL<Movie>>();

            mockObject.Setup(m => m.GetMovieById(id)).Returns(new Movie { MovieId = 1, Title = "3 Idiots", Genere = Genre.Drama, OverAllRating = 9, DirectorID = 2, Country = "India", ProductionYear = 2009 });

            Mock.Verify();
            var actualMoviewResult = mockObject.Object;
            var expectedMovie= actualMoviewResult.GetMovieById(id);

            var actualResult= actualMoviewResult.GetMovieById(id);
            Assert.AreEqual(expectedMovie.MovieId, actualResult.MovieId);
        }

        [Test]
        [TestCase(1)]
        public void DeleteMovieTest(int id)
        {
            Mock<IMoviesDAL<Movie>> mockObject = new Mock<IMoviesDAL<Movie>>();
            var flag = false;
        
            mockObject.Setup(m => m.DeleteMovie(id)).Returns(flag);
            Mock.Verify();
            var result = mockObject.Object;
            //Actual Result
            var movieDALResult = result.DeleteMovie(id);

            //Expected Result
            Assert.True(movieDALResult);
        }


        [Test]
        public void UpdateMovieTest()
        {
            Mock<IMoviesDAL<Movie>> mockObject = new Mock<IMoviesDAL<Movie>>();
            var flag = false;
            Movie movie = new Movie { MovieId = 1, Title = "3 Idiots", Genere = Genre.Drama, OverAllRating = 9, DirectorID = 1, Country = "India", ProductionYear = 2009 };
            if (movie.MovieId > 0)
            {
                flag = true;
            }
            mockObject.Setup(m => m.UpdateMovie(movie)).Returns(flag);
            Mock.Verify();
            var result = mockObject.Object;
            //Actual Result

            var movieDALResult = result.UpdateMovie(movie);

            //Expected Result
            Assert.True(movieDALResult);
        }
    }
}