using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReviewerRepository
    {
        public List<Reviewer> GetAllReviewers()
        {
            List<Reviewer> results = new List<Reviewer>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Reviewer";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Reviewer r = new Reviewer();
                    r.Id = sqlDataReader.GetInt32(0);
                    r.Name = sqlDataReader.GetString(1);
                    r.LastName = sqlDataReader.GetString(2);
                    r.Email = sqlDataReader.GetString(3);
                    r.Adress = sqlDataReader.GetString(4);
                    r.City = sqlDataReader.GetString(5);
                    r.PhoneNumber = sqlDataReader.GetDecimal(6);

                    results.Add(r);
                }
            }
            return results;
        }
        public int InsertReviewer(Reviewer r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Reviewer VALUES ('{0}','{1}','{2}','{3}','{4}',{5})", r.Name, r.LastName, r.Email, r.Adress, r.City, r.PhoneNumber);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
