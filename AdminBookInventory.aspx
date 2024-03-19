<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="ELibrary.AdminBookInventory" %>

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
                                <h3>Book Details</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center mb-3">
                                <img src="Images/book-stack_3389081.png" />
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col text-center mb-3">
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupload" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-3">
                                <label class="mb-3">Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="MemberIdTextBox" CssClass="form-control" runat="server" placeholder="Book Id"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-outline-primary" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label class="mb-3">Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="BookID" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
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
                                    <asp:DropDownList ID="DropDownList3" CssClass="form-control mb-3" runat="server">
                                        <asp:ListItem Text="select" Value="select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control mb-3" runat="server">
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
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="mb-3">Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-sm-12">
                                <label class="mb-3">Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="Address" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class=" row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="userLoginButton" CssClass="btn btn-outline-success mb-3" type="button" Width="100%" runat="server" Text="Add" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-outline-primary mb-3" type="button" Width="100%" runat="server" Text="Update" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Button ID="Button3" CssClass="btn btn-outline-danger mb-3" type="button" Width="100%" runat="server" Text="Delete" />
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
                                <h3>Book Inventory List</h3>
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
        <div class="row mb-3">
            <div class="col text-center">
                <a href="HomePage.aspx" class="nav-link">Back To Home Page</a>
            </div>
        </div>
    </div>
</asp:Content>
