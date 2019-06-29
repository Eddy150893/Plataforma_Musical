<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Iniciar_Sesion_Maestra.Master" AutoEventWireup="true" CodeBehind="Iniciar_Sesion.aspx.cs" Inherits="Plataforma_Musical.Vistas.Iniciar_Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 482px">
        <div style="height: 313px; margin-left: 498px; margin-top: 83px; width: 542px;">
            <table style="width: 100%; height: 311px" class="table">
                <tr>
                    <td style="text-align:center;">
                        <h1>Nombre Usuario</h1>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <asp:TextBox ID="txtusuario" runat="server" Height="28px" Width="217px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                    <h1>Contraseña</h1>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <asp:TextBox ID="txtcontraseña" runat="server" Height="28px" TextMode="Password" Width="215px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <asp:Button ID="btningresar" runat="server" Height="31px" Text="Ingresar" Width="214px" OnClick="btningresar_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <asp:HyperLink ID="hpvrecuperacion" runat="server" NavigateUrl="~/Vistas/Recuperar_contraseña.aspx">¿Olvidaste tu Contraseña?</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <asp:Button ID="btncrearcuenta" runat="server" Height="31px" Text="Crear Cuenta" Width="216px" OnClick="btncrearcuenta_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
