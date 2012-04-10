using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using MySql.Data;
using MySql.Data.MySqlClient;


namespace WebApplication3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string connStr = "server=130.207.114.235;user=cs4400_group8;database=cs4400_group8;password=u_f9gAnL;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                //string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent=@Continent";
                string sql = "SELECT name FROM category";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //Console.WriteLine("Enter a continent e.g. 'North America', 'Europe': ");
                //string user_input = Console.ReadLine();

                //cmd.Parameters.AddWithValue("@Continent", user_input);

                MySqlDataReader rdr = cmd.ExecuteReader();
                List<string> categories = new List<string>();

                while (rdr.Read())
                {
                    categories.Add(rdr["Name"].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}