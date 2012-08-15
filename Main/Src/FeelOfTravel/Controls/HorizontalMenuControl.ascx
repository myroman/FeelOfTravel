<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HorizontalMenuControl.ascx.cs" Inherits="FeelOfTravel.Controls.HorizontalMenuControl" %>
<script src="<%= ResolveClientUrl("~/Scripts/MainMenu.js") %>" type="text/javascript"></script>

<script type="text/javascript">
  $(document).ready(function () {
    $('.showing-sub-menu').hover(showSubMenu, hideSubMenu);
    $(".main-menu__first-level li > a").click(function () {

      var currentAnchor = $(this);
      while (!currentAnchor.parent().parent().hasClass("main-menu__first-level")) {
        currentAnchor = currentAnchor.parent();
        if (typeof (currentAnchor) === "undefined") {
          return;
        }
      }

      currentAnchor.parent().addClass("menu-item-current");
    });
  });
</script>

<div class="main-menu__container cf">
  <div class="main-menu__logo-text">
    <a href="../Default.aspx">
      Feel of travel
    </a>
  </div>

  <ul class="main-menu__first-level">
    <li><a href=<%= ResolveClientUrl("~/Default.aspx") %>>Главная</a></li>
    <li><a href=<%= ResolveClientUrl("~/PublicPages/About.aspx") %>>О компании</a></li>
    <li class="showing-sub-menu">
      <span>Акции</span>
      <ul class="main-menu__second-level showing-sub-menu">
        <li><a href=<%= ResolveClientUrl("~/PublicPages/HotOffers.aspx") %>>Спецпредложения</a></li>
        <li><a href=<%= ResolveClientUrl("~/PublicPages/Cruises.aspx") %>>Круизы</a></li>
        <li><a href=<%= ResolveClientUrl("~/PublicPages/BusTours.aspx") %>>Автобусные туры</a></li>
      </ul>
    </li>

    <li><a href=<%= ResolveClientUrl("~/PublicPages/TourSearch.aspx") %>>Поиск туров</a></li>

    <asp:PlaceHolder runat="server" Visible="<%# CurrentUserIsEditor %>">
    
      <li class="showing-sub-menu"><span>Редактор</span>
        <ul class="main-menu__second-level showing-sub-menu">
          <li><a href="<%= ResolveClientUrl("~/EditorPages/AboutFormEditor.aspx") %>">О компании</a></li>
          <li class="showing-sub-menu">
            <a href="<%= ResolveClientUrl("~/EditorPages/Articles/ArticleManagementPage.aspx") %>">Статьи</a>
            <ul class="main-menu__third-level showing-sub-menu">
              <li><a href=<%= ResolveClientUrl("~/EditorPages/Articles/ArticleDetailsPage.aspx") %>>Добавить</a></li>
            </ul>
          </li>
          <li class="showing-sub-menu cf">
            <a href="<%= ResolveClientUrl("~/EditorPages/Teasers/TeaserManagementPage.aspx") %>">Тизеры</a>
            <ul class="main-menu__third-level showing-sub-menu">
              <li><a href="<%= ResolveClientUrl("~/EditorPages/Teasers/TeaserDetailsPage.aspx") %>">Добавить</a></li>
            </ul>
          </li>
        </ul>
      </li>

    </asp:PlaceHolder>
  </ul>
  <input type="text" class="main-menu__searchbox"/>
</div>
