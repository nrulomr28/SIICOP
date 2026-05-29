using System;
using System.Web.Security;

namespace SIICOP_V1._2.SysAdmin
{
    public partial class Cambiar_Contrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;
            MembershipUser mu = Membership.GetUser(username);
            //mu.LastLoginDate
            if (mu != null)
            {
                mu.IsApproved = true;
                if (mu.IsLockedOut)
                {
                    mu.UnlockUser();
                }
                mu.ChangePassword(mu.ResetPassword(), password);
            }
            lbl_msj.Text = "se a cambiado la contraseña" + "de" + username;
            mpe_msj.Show();

        }
    }
}