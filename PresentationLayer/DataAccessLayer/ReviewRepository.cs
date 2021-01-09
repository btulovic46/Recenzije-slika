using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReviewRepository
    {
        public List<Review> GetAllReviews()
        {
            List<Review> results = new List<Review>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Review";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Review r = new Review();
                    r.Id = sqlDataReader.GetInt32(0);
                    r.Comment = sqlDataReader.GetString(1);
                    r.Grade = sqlDataReader.GetDouble(2);
                    r.ReviewerId = sqlDataReader.GetInt32(3);
                    r.PictureId = sqlDataReader.GetInt32(4);
                    

                    results.Add(r);
                }
            }
            return results;
        }
        public int InsertReview(Review r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Review VALUES ('{0}',{1},{2},{3})", r.Comment, r.Grade, r.ReviewerId, r.PictureId);

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int UpdateReview(Review r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Review SET Comment = '{0}', Grade = {1}, ReviewerId = {2}, PictureId = {3} WHERE Id = '{4}'",
                 r.Comment, r.Grade, r.ReviewerId, r.PictureId, r.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteReview(Review r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM Review WHERE Id = '{0}'", r.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
