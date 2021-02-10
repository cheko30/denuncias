<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="WebAppDenuncias.Reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

    <h1>Reportes</h1>
    <hr />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="900px" Width="800px"></rsweb:ReportViewer>

</asp:Content>
