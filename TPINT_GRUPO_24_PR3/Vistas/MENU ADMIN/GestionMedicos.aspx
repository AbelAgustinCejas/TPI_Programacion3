<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionMedicos.aspx.cs" Inherits="Vistas.MENU_ADMIN.GestionMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión Médicos</title>

    <style type="text/css">
        .encabezado {
            font-size: 30px;
            background-color: #E8F4FF;
            padding: 10px;
            border: 1px solid #4A90E2;
            text-align: center;
            margin-bottom: 30px;
        }

        .titulo-principal {
            background-color: cornflowerblue;
            color: white;
            padding: 15px;
            border-radius: 8px;
            margin-bottom: 20px;
            text-align: center;
            font-size: 32px;
            font-weight: bold;
            box-shadow: 0px 2px 5px rgba(0,0,0,0.2);
        }

        .botonera {
            display: flex;
            justify-content: center;
            gap: 10px;
            flex-wrap: wrap;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="encabezado">
            Bienvenido/a:
            <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>

                    <asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/IMAGENES/logout.jpg" CssClass="logout rounded-circle" OnClick="btnLogout_Click" />

        </div>

        <div class="titulo-principal">
            Gestión de Médicos</div>

        <div class="container mt-4">

            <!-- DATOS DEL MÉDICO -->
            <div class="card shadow-lg border-0">
                <div class="card-header bg-primary text-white">
                    <h4>Datos del médico</h4>
                </div>

                <div class="card-body">
                    <table class="table table-borderless">
                        <tr>
                            <td><strong>DNI</strong>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1"
                                    runat="server"
                                    ControlToValidate="txtDNI"
                                    ErrorMessage="Solo Numeros"
                                    ValidationExpression="^\d+$">
                                </asp:RegularExpressionValidator>
                            &nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator16"
                                    runat="server"
                                    ControlToValidate="txtDNI"
                                    ErrorMessage="Ingrese DNI" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Nombre</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator12"
                                    runat="server"
                                    ControlToValidate="txtNombre"
                                    ErrorMessage="Ingrese Nombre" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Apellido</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator11"
                                    runat="server"
                                    ControlToValidate="txtApellido"
                                    ErrorMessage="Ingrese Apellido" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Sexo</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator15"
                                    runat="server"
                                    ControlToValidate="ddlSexo"
                                    ErrorMessage="Ingrese Sexo" InitialValue="-1" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="-1">-- Seleccione --</asp:ListItem>
                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                    <asp:ListItem Value="O">Otro</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Nacionalidad</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator13"
                                    runat="server"
                                    ControlToValidate="txtNacionalidad"
                                    ErrorMessage="Ingrese Nacionalidad" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Fecha Nacimiento</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator6"
                                    runat="server"
                                    ControlToValidate="txtFechaNacimiento"
                                    ErrorMessage="Ingrese Fecha" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Dirección</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator14"
                                    runat="server"
                                    ControlToValidate="txtDireccion"
                                    ErrorMessage="Ingrese Direccion" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Correo Electrónico</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    ErrorMessage="Ingrese Correo" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Teléfono</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator10"
                                    runat="server"
                                    ControlToValidate="txtTelefono"
                                    ErrorMessage="Ingrese Telefono" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Especialidad</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidatorEspecialidad"
                                    runat="server"
                                    ControlToValidate="ddlEspecialidad"
                                    ErrorMessage="Ingrese Especialidad"
                                    InitialValue="-1" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Provincia</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator9"
                                    runat="server"
                                    ControlToValidate="ddlProvincia"
                                    ErrorMessage="Ingrese Provincia"
                                    InitialValue="-1" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                            </td>

                            <td><strong>Localidad</strong>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator8"
                                    runat="server"
                                    ControlToValidate="ddlLocalidad"
                                    ErrorMessage="Ingrese Localidad"
                                    InitialValue="-1" ValidationGroup="agregar"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-select"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                    <div class="text-center mt-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar médico" CssClass="btn btn-success px-4" OnClick="btnAgregar_Click" ValidationGroup="agregar" />

                        <asp:Button
                            ID="btnMenuPrincipal"
                            runat="server"
                            Text="Menú Principal"
                            CssClass="btn btn-outline-primary"
                            CausesValidation="false"
                            OnClick="btnMenuPrincipal_Click" />

                    </div>

                    <div class="text-center mt-2">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- HORARIOS DE ATENCIÓN -->
            <div class="card shadow mt-4 border-0">
                <div class="card-header bg-info text-white">
                    <h4>Horarios de atención</h4>
                </div>

                <div class="card-body">

                    <table class="table table-borderless">
                        <tr>
                            <td><strong>Médico</strong></td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlMedicoHorario" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicoHorario_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Día</strong></td>
                            <td>
                                <asp:DropDownList ID="ddlDias" runat="server" CssClass="form-select"></asp:DropDownList>
                            </td>

                            <td><strong>Hora inicio</strong></td>
                            <td>
                                <asp:DropDownList ID="ddlHoraInicio" runat="server" CssClass="form-select"></asp:DropDownList>
                            </td>

                            <td><strong>Hora final</strong></td>
                            <td>
                                <asp:DropDownList ID="ddlHoraFinal" runat="server" CssClass="form-select"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                    <div class="botonera mt-3">
                        <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar horario" CssClass="btn btn-info text-white" OnClick="btnAgregarHorario_Click" CausesValidation="false" />

                        <asp:Button ID="btnEliminarHorario" runat="server" Text="Eliminar horario seleccionado" CssClass="btn btn-danger" OnClick="btnEliminarHorario_Click" CausesValidation="false" />
                    </div>

                    <div class="text-center mt-2">
                        <asp:Label ID="lblMensajeHorario" runat="server"></asp:Label>
                    </div>

                    <asp:GridView ID="gvHorarios" DataKeyNames="IdHorario_HM" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered mt-3">
                        <Columns>
                            <asp:BoundField DataField="Dia" HeaderText="Día" />
                            <asp:BoundField DataField="HoraInicio_HM" HeaderText="Desde" />
                            <asp:BoundField DataField="HoraFin_HM" HeaderText="Hasta" />

                            <asp:TemplateField HeaderText="Seleccionar">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkEliminarHorario" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- USUARIO DEL MÉDICO -->
            <div class="card shadow mt-4 border-0" style="left: 0px; top: 0px">
                <div class="card-header bg-secondary text-white">
                    <h4>Usuario del médico</h4>
                </div>

                <div class="card-body">
                    <table class="table table-borderless">
                        <tr>
                            <td><strong>Médico</strong></td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlMedicoUsuario" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicoUsuario_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Nombre de usuario</strong></td>
                            <td>
                                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td><strong>Contraseña</strong></td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td><strong>Confirmar contraseña</strong></td>
                            <td>
                                <asp:TextBox ID="txtConfirmarPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </td>

                            <td colspan="2"></td>
                        </tr>
                    </table>

                    <div class="botonera mt-3">
                        <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear usuario" CssClass="btn btn-secondary" OnClick="btnCrearUsuario_Click" CausesValidation="false" />

                        <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar usuario" CssClass="btn btn-danger" OnClick="btnModificarUsuario_Click" CausesValidation="false" />
                        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar cambios" CssClass="btn btn-secondary" OnClick="btnGuardarCambios_Click" CausesValidation="false" Visible="False" />

                    </div>

                    <div class="text-center mt-2">
                        <asp:Label ID="lblMensajeUsuario" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- ACCIONES GENERALES -->
            <div class="text-center mt-4">
                <div class="botonera">

                    <asp:Button ID="btnVerMedicos" runat="server" Text="Listar médicos" OnClick="btnListar_Click" CssClass="btn btn-success" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar médico" CssClass="btn btn-warning" OnClick="btnModificar_Click" />

                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar médico" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Enabled="False" />

                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar eliminación" CssClass="btn btn-danger" CausesValidation="false" Visible="False" OnClick="btnConfirmarEliminar_Click" />

                </div>
            </div>

            <!-- MÉDICOS REGISTRADOS -->
            <div class="card shadow mt-4 border-0">
                <div class="card-header bg-dark text-white">
                    <h2>Médicos registrados</h2>
                </div>

                <div class="card-body">
                    <asp:GridView ID="gvMedicos" runat="server" AutoGenerateColumns="False" DataKeyNames="Legajo_MED" CssClass="table table-striped table-hover table-bordered" AllowPaging="True" OnPageIndexChanging="gvMedicos_PageIndexChanging" PageSize="4">
                        <Columns>
                            <asp:BoundField DataField="Legajo_MED" HeaderText="Legajo" />
                            <asp:BoundField DataField="DNI_MED" HeaderText="DNI" />
                            <asp:BoundField DataField="Nombre_MED" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido_MED" HeaderText="Apellido" />
                            <asp:BoundField DataField="Descripcion_ESP" HeaderText="Especialidad" />
                            <asp:BoundField DataField="Nombre_PRO" HeaderText="Provincia" />
                            <asp:BoundField DataField="Nombre_LOC" HeaderText="Localidad" />
                            <asp:BoundField DataField="Direccion_MED" HeaderText="Dirección" />
                            <asp:BoundField DataField="Email_MED" HeaderText="Email" />
                            <asp:BoundField DataField="Telefono_MED" HeaderText="Teléfono" />

                            <asp:TemplateField HeaderText="Seleccionar">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkSeleccion" runat="server" CssClass="check-grande" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
