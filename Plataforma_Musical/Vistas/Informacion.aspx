<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra_artista.master" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="Plataforma_Musical.Vistas.Informacion" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="Contenedor_artista">
    <table style="width: 100%">
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nombre del artista"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnombreartista" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Año de Formacion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtañoformacion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Pais"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="slcpais" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdescripcion" runat="server" Height="93px" TextMode="MultiLine" Width="214px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Foto de Portada"></asp:Label>
            </td>
            <td>
                <asp:Image ID="Imagen_artista" class="circulo" runat="server" Height="139px" Width="192px" />
                <asp:FileUpload ID="fuFotoConstancia" runat="server" hidden="true"/>
                <asp:Button ID="btnsubirconstancia" runat="server" Text="Button" hidden="true" OnClick="btnsubirconstancia_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Genero"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="ckbgeneros" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="facebook"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfacebook" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="twitter"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttwitter" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="YouTube"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtyoutube" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Pagina web"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpaginaweb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 400px">&nbsp;</td>
            <td>
                <asp:Button ID="btneliminar" runat="server" Text="Eliminar" Width="199px" OnClick="btneliminar_Click" />
            </td>
            <td>
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="215px" OnClick="btnactualizar_Click" />
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

