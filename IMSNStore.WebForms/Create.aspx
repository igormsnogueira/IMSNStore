<%@ Page Title="Criar Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IMSNStore.Application._Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2>Criar Novo Produto</h2>
        <hr />
        <p>
            Nome do Produto:
            <asp:TextBox ID="txtNewProductName" runat="server"></asp:TextBox>
        </p>
        <p>
            Preço:
            <asp:TextBox ID="txtNewProductPrice" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnCreateProduct" runat="server" Text="Criar Produto" OnClick="btnCreateProduct_Click" />
        </p>
        <p>
            Status da Criação:
            <asp:Label ID="lblCreateStatus" runat="server" Font-Bold="true"></asp:Label>
        </p>

        <hr />
        <a class="btn btn-secondary" runat="server" href="~/">Buscar Produtos</a>
    </main>


</asp:Content>
