<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="HotelReservation.UI.Pages.Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="width:850px;height:500px;max-height:500px; margin-left:150px;margin-top:-200px;">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox" >
            <div class="item active">
                <img src="../Assets/images/standart.jpg" alt="..." style="width:850px;height:500px;">
                <div class="carousel-caption">
                    Standart Oda
                </div>
            </div>
            <div class="item">
                <img src="../Assets/images/suit.jpg" alt="..." style="width:850px;height:500px;">
                <div class="carousel-caption">
                    Suit Oda
                </div>
            </div>

            <div class="item">
                <img src="../Assets/images/lux.jpg" alt="..." style="width:850px;height:500px;">
                <div class="carousel-caption">
                    Lux Oda
                </div>
            </div>
            ...
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

</asp:Content>
