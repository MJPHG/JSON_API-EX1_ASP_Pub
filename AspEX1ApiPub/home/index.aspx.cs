using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace AspEX1ApiPub.home
{
    public partial class index : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public string usernameI { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                SessionsInit();
                UserCheck();



                DataTable dataTable = this.JSONDataTBL();

                foreach (DataRow rowd in dataTable.Rows)
                {
                    if (rowd["parent"] is System.DBNull)
                    {
                        rowd["parent"] = "0";

                    }

                }

                this.PopulateTreeView(dataTable, "0", null);

            }
        }

        private void PopulateTreeView(DataTable dtParent, string parentId, TreeNode treeNode)
        {
            DataTable dtablechild = new DataTable();
            DataRow[] results = dtParent.Select("[parent] = '" + parentId + "'");
            dtablechild = results.CopyToDataTable();

            foreach (DataRow row in dtablechild.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row[1].ToString(),
                    Value = row[0].ToString()

                };
                TreeNode childm = new TreeNode
                {
                    Text = row[1].ToString(),
                    Value = row[0].ToString()

                };

                if (parentId == "0")
                {
                    TV1.Nodes.Add(child);
                    PopulateTreeView(dtParent, child.Value, child);
                }

                else
                {
                    treeNode.ChildNodes.Add(child);
                }

            }
        }

        public DataTable JSONDataTBL()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://netzwelt-devtest.azurewebsites.net/Territories/All");
                var jsonLinq = JObject.Parse(json);
                DataTable dt = new DataTable();
                //dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
                var trgArray = new JArray();
                foreach (JObject row in srcArray.Children<JObject>())
                {
                    var cleanRow = new JObject();
                    foreach (JProperty column in row.Properties())
                    {

                        if (column.Value is JValue)
                        {
                            cleanRow.Add(column.Name, column.Value);
                        }
                    }

                    trgArray.Add(cleanRow);
                }

                return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
                //return dt;
            }
        }

        private void SessionsInit()
        {

            string sessionusernameI = (string)Session["UserName"] ?? "0";



            if (!string.IsNullOrEmpty(sessionusernameI) || sessionusernameI != "0")
            {
                usernameI = (string)Session["UserName"] ?? "0";
                usernamedisplay.Text = usernameI;
            }
            else
            {
                usernameI = "0";
            }
        }

        private void UserCheck()
        {
            if (usernameI == "0")
            {
                Session.Abandon();
                Response.Redirect("~/account/login.aspx");
            }

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/account/login.aspx");
        }
    }
}