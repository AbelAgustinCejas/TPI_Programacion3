<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurnos.aspx.cs" Inherits="Vistas.AsignacionTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignación de Turnos</title>

    <style type="text/css">

        .encabezado {
            font-size: 30px;
            background-color: #E8F4FF;
            padding: 10px;
            border: 1px solid #4A90E2;
            text-align: center;
            margin-bottom: 30px;
        }

        .titulo {
            text-align: center;
            text-decoration: underline;
            margin-bottom: 20px;
        }

        .tabla-formulario {
            margin: 0 auto;
        }

        .tabla-formulario td {
            padding: 8px;
        }

        .contenedor-grid {
            text-align: center;
            margin-top: 15px;
        }

        .panel-resumen {
            border: 1px solid #BFBFBF;
            padding: 15px;
            background-color: #F8F8F8;
        }

        .tabla-resumen {
            width: 100%;
            text-align: left;
        }

        .tabla-resumen td {
            padding: 5px;
        }

        /* CONTENEDOR GENERAL */
        .contenedor-principal {
            display: flex;
            justify-content: center;
            align-items: flex-start;
            gap: 40px;
            margin-top: 20px;

            border: 2px solid #4A90E2;
            border-radius: 8px;
            padding: 20px;
            background-color: #FAFAFA;
        }

        .columna-formulario,
        .columna-resumen {
            flex: 1;
            padding: 10px;
        }

        .columna-resumen {
            border-left: 1px solid #C0C0C0;
        }

        .contenedor-turnos {
            display: flex;
            justify-content: center;
            gap: 60px;
            align-items: flex-start;
        }

    </style>
</head>

<body>

<form id="form1" runat="server">

    <!-- ENCABEZADO -->
    <div class="encabezado">
        Bienvenido/a:
        <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
    </div>

    <!-- TITULO -->
    <h2 class="titulo">Asignación de Turnos</h2>

    <!-- BUSCAR PACIENTE -->
    <table class="tabla-formulario">
        <tr>
            <td>Buscar Paciente por DNI:</td>
            <td>
                <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar Paciente" OnClick="btnBuscarPaciente_Click" />
            </td>
        </tr>
    </table>

    <br />

    <!-- GRID PACIENTE -->
    <div class="contenedor-grid">

        <asp:GridView ID="gvPaciente"
            runat="server"
            AutoGenerateColumns="False"
            Visible="true"
            Width="850px"
            DataKeyNames="IdPaciente_PAC"
            AutoPostBack="true"
            OnSelectedIndexChanged="gvPaciente_SelectedIndexChanged">

            <Columns>
                <asp:CommandField ShowSelectButton="True" />

   <asp:BoundField DataField="DNI_PAC" HeaderText="DNI" />
<asp:BoundField DataField="Nombre_PAC" HeaderText="Nombre" />
<asp:BoundField DataField="Apellido_PAC" HeaderText="Apellido" />
<asp:BoundField DataField="Sexo_PAC" HeaderText="Sexo" />
<asp:BoundField DataField="Nacionalidad_PAC" HeaderText="Nacionalidad" />
<asp:BoundField DataField="FechaNacimiento_PAC" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            </Columns>

        </asp:GridView>

    </div>

    <br />

    <!-- CONTENEDOR PRINCIPAL -->
    <div class="contenedor-principal">

        <!-- IZQUIERDA -->
        <div class="columna-formulario">

            <div class="contenedor-turnos">

                <!-- DDL -->
                <div>
                    <table class="tabla-formulario">

                        <tr>
                            <td>Especialidad:</td>
                            <td>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>Médico:</td>
                            <td>
                                <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                    </table>
                </div>

                <!-- CALENDARIO + HORARIO -->
                <div>
                    <table class="tabla-formulario">

                        <tr>
                            <td colspan="2" style="text-align:center;">
                                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            </td>
                        </tr>

                        <tr>
                            <td>Horario:</td>
                            <td>
                                <asp:DropDownList ID="ddlHorario" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                    </table>
                </div>

            </div>

        </div>

        <!-- DERECHA -->
        <div class="columna-resumen">

            <div class="panel-resumen">

                <h3 style="text-align:center; text-decoration: underline;">
                    Resumen del Turno
                </h3>

                <table class="tabla-resumen">

                    <tr>
                        <td><b>Paciente:</b></td>
                        <td><asp:Label ID="lblPacienteResumen" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><b>DNI:</b></td>
                        <td><asp:Label ID="lblDniResumen" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><b>Especialidad:</b></td>
                        <td><asp:Label ID="lblEspecialidadResumen" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><b>Médico:</b></td>
                        <td><asp:Label ID="lblMedicoResumen" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><b>Fecha:</b></td>
                        <td><asp:Label ID="lblFechaResumen" runat="server" /></td>
                    </tr>
                                          <tr>
      <td><b>Horario:</b></td>
      <td><asp:Label ID="lblHorarioResumen" runat="server" /></td>
  </tr>

                </table>

            </div>

            <br />

            <div style="text-align:center;">
                <asp:Button ID="btnConfirmarTurno"
                    runat="server"
                    Text="Confirmar Turno"
                    Width="180px"
                    Height="40px" OnClick="btnConfirmarTurno_Click" />
            </div>

        </div>

    </div>

    <br />

    <!-- MENSAJE -->
    <div style="text-align:center;">
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="true"></asp:Label>
    </div>

</form>

</body>
</html>