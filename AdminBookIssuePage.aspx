<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuePage.aspx.cs" Inherits="ELibrary.AdminBookIssuePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
        function readURL(input) {
            if (input.files && input.files[0]) {
                let reader = new FileReader();
                reader.onload = (e) => {
                    $('#imgTag').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <style>
        .book-id-column {
            width: 5vw;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class="container-fluid my-5">
        <div class="row mt-1">
            <div class="col-md-5">
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
                                        <asp:TextBox ID="BookID" CssClass="form-control" runat="server" placeholder="Book Id"></asp:TextBox>
                                        <asp:Button ID="QueryButton" CssClass="btn btn-secondary" type="button" runat="server" Text="Go" OnClick="HandleButtonClickEvents" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="memberName" CssClass="form-control mb-3" runat="server" placeholder="Member Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">Book Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="bookName" CssClass="form-control" runat="server" placeholder="Book Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="mb-3">Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="issueDate" CssClass="form-control mb-3" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label class="mb-3">End Date</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="returnDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Button ID="issueButton" CssClass="btn btn-outline-success mb-3" type="button" Width="100%" runat="server" Text="Issue" OnClick="HandleButtonClickEvents" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Button ID="returnButton" CssClass="btn btn-outline-primary mb-3" type="button" Width="100%" runat="server" Text="Return" OnClick="HandleButtonClickEvents" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
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
                                <asp:SqlDataSource runat="server" ID="sqlDs" ConnectionString='<%$ ConnectionStrings:OnlineLibraryManagementDBConnectionString %>' ProviderName='<%$ ConnectionStrings:OnlineLibraryManagementDBConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [BOOK_ISSUE_TABLE]"></asp:SqlDataSource>
                                <asp:GridView ID="gridView" CssClass="table table-success table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="sqlDs" OnRowDataBound="DefaultersRecord">
                                    <Columns>
                                        <asp:BoundField DataField="MEMBER_ID" HeaderText="MEMBER ID" SortExpression="MEMBER_ID"></asp:BoundField>
                                        <asp:BoundField DataField="MEMBER_NAME" HeaderText="MEMBER NAME" SortExpression="MEMBER_NAME"></asp:BoundField>
                                        <asp:BoundField DataField="BOOK_ID" HeaderText="BOOK ID" SortExpression="BOOK_ID"></asp:BoundField>
                                        <asp:BoundField DataField="BOOK_NAME" HeaderText="BOOK NAME" SortExpression="BOOK_NAME"></asp:BoundField>
                                        <asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUE DATE" SortExpression="ISSUE_DATE"></asp:BoundField>
                                        <asp:BoundField DataField="DUE_DATE" HeaderText="DUE DATE" SortExpression="DUE_DATE"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
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
