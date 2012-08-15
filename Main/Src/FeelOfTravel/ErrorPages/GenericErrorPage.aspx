<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenericErrorPage.aspx.cs"
  Inherits="FeelOfTravel.ErrorPages.GenericErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Что-то пошло не так...</h2>
  <p>
    На нашем сайте произошла неожиданная ошибка. Администратор уведомлен, и ошибка будет исправлена в ближайшее время.</p>
  <li><a href="../Default.aspx">Вернуться на главную страницу</a></li>
</asp:Content>
