var botaoPlaylist = document.getElementById("criar");
var id;
var t = localStorage.getItem("token");
var mensagem = document.getElementById("loginErrorMessage");

axios.get(`http://localhost:3000/user/id`, // endpoint para pegar o Id
    {
        headers: {
            "Authorization": `Bearer ${t}`
        }
    }).then(response => {
        id = response.data;
    }).catch(err => {
        console.log(err);
    });

botaoPlaylist.addEventListener("click", function (e) {
    e.preventDefault();

    var nomePlaylist = document.getElementById("nome").value;
    var descricaoPlaylist = document.getElementById("descricao").value;

    var data = {
        name: nomePlaylist,
        description: descricaoPlaylist,
        userId: id
    }

    axios.post("http://localhost:3000/playlist", data, {
        headers: {
            "Authorization": `Bearer ${t}`
        }
    }).then(response => {
        mensagem.innerText = "Playlist criada com sucesso!";
        mensagem.style.color = "green";

        window.setTimeout(() => {
            window.location = "../Pages/userPlaylists.html";
        }, 3000);
    }).catch(err => {
        console.log(err);
        mensagem.innerText = "Falha ao criar a playlist!";
        mensagem.style.color = "red";
    });
});