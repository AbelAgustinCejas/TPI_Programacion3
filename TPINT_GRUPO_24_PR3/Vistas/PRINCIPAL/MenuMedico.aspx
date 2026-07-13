<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Vistas.MenuMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Menú Médico</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f8f9fa;
        }

        .logout {
            width: 35px;
            height: 35px;
            cursor: pointer;
        }

        .grid th {
            background-color: #0d6efd;
            color: white;
            text-align: center;
            vertical-align: middle;
        }

        .grid td {
            text-align: center;
            vertical-align: middle;
        }

        .grid img {
            width: 32px;
            height: 32px;
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark bg-primary shadow">

            <div class="container-fluid">

                <span class="navbar-brand fw-bold fs-3">Menú Médico
                </span>

                <div class="d-flex align-items-center">

                    <asp:Label ID="lblUsuario" runat="server" CssClass="text-white fw-semibold me-3"> </asp:Label>

                    <asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/IMAGENES/logout.jpg" CssClass="logout rounded-circle" OnClick="btnLogout_Click" />

                </div>

            </div>

        </nav>

        <div class="container mt-4">


            <div class="card shadow-sm mb-4">

                <div class="card-header bg-primary text-white fw-bold">Buscar Turnos </div>

                <div class="card-body">

                    <div class="row g-3 align-items-end">

                        <div class="col-md-4">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"> </asp:TextBox>
                        </div>

                        <div class="col-auto">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" ValidationGroup="Buscar" />
                            <asp:RequiredFieldValidator ID="rfvBuscar" runat="server" ControlToValidate="txtBuscar" CssClass="validator" ErrorMessage="Ingrese texto a buscar" ForeColor="Red" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-auto">
                            <asp:Button ID="btnPendientes" runat="server" Text="Pendientes" CssClass="btn btn-warning" OnClick="btnPendientes_Click" />
                        </div>

                        <div class="col-auto">
                            <asp:Button ID="btnHistorial" runat="server" Text="Historial" CssClass="btn btn-secondary" OnClick="btnHistorial_Click" />
                        </div>

                    </div>

                </div>

            </div>

        <div class="mt-3 justify-content-center align-items-center">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" DisplayMode="List" ForeColor="Red" ValidationGroup="Buscar" />
        </div>

            <div class="card shadow-sm">

                <div class="card-header bg-primary text-white fw-bold">
                    Turnos
                </div>

                <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered grid"
                            DataKeyNames="IdTurno_TUR" AllowPaging="True" PageSize="8" OnRowCommand="gvTurnos_RowCommand" OnPageIndexChanging="gvTurnos_PageIndexChanging">

                            <Columns>

                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d/M/yyyy}" />
                                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                <asp:BoundField DataField="Asistencia" HeaderText="Asistencia" />

                                <asp:TemplateField HeaderText="Presente">

                                    <ItemTemplate>

                                        <asp:ImageButton ID="btnPresente" runat="server" ImageUrl="~/IMAGENES/presente2.jpg" CommandName="Presente" CommandArgument='<%# Container.DataItemIndex %>' />

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ausente">

                                    <ItemTemplate>

                                        <asp:ImageButton ID="btnAusente" runat="server" ImageUrl="~/IMAGENES/ausente2.jpg" CommandName="Ausente" CommandArgument='<%# Container.DataItemIndex %>' />

                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div class="text-center mt-3">

                        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"> </asp:Label>

                    </div>

                </div>

            </div>

        </div>


    </form>

</body>
</html>
