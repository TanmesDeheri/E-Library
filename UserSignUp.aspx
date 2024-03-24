<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="ELibrary.UserSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class=" container my-5">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/userLoginLogo.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>User Registration</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="userSignUpFullName" CssClass="form-control mb-3" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="userSignUpDOB" CssClass="form-control mb-3" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="userContactNumber" CssClass="form-control mb-3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="userEmailID" CssClass="form-control mb-3" runat="server" TextMode="Email" placeholder="Email ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">State</label>
                                <div class="form-group">
                                    <asp:DropDownList runat="server" ID="StateDropdown" CssClass="form-control" OnSelectedIndexChanged="StateDropdown_SelectedIndexChanged">
                                        <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">City</label>
                                <div class="form-group">
                                    <asp:DropDownList runat="server" ID="CityDropdown" CssClass="form-control">
                                        <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="userPinCode" CssClass="form-control mb-3" runat="server" TextMode="Number" placeholder="pincode"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label>Full Address</label>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:TextBox ID="userAddress" CssClass="form-control" runat="server" TextMode="Multiline" placeholder="Enter The Address" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-12 text-center">
                                <span class="badge bg-success">login Crendentials</span>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">User ID</label>
                                <asp:TextBox runat="server" ID="userID" CssClass="form-control mb-3" placeholder="User ID"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Password</label>
                                <asp:TextBox runat="server" ID="memberPassword" CssClass="form-control mb-3" TextMode="Password" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Button ID="userSignUpButton" CssClass="btn btn-outline-success" Width="100%" type="button" runat="server" Text="SignUp" OnClick="SignUp"/>
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
