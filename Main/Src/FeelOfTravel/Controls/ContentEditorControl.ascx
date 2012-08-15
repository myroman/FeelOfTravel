<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentEditorControl.ascx.cs" Inherits="FeelOfTravel.Controls.ContentEditorControl" %>
<script src="/Scripts/tinyMce/tiny_mce.js" type="text/javascript"></script>

<ajaxToolkit:AsyncFileUpload 
      runat="server" 
      ID="afuImageUpload"
      OnUploadedComplete="AfuImageUpload_OnUploadedComplete"
      Width="500px" 
      UploaderStyle="Modern" 
      UploadingBackColor="#CCFFFF" />
       <script type="text/javascript">
         function <%=this.GetUploadCompleteCallbackName() %>(sender, args) {
           insertImageTag('<%=txtContent.ClientID %>', args.get_fileName());
         }
       </script>

<asp:UpdatePanel runat="server">
  <ContentTemplate>
    <input type="button" id="btnBold" value="Жирный" onclick="insertBold();"/>
    <input type="button" id="btnItalics" value="Курсив" onclick="insertItalics();"/>
    <input type="button" id="btnReturnCaret" value="Перенос" onclick="insertReturnCaret();"/>
    <br />
    <asp:TextBox ID="txtContent"  Name="txtContent" runat="server" TextMode="MultiLine" 
                 Height="90px" Width="440px" onchange="enableButton();" onkeyup="enableButton();"/> 
  
    
    <asp:Button ID="btnSave" runat="server" Text="Сохранить" OnClick="BtnSaveClick" />
  </ContentTemplate>
</asp:UpdatePanel>
