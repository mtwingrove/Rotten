using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;


namespace Rotten
{
    class Program
    {

        static void movieData(string movieTitle)
        {
            // Get the data
            string APIKey = **YOUR ROTTEN TOMATOES API KEY **;
            string URLRequest = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=" + APIKey + "&q=" + movieTitle + "&page_limit=1";
           
            var textFromFile = (new WebClient()).DownloadString(URLRequest);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(textFromFile);
            var json = Newtonsoft.Json.Linq.JObject.Parse(textFromFile);
            var criticsScore = "";
            var criticsRating = "";
            var audienceScore = "";
            try
            {
                var actualMovieName = (string)json["movies"][0]["title"];
                var year = (string)json["movies"][0]["year"];
                var rating = (string)json["movies"][0]["mpaa_rating"];
                var runtime = (int)json["movies"][0]["runtime"];
                criticsScore = (string)json["movies"][0]["ratings"]["critics_score"];
                criticsRating = (string)json["movies"][0]["ratings"]["critics_rating"];
                audienceScore = (string)json["movies"][0]["ratings"]["audience_score"];

                if (criticsScore == "-1")
                {
                    criticsScore = @"N/A";
                }
                Console.WriteLine("\n" + actualMovieName + " (" + year + ")" + "\n" + littleLines(actualMovieName.Length));
                Console.WriteLine("MPAA Rating: " + nz(rating,"Not rated."));
                Console.WriteLine("Runtime: " + convertRuntimeString(runtime));
                Console.WriteLine("Critics Rating: " + nz(criticsRating,@"N/A"));
                Console.WriteLine("Critics Score: " + criticsScore);
                Console.WriteLine("Audience Score: " + nz(audienceScore,@"N/A")+"\n");
            }
            catch
            {   
                //Rotten Tomatoes didn't find anything to return
                Console.WriteLine("Could not find data for \"" + movieTitle + "\"\n");
            }
        }

        static string nz(string strInput, string strIfNull){
            string strReturn = "";
            if (strInput == null)
            {
                strReturn = strIfNull;
            }
            else
            {
                strReturn = strInput;
            }

            return strReturn;
        }
        static string convertRuntimeString(int runtimeMin)
        {
            //Converts 92min into 1:32
            TimeSpan span = TimeSpan.FromMinutes(runtimeMin);
            string runtimeString = span.ToString(@"h\:mm");
            return runtimeString;
        }
        static string littleLines(int titleLength)
        {
            //Adds the correct number of dashes underneath the title of the movie
            // Adds seven more dashes to account for the year string that is appended, " (1994)"
            string lines = "--------";
            for (int i = 0; i < titleLength; i++)
            {
                lines = lines + "-";
            }
            return lines;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\nSearching Rotten Tomatoes...");
            foreach (string s in args)
            {
                movieData(s);
            }
            // For Testing
            //movieData("/asdf");
            //Console.ReadLine();
        }
      
    }
}
