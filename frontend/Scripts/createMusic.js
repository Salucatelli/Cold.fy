var botaoMusica = document.getElementById("criarMusica");
var t = localStorage.getItem("token");
var mensagem = document.getElementById("loginErrorMessageMusic");

var urlParams = new URLSearchParams(window.location.search);
var id = urlParams.get('artistaid');

if (id != null) {
    var artistaid = document.getElementById("artistaId");
    artistaid.value = id;
}

botaoMusica.addEventListener("click", async function (e) {
    e.preventDefault();

    var nomeMusica = document.getElementById("nomeMusica").value;
    var duracaoMusica = document.getElementById("duracaoMusica").value;
    var artistaId = document.getElementById("artistaId").value;

    var data = {
        name: nomeMusica,
        Duration: duracaoMusica,
        artistId: parseInt(artistaId)
    }

    await axios.post("http://localhost:3000/music", data, {
        headers: {
            "Authorization": `Bearer ${t}`
        }
    }).then(response => {
        mensagem.innerText = "Musica criada com sucesso!";
        mensagem.style.color = "green";

        window.setTimeout(() => {
            window.location = "../index.html";
        }, 3000);
    }).catch(err => {
        console.log(err);
        mensagem.innerText = "Falha ao criar a Musica!";
        mensagem.style.color = "red";
    });
});