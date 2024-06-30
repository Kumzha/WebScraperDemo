using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraperDemo
{
    internal class MainApp
    {
        public static void Main (string[] args)

        {
            int NumberOfFilms = 150;


            WebScrapper webScreapper = new WebScrapper();
            FilmData[] filmData = webScreapper.RunSearch(150);

            MySqlConnection SqlConn = SqlConnection.SqlConnect();

            /*            string sqlSelect = "SELECT * FROM films";
                        //INSERT INTO `film_db`.`films` (`filmID`, `filmName`, `filmRating`) VALUES ('5', 'Film5', '5');
                        MySqlCommand cmd = new MySqlCommand(sqlSelect, SqlConn);
                        MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                        string data = "";

                        while (mySqlDataReader.Read())
                        {
                            data += "ID: " + mySqlDataReader["id"] + ", Name: " + mySqlDataReader["name"] + ", Rating: " + mySqlDataReader["rating"] + "\n";
                        }

                        Console.Write(data);
            */

/*            for (int i = 0; i < NumberOfFilms; i++)
            {
                string sqlInsert = "INSERT INTO films (name, rating, release_date, number_of_votes) VALUES (@name, @rating, @releaseDate, @numOfVotes)";

                using (MySqlCommand InsertIntoFilms = new MySqlCommand(sqlInsert, SqlConn))
                {
                    InsertIntoFilms.Parameters.AddWithValue("@name", filmData[i].name);
                    InsertIntoFilms.Parameters.AddWithValue("@rating", filmData[i].rating);
                    InsertIntoFilms.Parameters.AddWithValue("@releaseDate", filmData[i].releaseDate);
                    InsertIntoFilms.Parameters.AddWithValue("@numOfVotes", filmData[i].numOfVotes);

                    InsertIntoFilms.ExecuteNonQuery();
                }
            }*/


        }

    }
}
