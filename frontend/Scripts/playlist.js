var nome = document.getElementById('nomePlaylist');
var listaMusicas = document.getElementById('musicas');
var criarMusica = document.getElementById("criar");
var musicaId = document.getElementById('musicaId');
var listaMusicaDisponiveis = document.getElementById('listaMusicaDidponiveis');

var t = localStorage.getItem('token'); //Token

var urlParams = new URLSearchParams(window.location.search);
var playlistid = urlParams.get('id');

axios.get("http://localhost:3000/playlist/id", {
    headers: {
        "Authorization": `Bearer ${t}`
    },
    params: {
        id: playlistid
    }
}).then(response => {
    var playlist = response.data;
    var musicas = playlist[0].musics;

    nome.innerText = playlist[0].name;

    //Mostra as musicas da playlist-------------------------------------------------------
    musicas.forEach(musica => {
        var item = document.createElement("li");
        item.innerHTML = `<li>${musica.name} <button id="deletarMusicaPlaylist${musica.id}">Deletar</button></li> `;
        listaMusicas.appendChild(item);

        var botaoDeletarMusica = document.getElementById(`deletarMusicaPlaylist${musica.id}`);

        //Deletar musica da Playlist-------------------------------------------------------
        botaoDeletarMusica.addEventListener("click", (e) => {
            e.preventDefault()

            axios.delete("http://localhost:3000/playlist/deletemusic", {
                headers: {
                    "Authorization": `Bearer ${t}`
                },
                params: {
                    playlistid: playlistid,
                    musicid: musica.id
                }
            }).then(response => {
                console.log(response);
                window.location.reload();
            }).catch(error => {
                console.log(error);
            });
        });
    });
}).catch(err => console.log(err));

//Musicas Disponiveis-------------------------------------------------------
axios.get("http://localhost:3000/music").then(response => {

    var musicas = response.data;

    musicas.forEach(musica => {
        var item = document.createElement("li");
        item.innerText = musica.name + " - Id: " + musica.id;
        listaMusicasDisponiveis.appendChild(item);
    });
}).catch(err => console.log(err));


//Botão para criar musica-------------------------------------------------------
criarMusica.addEventListener('click', (e) => { //Metodo para adicionar musica
    e.preventDefault();

    console.log("Id da musica" + musicaId.value);

    data = {
        musicid: parseInt(musicaId.value)
    }

    axios.put(`http://localhost:3000/playlist/addmusic/${playlistid}/${musicaId.value}`, data, {
        headers: {
            "Authorization": `Bearer ${t}`
        },
    }).then(response => {
        console.log(response.data);
        window.location.reload();
    }).catch(err => console.log(err));
})

var botaoDeletarPlaylist = document.getElementById("deletarPlaylist");

botaoDeletarPlaylist.addEventListener("click", (e) => {
    e.preventDefault();

    axios.delete(`http://localhost:3000/playlist/delete`, {
        headers: {
            "Authorization": `Bearer ${t}`
        },
        params: {
            playlistid: playlistid
        }
    }).then(response => {
        console.log(response.data);
        window.location.href = "../Pages/userPlaylists.html";
    }).catch(err => console.log(err));
})

