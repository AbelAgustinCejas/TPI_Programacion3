<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.PRINCIPAL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: #f4f6f9;
        }

        .login-card {
            width: 100%;
            max-width: 430px;
            border: none;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,.15);
        }

        .login-title {
            color: #0d6efd;
            font-weight: bold;
        }

        .btn-login {
            width: 100%;
        }

        .validator {
            color: red;
            font-weight: bold;
            margin-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container vh-100 d-flex justify-content-center align-items-center">
            <div class="card login-card">
                <div class="card-body p-5">
                    <h2 class="text-center login-title mb-4"> Iniciar Sesión </h2>
                    <div class="mb-3">
                        <asp:Label ID="lblUsuario" runat="server" CssClass="form-label fw-semibold" Text="Usuario"> </asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" CssClass="validator" ErrorMessage="Debe ingresar un Usuario!"> * </asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-4">
                        <asp:Label ID="lblContrasenia" runat="server" CssClass="form-label fw-semibold" Text="Contraseña"> </asp:Label>
                        <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"> </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia" CssClass="validator" ErrorMessage="Debe ingresar una Contraseña!"> * </asp:RequiredFieldValidator>
                    </div>
                    <div class="d-grid mb-3">
                        <asp:Button ID="btnInSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary btn-lg btn-login" OnClick="btnInSesion_Click" />
                    </div>
                    <div class="text-center">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"> </asp:Label>
                    </div>
                    <div class="mt-3">
                        <asp:ValidationSummary ID="vsResumen" runat="server" CssClass="alert alert-danger" DisplayMode="List" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
