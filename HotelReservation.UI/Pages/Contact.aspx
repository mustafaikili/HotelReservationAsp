<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HotelReservation.UI.Pages.Contact2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom Theme files -->
<link href="../Assets/css/styleContact.css" rel="stylesheet" type="text/css" />
<!-- font-awesome icons -->
<link href="../Assets/css/font-awesome.css" rel="stylesheet"> 
<!-- //font-awesome icons -->
<!--Google Fonts-->
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact-form">
					<div class="w3l-contact-left">
						<div class="styled-input agile-styled-input-top">
							<input type="text" name="Name" required="">
							<label>Name</label>
							<span></span>
						</div>
						<div class="styled-input">
							<input type="email" name="Email" required=""> 
							<label>Email</label>
							<span></span>
						</div> 
						<div class="styled-input">
							<input type="text" name="Phone" required="">
							<label>Phone</label>
							<span></span>
						</div>
						<div class="styled-input">
							<input type="text" name="Subject" required="">
							<label>Subject</label>
							<span></span>
						</div>
					</div>
					<div class="w3l-contact-right">
						<div class="styled-input agileits-input">
							<textarea name="Message" required=""></textarea>
							<label>Message</label>
							<span></span>
						</div>	 
						<input type="submit" value="SEND">
					</div>
					<div class="clear"> </div>
			</div>
</asp:Content>
