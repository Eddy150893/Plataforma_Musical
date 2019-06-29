<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra_Busquedas.master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Plataforma_Musical.Vistas.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div style="height: 925px">
        
        
        <div style="height: 400px">
            <hr style="#000000: ;" />
<div class="wrapper col3">
  <div id="container">
    <div class="homepage">
      <ul>
        <li class="last">
            <label><span align="center"><h1>Generos</h1></span></label>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Vistas/images/Genero_disco.jpg" BorderColor="#95AD19" Height="278px" Width="293px" BorderWidth="3px" CssClass="light" OnClick="ImageButton2_Click" />
        </li>
         <li class="last">
          <p style="visibility:hidden;">_____________________________________</p>
        </li>
        <li class="last">
          
            <label><span align="center"><h1>Lista de Reproduccion</h1></span></label>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="281px" ImageUrl="~/Vistas/images/lista.jpg" Width="296px" BorderColor="#95AD19" BorderWidth="3px" CssClass="light" />
          
        </li>
      </ul>
      <br class="clear" />
    </div>
  </div>
</div>
       
         <hr style="#000000: ;" />
        <div style="height: 400px">
            <div class="wrapper col3">
  <div id="container">
    <div class="homepage">
      <ul>
        <li class="last">
            <label><span align="center"><h1>Artista Mas Influyente</h1></span></label>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Vistas/images/artistas.jpg" Height="282px" Width="296px" BorderColor="#95AD19" BorderWidth="3px" CssClass="light" />
        </li>
         <li class="last">
          <p style="visibility:hidden;">_____________________________________</p>
        </li>
        <li class="last">
          
            <label><span align="center"><h1>Albumes Populares</h1></span></label>
            <asp:ImageButton ID="ImageButton4" runat="server" Height="281px" ImageUrl="~/Vistas/images/albumes mas populares.jpg" Width="296px" BorderColor="#95AD19" BorderWidth="3px" CssClass="light" />
          
        </li>
      </ul>
      <br class="clear" />
    </div>
  </div>
</div>
        </div>
         
    </div>
   <div>
        </div>
        </div>
</asp:Content>
