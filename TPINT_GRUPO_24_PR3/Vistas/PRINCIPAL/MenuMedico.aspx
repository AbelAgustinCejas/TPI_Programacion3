<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Vistas.MenuMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menu Medicos</title>

    <style type="text/css">
        .label-busqueda {
            text-align: right;
            padding-right: 10px;
            font-size: 18px;
            white-space: nowrap;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">

        <!-- HEADER -->
        <div style="font-size: 30px; background-color: #C5D3BF; padding: 10px; border: 1px solid #4a90e2; text-align: center;">
            Bienvenido/a:&nbsp;
        <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
            <br />
        </div>

        <p style="font-size: 20px; text-decoration: underline; text-align: center;">
            Opciones disponibles
        </p>

        <table style="margin: auto; width: 520px; border-collapse: collapse;">

            <!-- BOTONES -->
            <tr>
                <td style="text-align: center; padding-bottom: 15px;">
                    <asp:Button
                        ID="btnTA"
                        runat="server"
                        Text="Turnos Asignados"
                        Width="250px"
                        Height="50px" />

                    <asp:Button
                        ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        Width="250px"
                        Height="50px" />
                </td>
            </tr>

            <!-- FILTROS -->
            <tr>
                <td style="text-align: center; padding-bottom: 15px;">

                    <span style="margin-right: 5px;">Sexo:</span>
                    <asp:DropDownList ID="ddlSexo" runat="server" >
                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                    </asp:DropDownList>

                    &nbsp;&nbsp;&nbsp;

                    <span style="margin-right: 5px;">Provincia:</span>
                    <asp:DropDownList ID="ddlProvincia" runat="server" >
                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                    </asp:DropDownList>

                    &nbsp;&nbsp;&nbsp;

                    <span style="margin-right: 5px;">Localidad:</span>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" >
                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                    </asp:DropDownList>

                    &nbsp;&nbsp;&nbsp;

                    <br />

                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" Width="100%" />

                </td>
            </tr>

            <!-- BUSQUEDA -->
            <tr>
                <td style="text-align: center; padding-bottom: 15px;">

                    <span style="font-size: 18px; margin-right: 10px;">Buscar por nombre:
                    </span>

                    <asp:TextBox
                        ID="txtBusqueda"
                        runat="server"
                        Width="300px" />

                </td>
            </tr>

            <!-- GRID -->
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" Width="100%"></asp:GridView>
                </td>
            </tr>

        </table>

    </form>

</body>
</html>
