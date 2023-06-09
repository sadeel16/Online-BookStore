﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebApplication2.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/loginCss.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                <div class="card border-0 shadow rounded-3 my-5">
                    <div class="card-body p-4 p-sm-5" style="align-self: center; width: 24rem;">
                        <h5 class="card-title text-center mb-5 fw-light fs-5">Sign In</h5>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="name_txt" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="floatingInput">Name</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="email_txt" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="floatingInput">Email address</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="phoneNumber_txt" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="floatingInput">Phone Number</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="address_txt" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="floatingInput">Address</label>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="password_txt" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <label for="floatingInput">Password</label>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="signup_btn" runat="server" OnClick="signup_btn_Click" Text="SignUp" class="btn btn-primary btn-login text-uppercase fw-bold" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
