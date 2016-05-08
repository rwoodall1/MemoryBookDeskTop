using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
namespace BaseClass.Forms
{
    public partial class bTopBottom : BaseClass.Base
    {
        public bTopBottom(string[] roles, UserPrincipal user) : base(roles, user)
        {
            InitializeComponent();
        }
        public bTopBottom()
        {
            InitializeComponent();
        }
    }
}
