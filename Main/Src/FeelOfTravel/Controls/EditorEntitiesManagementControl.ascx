<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditorEntitiesManagementControl.ascx.cs" Inherits="FeelOfTravel.Controls.EditorEntitiesManagementControl" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@ Register tagPrefix="ent" tagName="EntitiesList" src="~/Controls/EntitiesListControl.ascx" %>

<script src="<%= ResolveClientUrl("~/Scripts/EditorEntities.js") %>"></script>
<link rel="Stylesheet" media="screen" type="text/css" href="<%=ResolveClientUrl("~/Styles/Effects.css") %>" />
<link href="<%= ResolveClientUrl("~/Styles/editor-management.css") %>" rel="stylesheet" type="text/css"/>
<link href="<%=ResolveClientUrl("~/jquery-tooltip/jquery.tooltip.css") %>" rel="stylesheet"/>
<script type="text/javascript" src="<%=ResolveClientUrl("~/jquery-tooltip/jquery.tooltip.js") %>"></script>

<input id="hdTooltipIndex" type="hidden" runat="server"/>

<div class="entity-label-status">
  
</div>

<asp:PlaceHolder runat="server" Visible="<%# AddingIsEnabled %>">
  <asp:Button ID="btnAdd" runat="server" Text="Добавить" onclick="btnAdd_Click"/> 
  <br/>
</asp:PlaceHolder>

<div class="entity-list-refresh">
  <input type="button" value="Обновить"/>
</div>

<div class="entity-list">
  <ent:EntitiesList runat="server" ID="entitiesList" />
</div>