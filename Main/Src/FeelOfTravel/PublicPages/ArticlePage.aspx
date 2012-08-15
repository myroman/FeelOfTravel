<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticlePage.aspx.cs" Inherits="FeelOfTravel.PublicPages.ArticlePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <strong>
    <asp:Literal runat="server" ID="lblHeader"></asp:Literal> 
  </strong>
  <br/>
  <asp:Literal runat="server" ID="lblText"></asp:Literal>
  <asp:Label runat="server" ID="lblPrice"></asp:Label>
</asp:Content>
