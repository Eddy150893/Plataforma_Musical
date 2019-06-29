<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Nueva_Lista.aspx.cs" Inherits="Plataforma_Musical.Vistas.Nueva_Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:auto" id="Crear">
        <asp:label runat="server" text="Ingrese Nombre Lista"></asp:label>
        <asp:TextBox ID="txtnombrelista" runat="server" Width="256px"></asp:TextBox>
        <asp:Button ID="btncrearlista" runat="server" Text="Crear Lista" Width="196px" OnClick="btncrearlista_Click" />
    </div>
    <div style="height:auto" id="Canciones" runat="server">
         
    </div>
</asp:Content>
