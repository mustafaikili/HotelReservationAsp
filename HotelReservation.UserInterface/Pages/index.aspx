<%@ Page Title="" Language="C#" MasterPageFile="Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HotelReservation.UserInterface.index" %>

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

    <!----start-images-slider---->
    <div class="images-slider">
        <!-- start slider -->
        <div id="fwslider">
            <div class="slider_container">
                <div class="slide">
                    <!-- Slide image -->
                    <img src="../Assets/images/slider-bg.jpg" alt="" />
                    <!-- /Slide image -->
                    <!-- Texts container -->
                    <div class="slide_content">
                        <div class="slide_content_wrap">
                            <!-- Text title -->
                            <h4 class="title"><i class="bg"></i>Lorem Ipsum is simply <span class="hide">dummy text</span></h4>
                            <h5 class="title1"><i class="bg"></i>Morbi justo <span class="hide">condimentum accumsan</span></h5>
                            <!-- /Text title -->
                        </div>
                    </div>
                    <!-- /Texts container -->
                </div>
                <!-- /Duplicate to create more slides -->
                <div class="slide">
                    <img src="../Assets/images/slider-bg.jpg" alt="" />
                    <div class="slide_content">
                        <div class="slide_content_wrap">
                            <!-- Text title -->
                            <h4 class="title"><i class="bg"></i>Morbi justo <span class="hide">condimentum </span>text</h4>
                            <h5 class="title1"><i class="bg"></i>Lorem Ipsum is <span class="hide">simply dummy text</span> </h5>
                            <!-- /Text title -->
                        </div>
                    </div>
                </div>
                <!--/slide -->
            </div>
            <div class="timers"></div>
            <div class="slidePrev"><span></span></div>
            <div class="slideNext"><span></span></div>
        </div>
        <!--/slider -->
    </div>
    <!--start main -->
    <div class="main_bg">
        <div class="wrap">
            <div class="online_reservation">
                <div class="b_room">
                    <div class="booking_room">
                        <h4>Rezervasyon</h4>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry</p>
                    </div>
                    <div class="reservation">
                        <ul>
                            <li class="span1_of_1">
                                <h5>Oda Tipi:</h5>
                                <!----------start section_room----------->
                                <asp:DropDownList ID="drpRoomType" runat="server"></asp:DropDownList>
                                
                            </li>
                            <li class="span1_of_1 left">
                                <h5>Rezervasyon Tipi:</h5>
                                <!----------start section_room----------->
                                <asp:DropDownList ID="drpReservationType" runat="server"></asp:DropDownList>
                            </li>
                            <li class="span1_of_1 left">
                                <h5>Giriş Tarihi:</h5>
                                <div class="book_date">
                                        <%--<input class="date" id="datepicker" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}"/>--%>
                                            <input class="date" id="datepicker" name="Text" type="text" value="Giriş Tarihi" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Arrival date';}" required="" runat="server" />

                                </div>
                            </li>
                            <li class="span1_of_1 left">
                                <h5>Çıkış Tarihi:</h5>
                                <div class="book_date">
                                        <input class="date" id="datepicker1" type="text" value="DD/MM/YY" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'DD/MM/YY';}" runat="server">
                                    
                                </div>
                            </li>
                            <li class="span1_of_2 left">
                                <h5>Kişi Sayısı:</h5>
                                <!----------start section_room----------->
                                <asp:DropDownList ID="drpPersonCount" OnSelectedIndexChanged="drpPersonCount_SelectedIndexChanged"  AutoPostBack="true" runat="server" ></asp:DropDownList>
                            </li>
                            <li class="span1_of_3">
                                <div class="date_btn">
                                    <form>
                                        <input type="submit" value="Kontrol Et  " />
                                    </form>
                                </div>
                            </li>
                            <li class="span1_of_1 left">
                                <h5>Rezervasyon Durumu</h5>
                                <div class="book_date">
                                    <asp:Label ID="lblEmptyRoom" runat="server" Text=""></asp:Label>
                                </div>
                            </li>
                            <div class="clear"></div>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            <!--start grids_of_3 -->
            <div class="grids_of_3">
                <div class="grid1_of_3">
                    <div class="grid1_of_3_img">
                        <a href="details.html">
                            <img src="../Assets/images/pic2.jpg" alt="" />
                            <span class="next"></span>
                        </a>
                    </div>
                    <h4><a href="#">single room<span>120$</span></a></h4>
                    <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                </div>
                <div class="grid1_of_3">
                    <div class="grid1_of_3_img">
                        <a href="details.html">
                            <img src="../Assets/images/pic1.jpg" alt="" />
                            <span class="next"></span>
                        </a>
                    </div>
                    <h4><a href="#">double room<span>180$</span></a></h4>
                    <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                </div>
                <div class="grid1_of_3">
                    <div class="grid1_of_3_img">
                        <a href="details.html">
                            <img src="../Assets/images/pic3.jpg" alt="" />
                            <span class="next"></span>
                        </a>
                    </div>
                    <h4><a href="#">suite room<span>210$</span></a></h4>
                    <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
</asp:Content>
