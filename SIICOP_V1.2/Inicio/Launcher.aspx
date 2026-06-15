<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Launcher.aspx.cs" Inherits="SIICOP_V1._2.Inicio.Launcher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css"
      rel="stylesheet" />
    <link rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style runat="server" id="styleLauncher">

.dashboard-card
{
    border-radius: 18px;
    min-height: 260px;
    transition: all .25s ease;
    cursor: pointer;
    border: none;
    overflow: hidden;
    background: #fff;

    box-shadow: 0 .125rem .25rem rgba(0,0,0,.075);
}

.dashboard-card:hover
{
    transform: translateY(-8px);

    box-shadow:
        0 1rem 3rem rgba(0,0,0,.15);
}

.dashboard-card .card-body
{
    padding: 40px 25px;
}

.dashboard-card i
{
    font-size: 4.5rem;
    margin-bottom: 20px;
    transition: all .25s ease;
}

.dashboard-card h4
{
    font-size: 1.4rem;
    font-weight: 700;
    color: #212529;
}

.dashboard-card p
{
    color: #6c757d;
    margin-bottom: 0;
}

.dashboard-card:hover i
{
    transform: scale(1.08);
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
       <!-- HERO -->
<div class="container-fluid py-5 text-center"
     style="background: linear-gradient(135deg,#611232,#7a1838); color:white;">

    <img src="<%= ResolveUrl("~/Imagenes/SIICOP_2.png") %>"
         style="height:110px;"
         class="mb-3" />

    <h1 class="fw-bold">
        SIICOP
    </h1>

    <h5 class="mb-3">
        Sistema Integral de Información, Control Operativo y Productividad
    </h5>

    <div class="badge bg-light text-dark p-2">
        Usuario: <%: User.Identity.Name %>
    </div>

</div>

<!-- CONTENIDO -->
<div class="container py-5">

    <div class="row mb-4">

        <div class="col-md-12 text-center">

            <h2 class="fw-bold">
                Módulos / Opciones de usuario.
            </h2>

            <p class="text-muted">
                Seleccione un módulo para continuar
            </p>

        </div>

    </div>

    <div class="row">

        <asp:Repeater
            ID="rptMenu"
            runat="server">

            <ItemTemplate>

                <div class="col-xl-3 col-lg-4 col-md-6 mb-4">

                    <a href="<%# ResolveUrl(Eval("Url").ToString()) %>"
                       style="text-decoration:none;">

                        <div class="card dashboard-card shadow-sm"
                             style='border-top:8px solid <%# Eval("Color") %>;'>

                            <div class="card-body text-center">

                                <i class="<%# Eval("Icono") %>"
                                   style='color:<%# Eval("Color") %>;'>

                                </i>

                                <h4>
                                    <%# Eval("Titulo") %>
                                </h4>
                                <p>
                                    <%# Eval("Descripcion") %>
                                </p>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</div>

    </form>
</body>
</html>
