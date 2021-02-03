<%@ Page Title="Denuncias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Denuncias.aspx.cs" Inherits="WebAppDenuncias.Denuncias" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <script>
        function alert(success, text) {
            if (success) {
                Swal.fire({
                    title: 'Éxito!',
                    text: text,
                    icon: 'success',
                    showConfirmButton: false,
                    timer: 2000
                });
            } else {
                Swal.fire({
                    title: 'Error!',
                    text: text,
                    icon: 'error',
                    showConfirmButton: false,
                    timer: 2000
                });
            }
            
        }
    </script>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-12 col-md-6 col-lg-4 ">
                <h3>Registro</h3>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                <div class="form-group">
                    <!--label id="lblFolio" for="txtFolio" >Folio</label -->
                    <asp:Label ID="lblFolio" runat="server" Visible="false" Text="Folio"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtFolio" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDescripcion">Desripción</label>
                    <asp:TextBox CssClass="form-control" ID="txtDescripcion" runat="server" TextMode="MultiLine" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="drpTipo">Tipo Delito</label>
                    <asp:DropDownList CssClass="form-control" ID="drpTipo" runat="server" required AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtFechaSuceso">Fecha Suceso</label>
                    <asp:TextBox TextMode="DateTimeLocal" CssClass="form-control" ID="txtFechaSuceso" runat="server" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtUsuario">Usuario</label>
                    <asp:TextBox CssClass="form-control" ID="txtUsuario" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button CssClass="btn btn-primary" ID="btnGuardar" runat="server" Text="Registrar" OnClick="btnGuardarClick" />
                    <asp:Button CssClass="btn btn-primary" ID="btnEditar" runat="server" Text="Editar" Enabled="false" OnClick="btnEditarClick"/>
                </div>
                
            </div>
            <div class="col-12 col-md-6 col-lg-8 border">
                <h3>Listado</h3>
                <asp:GridView ID="grdListaDenuncias" runat="server" CssClass="table table-hover table-borderless table-responsive-sm" OnRowCommand="grdListaDenuncias_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("Folio") %>' OnCommand="lnkEliminar">
                                    <i class="bi bi-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%# Eval("Folio") %>' CommandName="editar">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
           
            </div>
        </div>
    </div>
</asp:Content>


