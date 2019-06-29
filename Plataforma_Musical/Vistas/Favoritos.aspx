<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Plataforma_Musical.Vistas.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 1482px">
       
        <div ID="Albumes_Favoritos" class="homepage" style="height: 700px;" runat="server">
        </div>
    <div style="height: 764px">
        <asp:Table ID="tabla_canciones" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell >Numero</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Duracion</asp:TableHeaderCell>
                

            </asp:TableHeaderRow>
        </asp:Table>
        
    </div>
        </div>
</asp:Content>
