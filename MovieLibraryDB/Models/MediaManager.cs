using System;


namespace MovieLibraryDB.Models
{
    public class MediaManager
    {

        private List<Movie> movies;
        private List<Show> shows;
        private List<Video> videos;




        public MediaManager()
        {
            //ADD AND POPULATE ***MOVIE*** OBJECT LIST
            movies = new List<Movie>();
            string movieListFile = "Files/movies10.csv";
            StreamReader movieReader = new StreamReader(movieListFile);
            //Skip header
            movieReader.ReadLine();
            int movieCount = 0;
            //Read video list until at end
            while (!movieReader.EndOfStream)
            {
                //Make new movie
                movies.Add(new Movie());
                //Hold all first movie elements in string
                string objectElements = movieReader.ReadLine();
                //Split each element to an array
                string[] arrayOfMovieElements = objectElements.Split(',');
                //Add each element to movie object properties
                movies[movieCount].Id = int.Parse(arrayOfMovieElements[0]);
                movies[movieCount].Title = arrayOfMovieElements[1];
                movies[movieCount].Genres = arrayOfMovieElements[2].Split('|');

                movieCount += 1;

            }
            movieReader.Close();

            //REPEAT STEPS FOR VIDEO OBJECTS AND SHOW OBJECTS FROM MOVIE OBJECTS



            //ADD AND POPULATE ***SHOW*** OBJECT LIST
            shows = new List<Show>();

            string showFileList = "Files/shows.csv";
            StreamReader showReader = new StreamReader(showFileList);
            //Skip header
            showReader.ReadLine();
            int showCount = 0;
            //Read video list until at end
            while (!showReader.EndOfStream)
            {
                shows.Add(new Show());
                string ElementsOfShowObjeect = showReader.ReadLine();
                string[] arrayOfShowElements = ElementsOfShowObjeect.Split(',');
                shows[showCount].Id = int.Parse(arrayOfShowElements[0]);
                shows[showCount].Title = arrayOfShowElements[1];
                shows[showCount].Episode = Int32.Parse(arrayOfShowElements[2]);
                shows[showCount].Season = Int32.Parse(arrayOfShowElements[3]);
                shows[showCount].Writers = arrayOfShowElements[4].Split('|');

                showCount += 1;

            }
            showReader.Close();




            //ADD AND POPULATE ***VIDEO*** OBJECT LIST
            videos = new List<Video>();

            string videoFileList = "Files/videos.csv";
            StreamReader videoReader = new StreamReader(videoFileList);
            //Skip header
            videoReader.ReadLine();
            int videoCount = 0;
            //Read video list until at end
            while (!videoReader.EndOfStream)
            {
                
                videos.Add(new Video());
                string elementsOfVideoObject = videoReader.ReadLine();
                string[] arrayOfVideoElements = elementsOfVideoObject.Split(',');
                videos[videoCount].Id = int.Parse(arrayOfVideoElements[0]);
                videos[videoCount].Title = arrayOfVideoElements[1];
                videos[videoCount].Format = arrayOfVideoElements[2].Replace("|", ", ");
                videos[videoCount].Length = Int32.Parse(arrayOfVideoElements[3]);
                string[] elementHolder = arrayOfVideoElements[4].Split("|");
                videos[videoCount].Regions = new int[elementHolder.Length];
                for (int i = 0; i < elementHolder.Length; i++)
                {
                    videos[videoCount].Regions[i] = Int32.Parse(elementHolder[i]);                 
                }
                videoCount += 1;

            }
            videoReader.Close();





        }
       
        //List each MOVIE object
        public void ListMovies()
        {
            foreach (var movie in movies)
            {
                movie.Display();

            }
        }

        //List each SHOW object
        public void ListShows()
        {
            foreach (var show in shows)
            {
                show.Display();

            }
        }

        //List each VIDEO object
        public void ListVideos()
        {
            foreach (var video in videos)
            {
                video.Display();

            }
        }

    }
}
