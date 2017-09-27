<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" EnableEventValidation="false" Inherits="HotelReservation.UI.Pages.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link href="../Assets/css/sign.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Transparent Login Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
    <!--web-fonts-->
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css' />
    <!--web-fonts-->

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header-w3l">
                <h1>Kayıt Ol</h1>
            </div>
            
            <div class="main-content-agile">
                <div class="sub-main-w3">
                    <input placeholder="TC Kimlik No" name="Name" class="user" type="text"  required="" id="txtCivilizationNumber" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="red" ControlToValidate="txtCivilizationNumber" runat="server" ErrorMessage="Tc Kimlik Numaranız Hatalı!" ValidationExpression="^[1-9]{1}[0-9]{9}[0,2,4,6,8]{1}$"></asp:RegularExpressionValidator><br />
                    <input placeholder="Kullanıcı Adı" name="Name" class="user" type="text" required="" id="txtUserName" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="red" ControlToValidate="txtUserName" runat="server" ErrorMessage="Kullanıcı Adı 6-10 karakter olmalıdır." ValidationExpression="[a-zA-Z]{6,16}"></asp:RegularExpressionValidator><br />
                    <input placeholder="Ad" name="Name" class="user" type="text" required="" id="txtFirstName" runat="server" /><br />
                    <input placeholder="Soyad" name="Name" class="user" type="text" required="" id="txtLastName" runat="server" /><br />
                    <input placeholder="Parola" name="Password" class="pass" type="password" required="" id="txtPassword" runat="server" /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="red" ControlToValidate="txtPassword" runat="server" ErrorMessage=" Parola 4-8 karakter olmalıdır ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir." ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator><br />
                    <input placeholder="Parola Tekrar" name="Password" class="pass" type="password" required="" id="txtPasswordAgain" runat="server" /><br />
                    <asp:CompareValidator ID="CompareValidator1" ForeColor="red" runat="server" ErrorMessage="Şifreler aynı değil!" ControlToValidate="txtPassword" ControlToCompare="txtPasswordAgain"></asp:CompareValidator><br />
                    <asp:Label ID="lblInfo" runat="server" ForeColor="Red" ></asp:Label><br />
                    <asp:Button ID="btnSignUp" runat="server" Text="" OnClick="btnSignUp_Click" /><br /><br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False" style="color:white;">Giriş yapmak için tıklayınız...</asp:LinkButton>
                </div>
            </div>

            <div class="footer">
            </div>

        </div>
    </form>
</body>
</html>
