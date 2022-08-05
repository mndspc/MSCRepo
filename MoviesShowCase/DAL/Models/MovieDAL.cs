using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MovieDAL : IMoviesDAL<Movie>
    {
     
        public bool AddMovie(Movie movie)
        {
            using (MSCDbEntities dbContext=new MSCDbEntities())
            {
                dbContext.Movies.Add(movie);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool DeleteMovie(int id)
        {         
            using (MSCDbEntities dbContext = new MSCDbEntities())
            {
                var movie = dbContext.Movies.Find(id);
                dbContext.Movies.Remove(movie);
                dbContext.SaveChanges();
                return true;
            }
        }

        public List<Movie> GetallMovies()
        {
            using (MSCDbEntities dbContext = new MSCDbEntities())
            {
                return dbContext.Movies.ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            using (MSCDbEntities dbContext = new MSCDbEntities())
            {
                var movie = dbContext.Movies.Find(id);         
                return movie;
            }
        }

        public bool UpdateMovie(Movie movie)
        {
            using (MSCDbEntities dbContext = new MSCDbEntities())
            {
                var existMovie = dbContext.Movies.Find(movie.MovieId);
                existMovie.MovieId=movie.MovieId;
                existMovie.Title=movie.Title;
                existMovie.ProductionYear=movie.ProductionYear;
                existMovie.Genere=movie.Genere;
                existMovie.Country = movie.Country;
                existMovie.DirectorID=movie.DirectorID;
                existMovie.OverAllRating=movie.OverAllRating;
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
