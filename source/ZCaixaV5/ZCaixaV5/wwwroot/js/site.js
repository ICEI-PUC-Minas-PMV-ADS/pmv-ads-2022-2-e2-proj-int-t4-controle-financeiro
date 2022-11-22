// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function validar() {
    //CatId
    if (document.getElementById("<%=CatId.ClientID%>").value == null) {
        alert("Informe a Categoria");
        document.getElementById("<%=CatId.ClientID%>").focus();
        return false;
    }
    //Data
    if (document.getElementById("<%=Data.ClientID%>").value == "") {
        alert("Informe a Data");
        document.getElementById("<%=Data.ClientID%>").focus();
        return false;
        //Checar Data
        var ck_nome = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
        var tempNome = document.getElementById("<%=Data.ClientID%>").value;
        var matchNome = tempNome.match(ck_nome);
        if (matchNome == null) {
            alert("Data Inválida  ");
            document.getElementById("<%=Data.ClientID %>").focus();
            return false;
        }
    }
    //Descrição
    if (document.getElementById("<%=Descricao.ClientID%>").value == "") {
        alert("Informe a Descrição");
        document.getElementById("<%=Descricao.ClientID%>").focus();
        return false;
    }
    //Alfanumerico e espaço(' '),nao aceita numeros e nem caracteres especiais min 5 e max 45 caracteres. 
    var ck_nome = /^{5,50}$/;
    var tempNome = document.getElementById("<%=Descricao.ClientID%>").value;
    var matchNome = tempNome.match(ck_nome);
    if (matchNome == null) {
        alert("Descrição Inválida  ");
        document.getElementById("<%=Descricao.ClientID %>").focus();
        return false;
    }
    //TipoLanId
    if (document.getElementById("<%=TipoLanId.ClientID%>").value == null) {
        alert("Informe o Tipo do Lançamento");
        document.getElementById("<%=TipoLanId.ClientID%>").focus();
        return false;
    }
    //Valor
    if (document.getElementById("<%=Valor.ClientID%>").value == null) {
        alert("Informe o Valor");
        document.getElementById("<%=Valor.ClientID%>").focus();
        return false;
    }

    alert("Lançamento Feito com sucesso");
    return true;
}

// Write your JavaScript code.
