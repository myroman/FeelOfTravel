<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="FeelOfTravel.TestPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.51116.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script type="text/javascript" src="/Scripts/Utils.js"></script>
  <script type="text/javascript"src="http://code.jquery.com/jquery-1.5.js"></script>

  <script type="text/javascript">
    $(function() {
      $("#div1 a").tooltip({
        bodyHandler: function() {
          return 'asdfasdfasdfasdafsd'/*$($(this).attr("href")).html()*/;
        },
        showURL: false
      });
    });
  </script>

  <link href="<%=ResolveClientUrl("~/Styles/Effects.css") %>" rel="stylesheet" type="text/css" />
  
  <link href="<%=ResolveClientUrl("~/jquery-tooltip/jquery.tooltip.css") %>" rel="stylesheet"/>
  <script type="text/javascript" src="<%=ResolveClientUrl("~/jquery-tooltip/jquery.tooltip.js") %>"></script>
  

  <style type="text/css">
    #tooltipDiv {
      display: none;
    }
  </style>
 <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>     
 </head>
<body>
  <form id="form1" runat="server">
  <div id="div1">
    Пошла Алиса <a href="#tooltipDiv">погулять</a>...
    <div id="tooltipDiv">
      Пошла Алиса погулять и покурила с гусеницей трубку<br/>
      О дааа...
    </div>
  </div>
  </form>
</body>
</html>
