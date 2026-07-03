<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="InformeAsistencia.aspx.cs"
    Inherits="Vistas.InformeAsistencia" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />

    <title>Informe de Asistencia</title>

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
            width: 120px;
        }

        .resumen {
            border: 1px solid #ccc;
            padding: 15px;
            margin-top: 20px;
            margin-bottom: 20px;
            background-color: #f5f5f5;
        }

        .titulo {
            margin-bottom: 20px;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">

        <div class="contenedor">

            <div class="titulo">
                <h2>Informe de Asistencia de Turnos</h2>
            </div>

            <div class="filtros">

                <div class="fila">

                    <span class="etiqueta">Fecha Desde:
                    </span>

                    <asp:TextBox
                        ID="txtDesde"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>

                </div>

                <div class="fila">

                    <span class="etiqueta">Fecha Hasta:
                    </span>

                    <asp:TextBox
                        ID="txtHasta"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>

                </div>

                <div class="fila">

                    <asp:Button
                        ID="btnGenerar"
                        runat="server"
                        Text="Generar Informe"
                        OnClick="btnGenerar_Click" />

                </div>

            </div>

            <div class="resumen">

                <h3>Resumen</h3>

                <asp:Label
                    ID="lblTotal"
                    runat="server">
                </asp:Label>

                <br />

                <asp:Label
                    ID="lblPresentes"
                    runat="server">
                </asp:Label>

                <br />

                <asp:Label
                    ID="lblAusentes"
                    runat="server">
                </asp:Label>

            </div>

            <asp:GridView
                ID="gvAsistencia"
                runat="server"
                Width="100%"
                AutoGenerateColumns="False">

                <Columns>

                    <asp:BoundField
                        DataField="Fecha"
                        HeaderText="Fecha" />

                    <asp:BoundField
                        DataField="Paciente"
                        HeaderText="Paciente" />

                    <asp:BoundField
                        DataField="Medico"
                        HeaderText="Médico" />

                    <asp:BoundField
                        DataField="Estado"
                        HeaderText="Estado" />

                </Columns>

            </asp:GridView>

        </div>

    </form>

</body>
</html>
