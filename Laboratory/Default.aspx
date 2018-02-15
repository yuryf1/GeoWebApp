<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratory._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Move to Me</h1>
        input values:&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="703px" Height="30px" BorderColor="#0099FF" BorderWidth="1px" Font-Size="14pt" ReadOnly ="true"></asp:TextBox>
        &nbsp;<br />
        adress:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="710px" Height="30px" BorderColor="#0099FF" BorderWidth="1px" Font-Size="14pt" ReadOnly ="true"></asp:TextBox>
        <br />
        <asp:Image ID="Image1" runat="server" Height="450px" Width="450px" BorderColor="#0099FF" BorderStyle="Double" BorderWidth="1px" />
        <asp:Image ID="Image2" runat="server" Height="450px" Width="450px" BorderColor="#0099FF" BorderStyle="Double" BorderWidth="1px" />
        <br />
        <br />
        <br />
        </div>

    <div class="row">
    </div>

</asp:Content>
