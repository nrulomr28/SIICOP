<%@ Page Title="Menú de dependencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuDependencias.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.MenuDependencias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
       .contenedor {
    position: relative;
    margin-bottom: 20px;
}

.titulo-overlay {
    position: absolute;
    top: 50%;
    left: 50%;

    transform: translate(-50%, -50%);

    background: rgba(0,0,0,.65);
    color: #fff;

    padding: 12px 24px;

    border-radius: 6px;

    font-size: 24px;
    font-weight: bold;
}

.img-dgpvi {
    width: 100%;
    height: 420px;
    object-fit: cover;

    border-radius: 4px;
}

.img-estrategia {
    width: 100%;
    height: 420px;
    object-fit: contain;

    border-radius: 4px;
}

.separator-container h2 {
    margin-bottom: 25px;
    font-weight: 600;
}

.opacar {
    transition: all .25s ease;
}

.opacar:hover {
    opacity: .90;
    transform: scale(1.01);
}

    </style>


    <br />
    <br />
<div class="container">
      <article id="post-69889" class="page">
          <div class="separator-container">
              <h2 class="text-center">Áreas adscritas</h2>
          </div>

          <div class="nota-contenido-page">
              <div class="row">


                  <div id="PanelDGPVI" runat="server" visible="false" class="col-md-6 col-sm-6 text-center contenedor">
                      <asp:ImageButton ID="ImageButton5" runat="server"
                          ImageUrl="~/Imagenes/Menudependencia/DGPVI.png"
                          CommandArgument=""
                          OnCommand="Imagen_Click" class="img-responsive img-thumbnail opacar" />
                      <h3 class="fw-bold titulo">DGPVI</h3>
                  </div>


                  <div id="PanelEjeAtencion" runat="server" visible="true" class="col-md-6 col-sm-6 text-center contenedor">
                      <asp:ImageButton ID="ImageButton4" runat="server"
                          ImageUrl="~/Imagenes/Menudependencia/IMG_ESTRATEGIA.jpg"
                          CommandArgument="Estrategia"
                          OnCommand="Imagen_Click" class="img-responsive img-thumbnail opacar" />
                      <h3 class="fw-bold titulo">Eje Atención</h3>
                  </div>

              </div>
          </div>
      </article>
  </div>
    <br />
</asp:Content>
