using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass.FormHandler;
using System.Security.Principal;
using BaseClass.Classes;
using NLog;
namespace BaseClass
{
   
        public partial class ParentForm : Form
        {

       
        public ParentForm() {
           //Logger Log = LogManager.GetCurrentClassLogger();
            InitializeComponent();
            }
       
        private void ParentForm_Load(object sender, EventArgs e)
            {
            this.OpenForms = new List<FormInstance>();
            }

        public List<FormInstance> OpenForms { get; set; }
            public string CurUser { get; set; }
            public string CurServer { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
            public void ExitApp()
            {
                Application.Exit();
            }
            public void Cascadewindows()
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }
            public void TileHrizontal()
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }

            public void TileVertical()
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }
            public void ArrangeWindows()
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
            }
            public void Copy()
            {
                string strName = null;

                strName = this.ActiveMdiChild.ActiveControl.GetType().Name;
                if (((ActiveForm != null)))
                {
                    try
                    {
                        switch (strName)
                        {
                            case "TextBox":
                                TextBox txtBox = (TextBox)this.ActiveControl;
                                txtBox.Copy();
                                break;
                            case "RichTextBox":
                                RichTextBox rtxtBox = (RichTextBox)this.ActiveControl;
                                rtxtBox.Copy();
                                break;
                            case "MaskedTextBox":
                                MaskedTextBox mskBox = (MaskedTextBox)this.ActiveControl;
                                mskBox.Copy();
                                break;
                            case "ComboBox":
                                //combo does not have a cut copy method
                                //active form created in first of method
                                ComboBox cmbBox = (ComboBox)ActiveForm.ActiveControl;
                                if (((cmbBox != null)))
                                {
                                    // Put selected text on Clipboard.
                                    Clipboard.SetDataObject(cmbBox.SelectedText);
                                }

                                break;
                        }

                    }
                    catch
                    {
                    }
                }
            }
            public void undo()
            {
                string strName = null;
                Form activeform = this.ActiveMdiChild;
                strName = this.ActiveMdiChild.ActiveControl.GetType().Name;
                if (((activeform != null)))
                {
                    try
                    {
                        switch (strName)
                        {
                            case "TextBox":
                                TextBox txtBox = (TextBox)this.ActiveControl;
                                txtBox.Undo();
                                break;
                            case "RichTextBox":
                                RichTextBox rtxtBox = (RichTextBox)this.ActiveControl;
                                rtxtBox.Undo();
                                break;
                            case "MaskedTextBox":
                                MaskedTextBox mskBox = (MaskedTextBox)this.ActiveControl;
                                mskBox.Undo();
                                break;


                        }

                    }
                    catch
                    {

                    }
                }
            }
            public void Cut()
            {
                string strName = null;
                Form activeform = this.ActiveMdiChild;
                strName = this.ActiveMdiChild.ActiveControl.GetType().Name;
                if (((activeform != null)))
                {
                    try
                    {
                        switch (strName)
                        {
                            case "TextBox":
                                TextBox txtBox = (TextBox)this.ActiveControl;
                                txtBox.Cut();
                                break;
                            case "RichTextBox":
                                RichTextBox rtxtBox = (RichTextBox)this.ActiveControl;
                                rtxtBox.Cut();
                                break;
                            case "MaskedTextBox":
                                MaskedTextBox mskBox = (MaskedTextBox)this.ActiveControl;
                                mskBox.Cut();
                                break;
                            case "ComboBox":
                                //combo does not have a cut copy method

                                ComboBox cmbBox = (ComboBox)activeform.ActiveControl;
                                if (((cmbBox != null)))
                                {
                                    // Put selected text on Clipboard.
                                    Clipboard.SetDataObject(cmbBox.SelectedText);
                                }

                                break;
                        }

                    }
                    catch(Exception ex)
                    {
                    }
                }
            }
            public void Paste()
            {
                string strName = null;
                Form activeform = this.ActiveMdiChild;
                strName = this.ActiveMdiChild.ActiveControl.GetType().Name;
                if (((activeform != null)))
                {
                    try
                    {
                        switch (strName)
                        {
                            case "TextBox":
                                TextBox txtBox = (TextBox)this.ActiveControl;
                                txtBox.Paste();
                                break;
                            case "RichTextBox":
                                RichTextBox rtxtBox = (RichTextBox)this.ActiveControl;
                                rtxtBox.Paste();
                                break;
                            case "MaskedTextBox":
                                MaskedTextBox mskBox = (MaskedTextBox)this.ActiveControl;
                                mskBox.Paste();
                                break;
                            case "ComboBox":
                                //combo does not have a cut copy method

                                ComboBox cmbBox = (ComboBox)activeform.ActiveControl;


                                //cmbBox.SelectedText = Clipboard.GetDataObject().GetData(DataFormats.Text);

                                break;


                        }

                    }
                    catch
                    {
                    }
                }
            }
        #region "Form Handler"
        //'Field 0 = Form Name
        //'Field 1 = Number of Instances
        //'Field 2 = Next available instance
        public FormAllowed AllowedInstance(string strFormName,int allowedInstances)
        {
            var retVal = new FormAllowed() { Allowed = true };
     
            foreach (FormInstance form in OpenForms)
            {
                if (form.FormName == strFormName)
                {
                    form.Instances += 1;
                    retVal.Number = form.Instances;
                    form.NextInstance += 1;
                    if (form.Instances > allowedInstances)
                    {
                        retVal.Allowed = false;
                        return retVal;
                    }
                
                }
            }

            //form not found so add to list and return new form
            var newform = Add(strFormName);
    
            return retVal;

        }

        private FormInstance Add(string strFormName)
        {
            FormInstance newForm = new FormInstance()
            {
                FormName = strFormName,
                Instances = 1,
                NextInstance = 2
            };
            this.OpenForms.Add(newForm);
            return newForm;
        }
        public void Decrease(string strFormName)
        {
            foreach (var form in OpenForms)
            {
                if (form.FormName == strFormName)
                {
                    form.Instances -= 1;
                    form.NextInstance -= 1;

                }
            }

        }

       
        #endregion
















        //-----------------------
    }
    public class FormAllowed
    {
        public bool Allowed { get; set; }
        public int Number { get; set; }
    }

}
