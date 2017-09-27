<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="HotelReservation.UI.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link href="../Assets/css/login.css" rel="stylesheet" type="text/css" media="all" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Transparent Login Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
    <!--web-fonts-->
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css' />
    <!--web-fonts-->
    <style>
        body{
            background-image:url("../Assets/images/bg2.jpg");
            background-repeat:no-repeat;
            background-size:cover;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header-w3l">
                <h1>Giriş Yap</h1>
            </div>

            <div class="main-content-agile">
                <div class="sub-main-w3">
                    <input placeholder="Kullanıcı Adı" name="Name" class="user" type="text" required="" id="txtUserName" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="red" ControlToValidate="txtUserName" runat="server" ErrorMessage="Kullanıcı Adı 6-10 karakter olmalıdır." ValidationExpression="[a-zA-Z]{6,16}"></asp:RegularExpressionValidator><br />
                    <input placeholder="Şifre" name="Password" class="pass" type="password" required="" id="txtPassword" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="red" ControlToValidate="txtPassword" runat="server" ErrorMessage=" Parola 4-8 karakter olmalıdır ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir." ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator><br />
                    <asp:Label ID="lblInfo" runat="server" ForeColor="Red" Visible="False"></asp:Label><br />
                    <asp:Button ID="btnLogin" runat="server" Text="" OnClick="btnLogin_Click" /><br /><br /><br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="color:white;">Eğer hesabınız yoksa üye olunuz!</asp:LinkButton>
                </div>
            </div>

            <div class="footer">
            </div>

        </div>
    </form>
</body>
</html>
