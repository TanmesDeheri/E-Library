<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="ELibrary.AdminBookInventory" %>

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
                                <h3>Book Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/book-stack_3389081.png" id="imgTag" height="150px" width="100px" />
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col text-center mb-3">
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupload" runat="server" CssClass="form-control" onchange="readURL(this)" />
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-3">
                                <label class="mb-3">Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="bookId" CssClass="form-control" runat="server" placeholder="Book Id"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-outline-primary" runat="server" OnClick="QueryBookDetails"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label class="mb-3">Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="BookName" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="Language" CssClass="form-control mb-3" runat="server">
                                        <asp:ListItem Text="select" Value="select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label class="mb-3">Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="PublisherDropdownList" CssClass="form-control mb-3" runat="server">
                                        <asp:ListItem Text="select" Value="select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="AuthorDropdownList" CssClass="form-control mb-3" runat="server">
                                        <asp:ListItem Text="select" Value="select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label class="mb-3">Publisher Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="PublisherDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="Genre" runat="server" CssClass="form-control" SelectionMode="Multiple">
                                        <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                                        <asp:ListItem Text="Adventure" Value="Adventure"></asp:ListItem>
                                        <asp:ListItem Text="Animation" Value="Animation"></asp:ListItem>
                                        <asp:ListItem Text="Biography" Value="Biography"></asp:ListItem>
                                        <asp:ListItem Text="Comedy" Value="Comedy"></asp:ListItem>
                                        <asp:ListItem Text="Crime" Value="Crime"></asp:ListItem>
                                        <asp:ListItem Text="Documentary" Value="Documentary"></asp:ListItem>
                                        <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                                        <asp:ListItem Text="Family" Value="Family"></asp:ListItem>
                                        <asp:ListItem Text="Fantasy" Value="Fantasy"></asp:ListItem>
                                        <asp:ListItem Text="Film Noir" Value="Film Noir"></asp:ListItem>
                                        <asp:ListItem Text="History" Value="History"></asp:ListItem>
                                        <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                                        <asp:ListItem Text="Music" Value="Music"></asp:ListItem>
                                        <asp:ListItem Text="Musical" Value="Musical"></asp:ListItem>
                                        <asp:ListItem Text="Mystery" Value="Mystery"></asp:ListItem>
                                        <asp:ListItem Text="Romance" Value="Romance"></asp:ListItem>
                                        <asp:ListItem Text="Sci-Fi" Value="Sci-Fi"></asp:ListItem>
                                        <asp:ListItem Text="Sport" Value="Sport"></asp:ListItem>
                                        <asp:ListItem Text="Superhero" Value="Superhero"></asp:ListItem>
                                        <asp:ListItem Text="Thriller" Value="Thriller"></asp:ListItem>
                                        <asp:ListItem Text="War" Value="War"></asp:ListItem>
                                        <asp:ListItem Text="Western" Value="Western"></asp:ListItem>
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="Pages" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="BookEdition" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Book Cost/Unit</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-3">Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="ActualStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="CurrentStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="IssuedBooks" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-12">
                                <label class="mb-3">Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="BookDescription" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="AddBook" CssClass="btn btn-outline-success mb-3" type="button" Width="100%" runat="server" Text="Add" OnClick="HandleBookData" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="UpdateBook" CssClass="btn btn-outline-primary mb-3" type="button" Width="100%" runat="server" Text="Update" OnClick="HandleBookData" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="DeleteBook" CssClass="btn btn-outline-danger mb-3" type="button" Width="100%" runat="server" Text="Delete" OnClick="HandleBookData" />
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
                                <h3>Book Inventory List</h3>
                            </div>
                        </div>
                        <hr />
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <asp:SqlDataSource ID="sqldsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:connectionToDB %>" SelectCommand="SELECT * FROM BOOK_MASTER_TABLE"></asp:SqlDataSource>
                                <asp:GridView ID="gridView" CssClass="table table-success table-striped table-hover table-bordered" runat="server" DataSourceID="sqldsSuppliers" AutoGenerateColumns="false" DataKeyNames="BOOK_ID">
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
        <div class="row mb-3">
            <div class="col text-center">
                <a href="HomePage.aspx" class="nav-link">Back To Home Page</a>
            </div>
        </div>
    </div>
</asp:Content>
