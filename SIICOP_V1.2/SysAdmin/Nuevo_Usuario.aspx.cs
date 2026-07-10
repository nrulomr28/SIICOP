using SIICOP_V1._2.Datos;
using System;
using System.Data.Entity.Validation;
using System.Web.Security;
using System.Web.UI;

namespace SIICOP_V1._2.SysAdmin
{
    public partial class Nuevo_Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {

          /*  try
            {
                MembershipCreateStatus status;
                SIICOPEntities ctx = new SIICOPEntities();

                Personales iNUevoregistro = new Personales();

                iNUevoregistro.Nombre = txtnombre.Text;
                iNUevoregistro.paterno = txtpaterno.Text;
                iNUevoregistro.materno = txtxmaterno.Text;
                iNUevoregistro.AreaTrabajo = ddlarea.SelectedItem.Text;
                iNUevoregistro.cat_areaidarea = Convert.ToInt32(ddlarea.SelectedValue.ToString());
                //tcSeguimiento.IdCuadrante = new int?(Convert.ToInt32(this.ddlCuadrante.SelectedValue.ToString()));
                iNUevoregistro.login = txtUsuario.Text;
                iNUevoregistro.fechacrecion = DateTime.Now;

                string password = txtPassword.Text;
                string usuario = txtUsuario.Text;

                Guid idNuevoUsuario = Guid.NewGuid();

                if (!Membership.ValidateUser(usuario, password) && (Membership.FindUsersByName(usuario) == null) || Membership.FindUsersByName(usuario).Count == 0)
                {
                    MembershipUser usuarioCreado = Membership.CreateUser(usuario, password);
                    string id = usuarioCreado.ProviderUserKey.ToString();
                    idNuevoUsuario = Guid.Parse(usuarioCreado.ProviderUserKey.ToString());
                    iNUevoregistro.guidUsuario = Guid.Parse(usuarioCreado.ProviderUserKey.ToString());
                    iNUevoregistro.login = usuario;
                                    }


                ctx.Personales.Add(iNUevoregistro);
                ctx.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Correcto", "Correcto()", true);

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('se acreado el usuario')", true);
            }
            catch (DbEntityValidationException xxxx)
            {

                throw xxxx;

            }

            catch (Exception ex)
            {


                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('El usuario no se a podido crear')", true);

            }*/
        }
    }
}