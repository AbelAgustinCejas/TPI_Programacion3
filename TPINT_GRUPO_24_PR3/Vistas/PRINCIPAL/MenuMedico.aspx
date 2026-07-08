<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="Vistas.MenuMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menú Médico</title>

    <style>
        *{
            font-family:Arial;
        }

        body{
            background:#F5F5F5;
        }

        .header{
            width:100%;
            height:90px;
            background:#0b6fa4;
            color:white;
        }

        .titulo{
            width:100%;
            font-size:30px;
            font-weight:bold;
        }

        .usuario{
            width:100%;
            font-size:20px;
        }

        .contenedor{
            width:100%;
            margin:30px auto;
        }

/*        .panelFiltros{
            background:white;
            border-radius:10px;
            padding:20px;
            display:flex;
            justify-content:space-between;
            margin-bottom:25px;
        }

        .filtro{
            width:32%;
        }

        .filtro label{
            display:block;
            margin-bottom:8px;
            font-weight:bold;
            color:#444;
        }
*/
        .textbox{
            width:100%;
            padding:10px;
            border:1px solid;
            border-radius:6px;
            font-size:15px;
        }

        .panelGrid{
            background:white;
            padding:20px;
            border-radius:10px;
        }

        .tituloGrid{
            font-size:24px;
            margin-bottom:15px;
            color:royalblue;
            font-weight:bold;
        }

        .grid{
            width:100%;
        }

        .grid th{
            background:#0b6fa4;
            color:white;
            padding:10px;
            text-align:center;
        }

        .grid td{
            padding:10px;
            border-bottom:1px solid;
            text-align:center;
        }

        .mensaje{
            margin-top:15px;
            color:orangered;
            font-weight:bold;
        }

    </style>

</head>
    <body>
        <form id="form1" runat="server">
            <div class="header">
                <div class="titulo">
                    Menu Medico
                </div>
                <div class="usuario">
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    <asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/IMAGENES/logout.jpg" OnClick="btnLogout_Click"/>
                </div>
            </div>
            <div class="contenedor">
<%--                <div class="panelFiltros">
                    <div class="filtro">
                        <label>Paciente</label>
                        <asp:TextBox ID="txtFiltro1" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div class="filtro">
                        <label>Fecha</label>
                        <asp:TextBox ID="txtFiltro2" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div class="filtro">
                        <label>DNI</label>
                        <asp:TextBox ID="txtFiltro3" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>--%>
                <div class="panelGrid">
                    <div class="tituloGrid"> Turnos </div>
                    <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="grid" DataKeyNames="IdTurno_TUR" OnRowCommand="gvTurnos_RowCommand" AllowPaging="True" OnPageIndexChanging="gvTurnos_PageIndexChanging" PageSize="8">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                            <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha"/>
                            <asp:BoundField DataField="Hora" HeaderText="Hora"/>
                            <asp:BoundField DataField="Asistencia" HeaderText="Asistencia"/>
                            <asp:TemplateField HeaderText="Presente">
                                <ItemTemplate>
                                    <asp:ImageButton
                                        ID="btnPresente"
                                        runat="server"
                                        ImageUrl="~/IMAGENES/presente2.jpg"
                                        CommandName="Presente"
                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ausente">
                                <ItemTemplate>
                                    <asp:ImageButton
                                        ID="btnAusente"
                                        runat="server"
                                        ImageUrl="~/IMAGENES/ausente2.jpg"
                                        CommandName="Ausente"
                                        CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="mensaje">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>