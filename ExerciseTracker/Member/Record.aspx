<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="ExerciseTracker.Member.Record" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:Table ID="RecordLayoutTable" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Table ID="GridViewContainer" runat="server"></asp:Table></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>