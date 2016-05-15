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
    public partial class Base : Form
    {
      
        protected Base()
        {
           
            InitializeComponent();
        }
        protected Logger Log { get; private set; } 
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
        protected Base(string[] roles, UserPrincipal userPrincipal)
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
            foreach (string role in _formRoles)
               
                if (_formPrincipal.IsInRole(role))
                    this.ValidatedUserRoles.Add(role);

            this.UserCanOpenForm = this.ValidatedUserRoles.Count > 0;
          
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
        private void Base_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                   FormInstance vForm = ((ParentForm)this.MdiParent).GetFormInstance(this.Name);
                if (vForm.Instances > this.MaxNumForms)
                {
                    //close
                    this.BeginInvoke(new MethodInvoker(this.Close));
                }
                if (vForm.Instances > 1)
                {
                    this.Text = this.Text + "(" + vForm.Instances.ToString() + ")";
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
        public virtual void Save()
        {

        }
        [Browsable(true)]
        public virtual void Delete()
        {

        }
        [Browsable(true)]
        public virtual void Add()
        {

        }
        public virtual void Cancel()
        {

        }

      
    }
}