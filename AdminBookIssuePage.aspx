<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuePage.aspx.cs" Inherits="ELibrary.AdminBookIssuePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class="container-fluid my-5">
        <div class="row mt-1">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Book Issuing</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/book-stack_3389081.png" />
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="MemberIdTextBox" CssClass="form-control mb-3" runat="server" placeholder="Member Id"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="BookID" CssClass="form-control" runat="server" Text="Book Id"></asp:TextBox>
                                        <asp:Button ID="Button1" CssClass="btn btn-secondary" type="button" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control mb-3" runat="server" placeholder="Member Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Book Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text="Book Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control mb-3" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">End Date</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Button ID="userLoginButton" CssClass="btn btn-outline-success mb-3" type="button" Width="100%" runat="server" Text="Issue" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-outline-primary mb-3" type="button" Width="100%" runat="server" Text="Return" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Issue Book List</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <asp:GridView ID="gridView" CssClass="table table-success table-striped table-hover" runat="server"></asp:GridView>
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
