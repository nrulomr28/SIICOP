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
        private SIICOPEntities ctx;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctx = new SIICOPEntities();

            // Dado que el GridView tiene EnableViewState="false", 
            // es obligatorio cargar el Grid en cada ciclo de vida (PostBack).
        
            if (!IsPostBack)
            {
                CargarDependencias();
                CargarAreas();
            }
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
                System.Diagnostics.Debug.WriteLine("Error al cargar Grid: " + ex.Message);
            }
        }

        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvuser.BottomPagerRow;
            if (pagerRow != null)
            {
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                if (pageList != null)
                {
                    gvuser.PageIndex = pageList.SelectedIndex;
                    CargarGrid(); // ¡CORRECCIÓN: Obligatorio volver a consultar y enlazar!
                }
            }
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
                Guid idusermember;
                if (Guid.TryParse(e.CommandArgument.ToString(), out idusermember))
                {
                    var login = ctx.Personales.FirstOrDefault(t => t.guidUsuario == idusermember);
                    if (login != null)
                    {
                        txtLogin.Text = login.login;
                        hfUsuarioSeleccionado.Value = login.login;
                        txtpassword.Text = "";
                        updModalPassword.Update();

                        // 2. ABRIMOS EL MODAL
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openModalpassword", "openModalpassword();", true);
                    }
                }
            }
        

           if (e.CommandName == "EditarUser")
            {
                int idusermember;
                if (int.TryParse(e.CommandArgument.ToString(), out idusermember))
                {
                    var user = ctx.Personales.FirstOrDefault(t => t.Personalid == idusermember);
                    if (user != null)
                    {
                        txtNombreEdit.Text = user.Nombre;
                        hfNombreUser.Value = user.Nombre;
                        txtApaterno.Text = user.paterno;
                        hfApaterno.Value = user.paterno;
                        txtAmaterno.Text = user.materno;
                        hfAMaterno.Value = user.materno;
                        updModaleditaruserm.Update();

                        // Validación segura para evitar crasheos si el catálogo cambia
                        if (user.cat_areaidarea != null && ddlArea.Items.FindByValue(user.cat_areaidarea.ToString()) != null)
                            ddlArea.SelectedValue = user.cat_areaidarea.ToString();

                        if (user.DependenciaId != null && ddldepen_edit.Items.FindByValue(user.DependenciaId.ToString()) != null)
                            ddldepen_edit.SelectedValue = user.DependenciaId.ToString();

                        Session["iduser"] = idusermember;

                        // Funciona perfectamente
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openModalEditUser", "openModalEditUser();", true);
                    }
                }
            }
        }



        protected void lkbGuardarContraseña_Click(object sender, EventArgs e)       {
            
            try
            {
                string username = txtLogin.Text.Trim();
               // string username = hfUsuarioSeleccionado.Value; 
                string password = txtpassword.Text;
                // CORRECCIÓN: Si el usuario está vacío, lanzamos error. Si tiene contenido, procedemos.
                if (string.IsNullOrEmpty(username))
                {
                    string script = "Swal.fire('Error', 'El usuario no fue detectado.', 'error');";
                    ScriptManager.RegisterStartupScript(lkbGuardarContraseña, lkbGuardarContraseña.GetType(), "ErrorLogin", script, true);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    string script = "Swal.fire('Atención', 'La contraseña no puede estar vacía.', 'warning');";
                    ScriptManager.RegisterStartupScript(lkbGuardarContraseña, lkbGuardarContraseña.GetType(), "ErrorPass", script, true);
                    return;
                }

                MembershipUser mu = Membership.GetUser(username);
                if (mu != null)
                {
                    if (mu.IsLockedOut) mu.UnlockUser();

                    // Cambiar contraseña
                    mu.ChangePassword(mu.ResetPassword(), password);

                    // Éxito: cerramos modal y lanzamos alerta
                    string scriptExito = "$('#myModalPassword').modal('hide'); Correcto();";
                    ScriptManager.RegisterStartupScript(lkbGuardarContraseña, lkbGuardarContraseña.GetType(), "ExitoPassword", scriptExito, true);
                }
                else
                {
                    throw new Exception("El usuario no existe en el sistema de membresía.");
                }
            }
            catch (Exception ex)
            {
                string mensajeSeguro = ex.Message.Replace("'", "\"");
                string scriptError = $"Swal.fire('Error', 'No se pudo cambiar: {mensajeSeguro}', 'error');";
                ScriptManager.RegisterStartupScript(lkbGuardarContraseña, lkbGuardarContraseña.GetType(), "ErrorPassword", scriptError, true);
            }
        }


        protected void lnkbEditUser_Click(object sender, EventArgs e)
        {
            if (Session["iduser"] == null) return;

            int iduser = Convert.ToInt32(Session["iduser"]);
            if (iduser != 0)
            {
                try
                {
                    var useredit = ctx.Personales.FirstOrDefault(t => t.Personalid == iduser);
                    if (useredit != null)
                    {
                        useredit.Nombre = txtNombreEdit.Text.Trim();
                        useredit.paterno = txtApaterno.Text.Trim();
                        useredit.materno = txtAmaterno.Text.Trim();

                        if (!string.IsNullOrEmpty(ddlArea.SelectedValue) && ddlArea.SelectedValue != "0")
                        {
                            useredit.cat_areaidarea = Convert.ToInt32(ddlArea.SelectedValue);
                            useredit.AreaTrabajo = ddlArea.SelectedItem.Text;
                        }

                        if (!string.IsNullOrEmpty(ddldepen_edit.SelectedValue) && ddldepen_edit.SelectedValue != "0")
                        {
                            int iddepen = Convert.ToInt32(ddldepen_edit.SelectedValue);
                            useredit.DependenciaId = iddepen;
                            useredit.Dependencia = ddldepen_edit.SelectedItem.Text;
                        }

                        ctx.SaveChanges();

                        // 1. Recargamos los datos del GridView
                        CargarGrid();

                        // 2. Cerramos el modal Y mostramos el mensaje de éxito
                        // Inyectamos el cierre del modal + la función Correcto()
                        string scriptExito = "$('#myModalEditUser').modal('hide'); Correcto();";

                        // Usamos 'lnkbEditUser' (el botón) como fuente para que el UpdatePanel lo procese
                        ScriptManager.RegisterStartupScript(lnkbEditUser, lnkbEditUser.GetType(), "ExitoEditar", scriptExito, true);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al editar usuario: " + ex.Message);
                    // Mensaje de error visible para el usuario
                    string scriptError = $"Swal.fire('Error', 'No se pudo guardar: {ex.Message.Replace("'", "")}', 'error');";
                    ScriptManager.RegisterStartupScript(lnkbEditUser, lnkbEditUser.GetType(), "ErrorEditar", scriptError, true);
                }
            }
        }
      /*  protected void lnkbEditUser_Click(object sender, EventArgs e)
        {
            if (Session["iduser"] == null) return;

            int iduser = Convert.ToInt32(Session["iduser"]);
            if (iduser != 0)
            {
                try
                {
                    var useredit = ctx.Personales.FirstOrDefault(t => t.Personalid == iduser);
                    if (useredit != null)
                    {
                        useredit.Nombre = txtNombreEdit.Text.Trim();
                        useredit.paterno = txtApaterno.Text.Trim();
                        useredit.materno = txtAmaterno.Text.Trim();

                        if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                        {
                            useredit.cat_areaidarea = Convert.ToInt32(ddlArea.SelectedValue);
                            useredit.AreaTrabajo = ddlArea.SelectedItem.Text;
                        }

                        if (!string.IsNullOrEmpty(ddldepen_edit.SelectedValue))
                        {
                            int iddepen = Convert.ToInt32(ddldepen_edit.SelectedValue);
                            useredit.DependenciaId = iddepen;
                            useredit.Dependencia = ddldepen_edit.SelectedItem.Text;
                        }

                        ctx.SaveChanges();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Correcto", "Correcto();", true);

                        CargarGrid();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al editar usuario: " + ex.Message);
                }
            }
        }
      */

        private void CargarAreas()
        {
            try
            {
                var areas = ctx.Cat_area.OrderBy(a => a.area_nombre).ToList();

                ddlAreaNuevo.DataSource = areas;
                ddlAreaNuevo.DataTextField = "area_nombre";
                ddlAreaNuevo.DataValueField = "idarea";
                ddlAreaNuevo.DataBind();
                ddlAreaNuevo.Items.Insert(0, new ListItem("--Seleccione área--", "0"));

                ddlArea.DataSource = areas;
                ddlArea.DataTextField = "area_nombre"; 
                ddlArea.DataValueField = "idarea";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("--Seleccione un área--", "0"));
               // ddlArea.Items.Insert(0, new ListItem("--Seleccione un área--", "0"));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar áreas: " + ex.Message);
            }
        }

        private void CargarDependencias()
        {
            try
            {
                
                var listadoDependencias = ctx.Cat_Dependencias
                                             .OrderBy(d => d.DependenciaNombre)
                                             .ToList();

                ddldepndencia.DataSource = listadoDependencias;
                ddldepndencia.DataTextField = "DependenciaSiglas"; 
                ddldepndencia.DataValueField = "DependenciaId";    
                ddldepndencia.DataBind();

                ddldepen_edit.DataSource = listadoDependencias;
                ddldepen_edit.DataTextField = "DependenciaSiglas";
                ddldepen_edit.DataValueField = "DependenciaId";
                ddldepen_edit.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar dependencias: " + ex.Message);
            }
        }
        protected void lnkbtnAgregarUser_Click(object sender, EventArgs e)
        {
          
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openModalNuevoUser", "openModalNuevoUser();", true);
        }



        /*  
          protected void lnkCrearUser_Click(object sender, EventArgs e)
          {
              try
              {
                  string usuario =  txtUsuarioLogin.Text.Trim();
                  string password = txtcontraseñanueva.Text;

                  if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password)) return;

                  if (Membership.GetUser(usuario) != null)
                  {
                      ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('El nombre de usuario ya se encuentra registrado.');", true);
                      return;
                  }

                  MembershipUser usuarioCreado = Membership.CreateUser(usuario, password);

                  if (usuarioCreado != null && usuarioCreado.ProviderUserKey != null)
                  {
                      Guid guidAsignado = Guid.Parse(usuarioCreado.ProviderUserKey.ToString());

                      Personales nuevoRegistro = new Personales
                      {
                          Nombre = txtNombreNuevo.Text.Trim(),
                          paterno = txtapellidopaternoNuevo.Text.Trim(),
                          materno = txtapellidomaternoNuevo.Text.Trim(),
                          login = usuario,
                          fechacrecion = DateTime.Now,
                          guidUsuario = guidAsignado
                      };

                      if (!string.IsNullOrEmpty(ddldepndencia.SelectedValue))
                      {
                          int iddepen = Convert.ToInt32(ddldepndencia.SelectedValue);
                          nuevoRegistro.DependenciaId = iddepen;
                          nuevoRegistro.Dependencia = ddldepndencia.SelectedItem.Text;
                      }

                      if (!string.IsNullOrEmpty(ddlAreaNuevo.SelectedValue))
                      {
                         // nuevoRegistro.cat_areaidarea = null;
                          nuevoRegistro.cat_areaidarea = Convert.ToInt32(ddlAreaNuevo.SelectedValue);
                          nuevoRegistro.AreaTrabajo = ddlAreaNuevo.SelectedItem.Text;
                      }

                      ctx.Personales.Add(nuevoRegistro);
                      ctx.SaveChanges();

                      ScriptManager.RegisterStartupScript(this, this.GetType(), "Correcto", "Correcto();", true);
                      CargarGrid();
                  }
              }
              catch (DbEntityValidationException ex)
              {
                  foreach (var validationErrors in ex.EntityValidationErrors)
                  {
                      foreach (var validationError in validationErrors.ValidationErrors)
                      {
                          System.Diagnostics.Debug.WriteLine($"Propiedad: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                      }
                  }
                  ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Error de validación en los campos de base de datos.');", true);
              }
              catch (Exception ex)
              {
                  System.Diagnostics.Debug.WriteLine("Error crítico al crear usuario: " + ex.Message);
                  ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Hubo un problema al guardar el registro.');", true);
              }
          }
        */

        protected void lnkCrearUser_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioLogin.Text.Trim();
            string password = txtcontraseñanueva.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password)) return;

            try
            {
                if (Membership.GetUser(usuario) != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('El nombre de usuario ya se encuentra registrado.');", true);
                    return;
                }

                MembershipUser usuarioCreado = Membership.CreateUser(usuario, password);

                if (usuarioCreado != null && usuarioCreado.ProviderUserKey != null)
                {
                    Guid guidAsignado = (Guid)usuarioCreado.ProviderUserKey;

                    Personales nuevoRegistro = new Personales
                    {
                        Nombre = txtNombreNuevo.Text.Trim(),
                        paterno = txtapellidopaternoNuevo.Text.Trim(),
                        materno = txtapellidomaternoNuevo.Text.Trim(),
                        login = usuario,
                        fechacrecion = DateTime.Now, 
                        guidUsuario = guidAsignado
                    };

                    if (!string.IsNullOrEmpty(ddldepndencia.SelectedValue))
                    {
                        nuevoRegistro.DependenciaId = Convert.ToInt32(ddldepndencia.SelectedValue);
                        nuevoRegistro.Dependencia = ddldepndencia.SelectedItem.Text;
                    }

                    if (!string.IsNullOrEmpty(ddlAreaNuevo.SelectedValue))
                    {
                        nuevoRegistro.cat_areaidarea = Convert.ToInt32(ddlAreaNuevo.SelectedValue);
                        nuevoRegistro.AreaTrabajo = ddlAreaNuevo.SelectedItem.Text;
                    }

                    ctx.Personales.Add(nuevoRegistro);
                    ctx.SaveChanges();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Correcto", "Correcto();", true);
                    CargarGrid();
                }
            }
            catch (DbEntityValidationException ex)
            {
                RevertirUsuarioMembership(usuario); 

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Propiedad: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Error de validación en los campos de base de datos.');", true);
            }
            catch (Exception ex)
            {
                RevertirUsuarioMembership(usuario); 

                System.Diagnostics.Debug.WriteLine("Error crítico al crear usuario: " + ex.Message);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Hubo un problema al guardar el registro.');", true);
            }
        }


        private void RevertirUsuarioMembership(string nombreUsuario)
        {
            try
            {
                if (Membership.GetUser(nombreUsuario) != null)
                {
                    Membership.DeleteUser(nombreUsuario, true); 
                    System.Diagnostics.Debug.WriteLine($"Rollback ejecutado: Usuario '{nombreUsuario}' eliminado de Membership.");
                }
            }
            catch (Exception rollbackEx)
            {
                System.Diagnostics.Debug.WriteLine("Error crítico durante el rollback del usuario: " + rollbackEx.Message);
            }
        }


        protected void ddldepen_edit_DataBound(object sender, EventArgs e)
        {
            // Opcional: Agregar elemento por defecto si enlazas dinámicamente
            // this.ddldepen_edit.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        public override void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
            base.Dispose();
        }
    }
}