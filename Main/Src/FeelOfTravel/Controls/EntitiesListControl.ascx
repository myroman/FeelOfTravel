<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntitiesListControl.ascx.cs" Inherits="FeelOfTravel.Controls.EntitiesListControl" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<script type="text/javascript" language="javascript">
  //<![CDATA[
  $(document).ready(function () {

    editorEntitiesControl.Initialize({
      entObj: <%# Provider.EntitiesTransferObject.ToJSON() %>
    });

    editorEntitiesControl.refreshData = function() {
      return <%# Provider.EntitiesTransferObject.JsonEntitiesList %>;
    };

  });//]]>
</script>

  <asp:Repeater ID="rptList" runat="server">
  <ItemTemplate>
      
    <asp:Label ID="litItemText" runat="server" Text="<%# GetItemText(Container.DataItem)%>" 
    CssClass="label-entity-in-list"/>
    <br/>
    
    <a id="aEdit" class="entity-list-button entity-edit">Изменить</a>
    <a id="aDelete" class="entity-list-button entity-delete">Удалить</a>
    <br/>

  </ItemTemplate>
</asp:Repeater>