<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Agregar_generos.aspx.cs"  Inherits="Plataforma_Musical.Vistas.Agregar_generos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div style="height: 1000px">
    <div style="height: 494px">
         <div style="height: 100px">
             
             <asp:Button ID="btnagregar" runat="server" Height="69px" style="margin-left: 165px; margin-top: 14px" Text="Agregar Genero" Width="539px" OnClick="btnagregar_Click" />
             </div>
       
         <hr style="#000000: ;" />
    <div id="Contenedor_generos" class="homepage" runat="server"/>
        
         </div>
         
         </div>
</asp:Content>
