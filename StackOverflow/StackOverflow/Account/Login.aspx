<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="StackOverflow.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section id="loginForm" >
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                    <ul>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Username</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="Please enter your username" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Please enter your password" />
                        </li>
                    </ul>
                    
                    <asp:Button runat="server" id="login" OnClick="Login_" Text="Login">

        </asp:Button>

        
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>

</asp:Content>
