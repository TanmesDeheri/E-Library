<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="ELibrary.ViewBooks" %>

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
    <div class="container">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col text-center">
                        <h3>Book Inventory List</h3>
                    </div>
                </div>
                <hr />
                <div class="row mb-3">
                    <div class="col-md-12">
                        <asp:SqlDataSource ID="sqldsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:connectionToDB %>" SelectCommand="SELECT * FROM BOOK_MASTER_TABLE"></asp:SqlDataSource>
                        <asp:GridView ID="gridView" CssClass="table table-striped table-hover table-bordered" runat="server" DataSourceID="sqldsSuppliers" AutoGenerateColumns="false" DataKeyNames="BOOK_ID">
                            <Columns>
                                <asp:BoundField DataField="BOOK_ID" HeaderText="Book ID" ReadOnly="true" SortExpression="BOOK_ID" HeaderStyle-CssClass="book-id-column" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label runat="server" ID="BookTitle" CssClass="text-capitalize" Text='<%# Eval("BOOK_NAME") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <span>Author-<asp:Label runat="server" ID="AuthorNameLabel" CssClass="text-capitalize" Text='<%# Eval("AUTHOR_NAME") %>'></asp:Label></span> | 
                                                            <span>Genre-<asp:Label runat="server" ID="Label1" CssClass="text-capitalize" Text='<%# Eval("GENRE") %>'></asp:Label></span> |
                                                            <span>Language-<asp:Label runat="server" ID="Label2" CssClass="text-capitalize" Text='<%# Eval("BOOK_LANGUAGE") %>'></asp:Label></span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <span>Publisher-<asp:Label runat="server" ID="Label3" CssClass="text-capitalize" Text='<%# Eval("PUBLISHER_NAME") %>'></asp:Label></span> | 
                                                            <span>Publish Date-<asp:Label runat="server" ID="Label4" CssClass="text-capitalize" Text='<%# Eval("PUBLISH_DATE") %>'></asp:Label></span> |
                                                            <span>Pages-<asp:Label runat="server" ID="Label5" CssClass="text-capitalize" Text='<%# Eval("NO_OF_PAGES") %>'></asp:Label></span> |
                                                            <span>Edition-<asp:Label runat="server" ID="Label6" CssClass="text-capitalize" Text='<%# Eval("BOOK_EDITION") %>'></asp:Label></span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <span>Cost-<asp:Label runat="server" ID="Label7" CssClass="text-capitalize"></asp:Label></span> | 
                                                            <span>Actual Stock-<asp:Label runat="server" ID="Label8" CssClass="text-capitalize" Text='<%# Eval("ACTUAL_STOCK") %>'></asp:Label></span> |
                                                            <span>Available-<asp:Label runat="server" ID="Label9" CssClass="text-capitalize" Text='<%# Eval("CURRENT_STOCK") %>'></asp:Label></span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            Description:<asp:Label runat="server" ID="Label10" CssClass="text-capitalize" Text='<%# Eval("BOOK_DESCRIPTION") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Image ID="BookImage" runat="server" CssClass="img-fluid" ImageUrl='<%# Eval("BOOK_IMAGE_LINK") %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
