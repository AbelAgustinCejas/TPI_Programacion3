<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionTurnos.aspx.cs" Inherits="Vistas.AsignacionTurnos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Asignación de Turnos</title>

    <style>
        body {
            background-color: #f5f7fa;
        }

        .encabezado {
            font-size: 28px;
            background-color: #E8F4FF;
            padding: 12px;
            border: 1px solid #4A90E2;
            text-align: center;
            margin-bottom: 30px;
        }

        .titulo {
            text-align: center;
            text-decoration: underline;
            margin-bottom: 25px;
        }

        .contenedor {
            width: 90%;
            margin: 0 auto;
        }

        .card {
            margin-bottom: 25px;
        }

        .card-header {
            font-weight: bold;
            background-color: #5D7B9D;
            color: white;
        }

        .tabla-formulario td {
            padding: 8px;
        }

        .contenedor-grid {
            overflow-x: auto;
        }

        .bloque-turno {
            display: flex;
            gap: 30px;
            align-items: stretch;
        }

        .columna-formulario,
        .columna-resumen {
            flex: 1;
        }

        .panel-resumen {
            height: 100%;
            border: 1px solid #BFBFBF;
            padding: 20px;
            background-color: #F8F8F8;
            border-radius: 6px;
        }

        .tabla-resumen {
            width: 100%;
        }

        .tabla-resumen td {
            padding: 8px;
            vertical-align: top;
        }

        .botones-turno {
            display: flex;
            justify-content: space-between;
            align-items: center;
            gap: 15px;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <div class="encabezado">
        Bienvenido/a:
        <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
    </div>

    <div class="contenedor">

        <h2 class="titulo">Asignación de Turnos</h2>

        <!-- BUSCAR PACIENTE -->
        <div class="card">
            <div class="card-header">
                Buscar Paciente
            </div>

            <div class="card-body">
                <div class="row align-items-end">
                    <div class="col-md-4">
                        <label class="form-label">DNI del paciente</label>
                        <asp:TextBox
                            ID="txtPacienteDNI"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            placeholder="Ej: 40111222"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <asp:Button
                            ID="btnBuscarPaciente"
                            runat="server"
                            Text="Buscar Paciente"
                            CssClass="btn btn-primary"
                            OnClick="btnBuscarPaciente_Click" />
                    &nbsp;<asp:Button
                            ID="btnLimpiar"
                            runat="server"
                            Text="Limpiar"
                            CssClass="btn btn-primary"
                            OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- GRID PACIENTE -->
        <div class="card">
            <div class="card-header">
                Pacientes encontrados
            </div>

            <div class="card-body contenedor-grid">
                <asp:GridView ID="gvPaciente"
                    runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="IdPaciente_PAC"
                    OnSelectedIndexChanged="gvPaciente_SelectedIndexChanged"
                    PageSize="5"
                    AllowPaging="True"
                    Width="100%"
                    CssClass="table table-striped table-hover text-center"
                    GridLines="None">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />

                        <asp:BoundField DataField="DNI_PAC" HeaderText="DNI" />
                        <asp:BoundField DataField="Nombre_PAC" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido_PAC" HeaderText="Apellido" />
                        <asp:BoundField DataField="Sexo_PAC" HeaderText="Sexo" />
                        <asp:BoundField DataField="Nacionalidad_PAC" HeaderText="Nacionalidad" />
                        <asp:BoundField DataField="FechaNacimiento_PAC" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    </Columns>

                    <HeaderStyle CssClass="table-primary" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
        </div>

        <!-- BLOQUE CENTRAL: DATOS DEL TURNO + RESUMEN -->
        <div class="card">
            <div class="card-header">
                Nuevo Turno
            </div>

            <div class="card-body">

                <div class="bloque-turno">

                    <!-- IZQUIERDA -->
                    <div class="columna-formulario">

                        <table class="tabla-formulario">

                            <tr>
                                <td>Especialidad:</td>
                                <td>
                                    <asp:DropDownList
                                        ID="ddlEspecialidad"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>Médico:</td>
                                <td>
                                    <asp:DropDownList
                                        ID="ddlMedico"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" style="text-align: center; padding-top: 20px;">
                                    <asp:Calendar
                                        ID="Calendar1"
                                        runat="server"
                                        OnSelectionChanged="Calendar1_SelectionChanged">
                                    </asp:Calendar>
                                </td>
                            </tr>

                            <tr>
                                <td>Horario:</td>
                                <td>
                                    <asp:DropDownList
                                        ID="ddlHorario"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlHorario_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                        </table>

                    </div>

                    <!-- DERECHA -->
                    <div class="columna-resumen">

                        <div class="panel-resumen">

                            <h4 class="text-center text-decoration-underline mb-4">
                                Resumen del Turno
                            </h4>

                            <table class="tabla-resumen">

                                <tr>
                                    <td><b>Paciente:</b></td>
                                    <td><asp:Label ID="lblPacienteResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                                <tr>
                                    <td><b>DNI:</b></td>
                                    <td><asp:Label ID="lblDniResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                                <tr>
                                    <td><b>Especialidad:</b></td>
                                    <td><asp:Label ID="lblEspecialidadResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                                <tr>
                                    <td><b>Médico:</b></td>
                                    <td><asp:Label ID="lblMedicoResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                                <tr>
                                    <td><b>Fecha:</b></td>
                                    <td><asp:Label ID="lblFechaResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                                <tr>
                                    <td><b>Horario:</b></td>
                                    <td><asp:Label ID="lblHorarioResumen" runat="server" Text="Pendiente" /></td>
                                </tr>

                            </table>

                            <div class="text-center mt-4">
                                <asp:Button
                                    ID="btnConfirmarTurno"
                                    runat="server"
                                    Text="Confirmar Turno"
                                    CssClass="btn btn-success btn-lg"
                                    Width="200px"
                                    OnClick="btnConfirmar_Click" />
                            </div>

                        </div>

                    </div>

                </div>

            </div>
        </div>

        <!-- MENSAJE -->
        <div class="text-center mt-3 mb-4">
            <asp:Label
                ID="lblMensaje"
                runat="server"
                CssClass="fw-bold text-success">
            </asp:Label>
        </div>

        <!-- ADMINISTRAR TURNOS EXISTENTES -->
        <div class="card">
            <div class="card-header">
                Administrar Turnos Existentes
            </div>

            <div class="card-body">

                <div class="botones-turno mb-3">

                    <div class="d-flex gap-2 align-items-end">

                        <div>
                            <label class="form-label">Buscar turno por DNI</label>

                            <div class="d-flex align-items-center gap-2">

                                <asp:TextBox
                                    ID="txtTurnoDNI"
                                    runat="server"
                                    CssClass="form-control"
                                    Width="240px"
                                    TextMode="Number"
                                    placeholder="Ej: 40111222"></asp:TextBox>

                            </div>
                        </div>

                        <asp:Button
                            ID="btnBuscarTurno"
                            runat="server"
                            OnClick="btnBuscarTurno_Click"
                            Text="Buscar Turno"
                            CssClass="btn btn-primary" />

                    </div>

                    <asp:Button
                        ID="btnEliminarTurno"
                        runat="server"
                        OnClick="btnEliminarTurno_Click"
                        Text="Eliminar Turno"
                        CssClass="btn btn-danger"
                        Enabled="false" />
                </div>

                <div class="contenedor-grid">
                    <asp:GridView ID="gvTurnos"
                        runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdTurno_TUR"
                        OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged"
                        OnPageIndexChanging="gvTurnos_PageIndexChanging"
                        PageSize="5"
                        AllowPaging="True"
                        Width="100%"
                        CssClass="table table-striped table-hover text-center"
                        GridLines="None">

                        <Columns>

                            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />

                            <asp:BoundField
                                DataField="Fecha_TUR"
                                HeaderText="Fecha"
                                DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:BoundField
                                DataField="Hora_TUR"
                                HeaderText="Hora" />

                            <asp:BoundField
                                DataField="Paciente"
                                HeaderText="Paciente" />

                            <asp:BoundField
                                DataField="Especialidad"
                                HeaderText="Especialidad" />

                            <asp:BoundField
                                DataField="Medico"
                                HeaderText="Médico" />

                        </Columns>

                        <HeaderStyle CssClass="table-primary" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle HorizontalAlign="Center" />

                    </asp:GridView>
                </div>

            </div>
        </div>

    </div>

</form>
</body>
</html>