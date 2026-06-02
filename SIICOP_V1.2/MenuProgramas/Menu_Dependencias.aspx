<%@ Page Title="Menú de dependencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Dependencias.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.Menu_Dependencias" %>





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
        <div class="row">
            <article id="post-69889" class="post-69889 page type-page status-publish hentry">
                <div class="separator-container">
                    <h2 style="text-align: center;">Áreas adscritas</h2>
                </div>
                <div class="nota-contenido-page">

                    <div class="row ex1">

    <!-- DGPVI -->
    <div class="col-md-4 col-sm-4 text-center contenedor">

        <asp:ImageButton ID="ImageButton5"
            runat="server"
            ImageUrl="~/Imagenes/Menudependencia/IMG_ATNCAUSAS.png"
            CommandArgument=""
            OnCommand="Imagen_Click"
            CssClass="img-responsive img-thumbnail img-dgpvi opacar" />

        <div class="titulo-overlay">
            DGPVI
        </div>

    </div>

    <!-- Estrategia -->
    <div class="col-md-8 col-sm-8 text-center contenedor">

        <asp:ImageButton ID="ImageButton4"
            runat="server"
            ImageUrl="~/Imagenes/Menudependencia/IMG_ESTRATEGIA.jpg"
            CommandArgument="Estrategia"
            OnCommand="Imagen_Click"
            CssClass="img-responsive img-thumbnail img-estrategia opacar" />

    </div>

</div>
                  
                    <div class="row ex1">
                    </div>

                </div>


                <!-- .entry-content -->
            </article>
            <!-- #post-## -->
        </div>
    </div>
    <br />
</asp:Content>
