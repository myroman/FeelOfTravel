<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cruises.aspx.cs" Inherits="FeelOfTravel.PublicPages.Cruises" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@Register tagPrefix="ControlsLibrary" tagName="TeaserViewControl" src="~/Controls/TeaserViewControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>
      <%=Utils.MakePublicHeader("Круизы")%>
  </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Круизы
  </h2>

  <ControlsLibrary:TeaserViewControl ID="tsvCruises" runat="server" />
</asp:Content>

<asp:Content runat="server" ID="RightColumn" ContentPlaceHolderID="RightContent"></asp:Content>
