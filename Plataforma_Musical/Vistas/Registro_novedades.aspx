<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Registro_novedades.aspx.cs" Inherits="Plataforma_Musical.Vistas.Registro_novedades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 1000px">
    <div style="height: 494px">
         <div style="height: 100px">
             <asp:Button ID="btnpublicar" runat="server" Height="26px" style="margin-left: 196px; margin-top: 23px" Text="+Publica una Noticia" Width="485px" OnClick="btnpublicar_Click" />
             <div style="height: 38px; width: 672px; margin-left: 0px; margin-top: 9px">
                 <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="~/Vistas/images/Musical.png" Width="58px" />
             </div>
             </div>
       
         <hr style="#000000: ;" />
    <div id="Contenedor_novedades" class="homepage" runat="server"/>

         </div>
         </div>
</asp:Content>
