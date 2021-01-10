using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GalleryRepository
    {
        public List<Gallery> GetAllGalleries()
        {
            List<Gallery> results = new List<Gallery>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Gallery";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Gallery g = new Gallery();
                    g.Id = sqlDataReader.GetInt32(0);
                    g.Name = sqlDataReader.GetString(1);
                    g.Adress = sqlDataReader.GetString(2);
                    g.City = sqlDataReader.GetString(3);
                    g.Email = sqlDataReader.GetString(4);

                    results.Add(g);
                }
            }
            return results;
        }
        public int InsertGallery(Gallery g)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Gallery VALUES ('{0}','{1}','{2}','{3})", g.Name, g.Adress, g.City, g.Email);

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int UpdateGallery(Gallery g)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Gallery SET Name = '{0}', Adress = '{1}', City = '{2}', Email = '{3}' WHERE Id = '{4}'",
                 g.Name, g.Adress, g.City, g.Email, g.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteGallery(Gallery g)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM Gallery WHERE Id = '{0}'", g.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
