<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Publicar_genero.aspx.cs" Inherits="Plataforma_Musical.Vistas.Publicar_genero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nombre Genero"></asp:Label>
                <asp:TextBox ID="txtnombregenero" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Image ID="Imagen_artista" runat="server" Height="149px" ImageUrl="~/Vistas/images/generos.jpg" Width="135px" />
                <asp:FileUpload ID="fuFotoConstancia" runat="server" hidden="true" />
                <asp:Button ID="btnsubirconstancia" runat="server" Text="Button" hidden="true" OnClick="Button1_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnpublicar" runat="server" Text="Publicar" OnClick="btnpublicar_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $('#<%=Imagen_artista.ClientID%>').click(function () {
            $('#<%=fuFotoConstancia.ClientID%>').click();
        });

        $('#<%=fuFotoConstancia.ClientID%>').change(
                function () {
                    $('#<%=btnsubirconstancia.ClientID%>').click();
                }
            );
    </script>
</asp:Content>
