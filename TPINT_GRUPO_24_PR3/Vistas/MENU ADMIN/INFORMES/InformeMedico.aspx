<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="InformeMedico.aspx.cs" Inherits="Vistas.InformeMedico" %>

<!DOCTYPE html>

<html>
<head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />


    <title>Informe por Medico</title>

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

    <h2>Informe de Turnos por Medico</h2>

    <div class="filtros">

            <div class="fila">

                <span class="etiqueta">
                    Médico:
                </span>

                <asp:DropDownList
                    ID="ddlMedicos"
                    runat="server">
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

    <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px" 
                  AllowPaging="True" OnPageIndexChanging="gvInforme_PageIndexChanging" PageSize="8">

        <Columns>

            <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Turnos" HeaderText="Cantidad de Turnos" />

        </Columns>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

    </asp:GridView>

</div>

</form>

</body>
</html>