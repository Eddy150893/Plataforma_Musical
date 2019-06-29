<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Artistas_eliminados.aspx.cs" Inherits="Plataforma_Musical.Vistas.Artistas_eliminados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 2000px">
        <asp:Table ID="tabla_artista_eliminados" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Numero</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Pais</asp:TableHeaderCell>
                 <asp:TableHeaderCell>Fecha eliminacion</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
