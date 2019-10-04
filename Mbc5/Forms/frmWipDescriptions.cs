using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
namespace Mbc5.Forms
{
    public partial class frmWipDescriptions : BaseClass.frmBase
    {

        public frmWipDescriptions(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
          
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

        }

        private UserPrincipal ApplicationUser { get; set; }
        private void WipDescriptions_Load(object sender, EventArgs e)
        {
            try
            {
                wipDescriptionsTableAdapter.FillAll(dsProdutn.WipDescriptions);
                wipDescriptionsTableAdapter.FillGroup(dsProdutn1.WipDescriptions);
                wipDescriptionsBindingSource.Filter="TableName=''";
                var a = wipDescriptionsBindingSource.Count;
                var b = bsTableNames.Count;

            }
            catch (Exception ex) {
               
                MbcMessageBox.Error(ex.Message);
            }
         

        }

        private void tableNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            wipDescriptionsBindingSource.Filter = "TableName='"+cmbTableName.SelectedValue.ToString().Trim()+"'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validate())
                {
                    wipDescriptionsBindingSource.EndEdit();
                    var a=wipDescriptionsTableAdapter.Update(dsProdutn);

                }
            }catch(Exception ex)
            {

            }
        }
    }
}
