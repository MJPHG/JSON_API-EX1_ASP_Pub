using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;
using System.Web.Security;

namespace AspEX1ApiPub.account
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {


            var postdataJ = new PostLoginData
            {
                username = usertb.Text,
                password = passtb.Text
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://netzwelt-devtest.azurewebsites.net/");

            string jsonData = JsonConvert.SerializeObject(postdataJ);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("Account/SignIn", content).Result;


            if (String.IsNullOrEmpty(usertb.Text) || String.IsNullOrEmpty(passtb.Text))
            {
                promptR.Text = "Username and Password is required!";
            }

            else if (!response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var postResponse = System.Text.Json.JsonSerializer.Deserialize<PostResponse>(responseContent, options);

                var responseContent2 = response.Content.ReadAsStringAsync().Result;
                var options2 = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var postResponse2 = System.Text.Json.JsonSerializer.Deserialize<PostResponse>(responseContent2, options2);

                promptR.Text = postResponse.message;
                
            }
            else
            {
                Session["UserName"] = postdataJ.username;
                Response.Redirect("~/home/index.aspx");

            }
        }
    }
}