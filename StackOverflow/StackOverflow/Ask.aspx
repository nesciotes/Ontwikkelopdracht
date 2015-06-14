<%@ Page Title="Ask a Question" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ask.aspx.cs" Inherits="StackOverflow.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <section id="ask_">
                            <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
        <asp:Label runat="server" AssociatedControlID="title">Title</asp:Label>
        <asp:TextBox runat="server" ID="title" />
        <asp:Label runat="server" AssociatedControlID="question">Question</asp:Label>
        <asp:TextBox runat="server" ID="question" Rows="7" TextMode="MultiLine" />
        <asp:Label runat="server" AssociatedControlID="tags">Tags (separate by comma's)</asp:Label>
        <asp:TextBox runat="server" ID="tags" />
        <asp:Button runat="server" id="ask" OnClick="Ask_" Text="Ask"></asp:Button>
    </section>
</asp:Content>