<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLoginPage.aspx.cs" Inherits="ELibrary.AdminLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class=" container my-5">
    <div class="row">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col text-center mb-3">
                            <img src="Images/software-engineer_6024190.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <h3>Admin Login</h3>
                        </div>
                    </div>
                    <hr />
                    <div class="row mb-3">
                        <div class="col">
                            <label>Admin ID:</label>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col">
                            <div class="form-group">
                                <asp:TextBox ID="memberLoginID" CssClass="form-control" runat="server" placeholder="Member ID"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col">
                            <label>Password:</label>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col">
                            <div class="form-group">
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class=" row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <asp:Button ID="userLoginButton" CssClass="btn btn-outline-primary" Width="100%" type="button" runat="server" Text="Login" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row mb-3">
    <div class="col text-center">
        <a href="HomePage.aspx" class="nav-link">Back To Home Page</a>
    </div>
</div>
</asp:Content>
