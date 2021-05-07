using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Sentiment_Analytics_Courses.Models
{
    public class Context_
    {
        SqlConnection con;
        SqlTransaction objTrans = null;
        public Context_()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=sentiment-analytics;Integrated Security=True");
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            return builder.Build();
        }

        //SqlConnection con = new SqlConnection("Data Source=ADMINRG-N8EO0RN\\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=True");

        //Get data table sentiment
        public DataSet get_sentiment()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("select * from Sentiment", con);

                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        //create data table sentiment
        public string create_sentiment(Sentiment emp)
        {
            DataSet ds = new DataSet();
            try
            {
                string select = "select * from Sentiment where SentimentText = N'" + emp.sentimentText + "'";
                SqlCommand sel = new SqlCommand(select, con);

                con.Open();
                var s = sel.ExecuteScalar();
                con.Close();

                if (s == null)
                {
                    string query = "insert into Sentiment(sentiment,sentimentText) " +
                       "values (N'" + emp.sentiment + "', N'" + emp.sentimentText.ToLower() + "')";
                    SqlCommand com = new SqlCommand(query, con);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    return "success";
                }
                else
                {
                    var a = ds;
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    return "exist";
                }
               
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "error";
            }
        }

        public  string delete_sentiment(IEnumerable<string> emp)
        {
            DataSet ds = new DataSet();
            string query = "";
            int flat = 0;
            foreach (var data in emp)
            {
                query = "delete from Sentiment where SentimentText = N'" + data + "'";

                try
                {
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        flat++;
                    }
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        objTrans.Rollback();
                        con.Close();
                    }
                    //throw new InvalidConstraintException(ex.Message);
                    return "error";
                }
            }
            return "success";
        }
    }
}
