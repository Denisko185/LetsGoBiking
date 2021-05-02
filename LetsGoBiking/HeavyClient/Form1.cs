using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Geo;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using HeavyClient.RoutingService;
using Itineraire;
using System.ServiceModel;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HeavyClient
{
    public partial class Form1 : Form
    {
        HttpClient client;
        RoutingWSClient routingS;
        Itinerary[] itinerarys;
        List<string> datasource;
        BasicHttpBinding binding;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            routingS = new RoutingWSClient();
            datasource = new List<string>();
            binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 10000000;
            binding.MaxBufferSize = 10000000;
        }

        private void btnvalider_Click(object sender, EventArgs e)
        {
            string depart = tbdepart.Text;
            string arrive = tbarrive.Text;
            GeoJson resultdep, resultarv;

            if(depart =="" || arrive == "")
            {
                MessageBox.Show("Veuillez reseigner la valeur des champs", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var webrequest1 = (HttpWebRequest)System.Net.WebRequest.Create("https://api-adresse.data.gouv.fr/search/?q=" + depart.Replace(' ', '+'));
            using (var respons = webrequest1.GetResponse())
            using (var reader = new StreamReader(respons.GetResponseStream()))
            {
                resultdep = JsonConvert.DeserializeObject<GeoJson>(reader.ReadToEnd());
            }
            if (resultdep.features.Count == 0)
            {
                MessageBox.Show("Veuillez reseigner un point de depart correct", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var webrequest2 = (HttpWebRequest)System.Net.WebRequest.Create("https://api-adresse.data.gouv.fr/search/?q=" + arrive.Replace(' ', '+'));
            using (var respons = webrequest2.GetResponse())
            using (var reader = new StreamReader(respons.GetResponseStream()))
            {
                resultarv = JsonConvert.DeserializeObject<GeoJson>(reader.ReadToEnd());
            }

            if (resultarv.features.Count == 0)
            {
                MessageBox.Show("Veuillez reseigner un point de d\'arrivé correct", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string a = resultdep.features[0].geometry.coordinates[0].ToString().Replace(",", ".") + "," + resultdep.features[0].geometry.coordinates[1].ToString().Replace(",", ".");
            string b = resultarv.features[0].geometry.coordinates[0].ToString().Replace(",", ".") + "," + resultarv.features[0].geometry.coordinates[1].ToString().Replace(",", ".");
            itinerarys = JsonConvert.DeserializeObject<Itinerary[]>(routingS.GetItinerarys(resultdep.features[0].geometry.coordinates[0].ToString().Replace(",",".") + "," + resultdep.features[0].geometry.coordinates[1].ToString().Replace(",", "."), resultarv.features[0].geometry.coordinates[0].ToString().Replace(",", ".") + "," + resultarv.features[0].geometry.coordinates[1].ToString().Replace(",", ".")));
            foreach(Itinerary it in itinerarys)
            {
                foreach(var step in it.features[0].properties.segments[0].steps)
                    datasource.Add(step.instruction);
            }

            listbitineraire.DataSource = datasource;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            tbdepart.Text = "";
            tbarrive.Text = "";
            listbitineraire.DataSource = new List<string>();
        }

        private void btnafficher_Click(object sender, EventArgs e)
        {
            string[] table = routingS.GetUtils();
            Double dureetot = 0 , distancetot = 0;
            Listvutil.Items.Clear();
            foreach(string s in table)
            {
                Stats stat = JsonConvert.DeserializeObject<Stats>(s);
                var row = new string[] { stat.departPoint[0] + "," + stat.departPoint[1], stat.arrivePoint[0] + "," + stat.arrivePoint[1], stat.departStationName, stat.arriveStationName, stat.distance.ToString(), stat.duration.ToString(), stat.dateHeure };
                var lvi = new ListViewItem(row);
                lvi.Tag = stat;
                Listvutil.Items.Add(lvi);
                dureetot += stat.duration;
                distancetot += stat.distance;
            }

            lbldistance.Text = (Math.Round((distancetot / table.Length)/1000,2)).ToString() + " Km";
            lbldure.Text = (Math.Round((dureetot / table.Length)/ 3600,2)).ToString()+" Heure";

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Point depart";
                    ws.Cells[1, 2] = "Point arrivée";
                    ws.Cells[1, 3] = "Station depart";
                    ws.Cells[1, 4] = "Station arrivée";
                    ws.Cells[1, 5] = "Distance";
                    ws.Cells[1, 6] = "Durée";
                    ws.Cells[1, 7] = "Date-heure";
                    int i = 2;
                    foreach(ListViewItem item in Listvutil.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        ws.Cells[i, 5] = item.SubItems[4].Text;
                        ws.Cells[i, 6] = item.SubItems[5].Text;
                        ws.Cells[i, 7] = item.SubItems[6].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Données exportés avec succes", "Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
