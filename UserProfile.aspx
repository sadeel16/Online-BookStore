﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication2.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br>
    <center>
        <div class="card mx-auto" style="width: 25rem;">

     <center>   <asp:Image ID="Image1" src="Uploaded/q.png" runat="server" Height="224px" Width="218px" class="card-img-top" /> </center>
            <div class="card-body"> </div>
         <ul  class="list-group list-group-flush">
            <li class="list-group-item">
         <div>
            <asp:Label ID="name_lbl" runat="server" Text="Name : "></asp:Label>
            <asp:TextBox ID="name_txt" ReadOnly="True" runat="server"></asp:TextBox>

        </div> 

            </li>
              <li class="list-group-item">
                    
            <asp:Label ID="email_lbl" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="email_txt" runat="server" style="margin-bottom: 0px" ReadOnly="True"></asp:TextBox>

              </li>

               <li class="list-group-item">

            <asp:Label ID="phone_lbl" runat="server" Text="Phone Number : "></asp:Label>
            <asp:TextBox ID="phone_txt" runat="server" ReadOnly="True" ></asp:TextBox>

              </li>

              <li class="list-group-item">

            <asp:Label ID="address_lbl" runat="server" Text="Address : "></asp:Label>
            <asp:TextBox ID="address_txt" runat="server" ReadOnly="True"></asp:TextBox>
              </li>
            

         </ul>
        
       <div class="card-body">
    
            <asp:Button ID="edit_btn" runat="server" Text="Edit" OnClick="edit_btn_Click" />
            <asp:Button ID="save_btn" runat="server" Text="Save" OnClick="save_btn_Click" />
  </div>
       
       
        </div>
    </center>
</asp:Content>
