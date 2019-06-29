
<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Iniciar_Sesion_Maestra.Master" AutoEventWireup="true" CodeBehind="Registrar_Usuario.aspx.cs" Inherits="Plataforma_Musical.Vistas.Registrar_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        
         function SetHiddenVariable() {
             var campo = $('#txtfecha').val();
            
             if (campo === '') {
                 
             } else {
                 
                 $("#HiddenField1").val($("#txtfecha").val());
                   var hiddenControl = '<%= HiddenField1.ClientID %>';
            document.getElementById(hiddenControl).value=campo;
                 
             }

         }
        
 </script>
    
    <div style="height: 500px">
    <table style="width: 100%">
        <tr>
            <th colspan="3"><h1>Registrar Usuario</h1></th>
        </tr>
        <tbody>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                
            </td>
            <td>
                <asp:textbox id="txtnombre" runat="server" width="379px"></asp:textbox> 
             
            </td>
        </tr>
        <tr>
            <td style="background-color: #99CD83; height: 34px;"></td>
            <td style="background-color: #99CD83; height: 34px;">
                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td style="background-color: #99CD83; height: 34px;">
                <asp:TextBox ID="txtapellido" runat="server" Width="378px"></asp:TextBox>
             
            </td>
        </tr>
        <tr>
            <td style="height: 26px"></td>
            <td style="height: 26px">
                <asp:Label ID="Label3" runat="server" Text="Fecha Nacimiento"></asp:Label>
                
            </td>
            <td style="height: 26px">
               
             
                <input type="text" id="txtfecha" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <script type="text/javascript">

                    var picker = new Pikaday(
        {
            field: document.getElementById('txtfecha'),
            firstDay: 1,
            minDate: new Date('1940-01-01'),
            maxDate: new Date('2020-12-31'),
            yearRange: [1940, 2020],
            numberOfMonths: 1,
            theme: 'dark-theme'
        });
                   
                   
                </script>
                
       
                  
           
            </td>
        </tr>
        <tr>
            <td style="height: 35px; background-color: #99CD83;"></td>
            <td style="height: 35px; background-color: #99CD83;">
                <asp:Label ID="Label4" runat="server" Text="Correo Electronico"></asp:Label>

            </td>
            <td style="height: 35px; background-color: #99CD83;">
                <asp:TextBox ID="txtcorreo" runat="server" Width="377px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Nombre Usuario"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtusuario" runat="server" Width="222px"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td style="background-color: #99CD83">&nbsp;</td>
            <td style="background-color: #99CD83">
                <asp:Label ID="Label6" runat="server" Text="Contraseña"></asp:Label>
            </td>
            <td style="background-color: #99CD83">
                <asp:TextBox ID="txtcontraseña" runat="server" TextMode="Password" Width="221px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Confirmar Contraseña"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtconfirmar" runat="server" TextMode="Password" Width="222px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <script type="text/javascript">
               
                </script>
                <asp:Button ID="btncrear" runat="server" Text="Crear" Width="127px" OnClick="btncrear_Click" onmouseover="SetHiddenVariable()"/>
            </td>
        </tr>
            </tbody>
    </table>
        </div>
</asp:Content>
