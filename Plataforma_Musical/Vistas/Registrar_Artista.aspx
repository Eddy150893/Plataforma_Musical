<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Registrar_Artista.aspx.cs" Inherits="Plataforma_Musical.Vistas.Registrar_Artista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="height: 1000px">
        <table style="width: 100%">
            <tr>
                <th colspan="2">Registrar Artista</th>
            </tr>
            <tr>
                <td style="height: 26px">
                    <asp:label id="Label1" runat="server" text="Nombre Artista"></asp:label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtnombreartista" runat="server" Width="281px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #99CD83">
                    <asp:Label ID="Label2" runat="server" Text="Año Formacion"></asp:Label>
                </td>
                <td style="background-color: #99CD83">
                    <asp:TextBox ID="txtañoformacion" runat="server" Width="278px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Pais"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="selectpaises" runat="server"></asp:DropDownList>
                    </td>
               
            </tr>
            <tr>
                <td style="background-color: #99CD83">
                    <asp:Label ID="Label4" runat="server" Text="Descripcion del Artista"></asp:Label>
                </td>
                <td style="background-color: #99CD83">
                    <asp:TextBox ID="txtdescripcion" runat="server" Height="83px" TextMode="MultiLine" Width="288px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Genero Musical"></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList ID="ckbgeneros" runat="server" Width="327px">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #99CD83">
                    <asp:Label ID="Label6" runat="server" Text="Foto Portada"></asp:Label>
                </td>
                <td style="background-color: #99CD83">
                    

                    
                                <asp:Image ID="Imagen_artista" class="circulo" runat="server" BorderStyle="Dashed" BorderWidth="3px" Height="138px" ImageUrl="~/Vistas/images/artistas.jpg" Width="225px" />
                                <asp:FileUpload ID="fuFotoConstancia" runat="server" hidden="true" />
                                <asp:Button ID="btnsubirconstancia" runat="server" Text="Button" Width="169px" hidden="true" OnClick="btnsubirconstancia_Click" />
                       
                    

                </td>
            </tr>
            <tr>
                <td colspan="2"><h1>Redes Sociales</h1></td>
            </tr>
            <tr>
                <td style="background-color: #99CD83">
                    <asp:Label ID="Label7" runat="server" Text="Facebook"></asp:Label>
                </td>
                <td style="background-color: #99CD83">
                    <asp:TextBox ID="txtfacebook" runat="server" Width="286px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Twitter"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txttuitter" runat="server" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #99CD83">
                    <asp:Label ID="Label9" runat="server" Text="YouTube"></asp:Label>
                </td>
                <td style="background-color: #99CD83">
                    <asp:TextBox ID="txtyoutube" runat="server" Width="281px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Pagina Web"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpaginaweb" runat="server" Width="278px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btncrearartista" runat="server" Text="Crear Artista" OnClick="btncrearartista_Click" style="height: 22px" />
                </td>
            </tr>
        </table>
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
