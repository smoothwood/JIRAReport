using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JIRAReport
{
    public partial class Form1 : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RapidViewID { get; set; }
        public string Cookies { get; set; }
        public string SelectedSprint { get; set; }
        public string SprintID { get; set; }
        public Dictionary<string, string> KeyValues { get; set; }
        public Form1()
        {
            
            InitializeComponent();
            KeyValues = new Dictionary<string, string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load basic info json file
            string basicInfoFilePath = ConfigurationManager.AppSettings["BasicInfo"];
            if (File.Exists(basicInfoFilePath))
            {
                using (StreamReader reader = new StreamReader(basicInfoFilePath))
                {
                    string jsonString = reader.ReadToEnd();
                    JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                    txtScrumTeamName.Text = jsonObject.Value<string>("ScrumTeamName").ToString();
                    txtScrumMaster.Text = jsonObject.Value<string>("ScrumMaster").ToString();
                    txtProductOwner.Text = jsonObject.Value<string>("ProductOwner").ToString();
                    txtSprintDuration.Text = jsonObject.Value<string>("SprintDuration").ToString();
                    txtUsername.Text = jsonObject.Value<string>("Username").ToString();
                    txtPassword.Text = jsonObject.Value<string>("Password").ToString();
                    txtRapidViewID.Text = jsonObject.Value<string>("RapidViewID").ToString();
                    JArray resources = jsonObject.Value<JArray>("Resources");
                    for(int i = 0; i < resources.Count; i++)
                    {
                        JObject resource = (JObject)resources[i];
                        gridResources.Rows.Add(
                            resource.Value<string>("ResourceName"),
                            resource.Value<string>("ResourceAvailability"),
                            resource.Value<string>("ResourceIDD"),
                            resource.Value<string>("ResourcePoints")
                        );
                    }


                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Username = txtUsername.Text.Trim();
                Password = txtPassword.Text.Trim();
                RapidViewID = txtRapidViewID.Text.Trim();

                if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(RapidViewID))
                {
                    return;
                }

                string credentialJson = "{\"username\":\"" + Username + "\",\"password\":\"" + Password + "\"}";
                string loginUrl = ConfigurationManager.AppSettings["LoginUrl"]; ;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginUrl);
                request.Method = "POST";
                request.ContentType = "application/json";

                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(credentialJson);
                    writer.Flush();
                }

                string cookies = "";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    cookies = response.GetResponseHeader("Set-Cookie");
                }
                //cookies string is something like: 
                //atlassian.xsrf.token=BNXE-6XGL-SVKK-NPBS|3aa69c9f1daa2c7e6071e49b20389e2994e71deb|lout;path=/,JSESSIONID=8208E5E3D568E23DEEB4DD67EE69ADA6;path=/;HttpOnly,AWSELB=29275955028EFEB51C86FD2BA33417069E3834007AFD5BB378F7D3BEA374103F885E613DAA542C0196619B7DB4DE7B3D5B656FA35A788D6FB74754DD872C953B234D095EE2;PATH=/;MAX-AGE=28800
                //need to replace "," with ";"
                cookies = cookies.Replace(",", ";");
                Cookies = cookies;

                string sprintsUrl = ConfigurationManager.AppSettings["SprintsUrl"];
                sprintsUrl = String.Format(sprintsUrl, RapidViewID);
                request = (HttpWebRequest)WebRequest.Create(sprintsUrl);
                request.Method = "GET";
                request.Headers.Add("Cookie", Cookies);

                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonString = reader.ReadToEnd();
                    JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                    JArray sprints = jsonObject.Value<JArray>("values");
                    JObject sprint;
                    gridSprints.Rows.Clear();
                    for(int i = 0; i < sprints.Count(); i++)
                    {
                        sprint = (JObject) sprints[i];
                        gridSprints.Rows.Add(
                            sprint.Value<string>("id"),
                            sprint.Value<string>("name"),
                            sprint.Value<string>("state"),
                            sprint.Value<string>("startDate"),
                            sprint.Value<string>("completeDate")
                            );
                    }
                }
                toolStripStatusLabel1.Text = "Double click sprint to show details";
                statusStrip1.Refresh();
            }
            catch(Exception ex)
            {
                
                toolStripStatusLabel1.Text = ex.Message;
                statusStrip1.Refresh();
            }
        }

        private void gridSprints_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                SelectedSprint = gridSprints.Rows[e.RowIndex].Cells[1].Value.ToString();
                SprintID = gridSprints.Rows[e.RowIndex].Cells[0].Value.ToString();
                string storiesUrl = ConfigurationManager.AppSettings["StoriesUrl"];
                storiesUrl = String.Format(storiesUrl, RapidViewID, SprintID);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(storiesUrl);
                request.Method = "GET";
                request.Headers.Add("Cookie", Cookies);

                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonString = reader.ReadToEnd();
                    JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonString);

                    JObject contents = jsonObject.Value<JObject>("contents");

                    JArray completedIssues = contents.Value<JArray>("completedIssues");
                    JArray issuesNotCompletedInCurrentSprint = contents.Value<JArray>("issuesNotCompletedInCurrentSprint");
                    JArray puntedIssues = contents.Value<JArray>("puntedIssues");
                    JObject issueKeysAddedDuringSprint = contents.Value<JObject>("issueKeysAddedDuringSprint");
                    //
                    List<string> addedStories = issueKeysAddedDuringSprint.Properties().Select(p => p.Name).ToList();


                    JObject issue;
                    string issueStatus;
                    gridStories.Rows.Clear();
                    for (int i = 0; i < completedIssues.Count(); i++)
                    {
                        issue = (JObject)completedIssues[i];
                        issueStatus = "Completed";
                        if (addedStories.IndexOf(issue.Value<string>("key")) > -1)
                        {
                            issueStatus = "Added-Completed";
                        }
                        gridStories.Rows.Add(
                            issue.SelectToken("epic")!=null?issue.Value<string>("epic"):"N/A",
                            issue.Value<string>("key"),
                            issue.Value<string>("summary"),
                            issue.Value<JObject>("currentEstimateStatistic").Value<JObject>("statFieldValue").Value<string>("value"),
                            issue.Value<string>("assigneeName"),
                            issueStatus
                        );
                    }

                    for (int i = 0; i < issuesNotCompletedInCurrentSprint.Count(); i++)
                    {
                        issue = (JObject)issuesNotCompletedInCurrentSprint[i];
                        issueStatus = "NotCompleted";
                        if (addedStories.IndexOf(issue.Value<string>("key")) > -1)
                        {
                            issueStatus = "Added-NotCompleted";
                        }
                        gridStories.Rows.Add(
                            issue.SelectToken("epic") != null ? issue.Value<string>("epic") : "N/A",
                            issue.Value<string>("key"),
                            issue.Value<string>("summary"),
                            issue.Value<JObject>("currentEstimateStatistic").Value<JObject>("statFieldValue").Value<string>("value"),
                            issue.Value<string>("assigneeName"),
                            issueStatus
                        );
                    }

                    for (int i = 0; i < puntedIssues.Count(); i++)
                    {
                        issue = (JObject)puntedIssues[i];
                        issueStatus = "Punted";
                        gridStories.Rows.Add(
                            issue.SelectToken("epic") != null ? issue.Value<string>("epic") : "N/A",
                            issue.Value<string>("key"),
                            issue.Value<string>("summary"),
                            issue.Value<JObject>("currentEstimateStatistic").Value<JObject>("statFieldValue").Value<string>("value"),
                            issue.Value<string>("assigneeName"),
                            issueStatus
                        );
                    }
                }
            }
        }

        private void btnGenerateWord_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValues.Clear();
                if (gridStories.Rows.Count == 0)
                {
                    toolStripStatusLabel1.Text = "Please select a valid sprint...";
                    return;
                }
                string targetFile = SelectedSprint + ".docx";
                File.Copy("template.docx", targetFile, true);


                FillTables(targetFile);

                // create key value pair, key represents words to be replace and 
                //values represent values in document in place of keys.
                
                KeyValues.Add("__PLACEHOLDER__SCRUM_TEAM_NAME", txtScrumTeamName.Text);
                KeyValues.Add("__PLACEHOLDER__SCRUM_MASTER", txtScrumMaster.Text);
                KeyValues.Add("__PLACEHOLDER__PRODUCT_OWNER", txtProductOwner.Text);
                KeyValues.Add("__PLACEHOLDER__SPRINT_DURATION", txtSprintDuration.Text);
                               
                KeyValues.Add("__PLACEHOLDER__SPRINT_NAME", SelectedSprint);
                string burndownChartUrl = string.Format(ConfigurationManager.AppSettings["BurndownChartUrl"], RapidViewID, SprintID);
                KeyValues.Add("__PLACEHOLDER__BURNDOWN_CHART", System.Net.WebUtility.HtmlEncode(burndownChartUrl));


                ReplacePlaceholder(targetFile, KeyValues);

                //Write basic info back to json file
                JObject basicInfo = new JObject();
                basicInfo.Add("ScrumTeamName", txtScrumTeamName.Text);
                basicInfo.Add("ScrumMaster", txtScrumMaster.Text);
                basicInfo.Add("ProductOwner", txtProductOwner.Text);
                basicInfo.Add("SprintDuration", txtSprintDuration.Text);
                basicInfo.Add("Username", txtUsername.Text);
                basicInfo.Add("Password", txtPassword.Text);
                basicInfo.Add("RapidViewID", txtRapidViewID.Text);
                JArray resources = new JArray();
                for(int i = 0; i < gridResources.Rows.Count - 1; i++)
                {
                    JObject resource = new JObject();
                    resource.Add("ResourceName", gridResources.Rows[i].Cells["gridResourceName"].Value.ToString());
                    resource.Add("ResourceAvailability", gridResources.Rows[i].Cells["gridResourceAvailability"].Value.ToString());
                    resource.Add("ResourceIDD", gridResources.Rows[i].Cells["gridResourceIDD"].Value.ToString());
                    resource.Add("ResourcePoints", gridResources.Rows[i].Cells["gridResourcePoints"].Value.ToString());
                    resources.Add(resource);
                }

                basicInfo.Add("Resources", resources);
                File.WriteAllText(ConfigurationManager.AppSettings["BasicInfo"], JsonConvert.SerializeObject(basicInfo));

                toolStripStatusLabel1.Text = "File generated successfully!";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            
        }

        public void FillTables(string document)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                #region Generate rows for each table
                TableRow tr;
                TableCell tc;

                #region Add rows for the first table in the document - EPICS in Sprint.
                int totalResourcePoints = 0;
                int totalResourceHours = 0;
                Table table1 = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().First();
                List<string> epics = new List<string>();
                for (int i = 0; i < gridStories.Rows.Count; i++)
                {

                    string epic = gridStories.Rows[i].Cells["gridStoryEpic"].Value.ToString();
                    if (epic != "N/A")
                    {
                        if (epics.IndexOf(epic) < 0)
                        {
                            epics.Add(epic);
                        }
                    }
                }

                for (int i = 0; i < epics.Count; i++)
                {
                    tr = new TableRow();

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(epics[i]))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text())));
                    tr.Append(tc);//leave second column blank, users fill value by themselves

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text())));
                    tr.Append(tc);//leave third column blank, users fill value by themselves

                    table1.Append(tr);
                }
                #endregion

                #region Add rows for the second table in the document - Capacity
                Table table2 = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().Skip(1).First();
                for (int i = 0; i < gridResources.Rows.Count-1; i++)
                {
                    tr = new TableRow();

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridResources.Rows[i].Cells["gridResourceName"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridResources.Rows[i].Cells["gridResourceAvailability"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridResources.Rows[i].Cells["gridResourceIDD"].Value.ToString()))));
                    tr.Append(tc);
                    totalResourceHours += Convert.ToInt32(gridResources.Rows[i].Cells["gridResourceIDD"].Value);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridResources.Rows[i].Cells["gridResourcePoints"].Value.ToString()))));
                    tr.Append(tc);
                    totalResourcePoints += Convert.ToInt32(gridResources.Rows[i].Cells["gridResourcePoints"].Value);

                    table2.Append(tr);
                }
                tr = new TableRow();

                tc = new TableCell();
                tc.Append(new Paragraph(new Run(new Text())));
                tr.Append(tc);

                tc = new TableCell();
                tc.Append(new Paragraph(new Run(new Text("Total"))));
                tr.Append(tc);

                tc = new TableCell();
                tc.Append(new Paragraph(new Run(new Text(totalResourceHours.ToString()))));
                tr.Append(tc);

                tc = new TableCell();
                tc.Append(new Paragraph(new Run(new Text(totalResourcePoints.ToString()))));
                tr.Append(tc);

                table2.Append(tr);
                #endregion

                #region Add rows for the third table in the document - Story Point commitment
                Table table3 = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().Skip(2).First();
                int totalStoryPoints = 0;
                for (int i = 0; i < gridStories.Rows.Count; i++)
                {
                    if (!chkChaos.Checked)
                    {
                        if (gridStories.Rows[i].Cells["gridStoryStatus"].Value.ToString().ToLower().StartsWith("added"))
                        {
                            continue;
                        }
                    }
                    tr = new TableRow();

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStoryEpic"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    string storyKey = gridStories.Rows[i].Cells["gridStoryKey"].Value.ToString();
                    Hyperlink hl = new Hyperlink(new Run(new Text(storyKey)))
                    {
                        Id = storyKey
                    };
                    tc.Append(new Paragraph(hl));
                    wordDoc.MainDocumentPart.AddHyperlinkRelationship(new Uri(String.Format(ConfigurationManager.AppSettings["IssueViewUrl"], storyKey)), false, storyKey);

                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStorySummary"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStoryPoint"].Value.ToString()))));
                    tr.Append(tc);

                    table3.Append(tr);

                    totalStoryPoints += Convert.ToInt32(gridStories.Rows[i].Cells["gridStoryPoint"].Value);
                }
                KeyValues.Add("__PLACEHOLDER__TOTAL_STORY_POINTS", totalStoryPoints.ToString());
                #endregion

                #region Add rows for the forth table in the document - Stories Added to Sprint
                Table table4 = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().Skip(3).First();
                for (int i = 0; i < gridStories.Rows.Count; i++)
                {
                    if(!gridStories.Rows[i].Cells["gridStoryStatus"].Value.ToString().ToLower().StartsWith("added"))
                    {
                        continue;
                    }
                    tr = new TableRow();

                    tc = new TableCell();
                    string storyKey = gridStories.Rows[i].Cells["gridStoryKey"].Value.ToString();
                    Hyperlink hl = new Hyperlink(new Run(new Text(storyKey)))
                    {
                        Id = "Added"+storyKey
                    };
                    tc.Append(new Paragraph(hl));
                    wordDoc.MainDocumentPart.AddHyperlinkRelationship(new Uri(String.Format(ConfigurationManager.AppSettings["IssueViewUrl"], storyKey)), false, "Added" + storyKey);

                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStorySummary"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStoryPoint"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell(); //leave forth column blank, users should fill out by themselves
                    tc.Append(new Paragraph(new Run(new Text())));
                    tr.Append(tc);

                    table4.Append(tr);

                }
                #endregion

                #region Add rows for the fifth table in the document - Punted Stories 
                Table table5 = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().Skip(4).First();
                for (int i = 0; i < gridStories.Rows.Count; i++)
                {
                    if (!gridStories.Rows[i].Cells["gridStoryStatus"].Value.ToString().ToLower().StartsWith("punted"))
                    {
                        continue;
                    }
                    tr = new TableRow();

                    tc = new TableCell();
                    string storyKey = gridStories.Rows[i].Cells["gridStoryKey"].Value.ToString();
                    Hyperlink hl = new Hyperlink(new Run(new Text(storyKey)))
                    {
                        Id = "Punted"+ storyKey
                    };
                    tc.Append(new Paragraph(hl));
                    wordDoc.MainDocumentPart.AddHyperlinkRelationship(new Uri(String.Format(ConfigurationManager.AppSettings["IssueViewUrl"], storyKey)), false, "Punted"+storyKey);

                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStorySummary"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new Text(gridStories.Rows[i].Cells["gridStoryPoint"].Value.ToString()))));
                    tr.Append(tc);

                    tc = new TableCell(); //leave forth column blank, users should fill out by themselves
                    tc.Append(new Paragraph(new Run(new Text())));
                    tr.Append(tc);

                    tc = new TableCell(); //leave fifth column blank, users should fill out by themselves
                    tc.Append(new Paragraph(new Run(new Text())));
                    tr.Append(tc);

                    table5.Append(tr); 
                }
                #endregion

                wordDoc.MainDocumentPart.Document.Save();
                #endregion
            }
        }

        public void ReplacePlaceholder(string document, Dictionary<string, string> dict)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                #region Replace placeholders with values
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                foreach (KeyValuePair<string, string> item in dict)
                {
                    Regex regexText = new Regex(item.Key);
                    docText = regexText.Replace(docText, item.Value);
                }

                using (StreamWriter sw = new StreamWriter(
                          wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
                #endregion

            }
        }


    }
}
