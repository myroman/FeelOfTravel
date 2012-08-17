<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BusTours.aspx.cs" Inherits="FeelOfTravel.PublicPages.BusTours" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>
      <%=Utils.MakePublicHeader("Автобусные туры")%>
  </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Автобусные туры
  </h2>

  <%--<ControlsLibrary:TeaserViewControl ID="tsvBusTours" runat="server" />--%>
</asp:Content>
<asp:Content runat="server" ID="RightContent" ContentPlaceHolderID="RightContent"></asp:Content>