using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PictureRepository
    {
        public List<Picture> GetAllPictures()
        {
            List<Picture> results = new List<Picture>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Picture";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Picture p = new Picture();
                    p.Id = sqlDataReader.GetInt32(0);
                    p.Name = sqlDataReader.GetString(1);
                    p.Creator = sqlDataReader.GetString(2);
                    p.Description = sqlDataReader.GetString(3);
                    p.AverageGrade = sqlDataReader.GetDouble(4);
                    p.GalleryId = sqlDataReader.GetInt32(5);
                    

                    results.Add(p);
                }
            }
            return results;
        }
        public int InsertPicture(Picture p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Picture VALUES ('{0}','{1}','{2}',{3},{4})", p.Name, p.Creator, p.Description, p.AverageGrade, p.GalleryId);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
