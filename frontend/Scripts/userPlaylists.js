var listaPlaylist = document.getElementById('listaPlaylist');
var t = localStorage.getItem('token');
var id;
var playlists;

axios.get(`http://localhost:3000/user/id`, // endpoint para pegar o Id
    {
        headers: {
            "Authorization": `Bearer ${t}`
        }
    }).then(response => {
        id = response.data;

        axios.get("http://localhost:3000/playlist/user",
            {
                headers: {
                    "Authorization": `Bearer ${t}`
                },
                params: {
                    id: id
                }
            }).then(response => {
                var playlists = response.data;
                console.log(playlists);

                //+ "\n" + playlist.musics.map(m => m.name + "\n")

                playlists.forEach(playlist => {
                    var item = document.createElement("li");
                    conteudo = playlist.name;
                    item.innerHTML = `<li><a href="./playlist.html?id=${playlist.id}">${conteudo}</a></li>`;
                    listaPlaylist.appendChild(item);
                });
            }).catch(err => console.log(err));

    }).catch(err => {
        console.log(err);
        alert("Não foi possível carregar as playlists.");
    });


