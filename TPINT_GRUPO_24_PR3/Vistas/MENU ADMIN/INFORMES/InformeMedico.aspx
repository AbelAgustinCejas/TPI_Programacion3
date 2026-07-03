<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="InformeMedico.aspx.cs"
    Inherits="Vistas.InformeMedico" %>

<!DOCTYPE html>

<html>
<head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Informe por Médico</title>

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

                <h2>Informe de Turnos por Médico</h2>

                <div class="filtros">

                    <div class="fila">

                        <asp:Label ID="lblMedico" runat="server" Text="Medico: "></asp:Label>

                        <asp:DropDownList ID="ddlMedico" runat="server">

                            <asp:ListItem>Todos</asp:ListItem>
                            <asp:ListItem>Ana Gómez</asp:ListItem>
                            <asp:ListItem>Carlos Díaz</asp:ListItem>
                            <asp:ListItem>Juan García</asp:ListItem>

                        </asp:DropDownList>

                    </div>

                    <div class="fila"> <asp:Button ID="btnGenerar" runat="server" Text="Generar Informe" OnClick="btnGenerar_Click" /> </div>

                </div>

                <div class="resumen"> <h3>Resumen</h3>

                    <asp:Label ID="lblTotal" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblPromedio" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblMayor" runat="server"></asp:Label>

                    <br />

                    <asp:Label ID="lblMenor" runat="server"></asp:Label> </div>

                <asp:GridView ID="gvMedicos" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField
                            DataField="Medico"
                            HeaderText="Médico" />

                        <asp:BoundField
                            DataField="Especialidad"
                            HeaderText="Especialidad" />

                        <asp:BoundField
                            DataField="Turnos"
                            HeaderText="Cantidad de Turnos" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </body>
</html>