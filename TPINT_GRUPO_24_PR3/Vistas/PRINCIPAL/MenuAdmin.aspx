<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu Administradores</title>
</head>
<body style="height: 495px">
    <form id="form1" runat="server">
        <div style="font-size:30px; background-color:#C5D3BF; padding:10px; border:1px solid #4a90e2; text-align:center;"> 
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
                    <asp:Button runat="server" Text="Gestion Pacientes" Width="250px" Height="50px" ID="btnGP" OnClick="btnGP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGM" runat="server" Text="Gestion Medicos" Width="250px" Height="50px" OnClick="btnGM_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAT" runat="server" Text="Asignacion de Turnos" Width="250px" Height="50px" OnClick="btnAT_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnInformeEspecialidad" runat="server" Text="Informe Especialidad" Width="250px" Height="50px" OnClick="btnInformeEspecialidad_Click" />
                    <br />
      
        <asp:Button ID="btnInformeMedico" runat="server" Height="52px" Text="Informe Medico" Width="251px" OnClick="btnInformeMedico_Click" />  
                    <br />
                    <asp:Button ID="btnInformeAsistencia" runat="server" Height="52px" OnClick="btnInformeAsistencia_Click" style="margin-top: 0px" Text="Informe Asistencia" Width="252px" />
                </td>
            </tr>
        </table>
      
    </form>
   
    </body>
</html>
