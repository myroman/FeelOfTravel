<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="FeelOfTravel.PublicPages.About" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <link href="<%= ResolveClientUrl("~/Styles/about-page.css") %>" rel="stylesheet"/>
  <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/ContactForm.js") %>"> </script>
  <script type="text/javascript" 
    src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=AIzaSyCeaxJNywIxlM64BR9cWVODCqELw8enK4o"></script>
  <script>
    $(document).ready(function () {
      initialize();

      $('span.about__about-content').html(decodeHtml("<%# AboutContent %>"));
      $('span.about__contacts-content').html(decodeHtml("<%# ContactsContent %>"));
    });

    var decodeHtml = function (e) {
      return $('<div/>').html(e).text();
    };

    var encodeHtml = function (e) {
      return $('<div/>').text(e).html();
    };
    
    $(window).unload(function () {
      GUnload();
    });
  </script>
  <title>
      <%=Utils.MakePublicHeader("О нас")%>
  </title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>О нас</h2>
    <p>
      <asp:Label runat="server" Text="" ID="litAboutText" class="about__about-content"/>  
    </p>
    
    <h2>Наши контакты</h2>
    
    <div class="about-contacts-text">
      <asp:Label ID="litContacts" runat="server" Text="" class="about__contacts-content"/>
      <span class="about-contacts-mail"></span>
    </div>
  
  <div class="about-contacts-map">asdf</div>
</asp:Content>
