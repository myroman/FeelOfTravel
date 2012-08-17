<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OfferManagementPage.aspx.cs" Inherits="FeelOfTravel.EditorPages.Offers.OfferManagementPage" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@ Register tagPrefix="EditorControls" tagName="EntitiesManagementControl" src="../../Controls/EditorEntitiesManagementControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title> <%=Utils.MakeEditorHeader("Управление статьями")%> </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Управление статьями
  </h2>
  <EditorControls:EntitiesManagementControl runat="server" ID="emcArticles"/>
</asp:Content>