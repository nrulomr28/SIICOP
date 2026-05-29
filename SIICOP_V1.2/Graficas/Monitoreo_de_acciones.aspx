<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Monitoreo_de_acciones.aspx.cs" Inherits="SIICOP_V1._2.Graficas.Monitoreo_de_acciones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/StyleResultados.css" rel="stylesheet" />
    <div class="container">
        <div class="mt-4" style="margin-top: 5% !important">
            <h1 style="text-align: center; font-size: 2.2EM; color: #851717;">MONITOREO DE ACCIONES EN MATERIA DE PREVENCIÓN SOCIAL DE LA VIOLENCIA Y LA DELINCUENCIA</h1>
            <div class="row">
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="input-group input-group-sm" id="Fecha1">
                        <asp:TextBox ID="txtFechaini" runat="server" CssClass=" form-control" placeholder="YYYY/MM/DD" autocomplete="off"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaini" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                        <span class="input-group-addon">
                            <i class="glyphicon glyphicon-calendar"></i>
                        </span>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="input-group input-group-sm" id="Fecha2">
                        <asp:TextBox ID="txtDateFin" runat="server" CssClass=" form-control" ReadOnly="false" placeholder="YYYY/MM/DD" autocomplete="off"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFin" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="btn btn-success">
                        <i class="fas fa-search"></i>
                        <asp:Button runat="server" ID="btnBuscar" CssClass="btn-success" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />
     
    </div>
    <div class="container-fluid">
           <div class="row" id="Resultados" runat="server" visible="false">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Height="900px" Width="100%">
            </rsweb:ReportViewer>
        </div>
    </div>


    <div class="modal fade" id="exampleModalValidador" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 style="text-align: center"><span class="fa fa-exclamation-triangle" aria-hidden="true" style="font-size: 2.4em; color: orange"></span></h3>
                            </div>
                        </div>
                        <div class="row">
                            <div method="post" class="form-horizontal" action="none">
                                <asp:Label runat="server" ID="validadottxt"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <span class="glyphicon glyphicon-floppy-remove" aria-hidden="true"></span>
                        Cancelar</button>

                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function AbrirModalValidador() {
            $('#exampleModalValidador').modal();
            return false;
        }

    </script>
</asp:Content>
