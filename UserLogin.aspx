<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="ELibrary.UserLogin" %>

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
                                <img src="Images/userLoginLogo.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member Login</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col">
                                <label>Member ID:</label>
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
                                    <asp:TextBox ID="MemberLoginPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-6 text-end">
                                <div class="form-group">
                                    <asp:Button ID="userLoginButton" CssClass="btn btn-outline-primary" type="button" runat="server" Text="Login" OnClick="CheckLoginCrendentials"/>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Button ID="userSignUpButton" CssClass="btn btn-outline-success" runat="server" Text="SignUp" OnClick="RedirectToSignUpPage" />
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
