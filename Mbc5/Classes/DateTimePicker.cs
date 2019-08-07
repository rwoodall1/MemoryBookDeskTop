//----------------------------------------------------------------------------------
// - Author			   - Pham Minh Tri
// - Last Updated      - 19/Nov/2003
//----------------------------------------------------------------------------------
// - Component:        - Nullable DateTimePicker
// - Version:          - 1.0
// - Description:      - A datetimepicker that allow null value.
//----------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Data;
namespace Mbc5.Classes
{
    /// <summary>
    /// Summary description for DateTimePicker.
    /// </summary>
    public class NullableDateTimePicker : System.Windows.Forms.DateTimePicker
    {
        private DateTimePickerFormat oldFormat = DateTimePickerFormat.Short;
        private string oldCustomFormat = null;
        private bool bIsNull = false;

        public NullableDateTimePicker() : base()
        {
        }
        private bool valSet { get; set; } = false;
        public new DateTime? Value {
            get {
                if (bIsNull)
                    return null;
                else
                    return base.Value;
            }
            set {
                if (!valSet)
                {
                    valSet = true;
                    if (bIsNull == false)
                    {
                        oldFormat = this.Format;
                        oldCustomFormat = this.CustomFormat;
                        
                    }
                    // preset to custom and ''
                    //this.Format = DateTimePickerFormat.Custom;
                    //this.CustomFormat = " ";
                }else if(valSet &&  value == null)
                {
                    if (bIsNull == true)
                    {
                     this.Format = DateTimePickerFormat.Custom;
                        this.CustomFormat = " ";
                
                    }
 
                }else if (valSet && value != null)
                {
                    if (bIsNull ==false)
                    {
                        this.Format = DateTimePickerFormat.Short;
                        this.CustomFormat = " ";
                        bIsNull = false;
                        base.Value = value.Value; }
                }
               
            }
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            
            
            
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (bIsNull)
                {
                    this.Format = oldFormat;
                    this.CustomFormat = oldCustomFormat;
                    bIsNull = false;
                }
            }
            
            base.OnCloseUp(eventargs);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Delete)
            {
                bIsNull = true;
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = " ";
                
                this.Value = null;
                var vBindingSource = (BindingSource)this.DataBindings[0].DataSource;
                var field = this.DataBindings[0].BindingMemberInfo.BindingField;
                var dr = (DataRowView)vBindingSource.Current;
                dr[field] = DBNull.Value;
            }
        } 
    }


  
}
