<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HotOffers.aspx.cs" Inherits="FeelOfTravel.PublicPages.HotOffers" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>
      <%=Utils.MakePublicHeader("Акции и спецпредложения")%>
  </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Действующие акции!
  </h2>
  <br/>
  <%--<ControlsLibrary:TeaserViewControl ID="tsvHotOffers" runat="server" />--%>
</asp:Content>
<asp:Content runat="server" ID="RightColumn" ContentPlaceHolderID="RightContent"> </asp:Content>