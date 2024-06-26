﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPublisherManagement.aspx.cs" Inherits="ELibrary.adminPublisherManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class="container my-5">
        <div class="row mt-1">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Publisher Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/userLoginLogo.png" />
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="PublisherID" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Button ID="Button1" CssClass="btn btn-secondary" type="button" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label class="mb-3">Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="PublisherName" CssClass="form-control mb-3" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class=" row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="userLoginButton" CssClass="btn btn-outline-success mb-3" type="button" Width="100%" runat="server" Text="Add"  OnClick="AddPublisherDetails"/>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-outline-primary mb-3" type="button" Width="100%" runat="server" Text="Update" OnClick="EditPublisherDetails" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="Button3" CssClass="btn btn-outline-danger mb-3" type="button" Width="100%" runat="server" Text="Delete" OnClick="DeletePublisherDetails" />
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
                                <h3>Publisher List</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <asp:SqlDataSource ID="sqldsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:connectionToDB %>" SelectCommand="SELECT * FROM PUBLISHER_MASTER_TABLE"></asp:SqlDataSource>
                                <asp:GridView ID="gridView" CssClass="table table-success table-striped table-hover" runat="server" DataSourceID="sqldsSuppliers"></asp:GridView>
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
