var nome = document.getElementById('nomeArtista');
var listaMusicas = document.getElementById('musicas');

var t = localStorage.getItem('token'); //Token

var urlParams = new URLSearchParams(window.location.search);
var id = urlParams.get('id');

axios.get("http://localhost:3000/artist/id", {
    headers: {
        "Authorization": `Bearer ${t}`
    },
    params: {
        id: id
    }
}).then(response => {
    var artist = response.data;
    var musicas = artist[0].musics;

    nome.innerText = artist[0].name;

    musicas.forEach(musica => {
        var item = document.createElement("li");
        item.innerText = musica.name;
        listaMusicas.appendChild(item);
    });
}).catch(err => console.log(err));


//Botão para criar musica
// criarMusica.addEventListener('click', (e) => { //Metodo para adicionar musica
//     e.preventDefault();

//     console.log("Id da musica" + musicaId.value);

//     data = {
//         musicid: parseInt(musicaId.value)
//     }

//     axios.put(`http://localhost:3000/playlist/addmusic/${id}/${musicaId.value}`, data, {
//         headers: {
//             "Authorization": `Bearer ${t}`
//         },
//     }).then(response => {
//         console.log(response.data);
//         window.location.reload();
//     }).catch(err => console.log(err));
// })