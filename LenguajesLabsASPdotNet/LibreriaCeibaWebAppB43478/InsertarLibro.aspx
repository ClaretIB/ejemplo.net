<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarLibro.aspx.cs" Inherits="LibreriaCeibaWebAppB43478.InsertarLibro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Insertar un nuevo Libro"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Titulo:"></asp:Label>
        <asp:TextBox ID="tb_titulo" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Año:"></asp:Label>
            <asp:TextBox ID="tb_ano" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="ISBN:"></asp:Label>
            <asp:TextBox ID="tb_isbn" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Publicador:"></asp:Label>
            <asp:DropDownList ID="ddl_publicadores" runat="server" Height="16px" Width="149px" OnSelectedIndexChanged="Page_Load" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="tb_precio" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Seleccione 1 o mas autores"></asp:Label>
        </p>
        <asp:ListBox ID="lb_autores" runat="server" Width="190px" Height="65px" SelectionMode="Multiple"></asp:ListBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_agregar" runat="server" OnClick="btn_agregar_Click" Text="&gt;&gt;" Width="41px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lb_autores2" runat="server" Height="65px" Width="182px" SelectionMode="Multiple"></asp:ListBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_extraer" runat="server" OnClick="btn_extraer_Click" Text="&lt;&lt;" Width="41px" />
        <br />
        <p>
            <asp:Button ID="btn_insertarLibro" runat="server" Text="Insertar Libro" OnClick="btn_insertarLibro_Click" />
        </p>
        <p>
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
