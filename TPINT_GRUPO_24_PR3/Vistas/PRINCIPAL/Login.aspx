<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.PRINCIPAL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Login</title>

    <style type="text/css">

        body {
            font-family: Arial;
            background-color: #F5F5F5;
        }

        .contenedor {
            width: 500px;
            margin: 100px auto;
            border: 1px groove #C0C0C0;
            background-color: white;
        }

        .titulo {
            background-color: #C5D3BF;
            text-align: center;
            padding: 15px;
            border-bottom: 1px solid #A0A0A0;
        }

        .contenido {
            padding: 30px;
        }

        .fila {
            text-align: center;
            margin-bottom: 20px;
        }

        .etiqueta {
            display: block;
            font-weight: bold;
            font-size: large;
            margin-bottom: 8px;
        }

        .textbox {
            width: 200px;
            height: 25px;
            border: 1px solid #808080;
        }

        .boton {
            width: 150px;
            height: 35px;
            font-size: medium;
            font-weight: bold;
        }

        .validator {
            color: red;
            font-weight: bold;
            margin-left: 5px;
        }

        .resumen {
            text-align: center;
            color: red;
            margin-top: 15px;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="contenedor">

        <div class="titulo">

            <asp:Label ID="lblTitulo"
                runat="server"
                Text="Iniciar Sesión"
                Font-Bold="True"
                Font-Size="XX-Large">
            </asp:Label>

        </div>

        <div class="contenido">

            <div class="fila">

                <asp:Label ID="lblUsuario"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Usuario:">
                </asp:Label>

                <asp:TextBox ID="txtUsuario"
                    runat="server"
                    CssClass="textbox">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvUsuario"
                    runat="server"
                    CssClass="validator"
                    ControlToValidate="txtUsuario">
                    *
                </asp:RequiredFieldValidator>

            </div>

            <div class="fila">

                <asp:Label ID="lblContrasenia"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Contraseña:">
                </asp:Label>

                <asp:TextBox ID="txtContrasenia"
                    runat="server"
                    CssClass="textbox"
                    TextMode="Password">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvContrasenia"
                    runat="server"
                    CssClass="validator"
                    ControlToValidate="txtContrasenia">
                    *
                </asp:RequiredFieldValidator>

            </div>

            <div class="fila">

    <asp:Button ID="btnInSesion"
        runat="server"
        Text="Iniciar Sesión"
        CssClass="boton"
        OnClick="btnInSesion_Click" />

        </div>

        <div class="fila">

            <asp:Label ID="lblMensaje"
                runat="server"
                ForeColor="Red"
                Font-Bold="True">
            </asp:Label>

        </div>

        <div class="resumen">

            <asp:ValidationSummary
                ID="vsResumen"
                runat="server" />

        </div>

        </div>

    </div>

</form>

</body>
</html>