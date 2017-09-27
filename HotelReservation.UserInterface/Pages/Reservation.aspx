<%@ Page Title="" Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="HotelReservation.UserInterface.Pages.Reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css' />
    <link href="../Assets/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../Assets/js/jquery.min.js"></script>
    <!--start slider -->
    <link rel="stylesheet" href="../Assets/css/fwslider.css" media="all" />
    <script src="../Assets/js/jquery-ui.min.js"></script>
    <script src="../Assets/js/css3-mediaqueries.js"></script>
    <script src="../Assets/js/fwslider.js"></script>
    <!--end slider -->
    <!---strat-date-piker---->
    <link rel="stylesheet" href="../Assets/css/jquery-ui.css" />
    <script src="../Assets/js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker,#datepicker1").datepicker();
        });
    </script>
    <!---/End-date-piker---->
    <link type="text/css" rel="stylesheet" href="../Assets/css/JFGrid.css" />
    <link type="text/css" rel="stylesheet" href="../Assets/css/JFFormStyle-1.css" />
    <script type="text/javascript" src="../Assets/js/JFCore.js"></script>
    <script type="text/javascript" src="../Assets/js/JFForms.js"></script>
    <!-- Set here the key for your domain in order to hide the watermark on the web server -->
    <script type="text/javascript">
        (function () {
            JC.init({
                domainKey: ''
            });
        })();
    </script>
    <!--nav-->
    <script>
        $(function () {
            var pull = $('#pull');
            menu = $('nav ul');
            menuHeight = menu.height();

            $(pull).on('click', function (e) {
                e.preventDefault();
                menu.slideToggle();
            });

            $(window).resize(function () {
                var w = $(window).width();
                if (w > 320 && menu.is(':hidden')) {
                    menu.removeAttr('style');
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--start main -->
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="res_online">
                    <h4>basic information</h4>
                    <p class="para">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                </div>
                <div class="span_of_2">
                    <div class="span2_of_1">
                        <h4>check-in:</h4>
                        <div class="book_date btm">
                            <form>
                                <input class="date" id="datepicker1" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}">
                            </form >
                        </div>
                        <div class="sel_room">
                            <h4>number of rooms</h4>
                            <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                <option value="null">Select a type of Room</option>
                                <option value="null">Suite room</option>
                                <option value="AX">Single room</option>
                                <option value="AX">Double room</option>
                            </select>
                        </div>
                        <div class="sel_room left">
                            <h4>adults per room:</h4>
                            <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                <option value="null">1</option>
                                <option value="null">2</option>
                                <option value="AX">3</option>
                                <option value="AX">4</option>
                            </select>
                        </div>
                    </div>
                    <div class="span2_of_1">
                        <h4>check-out:</h4>
                        <div class="book_date btm">
                            <form>
                                <input class="date" id="datepicker1" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}">
                            </form>
                        </div>
                        <div class="sel_room">
                            <h4>childern 0-5:</h4>
                            <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                <option value="null">0</option>
                                <option value="null">1</option>
                                <option value="null">2</option>
                                <option value="AX">3</option>
                                <option value="AX">4</option>
                            </select>
                        </div>
                        <div class="sel_room left">
                            <h4>childern 6-12:</h4>
                            <select id="country" onchange="change_country(this.value)" class="frm-field required">
                                <option value="null">0</option>
                                <option value="null">1</option>
                                <option value="null">2</option>
                                <option value="AX">3</option>
                                <option value="AX">4</option>
                            </select>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="res_btn">
                    <form>
                        <input type="submit" value="book now" style="width: 280px;">
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
