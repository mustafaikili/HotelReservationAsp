<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UserUpdate.aspx.cs" Inherits="HotelReservation.UI.Pages.UserUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Assets/css/userUpdate.css" rel="stylesheet" />
    <link href="../Assets/css/font-awesome.css" rel="stylesheet" />
    <!-- //font-awesome icons -->
    <!--Google Fonts-->
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />
    <script src="../Assets/js/jquery-1.11.1.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrap">
        <div class="w3ls-subscribe">
            <div class="agileits-border">
                <h4>Kullanıcı Güncelle</h4>
                <input type="text" id="txtFirstName" name="Name" placeholder="Ad" required="" runat="server" />
                <input type="text" id="txtLastName" name="Name" placeholder="Soyad" required="" runat="server" />
                <input type="text" id="txtEmail" name="Name" placeholder="Email" required="" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="red" ControlToValidate="txtEmail" runat="server" ErrorMessage="Geçerli bir mail adresi giriniz!." ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                <input type="text" id="txtTelephone" name="Name" placeholder="Telefon" required="" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="red" ControlToValidate="txtTelephone" runat="server" ErrorMessage="Geçerli bir numara giriniz!." ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"></asp:RegularExpressionValidator><br />
                <input type="text" id="txtPassword" name="Name" placeholder="Parola" required="" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="red" ControlToValidate="txtPassword" runat="server" ErrorMessage=" Parola 4-8 karakter olmalıdır ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir." ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator><br />
                <input type="text" id="txtPasswordAgain" name="Name" placeholder="Parola Tekrar" required="" runat="server" />
                <asp:CompareValidator ID="CompareValidator1" ForeColor="red" runat="server" ErrorMessage="Şifreler aynı değil!" ControlToValidate="txtPassword" ControlToCompare="txtPasswordAgain"></asp:CompareValidator><br />
                <asp:Label ID="lblInfo" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Button ID="userUpdate" runat="server" Text="Güncelle" OnClick="userUpdate_Click" />
            </div>
        </div>
    </div>

</asp:Content>
