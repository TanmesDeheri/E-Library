<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="ELibrary.AdminMemberManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class="container-fluid my-5">
        <div class="row mt-1">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/userLoginLogo.png" />
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-3">
                                <label class="mb-3">Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="MemberIdTextBox" CssClass="form-control" runat="server" placeholder="Member Id"></asp:TextBox>
                                        <asp:LinkButton ID="QueryButton" CssClass="btn btn-outline-primary" runat="server" OnClick="SearchMemberDetails"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label class="mb-3">Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="FullName" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="AccountStatus" CssClass="form-control me-2" runat="server" placeholder="Status"></asp:TextBox>
                                        <asp:LinkButton ID="ActiveButton" CssClass="btn btn-outline-success me-2" runat="server" OnClick="ActiveAccountStatus"><i class="fa-solid fa-user-check"></i></asp:LinkButton>
                                        <asp:LinkButton ID="PendingButton" CssClass="btn btn-outline-warning me-2" runat="server" OnClick="PendingAccountStatus"><i class="fa-solid fa-clock-rotate-left"></i></asp:LinkButton>
                                        <asp:LinkButton ID="DeactivateButton" CssClass="btn btn-outline-danger me-2" runat="server" OnClick="DeactivateAccountStatus"><i class="fa-solid fa-user-xmark"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-3">
                                <label class="mb-3">Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="DOB" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="ContactNumber" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label class="mb-3">Email Id</label>
                                <div class="form-group">
                                    <asp:TextBox ID="EmailId" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">State</label>
                                <div class="form-group">
                                    <asp:TextBox ID="StateName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="CityName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">PinCode</label>
                                <div class="form-group">
                                    <asp:TextBox ID="PinCode" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-12">
                                <label class="mb-3">Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="Address" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-12 text-center">
                                <div class="form-group">
                                    <asp:Button ID="userLoginButton" CssClass="btn btn-outline-danger mb-3" type="button" Width="100%" runat="server" Text="Delete User Permanently" OnClick="DeleteAuthorDetails"/>
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
                                <h3>Member List</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class=" overflow-auto">
                                <asp:SqlDataSource ID="sqldsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:connectionToDB %>" SelectCommand="SELECT * FROM MEMBER_MASTER_TABLE"></asp:SqlDataSource>
                                <asp:GridView ID="gridView" DataSourceID="sqldsSuppliers" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="MEMBER_ID" HeaderText="Member ID" />
                                        <asp:BoundField DataField="FULL_NAME" HeaderText="Full Name" />
                                        <asp:BoundField DataField="ACCOUNT_STATUS" HeaderText="Account Status" />
                                        <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number" />
                                        <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                                        <asp:BoundField DataField="STATE_NAME" HeaderText="State"/>
                                        <asp:BoundField DataField="CITY" HeaderText="City" />
                                    </Columns>
                                </asp:GridView>
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
    </div>
</asp:Content>
