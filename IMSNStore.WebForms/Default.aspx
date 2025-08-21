<%@ Page Title="Buscar Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IMSNStore.Application._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2>Consulta de Preço de Produto</h2>
        <hr />
        <p>
            Nome do Produto:
            <asp:TextBox ID="txtProduto" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Preço" OnClick="btnBuscar_Click" />
        </p>
        <p>
            Preço:
            <asp:Label ID="lblPreco" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
        </p>
        <p>
            Status:
            <asp:Label ID="lblStatus" runat="server" Font-Italic="true" ForeColor="Gray"></asp:Label>
        </p>
        <hr />
        <a class="btn btn-secondary" runat="server" href="~/Create">Criar Produtos</a>
    </main>


</asp:Content>
