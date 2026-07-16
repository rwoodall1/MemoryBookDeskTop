using BaseClass;
using BaseClass.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosShippingReport : BaseClass.frmBase
    {
        public new frmMain frmMain { get; set; }
        public frmTukiosShippingReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }
        private void btnRun_Click(object sender, EventArgs e)
        {
           
            //var sqlClient = new SQLCustomClient();
            //string cmd = @"Select MixBookOrder.Invno,MixBookOrder.RequestedShipDate,MixBookOrder.Description,MixBookOrder.Copies
            //                ,MixBookOrder.[Size],MixBookOrder.Pages,MixBookOrder.ShipName,MixbookOrder.CurrentBookLoc as BookLoc,CurrentCoverLoc As CoverLoc
            //                from MixBookOrder "
            //;
            //string _where = " Where (MixbookOrderStatus !='Shipped' AND MixbookOrderStatus !='Cancelled' ) AND RequestedShipDate<=@RequestedShipDate ";
            //string _order = "Order By 2, 7";
            //cmd += _where + _order;
            //sqlClient.CommandText(cmd);
            //sqlClient.AddParameter("@RequestedShipDate", dateTimePicker1.Value);
            //var result = sqlClient.SelectMany<ShipReport>();
            //if (result.IsError)
            //{
            //    MbcMessageBox.Error("Error running report:" + result.Errors[0].DeveloperMessage);
            //    return;
            //}
            //var data = (List<ShipReport>)result.Data;
            //SaveToCsv<ShipReport>(data);

        }

        private void SaveToCsv<T>(List<T> reportData)
        {
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;
            var lines = new List<string>();
            try
            {
                IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
                var header = string.Join(",", props.ToList().Select(x => x.Name));
                lines.Add(header);
                var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
                lines.AddRange(valueLines);
                File.WriteAllLines(path, lines.ToArray());
                Process.Start(saveFileDialog1.FileName);
            }
            catch (Exception ex) { MbcMessageBox.Error("Error creating csv file:" + ex.Message); }
        }
    }
    public class ShipReport
    {
        public int Invno { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public string Size { get; set; }
        public int Pages { get; set; }
        public string ShipName { get; set; }
        public string BookLoc { get; set; }
        public string CoverLoc { get; set; }

    }
}
