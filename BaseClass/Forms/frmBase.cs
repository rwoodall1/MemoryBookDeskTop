using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BaseClass.FormHandler;
using System.Security.Principal;
using BaseClass.Classes;
using Core;
using NLog;
using System.Configuration;
using System.Threading;

namespace BaseClass
{
    public partial class frmBase : Form
    {
      
        public frmBase()
        {
           
            InitializeComponent();
        }
       protected Logger Log { get;set; } 
        
        #region "Properties" 

        [Browsable(true)]
        //protected Logger Log { get; private set; }
        private bool CloseForm { get; set; }
        [Browsable(true)]
        public int MaxNumForms { get; set; } = 1;   
        public string CurrentInstance { get; set; }
        private enum CalledShowMethod
        {
            Show,
            ShowWithOwner
        }
        public virtual string Schcode { get; set; }="";
        public virtual string FormConnectionString { get; set; }
        public virtual int Invno { get; set; }
        public event EventHandler UserIsAllowed;
        public event EventHandler UserIsDenied;
        // Variable to capture the roles allowed for this form
        private List<string> _formRoles;
        // Variable to capture the users Principal
        private UserPrincipal _formPrincipal;
        public bool IsMainWindow { get; set; }
        public List<string> ValidatedUserRoles { get; private set; }
        /// <value><c>true</c> if [user can open form]; otherwise, <c>false</c>.</value>
		public bool UserCanOpenForm { get; private set; }
        #endregion
        protected frmBase(string[] roles, UserPrincipal userPrincipal)
        {
            Log = LogManager.GetLogger(GetType().FullName);
            if (!DesignMode)
            {
                this.IsMainWindow = false;
                this.ValidatedUserRoles = new List<string>();
                this._formRoles = new List<string>();
                this._formRoles.AddRange(roles);

                this._formPrincipal = userPrincipal;

                ValidateUserRoles();
            }

            InitializeComponent();

        }
        private void ValidateUserRoles()
        {
            if (_formRoles.Count < 1)//if no roles then form is open to everyone
            {
                this.UserCanOpenForm = true;
            }
            else
            {
                   foreach (string role in _formRoles)
               
                if (_formPrincipal.IsInRole(role))
                    this.ValidatedUserRoles.Add(role);

                this.UserCanOpenForm = this.ValidatedUserRoles.Count > 0;

            }
            
          
        }
        
        public new virtual void Show()
        {
            Show(CalledShowMethod.Show, null);
        }
        public new virtual void Show(IWin32Window owner)
        {
            Show(CalledShowMethod.ShowWithOwner, owner);
        }
        private void Show(CalledShowMethod calledShowMethod, IWin32Window owner)
        {
            if (!DesignMode)
            {
                if (UserCanOpenForm)
                {
                    ShowForm(calledShowMethod, owner);
                    if (UserIsAllowed != null)
                        UserIsAllowed(this, new EventArgs());
                }
                else
                {
                    if (UserIsDenied != null)
                    {
                        ShowForm(calledShowMethod, owner);
                        UserIsDenied(this, new EventArgs());
                    }
                    else
                        if (this.IsMainWindow)
                        Application.Exit();
                }
            }
            else
                ShowForm(calledShowMethod, owner);
        }
        private void ShowForm(CalledShowMethod calledShowMethod, IWin32Window owner)
        {
            if (calledShowMethod == CalledShowMethod.Show)
                base.Show();
            else
                base.Show(owner);
        }

        public new virtual DialogResult ShowDialog()
        {
            return ShowDialog(CalledShowMethod.ShowWithOwner, null);
        }
        public new virtual DialogResult ShowDialog(IWin32Window owner)
        {
            return ShowDialog(CalledShowMethod.ShowWithOwner, owner);
        }
        private DialogResult ShowDialog(CalledShowMethod calledShowMethod, IWin32Window owner)
        {
            if (!DesignMode)
            {
                DialogResult result = DialogResult.None;
                if (UserCanOpenForm)
                {
                    result = ShowDialogForm(calledShowMethod, owner);
                    if (UserIsAllowed != null)
                        UserIsAllowed(this, new EventArgs());
                }
                else
                {
                    if (UserIsDenied != null)
                    {
                        result = ShowDialogForm(calledShowMethod, owner);
                        UserIsDenied(this, new EventArgs());
                    }
                    else
                        if (IsMainWindow)
                        Application.Exit();
                }

                return result;
            }
            else
                return ShowDialogForm(calledShowMethod, owner);
        }
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            var Log1 = LogManager.GetCurrentClassLogger();
            
            Log1.Error(t.Exception,"Unhandled Windows Forms Error:" + t.Exception.Message);
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }
        private void Base_Load(object sender, EventArgs e)
        {
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
            if (!this.DesignMode)
            {
                FormAllowed allowedResult= ((ParentForm)this.MdiParent).AllowedInstance(this.Name,this.MaxNumForms);
                if (!allowedResult.Allowed)
                {
                    //close
                    this.BeginInvoke(new MethodInvoker(this.Close));
                }
                if (allowedResult.Number > 1)
                {
                    this.Text = this.Text + "(" + allowedResult.Number.ToString() + ")";
                }
            }
           
        }
       

        private void BaseForm_Disposed(object sender, EventArgs e)
        {            
            
        }
        private DialogResult ShowDialogForm(CalledShowMethod calledShowMethod, IWin32Window owner)
        {
            if (calledShowMethod == CalledShowMethod.Show)
                return base.ShowDialog();
            else
                return base.ShowDialog(owner);
        }

        private void Base_FormClosed(object sender, FormClosedEventArgs e)
        {
            
             ((ParentForm)this.MdiParent).Decrease(this.Name);
            this.Dispose();
           
        }
        [Browsable(true)]
        public virtual void Save(bool FromMenu)
        {
			
        }
        public virtual ApiProcessingResult<bool> Save()
        {
            return new ApiProcessingResult<bool>();
        }

        [Browsable(true)]
		public virtual void SchCodeSearch() {

		}
		public virtual void SchnameSearch() {

		}
		public virtual void OracleCodeSearch() {

		}
		public virtual void ProdutnNoSearch() {

		}
		public virtual void InvoiceNumberSearch() {

		}
        public virtual void FirstNameSearch()
        {

        }
        public virtual void LastNameSearch()
        {

        }
        public virtual void ZipCodeSearch()
        {

        }
        public virtual void EmailSearch()
        {

        }
        public virtual void JobNoSearch()
        {

        }
        public virtual void Fill()
        {

        }
        public virtual void Delete()
        {

        }
        [Browsable(true)]
        public virtual void Cancel() {


            }
        [Browsable(true)]
        public virtual bool Add()
        {
			return true;
        }

        private void basePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {

                this.basePanel.Dock = DockStyle.Fill;
                
                basePanel.BringToFront();
                var t = basePanel.Height/2;
                var s = (basePanel.Width/2)-92;
                this.innerPanel.Location= new Point(t, s);
                this.workingLabel.BringToFront();
            }
            else
            {
                this.basePanel.Dock = DockStyle.None;
               this.workingLabel.SendToBack();
                basePanel.SendToBack();
            }
        }

        private void basePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}