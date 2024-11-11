var nome = document.getElementById('nomePlaylist');
var listaMusicas = document.getElementById('musicas');
var criarMusica = document.getElementById("criar");
var musicaId = document.getElementById('musicaId');

var t = localStorage.getItem('token'); //Token

var urlParams = new URLSearchParams(window.location.search);
var id = urlParams.get('id');

axios.get("http://localhost:3000/playlist/id", {
    headers: {
        "Authorization": `Bearer ${t}`
    },
    params: {
        id: id
    }
}).then(response => {
    var playlist = response.data;
    var musicas = playlist[0].musics;

    nome.innerText = playlist[0].name;
    console.log(musicas);

    musicas.forEach(musica => {
        var item = document.createElement("li");
        item.innerText = musica.name + "\n" + musica.duration + "s";
        listaMusicas.appendChild(item);
    });
}).catch(err => console.log(err));

nome.innerHTML = '<a href="google.com" target="_blank">testes</a>';


//Botão para criar musica
criarMusica.addEventListener('click', (e) => { //Metodo para adicionar musica
    e.preventDefault();

    console.log("Id da musica" + musicaId.value);

    data = {
        musicid: parseInt(musicaId.value)
    }

    axios.put(`http://localhost:3000/playlist/addmusic/${id}/${musicaId.value}`, data, {
        headers: {
            "Authorization": `Bearer ${t}`
        },
    }).then(response => {
        console.log(response.data);
        window.location.reload();
    }).catch(err => console.log(err));
})