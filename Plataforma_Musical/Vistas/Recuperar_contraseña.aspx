<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Iniciar_Sesion_Maestra.Master" AutoEventWireup="true" CodeBehind="Recuperar_contraseña.aspx.cs" Inherits="Plataforma_Musical.Vistas.Recuperar_contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        
         function SetHiddenVariable() {
             var campo = $('#txtfecha_recuperacion').val();
            
             if (campo === '') {
                
             } else {
                 
                 $("#campo_oculto_fech").val($("#txtfecha_recuperacion").val());
                   var hiddenControl = '<%= campo_oculto_fecha.ClientID %>';
                    document.getElementById(hiddenControl).value=campo;
                    
             }

         }
        
 </script>
    <div style="height: 457px">
        <div style="height: 199px; width: 696px; margin-left: 374px; margin-right: 290px; margin-top: 126px">
            <table style="width: 100%; height: 193px">
                <tr>
                    <td colspan="2"><h1>Recuperar Contraseña:</h1><p> Debe introducir los datos siguientes</p></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    </td>
                    <td>
                        <input id="txtfecha_recuperacion" style="width: 246px; margin-left: 124px" type="text" /></td>
                        <asp:HiddenField ID="campo_oculto_fecha" runat="server" />
                    <script type="text/javascript">

                    var picker = new Pikaday(
                    {
                        field: document.getElementById('txtfecha_recuperacion'),
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
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Correo Electronico"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcorreo" runat="server" style="margin-left: 124px" Width="249px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 37px"></td>
                    <td style="height: 37px">
                        <asp:Button ID="Button1" runat="server" style="margin-left: 144px" Text="Recuperar Contraseña" onmouseover="SetHiddenVariable()" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 35px">
                        <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td style="height: 35px">
                        <asp:Label ID="lblcontraseña" runat="server" Text="####"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
