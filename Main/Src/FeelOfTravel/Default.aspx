<%@ Page Title="Домашняя страница" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FeelOfTravel.Default" %>
<%@ Register TagPrefix="Sletat" TagName="SearchFilter" Src="~/Controls/SletatMiniVerticalFilterControl.ascx" %>
<%@ Register TagPrefix="Sletat" TagName="SearchResults" Src="~/Controls/SletatSearchResultsControl.ascx" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <title>
      <%=Utils.MakePublicHeader("Главная страница - поиск туров")%>
  </title>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <div class="cf">
    <div class="search-filter">
      <Sletat:SearchFilter ID="searchControl" runat="server" />
    </div>
    <Sletat:SearchResults ID="searchResults" runat="server" />
  </div>
</asp:Content>