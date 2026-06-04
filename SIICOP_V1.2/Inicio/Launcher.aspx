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
    border-radius: 20px;
    min-height: 280px;
    transition: all .30s ease;
    cursor: pointer;
    border: none;
    overflow: hidden;
}

.dashboard-card:hover
{
    transform: translateY(-10px) scale(1.03);
}

.dashboard-card .card-body
{
    padding-top: 40px;
}

.dashboard-card i
{
    font-size: 5rem;
    color: #6D132D;
    margin-bottom: 25px;
}

.dashboard-card h4
{
    font-size: 1.8rem;
    font-weight: 700;
    margin-bottom: 15px;
}

.dashboard-card p
{
    color: #666;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-center mb-5">

    <h1>
        Sistema de Información Control y Productividad
    </h1>

    <h5>
        Bienvenido: <%: User.Identity.Name %>
    </h5>

</div>

        <div>

             <div class="container mt-5">

        <div class="row">

            <asp:Repeater
    ID="rptMenu"
    runat="server">

    <ItemTemplate>

        <div class="col-md-3 mb-4">

            <a href="<%# ResolveUrl(Eval("Url").ToString()) %>"
               style="text-decoration:none;">

                <div class="card dashboard-card"
     style='border-top:8px solid <%# Eval("Color") %>;'>

                    <div class="card-body text-center">

                        <i class="<%# Eval("Icono") %> fa-3x mb-3"></i>

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

    </div>
    </form>
</body>
</html>
