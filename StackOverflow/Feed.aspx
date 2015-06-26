<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/MasterpageLoggedGuest.master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="SMEEvent.GUI.Pages.Guest.Feed" %>
<asp:Content runat="server" contentplaceholderid="ContentPage" ID="content">
<div ID="feed" runat="server">

</div>
<div id="postmessage">
    <asp:TextBox mode="multiline" runat="server" id="message" placeholder="Typ hier uw bericht..." />
    <img src="http://www.vclongeaton.com/VCLE/images/camera-icon-hi.png" id="addmedia">
    <asp:Button runat="server" id="sendmessage" onClick="postMessage" Text="Verstuur"></asp:Button>
  </div>    
    </asp:Content> 