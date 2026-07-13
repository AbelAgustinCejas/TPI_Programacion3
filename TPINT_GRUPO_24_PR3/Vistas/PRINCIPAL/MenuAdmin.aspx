<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />

    <title>Menú Administrador</title>
</head>

<body class="bg-light">

    <form id="form1" runat="server">

        <div class="container py-5">

            <div class="card shadow-sm mb-4">

                <div class="card-body text-center">

                    <h2 class="mb-2">Panel de Administración</h2>

                    <h5 class="text-muted">
                        Bienvenido/a:
                        <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>

                    <asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/IMAGENES/logout.jpg" CssClass="logout rounded-circle" OnClick="btnLogout_Click" />

                    </h5>

                </div>

            </div>

            <div class="card shadow-sm">

                <div class="card-header">
                    Opciones disponibles
                </div>

                <div class="card-body">

                    <div class="d-grid gap-3 col-md-6 mx-auto">

                        <asp:Button
                            ID="btnGP"
                            runat="server"
                            Text="Gestión de Pacientes"
                            CssClass="btn btn-primary btn-lg"
                            OnClick="btnGP_Click" />

                        <asp:Button
                            ID="btnGM"
                            runat="server"
                            Text="Gestión de Médicos"
                            CssClass="btn btn-primary btn-lg"
                            OnClick="btnGM_Click" />

                        <asp:Button
                            ID="btnAT"
                            runat="server"
                            Text="Asignación de Turnos"
                            CssClass="btn btn-primary btn-lg"
                            OnClick="btnAT_Click" />

                        <hr />

                        <asp:Button
                            ID="btnInformeEspecialidad"
                            runat="server"
                            Text="Informe por Especialidad"
                            CssClass="btn btn-outline-primary"
                            OnClick="btnInformeEspecialidad_Click" />

                        <asp:Button
                            ID="btnInformeMedico"
                            runat="server"
                            Text="Informe por Médico"
                            CssClass="btn btn-outline-primary"
                            OnClick="btnInformeMedico_Click" />

                        <asp:Button
                            ID="btnInformeAsistencia"
                            runat="server"
                            Text="Informe de Asistencia"
                            CssClass="btn btn-outline-primary"
                            OnClick="btnInformeAsistencia_Click" />

                    </div>

                </div>

            </div>

        </div>

    </form>

</body>
</html>