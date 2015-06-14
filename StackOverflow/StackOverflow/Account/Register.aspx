<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StackOverflow.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                        <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Username</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="Please enter your username" />
                        </li>
                            <li>
                            <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
                            <asp:TextBox runat="server" ID="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="field-validation-error" ErrorMessage="Please enter your e-mail" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Please enter your password" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password Again</asp:Label>
                            <asp:TextBox runat="server" ID="Password2" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Please enter your password again" />
                        </li>
                    </ol>
                        <asp:Button runat="server" id="register" CommandName="MoveNext" Text="Register" />

    </section>
</asp:Content>