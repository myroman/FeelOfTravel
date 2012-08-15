<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TeaserManagementPage.aspx.cs" Inherits="FeelOfTravel.EditorPages.Teasers.TeaserManagementPage" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@ Register TagPrefix="EditorControls" TagName="EntitiesManagementControl" Src="~/Controls/EditorEntitiesManagementControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title> <%=Utils.MakeEditorHeader("Управление тизерами")%> </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Управление тизерами
  </h2>
  <EditorControls:EntitiesManagementControl runat="server" ID="emcTeasers"/>
</asp:Content>
