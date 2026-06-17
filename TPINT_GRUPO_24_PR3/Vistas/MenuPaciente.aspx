<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPacientes.aspx.cs" Inherits="Vistas.MenuPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu Pacientes</title>
    <style type="text/css">
    .label-busqueda {
        text-align: right;
        padding-right: 10px;
        font-size: 18px;
        white-space: nowrap;
    }
        .auto-style3 {
            height: 25px;
            width: 184px;
        }
        .auto-style4 {
            height: 25px;
            width: 121px;
        }
        .auto-style6 {
            width: 320px;
        }
        .auto-style7 {
            width: 320px;
            height: 31px;
        }
        .auto-style8 {
            height: 31px;
        }
        .auto-style10 {
            width: 772px;
            height: 39px;
        }
        .auto-style11 {
            width: 566px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div><div style="font-size: 30px; background-color: #C5D3BF; padding: 10px; border: 1px solid #4a90e2; text-align: center;">
    Bienvenido/a:&nbsp;
<asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
</div>
        </div>
        <p style="font-size: 20px; text-decoration: underline; text-align: center;">
      Opciones disponibles<table style="width: 32%; height: 87px; margin-left: 400px; margin-right: 0px; margin-top: 23px;">
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="BtnSeleccionar" runat="server" OnClick="Button1_Click2" Text="Solicitar Turno" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="BtnMis" runat="server" Text="Cancelar Turno" />
                    </td>
                </tr>
                </table>
  </p>
&nbsp;&nbsp;&nbsp;S<table style="width: 79%;">
            <tr>
                <td class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buscar Paciente por DNI:&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%; margin-left: 242px;">
            <tr>
                <td class="auto-style6">Especialidad:</td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Buscar Medico:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Fecha Disponibles:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table style="width:71%;">
            <tr>
                <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Horarios Disponibles:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                    &nbsp;</td>
            </tr>
        </table>
        <p>
&nbsp;<asp:GridView ID="GridView1" runat="server" Height="183px" style="margin-left: 236px; margin-right: 380px" Width="711px">
            </asp:GridView>
        </p>
    </form>
</body>
</html>
