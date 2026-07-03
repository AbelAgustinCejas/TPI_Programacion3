<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs"
Inherits="Vistas.PRINCIPAL.SUBMENUS_ADMIN.ModificarPaciente" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Modificar Paciente</title>

    <!-- Bootstrap (si no lo tenés global) -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        .grid-container {
            max-width: 1200px;
            margin: 0 auto;
        }

        .grid-small {
            font-size: 13px;
        }

        .grid-small th,
        .grid-small td {
            padding: 6px !important
            vertical-align: middle;
        }

        .table-wrapper {
            overflow-x: auto;
            max-height: 250px;
        }

        .form-box {
            max-width: 1200px;
            margin: 0 auto;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

<div class="container mt-3">

    <h2 class="text-center mb-3">MODIFICACIÓN DE PACIENTES</h2>

    <!-- 🔥 BUSQUEDA -->
    <div class="form-box mb-3">

    <div class="row align-items-center justify-content-center">

        <div class="col-auto">
            <b>DNI:</b>
        </div>

        <div class="col-auto">
            <asp:TextBox ID="txtBuscarDNI" runat="server" CssClass="form-control" />
        </div>

        <div class="col-auto">
            <asp:Button ID="btnBuscar" runat="server"
                Text="Buscar"
                CssClass="btn btn-primary"
                OnClick="btnBuscar_Click" Height="33px" Width="83px" />
        </div>

    </div>

</div>

    <!-- 🔥 GRID -->
    <div class="grid-container table-wrapper mb-4">

        <asp:GridView ID="gvPaciente"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdPaciente_PAC"
            CssClass="table table-striped table-bordered table-sm grid-small"
            Visible="False">

            <Columns>

                <asp:BoundField DataField="DNI_PAC" HeaderText="DNI" />
                <asp:BoundField DataField="Nombre_PAC" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido_PAC" HeaderText="Apellido" />
                <asp:BoundField DataField="Sexo_PAC" HeaderText="Sexo" />
                <asp:BoundField DataField="Nacionalidad_PAC" HeaderText="Nacionalidad" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:BoundField DataField="Provincia" HeaderText="Provincia" />

                <asp:BoundField DataField="FechaNacimiento_PAC"
                    HeaderText="Nacimiento"
                    DataFormatString="{0:yyyy-MM-dd}" />

                <asp:BoundField DataField="Direccion_PAC" HeaderText="Dirección" />
                <asp:BoundField DataField="Email_PAC" HeaderText="Email" />
                <asp:BoundField DataField="Telefono_PAC" HeaderText="Teléfono" />

                <asp:TemplateField HeaderText="Sel">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkSeleccion" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

    <!-- 🔥 FORMULARIO -->
    <div class="form-box">

        <table class="table table-borderless">

            <tr>
                <td><b>Nombre</b></td>
                <td><asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /></td>

                <td><b>Apellido</b></td>
                <td><asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" /></td>
            </tr>

            <tr>
                <td><b>Sexo</b></td>
                <td>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccionar" Value="" />
                        <asp:ListItem Text="Masculino" Value="M" />
                        <asp:ListItem Text="Femenino" Value="F" />
                    </asp:DropDownList>
                </td>

                <td><b>Nacionalidad</b></td>
                <td>
                    <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" />
                </td>
            </tr>

            <tr>
                <td><b>Fecha Nac.</b></td>
                <td>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server"
                        TextMode="Date" CssClass="form-control" />
                </td>

                <td><b>Dirección</b></td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                </td>
            </tr>

            <tr>
                <td><b>Email</b></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"
                        TextMode="Email" CssClass="form-control" />
                </td>

                <td><b>Teléfono</b></td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </td>
            </tr>

            <tr>
                <td><b>Provincia</b></td>
                <td>
                    <asp:DropDownList ID="ddlProvincia" runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"
                        CssClass="form-select" />
                </td>

                <td><b>Localidad</b></td>
                <td>
                    <asp:DropDownList ID="ddlLocalidad" runat="server"
                        CssClass="form-select" AutoPostBack="True" />
                </td>
            </tr>

        </table>

        <!-- 🔥 BOTONES -->
        <div class="d-flex gap-2 mt-3">

            <asp:Button ID="btnGuardar" runat="server"
                Text="Guardar cambios"
                CssClass="btn btn-success"
                OnClick="btnGuardar_Click" />

            <asp:Button ID="btnLimpiar" runat="server"
                Text="Cancelar"
                CssClass="btn btn-secondary"
                CausesValidation="false"
                OnClick="btnLimpiar_Click" />

        </div>

        <br />

        <asp:Label ID="LblMensaje" runat="server" CssClass="text-danger" />

    </div>

</div>

</form>
</body>
</html>
