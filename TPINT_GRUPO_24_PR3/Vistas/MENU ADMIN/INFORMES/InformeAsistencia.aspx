<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="InformeAsistencia.aspx.cs"
    Inherits="Vistas.InformeAsistencia" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Informe de Asistencia</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">

    <form id="form1" runat="server">

        <div class="container py-4">

            <h2 class="mb-4">Informe de Asistencia de Turnos</h2>

            <div class="mb-3">
                <asp:Button
                    ID="btnMenuPrincipal"
                    runat="server"
                    Text="Menú Principal"
                    CssClass="btn btn-outline-secondary"
                    CausesValidation="False"
                    OnClick="btnMenuPrincipal_Click" />
            </div>


            <div class="card mb-4">
                <div class="card-header">Filtros</div>
                <div class="card-body">

                    <div class="row g-3">

                        <div class="col-md-6">
                            <label class="form-label">Fecha desde</label>

                            <asp:TextBox
                                ID="txtDesde"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Date">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator
                                ID="rfvFechaDesde"
                                runat="server"
                                ControlToValidate="txtDesde"
                                CssClass="text-danger"
                                ErrorMessage="Seleccione fecha inicial." />
                        </div>

                        <div class="col-md-6">
                            <label class="form-label">Fecha hasta</label>

                            <asp:TextBox
                                ID="txtHasta"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Date">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator
                                ID="rfvFechaHasta"
                                runat="server"
                                ControlToValidate="txtHasta"
                                CssClass="text-danger"
                                ErrorMessage="Seleccione fecha final." />
                        </div>

                        <div class="col-12 text-end mt-2">
                            <asp:Button
                                ID="btnGenerar"
                                runat="server"
                                Text="Generar Informe"
                                CssClass="btn btn-primary"
                                OnClick="btnGenerar_Click" />
                        </div>

                    </div>

                </div>
            </div>
        </div>

        <div class="card mb-4">
            <div class="card-header">Resumen</div>
            <div class="card-body">
                <asp:Label ID="lblTotal" runat="server"></asp:Label><br />
                <asp:Label ID="lblPresentes" runat="server"></asp:Label><br />
                <asp:Label ID="lblAusentes" runat="server"></asp:Label><br />
                <asp:Label ID="lblPorcentajeAsistencia" runat="server"></asp:Label><br />
                <asp:Label ID="lblPendientes" runat="server"></asp:Label>
            </div>
        </div>

        <asp:GridView ID="gvAsistencia"
            runat="server"
            CssClass="table table-striped table-bordered"
            AutoGenerateColumns="False"
            AllowPaging="True"
            PageSize="5"
            OnPageIndexChanging="gvAsistencia_PageIndexChanging">

            <Columns>
                <asp:BoundField DataField="Fecha_TUR" HeaderText="Fecha" DataFormatString="{0:d/M/yyyy}" />
                <asp:BoundField DataField="Hora_TUR" HeaderText="Hora" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:BoundField DataField="Asistencia" HeaderText="Asistencia" />
            </Columns>

        </asp:GridView>

   
    </form>

</body>
</html>
