<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Editar_noticia.aspx.cs" Inherits="Plataforma_Musical.Vistas.Editar_noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="height: 500px">

        <div style="height: 455px; width: 857px; margin-left: 326px; margin-top: 38px">
            <table style="width: 100%; height: 454px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Titulo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txttitulo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 271px">
                        <asp:Label ID="Label2" runat="server" Text="Contenido"></asp:Label>
                    </td>
                    <td style="height: 271px">
                        <asp:TextBox ID="txtcontenido" runat="server" Height="253px" style="margin-left: 43px" TextMode="MultiLine" Width="661px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Foto Portada"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="Imagen_artista" runat="server" Height="115px" Width="120px" ImageUrl="~/Vistas/images/noticias.jpg" />
                        <asp:FileUpload ID="fuFotoConstancia" runat="server" hidden="true"/>
                        <asp:Button ID="btnsubirconstancia" runat="server" OnClick="Button1_Click" Text="Button" hidden="true"/>
                    </td>
                </tr>
            </table>
        </div>

    </div>
    <div style="height: 300px">
        <div style="width: 229px; height: 28px; margin-left: 582px">
            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="225px" OnClick="btnpublicar_Click" />
        </div>
    </div>
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
