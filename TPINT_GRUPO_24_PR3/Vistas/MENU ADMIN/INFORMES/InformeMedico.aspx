<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="InformeMedico.aspx.cs" Inherits="Vistas.InformeMedico" %>

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
            margin: 20px 0;
            background-color: #f5f5f5;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <h2>Bienvenido/a:
                <asp:Label ID="lblUsuarioIngresado" runat="server"></asp:Label>
            </h2>
            <h2>Informe de Turnos por Médico</h2>

            <div class="mb-3">
                <asp:Button
                    ID="btnMenuPrincipal"
                    runat="server"
                    Text="Menú Principal"
                    CssClass="btn btn-outline-secondary"
                    CausesValidation="False"
                    OnClick="btnMenuPrincipal_Click" />
            </div>


            <div class="filtros">
                <div class="fila">
                    <span class="etiquet
                    <asp:DropDownList ID="ddlMedicos" runat="server" CssClass="form-select d-inline-block" Width="300px" />
                    <asp:RequiredFieldValidator ID="rqfMedico" runat="server" ControlToValidate="ddlMedicos" ErrorMessage="Seleccione un medico"></asp:RequiredFieldValidator>
                </div>

                <div class="fila">
                    <span class="etiqueta">Fecha desde:</span>
                    <asp:TextBox ID="txtDesde" runat="server" TextMode="Date" CssClass="form-control d-inline-block" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvFechaDesde" runat="server"
                        ControlToValidate="txtDesde" ErrorMessage="Ingrese la fecha desde."
                        CssClass="text-danger" Display="Dynamic" ValidationGroup="Informe" />
                </div>

                <div class="fila">
                    <span class="etiqueta">Fecha hasta:</span>
                    <asp:TextBox ID="txtHasta" runat="server" TextMode="Date" CssClass="form-control d-inline-block" Width="200px" />
                    <asp:RequiredFieldValidator ID="rfvFechaHasta" runat="server"
                        ControlToValidate="txtHasta" ErrorMessage="Ingrese la fecha hasta."
                        CssClass="text-danger" Display="Dynamic" ValidationGroup="Informe" />
                    <asp:CompareValidator ID="cvFechas" runat="server"
                        ControlToValidate="txtHasta" ControlToCompare="txtDesde"
                        Operator="GreaterThanEqual" Type="Date"
                        ErrorMessage="La fecha hasta no puede ser anterior a la fecha desde."
                        CssClass="text-danger" Display="Dynamic" ValidationGroup="Informe" />
                </div>

                <div class="fila">
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar Informe"
                        CssClass="btn btn-primary" OnClick="btnGenerar_Click" ValidationGroup="Informe" />
                </div>
            </div>

            <div id="divResumen" runat="server" class="resumen" visible="false">
                <h3>Resumen</h3>
                <asp:Label ID="lblTotal" runat="server" /><br />
                <asp:Label ID="lblMayor" runat="server" /><br />
                <asp:Label ID="lblMenor" runat="server" />
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
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
