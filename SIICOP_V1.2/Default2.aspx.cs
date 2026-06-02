using SIICOP_V1._2.Datos;
using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;

using SIICOP_V1._2.Clases.Services;


namespace SIICOP_V1._2
{
    public partial class _Default : Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        public enum AccionExpediente { Creacion, Edicion, Visualizacion }

        int sessionPrograID;
        int progragr;
        string Delegacion;
        string fechaMes;
        //int año = 2020;
        int año = DateTime.Now.Year;
        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {

                

                string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                var area = a.cat_areaidarea;
                 

                if (a.Dependencia == "SSP DVI")
                {
                    var progra = 0;

                    if (area == 1022)
                    {
                        progra = 7;
                    }
                    if (area == 7)
                    {
                        progra = 8;
                    }
                    if (area == 4)
                    {
                        progra = 9; //pruebas
                    }
                    if (area == 6)
                    {
                        progra = 10;
                    }
                    if (area == 8)
                    {
                        progra = 11;
                    }
                    if (area == 5)
                    {
                        progra = 12;
                    }
                    if (area == 3)
                    {
                        progra = 13;
                    }
                    //if (area == 1023)
                    //{
                    //    progra = 14;
                    //}
                    if (area == 1025 || area== 1027)
                    {
                        progra = 14;
                    }

                    if (area == 1022 || area == 7 || area == 4 || area == 6 || area == 8 || area == 5 || area == 3 || area == 1025 || area == 1027 || area == 1)
                    {
                        Session["Delegacion"] = "CONURBACION XALAPA XX";
                    }


                    Session["sessionPrograID"] = progra;
                    Session["programa"] = progra;

                    if (User.IsInRole("CapSEMP") || User.IsInRole("Admin_Empresarial") || User.IsInRole("Admin_FDC") || User.IsInRole("Admin_Escolar") || User.IsInRole("Inclusión_Social") ||
                  User.IsInRole("CapEscolar") || User.IsInRole("Cap_FF") || this.User.IsInRole("Cap_PC") || this.User.IsInRole("Admin_PC") || User.IsInRole("Cap_PVM") 
                  || User.IsInRole("Admin_PVM") || User.IsInRole("Admin_RVCPZ"))
                    {


                        Conteo_acciones_bene_Gral_porarea();
                        resultadoPorAREA.Visible = true;
                        resultadosADMIN.Visible = false;
                        Conteo_A_B_TB_X_Cargadetrabajo();
                    }
                    else
                    {
                        if (this.User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("Visualizador") || User.IsInRole("Operador"))
                        {
                            Conteo_acciones_bene_Admin();

                            resultadoPorAREA.Visible = false;
                            resultadosADMIN.Visible = true;

                        }
                    }

                    if (User.IsInRole("Foráneo"))
                    {
                        if (area == 1020)
                        {
                            Session["Delegacion"] = "CONURBACION VERACRUZ XXIII";
                            DivForaneos.Visible = true;
                            Conteo_A_B_TB_X_CargadetraForaneobajo();
                        }

                        if (area == 1012)
                        {
                            Session["Delegacion"] = "CONURBACION POZA RICA";
                            DivForaneos.Visible = true;
                            Conteo_A_B_TB_X_CargadetraForaneobajo();
                        }
                        if (area == 1011)
                        {
                            Session["Delegacion"] = "COORDINACION CORDOBA";
                            DivForaneos.Visible = true;
                            Conteo_A_B_TB_X_CargadetraForaneobajo();
                        }

                        if (area == 1009)
                        {
                            Session["Delegacion"] = "COORDINACION COATZACOALCOS";
                            DivForaneos.Visible = true;
                            Conteo_A_B_TB_X_CargadetraForaneobajo();
                        }

                    }

                }
                else
                {

                    if (a.Dependencia == "C4")
                    {
                        Response.Redirect("~/Bienvenido_C4.aspx");
                    }

                    if (a.Dependencia == "DGTSV")
                    {
                        Response.Redirect("~/Bienvenido_DGTSV.aspx");
                    }

                    if (a.Dependencia == "CEPREVIDE")
                    {
                        Response.Redirect("~/Bienvenido_CEPREVIDE.aspx");
                    }
                    if (a.Dependencia == "SESCESP")
                    {
                        Response.Redirect("~/Bienvenido_CVcMyCPC.aspx");
                    }
                    else
                    {
                        MembershipUser user = Membership.GetUser(false);
                        Membership.UpdateUser(user);
                        ctx.SaveChanges();
                        Session.Clear();
                        Session.Abandon();
                        FormsAuthentication.RedirectToLoginPage();
                        FormsAuthentication.SignOut();
                        Response.Redirect("~/Inicio/Inicio.aspx");
                    }


                }

            }// termina el posback


        } // termina el load


        #region //METODOS PARA LOS % DE TENDIDOS Y ACCIONES
        //BENEFICIADOS Y ACCIONES GENERALES POR AREA

        private void Conteo_acciones_bene_Admin()
        {
            fechaMes = Convert.ToString(DateTime.Now.Month);
            int mesactual = DateTime.Now.Month;
            //int año = DateTime.Now.Year;

            // tipoB_A  1= BENEFICIADOS 2= ACCIONES

            #region //EMPRESARIAL
            //BENEFICIADOS

            int BeneficiadosEmpreSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosEmpre = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 13 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosEmpre != null)
            {
                BeneficiadosEmpreObje.InnerText = Convert.ToString(beneficiadosEmpre.cifra);
            }
            else { BeneficiadosEmpreObje.InnerText = "0"; }

            var Benefici_ReporteEmpre = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 13).ToList();
            if (Benefici_ReporteEmpre[0] != null)
            {
                BeneficiadosEmpreObt.InnerText = Convert.ToString(Benefici_ReporteEmpre[0]);
            }
            else
            {
                BeneficiadosEmpreObt.InnerText = "0";
            }


            //ACCIONES 
            int Accionesobj = 0;
            tb_AcionesBeneficiadosXmes AccionesEmpreObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 13 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesEmpreObj != null)
            {
                MesActividdesGral.InnerText = AccionesEmpreObj.mesTEX;
                spanAccionEmpreObje.InnerText = Convert.ToString(AccionesEmpreObj.cifra);
                Accionesobj = Convert.ToInt32(AccionesEmpreObj.cifra);
            }
            else
            {
                MesActividdesGral.InnerText = "Sin datos";
                spanAccionEmpreObje.InnerText = "0";
                Accionesobj = 0;
            }

            int accioncountEmpreObt = 0;
            var accioncountEmpreObtbus = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 13).ToList();
            if (accioncountEmpreObtbus[0] != null)
            {
                SpanAccionEmpreObt.InnerText = Convert.ToString(accioncountEmpreObtbus[0]);
                accioncountEmpreObt = Convert.ToInt32(accioncountEmpreObtbus[0]);

            }
            else
            {
                SpanAccionEmpreObt.InnerText = "0";
                accioncountEmpreObt = 0;
            }




            double totalEmpre = 0;
            double vamosEmpre = 0;
            double.TryParse(Convert.ToString(Accionesobj), out totalEmpre);
            double.TryParse(Convert.ToString(accioncountEmpreObt), out vamosEmpre);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentComplete = (int)(0.5f + ((100f * vamosEmpre) / totalEmpre));

            if (percentComplete >= 75)
            {
                ArribaEmpreAccion.Visible = true;
            }
            else
            {
                if (percentComplete <= 49)
                {
                    abajoaEmpreAccion.Visible = true;
                }
                else
                {
                    if (percentComplete == 50 || percentComplete <= 72)
                    {
                        medioEmpreAccion.Visible = true;
                    }
                }
            }
            //
            #endregion

            #region //ESCOLAR
            //BENEFICIADOS
            int BeneficiadosEscoSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosEscolarOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 9 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosEscolarOBJ != null)
            {
                SpanBeneficiadosEscolarOBJ.InnerText = Convert.ToString(beneficiadosEscolarOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosEscolarOBJ.InnerText = "0";
            }

            var BerimesAccionesTablaPrinEscolar = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 9).ToList();
            if (BerimesAccionesTablaPrinEscolar[0] != null)
            {
                SpanBeneficiadosEscolarOBT.InnerText = Convert.ToString(BerimesAccionesTablaPrinEscolar[0]);
            }
            else
            {
                SpanBeneficiadosEscolarOBT.InnerText = "0";
            }

            //ACCIONES
            int AccionesEscolar = 0;
            tb_AcionesBeneficiadosXmes AccionesEscolarObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 9 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesEscolarObj != null)
            {
                SpanAccionesEscolarOBJ.InnerText = Convert.ToString(AccionesEscolarObj.cifra);
                AccionesEscolar = Convert.ToInt32(AccionesEscolarObj.cifra);
            }
            else
            {
                SpanAccionesEscolarOBJ.InnerText = "0";
                AccionesEscolar = 0;
            }


            int accioncountEscolar = 0;
            var accioncountEscolarObt = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 9).ToList();
            if (accioncountEscolarObt[0] != null)
            {
                SpanAccionesEscolarOBT.InnerText = Convert.ToString(accioncountEscolarObt[0]);
                accioncountEscolar = Convert.ToInt32(accioncountEscolarObt[0]);

            }
            else
            {
                SpanAccionesEscolarOBT.InnerText = "0";
                accioncountEscolar = 0;
            }


            double totalEscolar = 0;
            double vamosEscolar = 0;
            double.TryParse(Convert.ToString(AccionesEscolar), out totalEscolar);
            double.TryParse(Convert.ToString(accioncountEscolar), out vamosEscolar);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteEscolar = (int)(0.5f + ((100f * vamosEscolar) / totalEscolar));

            if (percentCompleteEscolar >= 75)
            {
                ArribaEscoAccion.Visible = true;
            }
            else
            {
                if (percentCompleteEscolar <= 49)
                {
                    AbajoEscoAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteEscolar == 50 || percentCompleteEscolar <= 72)
                    {
                        mediEscoAccion.Visible = true;
                    }
                }
            }
            #endregion

            #region //Redes Vecinales
            //BENEFICIADOS
            int BeneficiadosRedesSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosRedesOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 8 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosRedesOBJ != null)
            {
                SpanBeneficiadosRedesObj.InnerText = Convert.ToString(beneficiadosRedesOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosRedesObj.InnerText = "0";
            }

            var BerimesAccionesTablaPrinREDES = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 8).ToList();
            if (BerimesAccionesTablaPrinREDES[0] != null)
            {
                SpanBeneficiadosRedesObt.InnerText = Convert.ToString(BerimesAccionesTablaPrinREDES[0]);
            }
            else
            {
                SpanBeneficiadosRedesObt.InnerText = "0";
            }


            //ACCIONES
            int accionesRedes = 0;
            tb_AcionesBeneficiadosXmes AccionesRedesObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 8 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesRedesObj != null)
            {
                SpanAccionesRedesObj.InnerText = Convert.ToString(AccionesRedesObj.cifra);
                accionesRedes = Convert.ToInt32(AccionesRedesObj.cifra);
            }
            else
            {
                SpanAccionesRedesObj.InnerText = "0";
                accionesRedes = 0;
            }

            int accioncountRedesObt = 0;
            var accioncountRedesObtbus = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 8).ToList();
            if (accioncountRedesObtbus[0] != null)
            {
                SpanAccionesRedesObt.InnerText = Convert.ToString(accioncountRedesObtbus[0]);
                accioncountRedesObt = Convert.ToInt32(accioncountRedesObtbus[0]);

            }
            else
            {
                SpanAccionesRedesObt.InnerText = "0";
                accioncountRedesObt = 0;
            }

            double totalRedes = 0;
            double vamosRedes = 0;
            double.TryParse(Convert.ToString(accionesRedes), out totalRedes);
            double.TryParse(Convert.ToString(accioncountRedesObt), out vamosRedes);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteRedes = (int)(0.5f + ((100f * vamosRedes) / totalRedes));

            //string porce =  percentCompleteRedes.ToString("0.00%");

            if (percentCompleteRedes >= 75)
            {
                ArribaRedesAccion.Visible = true;
            }
            else
            {
                if (percentCompleteRedes <= 49)
                {
                    AbajoRedesAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteRedes == 50 || percentCompleteRedes <= 72)
                    {
                        MedioRedesAccion.Visible = true;
                    }
                }
            }
            #endregion

            #region //Deporte y cultura
            //BENEFICIADOS
            int BeneficiadosDeportes_CulturaSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosDeportes_CulturaOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 12 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosDeportes_CulturaOBJ != null)
            {
                SpanBeneficiadosDeportesObj.InnerText = Convert.ToString(beneficiadosDeportes_CulturaOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosDeportesObj.InnerText = "0";
            }

            var BerimesAccionesTablaPrinDeporteCult = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 12).ToList();
            if (BerimesAccionesTablaPrinDeporteCult[0] != null)
            {
                SpanBeneficiadosDeportesObt.InnerText = Convert.ToString(BerimesAccionesTablaPrinDeporteCult[0]);
            }
            else
            {
                SpanBeneficiadosDeportesObt.InnerText = "0";
            }

            //ACCIONES
            int AccionesDepor_Cult = 0;
            tb_AcionesBeneficiadosXmes AccionesDeporte_CulturaObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 12 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesDeporte_CulturaObj != null)
            {
                SpanAccionesDeportesObj.InnerText = Convert.ToString(AccionesDeporte_CulturaObj.cifra);
                AccionesDepor_Cult = Convert.ToInt32(AccionesDeporte_CulturaObj.cifra);
            }
            else
            {
                SpanAccionesDeportesObj.InnerText = "0";
                AccionesDepor_Cult = 0;
            }


            int accioncountDeporte_Cultura = 0;
            var accioncountDeporte_CulturaObtbus = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 12).ToList();
            if (accioncountDeporte_CulturaObtbus[0] != null)
            {
                SpanAccionesDeportesObt.InnerText = Convert.ToString(accioncountDeporte_CulturaObtbus[0]);
                accioncountDeporte_Cultura = Convert.ToInt32(accioncountDeporte_CulturaObtbus[0]);

            }
            else
            {
                SpanAccionesDeportesObt.InnerText = "0";
                accioncountDeporte_Cultura = 0;
            }


            double totalDeporte_cultu = 0;
            double vamosDeporte_cultu = 0;
            double.TryParse(Convert.ToString(AccionesDepor_Cult), out totalDeporte_cultu);
            double.TryParse(Convert.ToString(accioncountDeporte_Cultura), out vamosDeporte_cultu);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteDeporte_cultus = (int)(0.5f + ((100f * vamosDeporte_cultu) / totalDeporte_cultu));

            if (percentCompleteDeporte_cultus >= 75)
            {
                ArribaDeporteAccion.Visible = true;
            }
            else
            {
                if (percentCompleteDeporte_cultus <= 49)
                {
                    AbajoDeporteAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteDeporte_cultus == 50 || percentCompleteDeporte_cultus <= 72)
                    {
                        MedioDeporteAccion.Visible = true;
                    }
                }
            }
            #endregion

            #region //Genero
            //BENEFICIADOS
            int BeneficiadosGeneroSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosGeneroOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 10 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosGeneroOBJ != null)
            {
                SpanBeneficiadosGeneroObj.InnerText = Convert.ToString(beneficiadosGeneroOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosGeneroObj.InnerText = "0";
            }


            var BerimesAccionesTablaPrinGenero = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 10).ToList();
            if (BerimesAccionesTablaPrinGenero[0] != null)
            {
                SpanBeneficiadosGeneroObt.InnerText = Convert.ToString(BerimesAccionesTablaPrinGenero[0]);
            }
            else
            {
                SpanBeneficiadosGeneroObt.InnerText = "0";
            }

            //ACCIONES
            int AccionesGenero = 0;
            tb_AcionesBeneficiadosXmes AccionesGeneroObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 10 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesGeneroObj != null)
            {
                SpanAccionesGeneroObj.InnerText = Convert.ToString(AccionesGeneroObj.cifra);
                AccionesGenero = Convert.ToInt32(AccionesGeneroObj.cifra);
            }
            else
            {
                SpanAccionesGeneroObj.InnerText = "0";
                AccionesGenero = 0;
            }


            int accioncountGenero = 0;
            var accioncountGeneroObt = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 10).ToList();
            if (accioncountGeneroObt[0] != null)
            {
                SpanAccionesGeneroObt.InnerText = Convert.ToString(accioncountGeneroObt[0]);
                accioncountGenero = Convert.ToInt32(accioncountGeneroObt[0]);

            }
            else
            {
                SpanAccionesGeneroObt.InnerText = "0";
                accioncountGenero = 0;
            }




            double totalGenero = 0;
            double vamosGenero = 0;
            double.TryParse(Convert.ToString(AccionesGenero), out totalGenero);
            double.TryParse(Convert.ToString(accioncountGenero), out vamosGenero);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteGenero = (int)(0.5f + ((100f * vamosGenero) / totalGenero));

            if (percentCompleteGenero >= 75)
            {
                ArribaGeneroAccion.Visible = true;
            }
            else
            {
                if (percentCompleteGenero <= 49)
                {
                    AbajoGeneroAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteGenero == 50 || percentCompleteGenero <= 72)
                    {
                        MedioGeneroAccion.Visible = true;
                    }
                }
            }
            #endregion

            #region //Igualdad de genero
            //BENEFICIADOS
            int BeneficiadosIgualdadSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosIgualdadOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 7 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosIgualdadOBJ != null)
            {
                SpanBeneficiadosIgualdadObj.InnerText = Convert.ToString(beneficiadosIgualdadOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosIgualdadObj.InnerText = "0";
            }

            var BerimesAccionesTablaPrinIgualdad = ctx.sp_Reporte_Acciones_Beneficiados(1, mesactual, año, 7).ToList();
            if (BerimesAccionesTablaPrinIgualdad[0] != null)
            {
                SpanBeneficiadosIgualdadObt.InnerText = Convert.ToString(BerimesAccionesTablaPrinIgualdad[0]);
            }
            else
            {
                SpanBeneficiadosIgualdadObt.InnerText = "0";
            }


            //ACCIONES
            int AccionesIgualda = 0;
            tb_AcionesBeneficiadosXmes AccionesIgualdadObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 7 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesIgualdadObj != null)
            {
                SpanAccionesIgualdadObj.InnerText = Convert.ToString(AccionesIgualdadObj.cifra);
                AccionesIgualda = Convert.ToInt32(AccionesIgualdadObj.cifra);
            }
            else
            {
                SpanAccionesIgualdadObj.InnerText = "0";
                AccionesIgualda = 0;
            }


            int accioncountIgualdat = 0;

            var accioncountIgualdadObt = ctx.sp_Reporte_Acciones_Beneficiados(2, mesactual, año, 7).ToList();
            if (accioncountIgualdadObt[0] != null)
            {
                SpanAccionesIgualdadObt.InnerText = Convert.ToString(accioncountIgualdadObt[0]);
                accioncountIgualdat = Convert.ToInt32(accioncountIgualdadObt[0]);

            }
            else
            {
                SpanAccionesIgualdadObt.InnerText = "0";
                accioncountIgualdat = 0;
            }

            double totalIualdad = 0;
            double vamosIgualdad = 0;
            double.TryParse(Convert.ToString(AccionesIgualda), out totalIualdad);
            double.TryParse(Convert.ToString(accioncountIgualdat), out vamosIgualdad);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteIgualdad = (int)(0.5f + ((100f * vamosIgualdad) / totalIualdad));

            if (percentCompleteIgualdad >= 75)
            {
                ArribaIgualdadAccion.Visible = true;
            }
            else
            {
                if (percentCompleteIgualdad <= 49)
                {
                    AbajoIgualdadAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteIgualdad == 50 || percentCompleteIgualdad <= 72)
                    {
                        MedioIgualdadAccion.Visible = true;
                    }
                }
            }
            #endregion

            #region //Redes Veracruzanas en la Construcción de la Paz

            //BENEFICIADOS
            int BeneficiadosRedesVerPazSuma = 0;
            tb_AcionesBeneficiadosXmes beneficiadosRedesVerPazOBJ = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 14 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
            if (beneficiadosRedesVerPazOBJ != null)
            {
                SpanBeneficiadosRedesVerPazObj.InnerText = Convert.ToString(beneficiadosRedesVerPazOBJ.cifra);
            }
            else
            {
                SpanBeneficiadosRedesVerPazObj.InnerText = "0";
            }

            tb_Reporte_Diario BerimesAccionesTablaPrinRedesVerPaz = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == 14).FirstOrDefault();
            if (BerimesAccionesTablaPrinRedesVerPaz != null)
            {
                var AcbenisumaRedesVerPaz = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == 14).Sum(x => x.total_atendidos.Value).ToString();
                BeneficiadosRedesVerPazSuma = Convert.ToInt32(AcbenisumaRedesVerPaz);
                SpanBeneficiadosRedesVerPazobt.InnerText = Convert.ToString(BeneficiadosRedesVerPazSuma);
            }
            else
            {
                SpanBeneficiadosRedesVerPazobt.InnerText = "0";
            }


            //ACCIONES
            int AccionesRedesVerPaz = 0;
            tb_AcionesBeneficiadosXmes AccionesRedesVerPazObj = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == 14 && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
            if (AccionesRedesVerPazObj != null)
            {
                SpanAccionesRedesVerPazObj.InnerText = Convert.ToString(AccionesRedesVerPazObj.cifra);
                AccionesRedesVerPaz = Convert.ToInt32(AccionesRedesVerPazObj.cifra);
            }
            else
            {
                SpanAccionesRedesVerPazObj.InnerText = "0";
                AccionesRedesVerPaz = 0;
            }


            int accioncountRedesVerPaz = 0;
            tb_Reporte_Diario accioncountRedesVerPazObt = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == 14).FirstOrDefault();
            if (accioncountIgualdadObt != null)
            {
                var accioncountRedesVerPazobt = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == 14).Count().ToString();
                SpanAccionesRedesVerPazObt.InnerText = accioncountRedesVerPazobt;
                accioncountRedesVerPaz = Convert.ToInt32(accioncountRedesVerPazobt);
            }
            else
            {
                accioncountRedesVerPaz = 0;
                SpanAccionesRedesVerPazObt.InnerText = "0";
            }

            double totalRedesVerPaz = 0;
            double vamosRedesVerPaz = 0;
            double.TryParse(Convert.ToString(AccionesRedesVerPaz), out totalRedesVerPaz);
            double.TryParse(Convert.ToString(accioncountRedesVerPaz), out vamosRedesVerPaz);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteRedesVerPaz = (int)(0.5f + ((100f * vamosRedesVerPaz) / totalRedesVerPaz));

            if (percentCompleteRedesVerPaz >= 75)
            {
                ArribaIRedesVerPazAccion.Visible = true;
            }
            else
            {
                if (percentCompleteRedesVerPaz <= 49)
                {
                    AbajoRedesVerPazAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteRedesVerPaz == 50 || percentCompleteRedesVerPaz <= 72)
                    {
                        MedioRedesVerPazAccion.Visible = true;
                    }
                }
            }
            #endregion
        }


        private void Conteo_acciones_bene_Gral_porarea()
        {

            this.progragr = int.Parse(this.Session["programa"].ToString());

            fechaMes = Convert.ToString(DateTime.Now.Month);
            //int año = DateTime.Now.Year;
            var totaBeniXmes = 0;
            var totalAcciones = 0;

            if (progragr != 0)
            {
                tb_AcionesBeneficiadosXmes beneficiados = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == progragr && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 1).FirstOrDefault();
                if (beneficiados == null)
                {
                    beniObj.InnerText = "0";
                    mes.InnerText = "SIN DATOS";
                }
                else
                {
                    totaBeniXmes = Convert.ToInt32(beneficiados.cifra);
                    beniObj.InnerText = totaBeniXmes.ToString();
                    mes.InnerText = beneficiados.mesTEX;
                }



                int benipormes;
                int mesactual = DateTime.Now.Month;
                var berificacionHayelemnetos = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == progragr).FirstOrDefault();
                //var benisuma = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.programasID == progra).ToList();
                if (berificacionHayelemnetos == null)
                {
                    benipormes = 0;
                    aldiabeni.InnerText = "0";
                }
                else
                {
                    var benisuma = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == progragr).Sum(x => x.total_atendidos.Value).ToString();

                    benipormes = Convert.ToInt32(benisuma);
                    aldiabeni.InnerText = Convert.ToString(benipormes);
                }


                tb_AcionesBeneficiadosXmes Acciones = this.ctx.tb_AcionesBeneficiadosXmes.Where(x => x.programa == progragr && x.MesInt == fechaMes && x.Año == año && x.TipoB_A == 2).FirstOrDefault();
                if (Acciones != null)
                {
                    totalAcciones = Convert.ToInt32(Acciones.cifra);
                    accionesObj.InnerText = totalAcciones.ToString();
                }
                else
                {
                    totalAcciones = 0;
                    accionesObj.InnerText = "0";
                }

                int Accionpormes = 0;
                tb_Reporte_Diario accionesGral = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == progragr).FirstOrDefault();
                if (accionesGral != null)
                {
                    var accioncount = ctx.tb_Reporte_Diario.Where(p => p.fecha.Value.Month == mesactual && p.fecha.Value.Year == año && p.programasID == progragr).Count().ToString();
                    Accionpormes = Convert.ToInt32(accioncount);
                    accionesdia.InnerText = accioncount;
                }
                else
                {
                    Accionpormes = 0;
                    accionesdia.InnerText = "0";
                }


                double totalac = 0;
                double vamosac = 0;
                double.TryParse(Convert.ToString(totalAcciones), out totalac);
                double.TryParse(Convert.ToString(Accionpormes), out vamosac);
                //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
                int percentCompleteac = (int)(0.5f + ((100f * vamosac) / totalac));

                if (percentCompleteac >= 75)
                {
                    arribaac.Visible = true;
                }
                else
                {
                    if (percentCompleteac <= 25)
                    {
                        abajoac.Visible = true;


                    }
                    else
                    {
                        if (percentCompleteac >= 50 || percentCompleteac == 65)
                        {
                            medioac.Visible = true;
                        }
                    }
                }
            }






        }

        private void Conteo_A_B_TB_X_Cargadetrabajo()
        {
            this.progragr = int.Parse(this.Session["programa"].ToString());
            String Dele = (String)Session["Delegacion"];

            fechaMes = Convert.ToString(DateTime.Now.Month);
            int mesactual = DateTime.Now.Month;
            //int año = DateTime.Now.Year;
            //ACCIONES
            int AccionXarea = 0;
            tbCarga_trabajo_Dele AccionesXareaObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == progragr && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaObj != null)
            {
                StrongMesCaraga.InnerText = AccionesXareaObj.Mes_letra;
                StrongCordinacion.InnerText = AccionesXareaObj.Delegacion;
                spanAccionXareaObje.InnerText = Convert.ToString(AccionesXareaObj.cifra);
                AccionXarea = Convert.ToInt32(AccionesXareaObj.cifra);
            }
            else
            {
                StrongMesCaraga.InnerText = "SIN DATOS";
                StrongCordinacion.InnerText = "SIN DATOS";
                spanAccionXareaObje.InnerText = "0";
                AccionXarea = 0;
            }



            this.spanAccionXareaObjt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                  join std in ctx.tb_DireccionReporte
                                                  on s.idResumenDiario equals std.idResumenDiario
                                                  where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == progragr
                                                  select s.programasID).Count().ToString();

            double totalGral = 0;
            double vamosGrald = 0;
            double.TryParse(Convert.ToString(AccionXarea), out totalGral);
            double.TryParse(Convert.ToString(spanAccionXareaObjt.InnerText), out vamosGrald);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteg = (int)(0.5f + ((100f * vamosGrald) / totalGral));

            if (percentCompleteg >= 75 || percentCompleteg >= 100)
            {
                ArribagralAccion.Visible = true;
            }
            else
            {
                if (percentCompleteg <= 49)
                {
                    AbajoagralAccion.Visible = true;
                }
                else
                {
                    if (percentCompleteg == 50 || percentCompleteg <= 72)
                    {
                        mediogralAccion.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            int BeneficiadosXdiaSuma = 0;
            tbCarga_trabajo_Dele beneficiadosGralxdiadOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == progragr && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosGralxdiadOBJ != null)
            {
                spanBeniXaccionXareaObje.InnerText = Convert.ToString(beneficiadosGralxdiadOBJ.cifra);
            }
            else
            {
                spanBeniXaccionXareaObje.InnerText = "0";
            }




            this.SpanBeneficiadosIgualdadObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                          join std in ctx.tb_DireccionReporte
                                                          on s.idResumenDiario equals std.idResumenDiario
                                                          where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == progragr
                                                          select s.total_atendidos).Sum().ToString();


            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == progragr && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosGralxmesdOBJ != null)
            {
                spanBeniTotalXareaObje.InnerText = Convert.ToString(beneficiadosGralxmesdOBJ.cifra);
            }
            else
            {
                spanBeniTotalXareaObje.InnerText = "0";
            }



            this.spanBeniTotalXareaObjt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                     join std in ctx.tb_DireccionReporte
                                                     on s.idResumenDiario equals std.idResumenDiario
                                                     where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == progragr
                                                     select s.total_atendidos).Sum().ToString();
        }
        //CONTEO DE META Y OBTENIDOS POR ENLACE CON EL SECTOR EMPRESARIAL 

        private void Conteo_A_B_TB_X_CargadetraForaneobajo()
        {
            String Dele = (String)Session["Delegacion"];

            fechaMes = Convert.ToString(DateTime.Now.Month);
            int mesactual = DateTime.Now.Month;
            //int año = DateTime.Now.Year;

            #region //EMPRESARIAL
            //ACCIONES
            int accionesEmpreFora = 0;
            tbCarga_trabajo_Dele AccionesXareaEmpreObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 13 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaEmpreObj != null)
            {
                MesForaneo.InnerText = AccionesXareaEmpreObj.Mes_letra;
                spanAccionesForaneoEmpreObj.InnerText = Convert.ToString(AccionesXareaEmpreObj.cifra);
                accionesEmpreFora = Convert.ToInt32(AccionesXareaEmpreObj.cifra);
            }
            else
            {
                MesForaneo.InnerText = "SIN DATOS";
                spanAccionesForaneoEmpreObj.InnerText = "0";
                accionesEmpreFora = 0;
            }



            this.spanAccionesForaneoEmpreObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                          join std in ctx.tb_DireccionReporte
                                                          on s.idResumenDiario equals std.idResumenDiario
                                                          where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 13
                                                          select s.programasID).Count().ToString();

            double totalGralEmpre = 0;
            double vamosGraldempre = 0;
            double.TryParse(Convert.ToString(accionesEmpreFora), out totalGralEmpre);
            double.TryParse(Convert.ToString(spanAccionesForaneoEmpreObt.InnerText), out vamosGraldempre);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegEmpre = (int)(0.5f + ((100f * vamosGraldempre) / totalGralEmpre));

            if (percentCompletegEmpre >= 75)
            {
                spanArribaForaEmpre.Visible = true;
            }
            else
            {
                if (percentCompletegEmpre <= 49)
                {
                    spaAbajoForaEmpre.Visible = true;
                }
                else
                {
                    if (percentCompletegEmpre == 50 || percentCompletegEmpre <= 72)
                    {
                        spanMedioForaEmpre.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaEmpreOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 13 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaEmpreOBJ != null)
            {
                spanBeniPordiaEMpreObj.InnerText = Convert.ToString(beneficiadosXdiaEmpreOBJ.cifra);
            }
            else
            {
                spanBeniPordiaEMpreObj.InnerText = "0";
            }

            this.spanBeniPordiaEMpreObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                     join std in ctx.tb_DireccionReporte
                                                     on s.idResumenDiario equals std.idResumenDiario
                                                     where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 13
                                                     select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalEMpredOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 13 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalEMpredOBJ != null)
            {
                spanBeniTotalEmpreObj.InnerText = Convert.ToString(beneficiadosTotalEMpredOBJ.cifra);
            }
            else
            {
                spanBeniTotalEmpreObj.InnerText = "0";
            }



            this.spanBeniTotalEmpreObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                    join std in ctx.tb_DireccionReporte
                                                    on s.idResumenDiario equals std.idResumenDiario
                                                    where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 13
                                                    select s.total_atendidos).Sum().ToString();

            #endregion


            #region //ESCOLAR
            //ACCIONES
            int accionesEscoFora = 0;
            tbCarga_trabajo_Dele AccionesXareaEscoObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 9 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaEscoObj != null)
            {
                spanAccionesForaneoEscoObj.InnerText = Convert.ToString(AccionesXareaEscoObj.cifra);
                accionesEscoFora = Convert.ToInt32(AccionesXareaEscoObj.cifra);
            }
            {
                spanAccionesForaneoEscoObj.InnerText = "0";
                accionesEscoFora = 0;

            }
            this.spanAccionesForaneoEscoObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                         join std in ctx.tb_DireccionReporte
                                                         on s.idResumenDiario equals std.idResumenDiario
                                                         where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 9
                                                         select s.programasID).Count().ToString();

            double totalGralESCO = 0;
            double vamosGraldESCO = 0;
            double.TryParse(Convert.ToString(accionesEscoFora), out totalGralESCO);
            double.TryParse(Convert.ToString(spanAccionesForaneoEscoObt.InnerText), out vamosGraldESCO);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int porcentajeEscolar = (int)(0.5f + ((100f * vamosGraldESCO) / totalGralESCO));

            if (porcentajeEscolar >= 75)
            {
                spanArribaForaESCO.Visible = true;
            }
            else
            {
                if (porcentajeEscolar <= 49)
                {
                    spanAbajoForaESCO.Visible = true;
                }
                else
                {
                    if (porcentajeEscolar == 50 || porcentajeEscolar <= 72)
                    {
                        spanMedioForaESCO.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaEscoOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 9 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaEscoOBJ != null)
            {
                spanBeneficiadosXdiasForaneoEscoObj.InnerText = Convert.ToString(beneficiadosXdiaEscoOBJ.cifra);
            }
            else
            {
                spanBeneficiadosXdiasForaneoEscoObj.InnerText = "0";
            }

            this.spanBeneficiadosXdiasForaneoEscoObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                                  join std in ctx.tb_DireccionReporte
                                                                  on s.idResumenDiario equals std.idResumenDiario
                                                                  where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 9
                                                                  select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalEscolardOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 9 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalEscolardOBJ != null)
            {
                spanBeneficiadosForaneoEscoObj.InnerText = Convert.ToString(beneficiadosTotalEscolardOBJ.cifra);
            }
            else
            {
                spanBeneficiadosForaneoEscoObj.InnerText = "0";
            }



            this.spanBeneficiadosForaneoEscoObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                             join std in ctx.tb_DireccionReporte
                                                             on s.idResumenDiario equals std.idResumenDiario
                                                             where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 9
                                                             select s.total_atendidos).Sum().ToString();

            #endregion

            #region //REDESVECINALES
            //ACCIONES
            int redesAccionesFora = 0;
            tbCarga_trabajo_Dele AccionesXareaRedesObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 8 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaRedesObj != null)
            {
                spanAccionesForaneoRedesObj.InnerText = Convert.ToString(AccionesXareaRedesObj.cifra);
                redesAccionesFora = Convert.ToInt32(AccionesXareaRedesObj.cifra);
            }
            else
            {
                spanAccionesForaneoRedesObj.InnerText = "0";
                redesAccionesFora = 0;

            }

            this.spanAccionesForaneoRedesObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                          join std in ctx.tb_DireccionReporte
                                                          on s.idResumenDiario equals std.idResumenDiario
                                                          where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 8
                                                          select s.programasID).Count().ToString();

            double totalGralRedes = 0;
            double vamosGraldRedes = 0;
            double.TryParse(Convert.ToString(redesAccionesFora), out totalGralRedes);
            double.TryParse(Convert.ToString(spanAccionesForaneoEmpreObt.InnerText), out vamosGraldRedes);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int porcentajeRedes = (int)(0.5f + ((100f * vamosGraldRedes) / totalGralRedes));

            if (porcentajeRedes >= 75)
            {
                spanArribaForaRedes.Visible = true;
            }
            else
            {
                if (porcentajeRedes <= 49)
                {
                    spanAbajoForaRedes.Visible = true;
                }
                else
                {
                    if (porcentajeRedes == 50 || porcentajeRedes <= 72)
                    {
                        spanMedioForaRedes.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaRedesOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 8 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaRedesOBJ != null)
            {
                spanBeneficiadosXdiasForaneoRedesObj.InnerText = Convert.ToString(beneficiadosXdiaRedesOBJ.cifra);
            }
            else
            {
                spanBeneficiadosXdiasForaneoRedesObj.InnerText = "0";
            }


            this.spanBeneficiadosXdiasForaneoRedesObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                                   join std in ctx.tb_DireccionReporte
                                                                   on s.idResumenDiario equals std.idResumenDiario
                                                                   where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 8
                                                                   select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalRedesdOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 8 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalRedesdOBJ != null)
            {
                spanBeneficiadosForaneoRedObj.InnerText = Convert.ToString(beneficiadosTotalRedesdOBJ.cifra);
            }
            else
            {
                spanBeneficiadosForaneoRedObj.InnerText = "0";
            }



            this.spanBeneficiadosForaneRedoObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                            join std in ctx.tb_DireccionReporte
                                                            on s.idResumenDiario equals std.idResumenDiario
                                                            where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 8
                                                            select s.total_atendidos).Sum().ToString();
            #endregion


            #region//Deporte y cultura
            //ACCIONES
            int accionesDeportesFora = 0;
            tbCarga_trabajo_Dele AccionesXareaDeporteObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaDeporteObj != null)
            {
                spanAccionesForaneoDeporteObj.InnerText = Convert.ToString(AccionesXareaDeporteObj.cifra);
                accionesDeportesFora = Convert.ToInt32(AccionesXareaDeporteObj.cifra);
            }
            else
            {
                spanAccionesForaneoDeporteObj.InnerText = "0";
                accionesDeportesFora = 0;
            }



            this.spanAccionesForaneoDeporteObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                            join std in ctx.tb_DireccionReporte
                                                            on s.idResumenDiario equals std.idResumenDiario
                                                            where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 12
                                                            select s.programasID).Count().ToString();

            double totalGralDeporte = 0;
            double vamosGraldDeporte = 0;
            double.TryParse(Convert.ToString(accionesDeportesFora), out totalGralDeporte);
            double.TryParse(Convert.ToString(spanAccionesForaneoDeporteObt.InnerText), out vamosGraldDeporte);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteDeporte = (int)(0.5f + ((100f * vamosGraldDeporte) / totalGralDeporte));

            if (percentCompleteDeporte >= 75)
            {
                spanArribaForaDeporte.Visible = true;
            }
            else
            {
                if (percentCompleteDeporte <= 49)
                {
                    spanAbajoForaDeporte.Visible = true;
                }
                else
                {
                    if (percentCompleteDeporte == 50 || percentCompleteDeporte <= 72)
                    {
                        spanMinibForaDeporte.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaDeporteOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaDeporteOBJ != null)
            {
                spanBeneficiadosXdiasForaneoDeportesObj.InnerText = Convert.ToString(beneficiadosXdiaDeporteOBJ.cifra);

            }
            else
            {
                spanBeneficiadosXdiasForaneoDeportesObj.InnerText = "0";

            }

            this.spanBeneficiadosXdiasForaneoDeportesObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                                      join std in ctx.tb_DireccionReporte
                                                                      on s.idResumenDiario equals std.idResumenDiario
                                                                      where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 12
                                                                      select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalDeportedOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalDeportedOBJ != null)
            {
                spanBeneficiadosForaneoDEObj.InnerText = Convert.ToString(beneficiadosTotalDeportedOBJ.cifra);

            }
            else
            {
                spanBeneficiadosForaneoDEObj.InnerText = "0";

            }

            this.spanBeneficiadosForaneoDEObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                           join std in ctx.tb_DireccionReporte
                                                           on s.idResumenDiario equals std.idResumenDiario
                                                           where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 12
                                                           select s.total_atendidos).Sum().ToString();
            #endregion

            #region//Genero
            //ACCIONES
            int accionesGeneroFora = 0;
            tbCarga_trabajo_Dele AccionesXareaGeneroObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 10 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaGeneroObj != null)
            {
                spanAccionesForaneoGneroObj.InnerText = Convert.ToString(AccionesXareaGeneroObj.cifra);
                accionesGeneroFora = Convert.ToInt32(AccionesXareaGeneroObj.cifra);
            }
            else
            {
                spanAccionesForaneoGneroObj.InnerText = "0";
                accionesGeneroFora = 0;
            }

            this.spanAcionesForaneoGneroObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                         join std in ctx.tb_DireccionReporte
                                                         on s.idResumenDiario equals std.idResumenDiario
                                                         where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 10
                                                         select s.programasID).Count().ToString();

            double totalGralGenero = 0;
            double vamosGraldGenero = 0;
            double.TryParse(Convert.ToString(accionesGeneroFora), out totalGralGenero);
            double.TryParse(Convert.ToString(spanAcionesForaneoGneroObt.InnerText), out vamosGraldGenero);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteGenero = (int)(0.5f + ((100f * vamosGraldGenero) / totalGralGenero));

            if (percentCompleteGenero >= 75)
            {
                spanArribaForaGenero.Visible = true;
            }
            else
            {
                if (percentCompleteGenero <= 49)
                {
                    spanAbajoaForaGenero.Visible = true;
                }
                else
                {
                    if (percentCompleteGenero == 50 || percentCompleteGenero <= 72)
                    {
                        spanMedioForaGenero.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaGeneroOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 10 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaGeneroOBJ != null)
            {
                spanBeneficiadosXdiaForaneoGneroObj.InnerText = Convert.ToString(beneficiadosXdiaGeneroOBJ.cifra);
            }
            else
            {
                spanBeneficiadosXdiaForaneoGneroObj.InnerText = "0";
            }



            this.spanBeneficiadosXdiaForaneoGneroObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                                  join std in ctx.tb_DireccionReporte
                                                                  on s.idResumenDiario equals std.idResumenDiario
                                                                  where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 10
                                                                  select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalGneroOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 10 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalGneroOBJ != null)
            {
                spanBeneficiadosForaneoGneroObj.InnerText = Convert.ToString(beneficiadosTotalGneroOBJ.cifra);
            }
            else
            {
                spanBeneficiadosForaneoGneroObj.InnerText = "0";
            }

            this.spanBeneficiadosForaneoGneroObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                              join std in ctx.tb_DireccionReporte
                                                              on s.idResumenDiario equals std.idResumenDiario

                                                              where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 10
                                                              select s.total_atendidos).Sum().ToString();
            #endregion

            #region//Igualdad
            //ACCIONES
            int accionesIgualForaneo = 0;
            tbCarga_trabajo_Dele AccionesXareaIualdadObj = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 7 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            if (AccionesXareaIualdadObj != null)
            {
                spanAccionesForaneoIgualdadObj.InnerText = Convert.ToString(AccionesXareaIualdadObj.cifra);
                accionesIgualForaneo = Convert.ToInt32(AccionesXareaIualdadObj.cifra);
            }
            else
            {
                spanAccionesForaneoIgualdadObj.InnerText = "0";
                accionesIgualForaneo = 0;
            }



            this.spanAccionesForaneoIgualdadObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                             join std in ctx.tb_DireccionReporte
                                                             on s.idResumenDiario equals std.idResumenDiario
                                                             where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 7
                                                             select s.programasID).Count().ToString();

            double totalGralIgualdad = 0;
            double vamosGraldIgualdad = 0;
            double.TryParse(Convert.ToString(accionesIgualForaneo), out totalGralIgualdad);
            double.TryParse(Convert.ToString(spanAccionesForaneoIgualdadObt.InnerText), out vamosGraldIgualdad);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteIgualdad = (int)(0.5f + ((100f * vamosGraldIgualdad) / totalGralIgualdad));

            if (percentCompleteIgualdad >= 75)
            {
                spanArribaForaIgualdad.Visible = true;
            }
            else
            {
                if (percentCompleteIgualdad <= 49)
                {
                    spanAbajoForaIgualdad.Visible = true;
                }
                else
                {
                    if (percentCompleteIgualdad == 50 || percentCompleteIgualdad <= 72)
                    {
                        spanMedioForaIgualdad.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 

            //CONTEO DE BENEFICIADOS POR DIA 
            tbCarga_trabajo_Dele beneficiadosXdiaIgualdadOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 7 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 2).FirstOrDefault();
            if (beneficiadosXdiaIgualdadOBJ != null)
            {
                spanBeniXidaForaneoIgualdadObj.InnerText = Convert.ToString(beneficiadosXdiaIgualdadOBJ.cifra);

            }
            else
            {
                spanBeniXidaForaneoIgualdadObj.InnerText = "0";

            }

            this.spanBeniXidaForaneoIgualdadObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                             join std in ctx.tb_DireccionReporte
                                                             on s.idResumenDiario equals std.idResumenDiario
                                                             where s.fecha.Value.Month >= mesactual && s.fecha == DateTime.Now && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 7
                                                             select s.total_atendidos).Sum().ToString();

            //TERMINA EL CONTEO DE BENEFICIADOS POR DIA

            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosTotalIgualdadOBJ = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 7 && x.Mes_Num == mesactual && x.Año == año && x.Delegacion == Dele && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            if (beneficiadosTotalIgualdadOBJ != null)
            {
                spanBenificiadosForaneoIgualdadObj.InnerText = Convert.ToString(beneficiadosTotalIgualdadOBJ.cifra);

            }
            else
            {
                spanBenificiadosForaneoIgualdadObj.InnerText = "0";
            }


            this.spanBenificiadosForaneoIgualdadObt.InnerText = (from s in ctx.tb_Reporte_Diario
                                                                 join std in ctx.tb_DireccionReporte
                                                                 on s.idResumenDiario equals std.idResumenDiario
                                                                 where s.fecha.Value.Month >= mesactual && s.fecha.Value.Year == año && s.DelegacionOcoonurbacion == Dele && s.programasID == 7
                                                                 select s.total_atendidos).Sum().ToString();

            #endregion
        }
        #endregion



    }
}