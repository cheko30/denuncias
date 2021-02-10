<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListDenuncias.aspx.cs" Inherits="WebAppDenuncias.ListDenuncias" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-12 col-md-2"></div>
            <div class="col-12 col-md-8">
                <h3>Listado de Denuncias</h3>
                <asp:GridView ID="grdListaDenuncias" runat="server" CssClass="table table-hover table-borderless table-responsive-sm" OnRowDataBound="grdListaDenuncias_RowDataBound" OnRowCommand="grdListaDenuncias_RowCommand">
                </asp:GridView>
            </div>
            <div class="col-12 col-md-2"></div>
        </div>
    </div>
</asp:Content>