var t = localStorage.getItem("token");
var criar = document.getElementById("criar");
var mensagem = document.getElementById("mensagem");

axios.get("http://localhost:3000/user/id", // endpoint para verificar se está logado
    {
        headers: {
            "Authorization": `Bearer ${t}`,
        }
    }).then(response => {
    })
    .catch(err => {
        console.log(err)
        window.location = "../index.html";
    });


criar.addEventListener("click", (e) => { //Criar um Artista
    e.preventDefault();

    var nome = document.getElementById("nome").value;
    var descricao = document.getElementById("descricao").value;
    var generoId = document.getElementById("generoId").value;
    var data;

    if (!generoId) {
        data = {
            Name: nome,
            Description: descricao
        }
    }
    else {
        data = {
            Name: nome,
            Description: descricao,
            MusicalGenreId: generoId
        }
    }

    axios.post("http://localhost:3000/artist", data,
        {
            headers: {
                "Authorization": `Bearer ${t}`,
            }
        }
    ).then(response => {
        var artistaid = response.data[0].id;

        mensagem.style.color = "green";
        mensagem.innerText = "Artista Criado com sucesso";

        window.setTimeout(() => {
            window.location = `../Pages/artist.html?id=${artistaid}`;
        }, 3000)

    }).catch(err => {
        mensagem.style.color = "red";
        mensagem.innerText = "Erro ao criar Artista";
        console.log(err);
    })
})
