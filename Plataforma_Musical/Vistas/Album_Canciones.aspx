<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra_Busquedas.master" AutoEventWireup="true" CodeBehind="Album_Canciones.aspx.cs" Inherits="Plataforma_Musical.Vistas.Album_Canciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div style="height: 1382px">
       
        <div ID="Contenedor_Album" class="homepage" style="height: 100px; padding-top:100px;" runat="server">
        </div>
    <div style="height: 400px">
        <asp:Table ID="tabla_canciones" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell >Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Play</asp:TableHeaderCell>
                <asp:TableHeaderCell>Me Gusta</asp:TableHeaderCell>
                <asp:TableHeaderCell>Favorito</asp:TableHeaderCell>

            </asp:TableHeaderRow>
        </asp:Table>
        
    </div>
        <div style="height: 764px" id="Contenedor_Comentarios" runat="server">
            <div style="height: 148px">
                <asp:Label ID="lblusuario" runat="server" Text="Comentario"></asp:Label>
                <asp:TextBox ID="txtComentario" runat="server" Height="131px" TextMode="MultiLine" Width="525px"></asp:TextBox>
                <asp:Button ID="txtagregarcomentario" runat="server" OnClick="txtagregarcomentario_Click" Text="Agregar Comentario" />
            </div>
        </div>
        </div>
</asp:Content>
