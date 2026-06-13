<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu Administrador</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size:30px; background-color:#e8f4ff; padding:10px; border:1px solid #4a90e2; text-align:center;"> 
            Bienvenido/a:&nbsp;
            <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
            <br />
        </div>
      
    <p style="font-size:20px; text-decoration: underline; text-align:center;">
        Opciones disponibles</p>
 
    <p>
        &nbsp;</p>
   
        <table style="margin:auto;">
            <tr>
                <td>
                    <asp:Button runat="server" Text="Gestion Pacientes" Width="250px" Height="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Gestion Medicos" Width="250px" Height="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Asignacion turnos" Width="250px" Height="50px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Informes" Width="250px" Height="50px" />
                </td>
            </tr>
        </table>
      
    </form>
   
    </body>
</html>
