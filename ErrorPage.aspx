<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ELibrary.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMasterContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="container-fluid">
                    <h1 class="mt-5">Oops! Something Went Wrong!!!!</h1>
                    <div class="accordion accordion-flush" id="accordionFlushExample">
                        <div class="accordion-item">
                            <h2 class="accordion-header" id="flush-headingOne">
                                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                                    <asp:Label ID="errorText" runat="server" CssClass="font-monospace"></asp:Label>
                                </button>
                            </h2>
                            <div id="flush-collapseOne" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                                <div class="accordion-body">
                                    <asp:Label ID="errorTextDesc" runat="server" CssClass="font-monospace"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <img src="Images/errorSign.svg" />
            </div>
        </div>
        <div class="container-fluid"></div>
    </div>
</asp:Content>
