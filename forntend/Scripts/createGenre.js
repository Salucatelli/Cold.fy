var botaoMusica = document.getElementById("criar");
var t = localStorage.getItem("token");
var mensagem = document.getElementById("loginErrorMessage");


botaoMusica.addEventListener("click", async function (e) {
    e.preventDefault();

    var nome = document.getElementById("nome").value;
    var descricao = document.getElementById("descricao").value;

    var data = {
        name: nome,
        description: descricao
    }

    await axios.post("http://localhost:3000/musicalgenre", data, {
        headers: {
            "Authorization": `Bearer ${t}`
        }
    }).then(response => {
        mensagem.innerText = "Genero criada com sucesso!";
        mensagem.style.color = "green";
    }).catch(err => {
        console.log(err);
        mensagem.innerText = "Falha ao criar a Genero!";
        mensagem.style.color = "red";
    });
});