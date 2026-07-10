<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionPacientes.aspx.cs" Inherits="Vistas.MENU_ADMIN.GestionPacientes" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Pacientes</title>

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

        .tabla-formulario {
            width: 75%;
            margin: 0 auto;
        }

        .check-grande {
            transform: scale(1.4);
        }

        .auto-style1 {
            --bs-form-select-bg-img: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16'%3e%3cpath fill='none' stroke='%23343a40' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='m2 5 6 6 6-6'/%3e%3c/svg%3e");
            display: block;
            width: 100%;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: var(--bs-body-color);
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-size: 16px 12px;
            border-radius: var(--bs-border-radius);
            transition: none;
            margin-top: 0;
            background-color: var(--bs-body-bg);
            background-image: url('var(--bs-form-select-bg-img),var(--bs-form-select-bg-icon,none)');
            background-repeat: no-repeat;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="encabezado">
            Bienvenido/a:
            <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
        </div>

        <div class="titulo-principal">
            Gestión de Pacientes
        </div>

        <table class="table table-bordered tabla-formulario">

            <tr>
                <td><b>Nombre</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator12"
                        runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="Ingrese Nombre">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtNombre"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>

                <td><b>DNI</b>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1"
                        runat="server"
                        ControlToValidate="DNI"
                        ErrorMessage="Solo Numeros"
                        ValidationExpression="^\d+$">
                    </asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="DNI"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><b>Apellido</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator11"
                        runat="server"
                        ControlToValidate="txtApellido"
                        ErrorMessage="Ingrese Apellido">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtApellido"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>

                <td><b>Sexo</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator15"
                        runat="server"
                        ControlToValidate="ddlSexo"
                        ErrorMessage="Ingrese Sexo">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList
                        ID="ddlSexo"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="--Seleccione--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td><b>Nacionalidad</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator13"
                        runat="server"
                        ControlToValidate="txtNacionalidad"
                        ErrorMessage="Ingrese Nacionalidad">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtNacionalidad"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>

                <td><b>Fecha Nacimiento</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6"
                        runat="server"
                        ControlToValidate="txtFechaNacimiento"
                        ErrorMessage="Ingrese Fecha">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtFechaNacimiento"
                        runat="server"
                        TextMode="Date"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><b>Dirección</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator14"
                        runat="server"
                        ControlToValidate="txtDireccion"
                        ErrorMessage="Ingrese Direccion">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtDireccion"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>

                <td><b>Correo Electrónico</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator7"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Ingrese Correo">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        TextMode="Email"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><b>Provincia</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator9"
                        runat="server"
                        ControlToValidate="ddlProvincia"
                        ErrorMessage="Ingrese Provincia"
                        InitialValue="-1">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList
                        ID="ddlProvincia"
                        runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"
                        CssClass="form-select">
                    </asp:DropDownList>
                </td>

                <td><b>Localidad</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator8"
                        runat="server"
                        ControlToValidate="ddlLocalidad"
                        ErrorMessage="Ingrese Localidad"
                        InitialValue="-1">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList
                        ID="ddlLocalidad"
                        runat="server"
                        CssClass="form-select"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td><b>Teléfono</b>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator10"
                        runat="server"
                        ControlToValidate="txtTelefono"
                        ErrorMessage="Ingrese Telefono">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox
                        ID="txtTelefono"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>
                </td>

                <td></td>
                <td></td>
            </tr>

            <tr>
                <td colspan="4">

                    <div class="d-flex justify-content-between align-items-center mt-3">

                        <div class="d-flex flex-wrap gap-2">

                            <asp:Button
                                ID="btnAgregar"
                                runat="server"
                                Text="Agregar"
                                CssClass="btn btn-success"
                                OnClick="btnAgregar_Click" />

                            <asp:Button
                                ID="btnVerPacientes"
                                runat="server"
                                Text="Ver Pacientes"
                                CssClass="btn btn-primary"
                                CausesValidation="false"
                                OnClick="BtnListado_Click" />

                            <asp:Button
                                ID="btnEliminar"
                                runat="server"
                                Text="Eliminar"
                                CssClass="btn btn-danger"
                                CausesValidation="false"
                                OnClick="btnEliminar_Click" Enabled="False" />

                            <asp:Button
                                ID="btnModificar"
                                runat="server"
                                Text="Modificar"
                                CssClass="btn btn-warning"
                                CausesValidation="false"
                                OnClick="btnModificar_Click" />

                            <asp:Button
                                ID="btnConfirmarEliminar"
                                runat="server"
                                Text="Confirmar"
                                CssClass="btn btn-danger"
                                CausesValidation="false"
                                Visible="False"
                                OnClick="btnConfirmarEliminar_Click" />

                            <asp:Button
                                ID="btnLimpiar"
                                runat="server"
                                Text="Limpiar"
                                CssClass="btn btn-secondary"
                                CausesValidation="false"
                                OnClick="btnLimpiar_Click" />

                        </div>


                        <asp:Button
                            ID="btnMenuPrincipal"
                            runat="server"
                            Text="Menú Principal"
                            CssClass="btn btn-outline-primary"
                            CausesValidation="false"
                            OnClick="btnMenuPrincipal_Click" />

                    </div>

                </td>
            </tr>

        </table>


        <div id="divFiltros" runat="server">
            <%--Englobamos los filtros bajo un div para ocultarlos facilmente.--%>

            <div class="text-center mt-3 mb-3">
                <asp:Label ID="LblMensaje" runat="server"></asp:Label>
            </div>

            <div class="table-responsive mt-4 px-3">
            </div>

            <div class="row justify-content-center align-items-end g-3 mt-4 mb-4">

                <div class="col-md-4">

                    <label class="form-label fw-bold">
                        Buscar
                    </label>

                    <asp:TextBox
                        ID="txtBusqueda"
                        runat="server"
                        CssClass="form-control"
                        placeholder="DNI, nombre o apellido">
                    </asp:TextBox>

                </div>

                <div class="col-md-2">

                    <label class="form-label fw-bold">
                        Sexo
                    </label>

                    <asp:DropDownList
                        ID="ddlFiltroSexo"
                        runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Ambos" Value=""></asp:ListItem>
                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="col-md-3">

                    <label class="form-label fw-bold">
                        Provincia
                    </label>

                    <asp:DropDownList
                        ID="ddlFiltroProvincia"
                        runat="server"
                        CssClass="form-select">
                    </asp:DropDownList>

                </div>

                <div class="col-md-2 d-grid">

                    <asp:Button
                        ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        CssClass="btn btn-primary"
                        CausesValidation="false"
                        OnClick="btnBuscar_Click" />

                </div>

            </div>

            <div class="table-responsive mt-4 px-3">

                <asp:GridView
                    ID="gvPacientes"
                    runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="IdPaciente_PAC"
                    CssClass="table table-striped table-bordered table-sm text-center align-middle"
                    Width="100%"
                    AllowPaging="True"
                    OnPageIndexChanging="gvPacientes_PageIndexChanging"
                    PageSize="8">

                    <Columns>

                        <asp:BoundField DataField="DNI_PAC" HeaderText="DNI" />

                        <asp:BoundField DataField="Nombre_PAC" HeaderText="Nombre" />

                        <asp:BoundField DataField="Apellido_PAC" HeaderText="Apellido" />

                        <asp:BoundField DataField="Sexo_PAC" HeaderText="Sexo" />

                        <asp:BoundField DataField="Nacionalidad_PAC" HeaderText="Nacionalidad" />

                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" />

                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" />

                        <asp:BoundField
                            DataField="FechaNacimiento_PAC"
                            DataFormatString="{0:yyyy-MM-dd}"
                            HeaderText="Fecha de nacimiento" />

                        <asp:BoundField DataField="Direccion_PAC" HeaderText="Dirección" />

                        <asp:BoundField DataField="Email_PAC" HeaderText="Correo electrónico" />

                        <asp:BoundField DataField="Telefono_PAC" HeaderText="Teléfono" />

                        <asp:TemplateField HeaderText="">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />

                            <ItemTemplate>

                                <asp:CheckBox
                                    ID="checkSeleccion"
                                    runat="server"
                                    CssClass="check-grande" />

                            </ItemTemplate>

                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </form>

</body>
</html>
