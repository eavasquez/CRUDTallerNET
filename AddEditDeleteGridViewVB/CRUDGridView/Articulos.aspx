<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Articulos.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD con GridView</title>   
    <script src="Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Content/bootstrap.min.js" type="text/javascript"></script>
    <style type="text/css">
        #GridContainer
        {
            margin-top:5em;
            margin-left:auto;
            margin-right:auto;
            width:50%;            
        }

        #LabelContainer
        {
            text-align:center;
        }

        #lblHeading
        {
            margin-left:auto;
            margin-right:auto;
            font-weight:bold;
            font-size:1.5em;
        }
    </style>
</head>
<body>
    <div class="center-block text-center">
    <ul class="nav nav-pills text-center center-block">
  <li role="presentation"><a href="/Default.aspx">Clientes</a></li>
  <li role="presentation" class="active"><a href="#">Articulos</a></li>
  <li role="presentation"><a href="/Documentos.aspx">Documentos</a></li>
</ul>
</div>
        
    <form id="form1" runat="server">
    <div id="Container">
        <div id="GridContainer">
            <div id="LabelContainer">
                <asp:Label ID="lblHeading" runat="server" Text="CRUD Articulos" >
                </asp:Label>
            </div>           
            <br />
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id, Codigo" 
                ShowFooter="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" 
                OnRowDeleting="GridView1_RowDeleting"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" 
                CellPadding="0" ForeColor="#333333" CssClass="table table-striped table-bordered table-condensed">
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo">
                            <EditItemTemplate>
                                <asp:TextBox id="txtName" runat="server" Text='<%# Eval("Codigo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label id="Label1" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewName" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                            <ItemStyle Wrap="True" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo">
                            <EditItemTemplate>
                                &nbsp;           
                                <asp:DropDownList ID="cmbGender" runat="server">
                                    <asp:ListItem>Producto</asp:ListItem>
                                    <asp:ListItem>Servicio</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Tipo")%>' id="Label2"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbNewGender" runat="server" >
                                    <asp:ListItem>Producto</asp:ListItem>
                                    <asp:ListItem>Servicio</asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descripcion">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Eval("Descripcion")%>' id="txtCity"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Descripcion")%>' id="Label3"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewCity" runat="server" ></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio de venta">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Eval("PrecioVenta")%>' id="txtState"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("PrecioVenta")%>' id="Label4"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewState" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Activo">
                            <EditItemTemplate>
                                &nbsp;
                            <asp:DropDownList ID="cmbType" runat="server">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Activo") %>' id="Label5"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbNewType" runat="server">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                <ItemTemplate>                                    
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" CssClass="btn btn-primary" Text="Editar"></asp:LinkButton>  
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" CssClass="btn btn-info" CommandName="Update" Text="Modificar"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CssClass="btn btn-info"  CommandName="Cancel" Text="Cancelar"></asp:LinkButton> 
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkAddNew" CssClass="btn btn-primary" runat="server" CommandName="AddNew">Agregar</asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
    
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>        
                                <span onclick="return confirm('Estas seguro de eliminar el articulo??')">
                                    
                                    <asp:LinkButton ID="lnkB" runat="Server" CssClass="btn btn-primary"  Text="Borrar" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Delete"></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>                      
        </div>    
    </div>
    </form>
</body>
</html>
