<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:100px;width:100%"> </div>
        <div style="height:500px;width:25%;float:left"> </div>
        <div style="height:50px;width:70%;float:left;font-size:large"> INICIAR SESION </div>
        <div style="height:20px;width:70%;float:left"> Usuario: </div>
        <div style="height:30px;width:70%;float:left"> <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox> </div>
        <div style="height:20px;width:70%;float:left"> Contraseña: </div>
        <div style="height:30px;width:70%;float:left"> <asp:TextBox ID="txtContrasenia" runat="server"></asp:TextBox> </div>
        <div style="height:30px;width:70%;float:left"> <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion"/> </div>
    </form>
</body>
</html>
