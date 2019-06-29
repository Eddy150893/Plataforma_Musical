<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Pagina_Maestra_artista.master" AutoEventWireup="true" CodeBehind="Publicar_album.aspx.cs" Inherits="Plataforma_Musical.Vistas.Publicar_album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor_artista" runat="server">
<script type="text/javascript">

        function SetHiddenVariable() {
            var campo = $('#txtfecha_publicacion').val();

            if (campo === '') {

            } else {

                $("#campo_oculto_fecha_publicacion").val($("#txtfecha_publicacion").val());
                var hiddenControl = '<%= campo_oculto_fecha_publicacion.ClientID %>';
                 document.getElementById(hiddenControl).value = campo;

             }

         }

</script>
    <div style="height: 1382px">

        <div style="height: 100px; padding-top:100px;">
        </div>

<!--###############################################################################################################-->
        <div style="height: 682px">
            <hr style="#000000: ;" />
            <table style="width: 100%; height: 367px">
                    <tr>
                        <td style="width: 400px" rowspan="5">&nbsp;</td>
                        <td style="width: 415px">
                            <asp:Label ID="Label1" runat="server" Text="Titulo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttitulo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 415px">
                            <asp:Label ID="Label2" runat="server" Text="Foto de Portada"></asp:Label>
                        </td>
                        <td>&nbsp;<asp:Image ID="Imagen_album" runat="server" Height="95px" Width="168px" ImageUrl="~/Vistas/images/albumes mas populares.jpg" />
                            <asp:FileUpload ID="foto_album" runat="server" hidden="true" />
                            <asp:Button ID="btnsubirportada" runat="server" Text="Button" OnClick="btnsubirportada_Click" hidden="true" />

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 415px">
                            <asp:Label ID="Label3" runat="server" Text="Reseña"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtreseña" runat="server" Height="116px" TextMode="MultiLine" Width="189px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 415px">
                            <asp:Label ID="Label4" runat="server" Text="Fecha de Publicacion"></asp:Label>
                        </td>
                        <td>
                            <input id="txtfecha_publicacion" style="width: 246px; margin-left: 0px" type="text" />
                            <asp:HiddenField ID="campo_oculto_fecha_publicacion" runat="server" />
                        </td>
                        <script type="text/javascript">

                            var picker = new Pikaday(
                            {
                                field: document.getElementById('txtfecha_publicacion'),
                                firstDay: 1,
                                minDate: new Date('1940-01-01'),
                                maxDate: new Date('2020-12-31'),
                                yearRange: [1940, 2020],
                                numberOfMonths: 1,
                                theme: 'dark-theme'
                            });


                        </script>
                    </tr>
                    <tr>
                        <td style="width: 415px">
                            <asp:Label ID="Label5" runat="server" Text="Cancion"></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="agrebar_cancion" runat="server" ImageUrl="~/Vistas/images/agregar_cancion.jpg" />
                            <asp:FileUpload ID="explorador_archivos" runat="server" hidden="true" />
                            <asp:Button ID="btnsubir" runat="server" Text="Button" hidden="true" OnClick="btnsubir_Click" />
                        </td>
                    </tr>
                </table>
            </div>
 <!--###############################################################################################################-->      
    

    <script type="text/javascript">
        $('#<%=Imagen_album.ClientID%>').click(function () {
            $('#<%=foto_album.ClientID%>').click();
        });

        $('#<%=foto_album.ClientID%>').change(
                function () {
                    $('#<%=btnsubirportada.ClientID%>').click();
                }
            );
    </script>
    <script type="text/javascript">
        $('#<%=agrebar_cancion.ClientID%>').click(function () {
            $('#<%=explorador_archivos.ClientID%>').click();
        });

        $('#<%=explorador_archivos.ClientID%>').change(
                function () {
                    $('#<%=btnsubir.ClientID%>').click();
                }
            );
    </script>


    <div style="height: 400px">
        <asp:Table ID="tabla_canciones" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Numero</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Duracion</asp:TableHeaderCell>
                <asp:TableHeaderCell>Acciones</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
<!--###############################################################################################################-->   
<div style="height: 100px">

    <table style="width: 100%">
        <tr>
            <td style="width: 828px">
                <asp:Button ID="btncancelar" runat="server" style="margin-left: 633px" Text="Cancelar" Width="204px" />
            </td>
            <td>
                <asp:Button ID="btnfinalizar" runat="server" style="margin-left: 0px" Text="Finalizar" Width="226px" OnClick="btnfinalizar_Click" onmouseover="SetHiddenVariable()"/>
            </td>
        </tr>
    </table>

</div>
</div>
</asp:Content>
