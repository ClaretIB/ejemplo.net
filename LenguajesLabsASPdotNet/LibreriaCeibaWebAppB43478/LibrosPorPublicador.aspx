<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="LibrosPorPublicador.aspx.cs" Inherits="LibreriaCeibaWebAppB43478.LibrosPorPublicador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <h3>  
          <asp:Label ID="Label2" runat="server" Text="Seleccione un publicador:"></asp:Label> </h3>
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Publicador: "></asp:Label>
    &nbsp;&nbsp;
        <asp:DropDownList ID="ddl_publicadores" runat="server" Height="19px" OnSelectedIndexChanged="ddl_publicadores_SelectedIndexChanged" Width="158px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="lbPublicadores" runat="server" Width="144px"></asp:ListBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_test" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Lb_libros" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="grv_autores" runat="server" OnPageIndexChanged="Page_Load" OnSelectedIndexChanged="grv_autores_SelectedIndexChanged" OnSorted="Page_Load" 
             OnRowDataBound="grv_autores_RowDataBound">
        </asp:GridView>
        
        <br />
        <asp:GridView ID="gv_autor" runat="server" OnPageIndexChanged="Page_Load" OnSelectedIndexChanged="Page_Load">
        </asp:GridView>
        
    </form>
</body>
</html>
