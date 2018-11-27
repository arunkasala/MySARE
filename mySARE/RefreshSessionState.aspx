<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RefreshSessionState.aspx.cs" Inherits="mySARE.RefreshSessionState" %>

<html>
    <head>
    <%
    Response.Write(@"<meta http-equiv=""refresh"" content=""900;url=RefreshSessionState.aspx?x=" +
    Server.UrlEncode(DateTime.Now.ToString()) + @""" />");
    %>
    </head>
    <body>

    </body>
</html>
