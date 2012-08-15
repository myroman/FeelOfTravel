<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AboutFormEditor.aspx.cs" 
Inherits="FeelOfTravel.EditorPages.AboutFormEditor" %>
<%@ Import Namespace="FeelOfTravel.Logic.Common" %>
<%@ Register TagPrefix="uc1" TagName="ContentEditorControl" Src="~/Controls/ContentEditorControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TinyMceEditorControl" Src="~/Controls/TinyMceEditorControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <title>
      <%=Utils.MakeEditorHeader("О нас")%>
  </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </ajaxToolkit:ToolkitScriptManager>
  <uc1:TinyMceEditorControl ID="AboutEditorControl" runat="server" />
</asp:Content>
