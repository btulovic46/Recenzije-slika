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
        public int UpdatePicture(Picture p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Picture SET Name = '{0}', Creator = '{1}', Description = '{2}', AverageGrade = {3}, WHERE Id = '{4}'",
                 p.Name, p.Creator, p.Description, p.AverageGrade, p.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeletePicture(Picture p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM Picture WHERE Id = '{0}'", p.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
