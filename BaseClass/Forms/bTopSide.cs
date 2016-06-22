using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using BaseClass.Classes;
namespace BaseClass.Forms
{
    public partial class bTopSide : BaseClass.frmBase
    {
        public bTopSide(string[] roles,UserPrincipal user) : base(roles, user)
        { 
            
            InitializeComponent();
        }
        public bTopSide()
        {
            InitializeComponent();
        }
    }
}
