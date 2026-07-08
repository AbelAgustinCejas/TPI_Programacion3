<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="InformeEspecialidad.aspx.cs" Inherits="Vistas.InformeEspecialidad" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <title>Informe por Especialidad</title>

    <style>

        body {
            font-family: Arial;
            margin: 30px;
        }

        .contenedor {
            width: 900px;
            margin: auto;
        }

        .filtros {
            border: 1px solid #ccc;
            padding: 20px;
            margin-bottom: 20px;
        }

        .fila {
            margin-bottom: 15px;
        }

        .etiqueta {
            display: inline-block;
            width: 150px;
        }

        .resumen {
            border: 1px solid #ccc;
            padding: 15px;
            margin-top: 20px;
            margin-bottom: 20px;
            background-color: #f5f5f5;
        }

    </style>

</head>
<body>

<form id="form1" runat="server">

<div class="contenedor">

    <h2>Informe de Turnos por Especialidad</h2>

    <div class="filtros">

        <div class="fila">

            <span class="etiqueta">
                Especialidad:
            </span>

            <asp:DropDownList
                ID="ddlEspecialidad"
                runat="server">

                <asp:ListItem>Todas</asp:ListItem>
                <asp:ListItem>Cardiología</asp:ListItem>
                <asp:ListItem>Pediatría</asp:ListItem>
                <asp:ListItem>Traumatología</asp:ListItem>
                <asp:ListItem>Dermatología</asp:ListItem>

            </asp:DropDownList>

        </div>

        <div class="fila">

            <asp:Button
                ID="btnGenerar"
                runat="server"
                Text="Generar Informe"
                OnClick="btnGenerar_Click" />

        </div>

    </div>

    <div id="divResumen" runat="server" class="resumen" visible="false">

        <h3>Resumen</h3>

        <asp:Label ID="lblTotal" runat="server"></asp:Label>

        <br />

        <asp:Label ID="lblMayor" runat="server"></asp:Label>

        <br />

        <asp:Label ID="lblMenor" runat="server"></asp:Label>

    </div>

    <asp:GridView
    ID="gvInforme"
    runat="server"
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px" AllowPaging="True" OnPageIndexChanging="gvInforme_PageIndexChanging" PageSize="4">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

    <Columns>

        <asp:BoundField
            DataField="Especialidad"
            HeaderText="Especialidad" />

        <asp:BoundField
            DataField="Cantidad"
            HeaderText="Cantidad de Turnos" />

    </Columns>

        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

</asp:GridView>

</div>

</form>

</body>
</html>