<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TourSearch.aspx.cs" Inherits="FeelOfTravel.PublicPages.TourSearch" %>

<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@ Register TagPrefix="Sletat" TagName="SearchFilter" Src="~/Controls/SletatMiniVerticalFilterControl.ascx" %>
<%@ Register TagPrefix="Sletat" TagName="SearchResults" Src="~/Controls/SletatSearchResultsControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>
    <%=Utils.MakePublicHeader("Поиск туров")%>
  </title>
  <link href="../Styles/public-pages-common.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="cf">
    <div class="search-filter">
      <Sletat:SearchFilter ID="searchControl" runat="server" />
    </div>
    <Sletat:SearchResults ID="searchResults" runat="server" />
  </div>
</asp:Content>
<asp:Content runat="server" ID="RightColumn" ContentPlaceHolderID="RightContent"></asp:Content>