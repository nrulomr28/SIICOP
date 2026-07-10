using AjaxControlToolkit.Bundling;
using SIICOP_V1._2.Datos;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.SysAdmin
{
    public partial class ControlUser : System.Web.UI.Page
    {
        SIICOPEntities ctx /*= new SIICOPEntities()*/;
        int iduser;

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
         
            ctx = new SIICOPEntities();

         
            CargarGrid();
        }

        private void CargarGrid()
        {
            try
            {
                var usuarios = ctx.Personales.OrderByDescending(u => u.fechacrecion).ToList();
                gvuser.DataSource = usuarios;
                gvuser.DataBind();
            }
            catch (Exception ex)
            {
             
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    
        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvuser.BottomPagerRow;         
            DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");           
            gvuser.PageIndex = pageList.SelectedIndex;           
        }
        protected void gvuser_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = gvuser.BottomPagerRow;
                if (pagerRow == null) return;
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabelt");
                if (pageList != null)
                {
                    pageList.Items.Clear();
                    for (int i = 0; i < gvuser.PageCount; i++)
                    {
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString(), i.ToString());
                        if (i == gvuser.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pageList.Items.Add(item);
                    }
                }
                if (pageLabel != null)
                {
                    int currentPage = gvuser.PageIndex + 1;
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + gvuser.PageCount.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en DataBound: " + ex.Message);
            }
        }
        protected void gvuser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvuser.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void gvuser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ResetPassword")
            {               
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {

                    Guid idusermember = Guid.Parse(numFila.ToString());
                    var login = ctx.Personales.Where(t => t.guidUsuario == idusermember).FirstOrDefault();
                    txtLogin.Text = login.login;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalpassword", "openModalpassword();", true);
                }
            }
            if (e.CommandName == "EditarUser")
            {
                iduser = 0;
                int numFila;
                if (int.TryParse(e.CommandArgument.ToString(), out numFila))
                {

                    int idusermember = int.Parse(numFila.ToString());
                    var user = ctx.Personales.Where(t => t.Personalid == idusermember).FirstOrDefault();
                    txtNombreEdit.Text = user.Nombre;
                    txtApaterno.Text = user.paterno;
                    txtAmaterno.Text = user.materno;
              //   ddlArea.SelectedValue = Convert.ToInt32(user.cat_areaidarea).ToString();
              //   ddlArea.SelectedValue = Convert.ToInt32(user.cat_areaidarea).ToString();
              //   ddldepen_edit.SelectedValue = user.DependenciaId != null ? user.DependenciaId.ToString() : "0"; ;
                    Session["iduser"] = idusermember;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalEditUser", "openModalEditUser();", true);
                }
            }
        }

        protected void lkbGuardarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLogin.Text;
                string password = txtpassword.Text;
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Correcto", "Correcto()", true);

                }

            }
            catch (Exception ex)
            {

            }

        }
      
        protected void lnkbEditUser_Click(object sender, EventArgs e)
        {

            int iduser = Convert.ToInt32(Session["iduser"].ToString());
            if (iduser != 0)
            {
                try
                {
                    var useredit = ctx.Personales.Where(t => t.Personalid == iduser).FirstOrDefault();
                    useredit.Nombre = txtNombreEdit.Text;
                    useredit.paterno = txtApaterno.Text;
                    useredit.materno = txtAmaterno.Text;
               //     useredit.cat_areaidarea = Convert.ToInt32(ddlArea.SelectedValue);
                //    useredit.AreaTrabajo = ddlArea.SelectedItem.Text;
                   
                   /* int iddepen = Convert.ToInt32(ddldepen_edit.SelectedValue.ToString());
                    useredit.DependenciaId = iddepen;
                    if (iddepen == 1)
                    {
                        useredit.Dependencia = "SSP DVI";
                    }

                    if (iddepen == 2)
                    {
                        useredit.Dependencia = "C4";
                    }

                    if (iddepen == 3)
                    {
                        useredit.Dependencia = "DGTSV";
                    }


                    if (iddepen == 4)
                    {
                        useredit.Dependencia = "CEPREVIDE";
                    }
                    if (iddepen == 5)
                    {
                        useredit.Dependencia = "SESCESP";
                    }
                    if (iddepen == 6)
                    {
                        useredit.Dependencia = "DGPRS";
                    }

                    useredit.DependenciaId = iddepen;
                   */
                    ctx.SaveChanges();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Correcto", "Correcto()", true);
                    gvuser.DataBind();
                }
                catch (Exception ex)
                {


                }

            }
        }
        //CREAR NUEVO USUARIO
        protected void lnkbtnAgregarUser_Click(object sender, EventArgs e)

        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalNuevoUser", "openModalNuevoUser()", true);

        }

        protected void lnkCrearUser_Click(object sender, EventArgs e)
        {
         
          /*  try
            {
                SIICOPEntities ctx = new SIICOPEntities();

                Personales iNUevoregistro = new Personales();



                iNUevoregistro.Nombre = txtNombreNuevo.Text;
                iNUevoregistro.paterno = txtapellidopaternoNuevo.Text;
                iNUevoregistro.materno = txtapellidomaternoNuevo.Text;
             //   iNUevoregistro.AreaTrabajo = ddlAreaNuevo.SelectedItem.Text;
             //   iNUevoregistro.cat_areaidarea = Convert.ToInt32(ddlAreaNuevo.SelectedValue.ToString());
               
                int iddepen  = Convert.ToInt32(ddldepndencia.SelectedValue.ToString());
                iNUevoregistro.DependenciaId = iddepen;
                if(iddepen == 1)
                {
                    iNUevoregistro.Dependencia = "SSP DVI";
                }

                if (iddepen == 2)
                {
                    iNUevoregistro.Dependencia = "C4";
                }

                if (iddepen == 3)
                {
                    iNUevoregistro.Dependencia = "DGTSV";
                }

                if (iddepen == 4)
                {
                    iNUevoregistro.Dependencia = "CEPREVIDE";
                }
                if (iddepen == 5)
                {
                    iNUevoregistro.Dependencia = "SESCESP";
                }
                if (iddepen == 6)
                {
                    iNUevoregistro.Dependencia = "DPRS";
                }

                iNUevoregistro.login = txtUsuarioLogin.Text;
                iNUevoregistro.fechacrecion = DateTime.Now;

                string password = txtcontraseñanueva.Text;
                string usuario = txtUsuarioLogin.Text;

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
                gvuser.DataBind();

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('se acreado el usuario')", true);
            }
            catch (DbEntityValidationException xxxx)
            {

                throw xxxx;

            }

            catch (Exception ex)
            {


                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('El usuario no se ha podido crear')", true);

            }*/
            
        }


        protected void ddldepen_edit_DataBound(object sender, EventArgs e)
        {
          //  this.ddldepen_edit.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }
    }
}