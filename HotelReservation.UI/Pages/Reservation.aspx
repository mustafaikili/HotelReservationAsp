<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="HotelReservation.UI.Pages.RoomTypeSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Reservation Information</title>
    <link href="../Assets/css/reservation.css" rel='stylesheet' type='text/css' />
    <link href="//fonts.googleapis.com/css?family=Alegreya+Sans" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Hotel Enquiry  Form Widget Responsive, Login Form Web Template, Flat Pricing Tables, Flat Drop-Downs, Sign-Up Web Templates, Flat Web Templates, Login Sign-up Responsive Web Template, Smartphone Compatible Web Template, Free Web Designs for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>

</head>
    l
<body>

    <h1>India Hotel</h1>

    <div class="main-agile">
        <form action="#" method="post" runat="server">
            <input id="dtpStartDate" name="Text" type="text" value="Giriş Tarihi" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Arrival date';}" required="" runat="server" />
            <input id="dtpEndDate" name="Text" type="text" value="Çıkış Tarihi" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Departure date';}" required="" runat="server" />
            <asp:DropDownList ID="drpRoomType" runat="server"></asp:DropDownList><br />
            <asp:DropDownList ID="drpReservationType" runat="server"></asp:DropDownList><br />
            <asp:DropDownList ID="drpPersonCount" OnSelectedIndexChanged="drpPersonCount_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList><br />
            <asp:Label ID="lblEmptyRoom" runat="server" Text=""></asp:Label><br />
            <br />
            <br />
            <asp:Button ID="continue" runat="server" Text="Kontrol Et" OnClick="continue_Click" />
        </form>
    </div>

    <div class="footer-w3l">
        <p class="agileinfo">&copy; 2017 Hotel İndia. All Rights Reserved | Design by İndia Team </p>
    </div>

    <!-- Calendar -->
    <script src="../Assets/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../Assets/css/jquery-ui.css" />
    <script src="../Assets/js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dtpStartDate,#dtpEndDate").datepicker();
        });
    </script>
    <!-- //Calendar -->

</body>
</html>
