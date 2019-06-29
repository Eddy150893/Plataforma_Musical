<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Consulta_usuarios.aspx.cs" Inherits="Plataforma_Musical.Vistas.Consulta_usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 2000px">
       
          <asp:Table ID="tabla_usuario" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Numero</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Apellido</asp:TableHeaderCell>
                <asp:TableHeaderCell>Usuario</asp:TableHeaderCell>
                <asp:TableHeaderCell>Fecha Creacion</asp:TableHeaderCell>
                <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
                 <asp:TableHeaderCell>Acciones</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
       
    </div>
    
</asp:Content>
