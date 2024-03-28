using OpenAI_API.Moderation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RL
{
    internal class Helper
    {
        Random random = new Random();
        public String randomlySelect(string[] stringArray, int optional)
        {
            if (optional == 1)
            {
                var o = random.Next(0, 2);
                if (o == 0)
                {
                    return "";
                }
            }
            var choice = random.Next(0, stringArray.Length);
            return stringArray[choice];
        }
        public int randomFromRange(int start, int end)
        {
            var choice = random.Next(start, end);
            return choice;
        }

        public void store(string selectedBasePrompt, string selectedModifier, string selectedBeefModifier, string question, string response)
        {
            string connetionString = "Server=localhost;Database=master;Trusted_Connection=True;";
            string sql = "insert into [dbo].[TheDumpster] ([Prompt], [Modifier], [BeefModifier], [Question], [Response]) values(@selectedBasePrompt, @selectedModifier, @selectedBeefModifier, @question, @response)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.Add("@selectedBasePrompt", SqlDbType.NVarChar).Value = selectedBasePrompt;
                        cmd.Parameters.Add("@selectedModifier", SqlDbType.NVarChar).Value = selectedModifier;
                        cmd.Parameters.Add("@selectedBeefModifier", SqlDbType.NVarChar).Value = selectedBeefModifier;
                        cmd.Parameters.Add("@question", SqlDbType.NVarChar).Value = question;
                        cmd.Parameters.Add("@response", SqlDbType.NVarChar).Value = response;

                        // Let's ask the db to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                           Console.WriteLine("Row inserted!!");
                        else
                            // Well this should never really happen
                            Console.WriteLine("No row inserted");

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                }
            }
        }
    }
}
