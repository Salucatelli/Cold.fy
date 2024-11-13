// Iniciating token on Axios
// axios.interceptors.request.use((config) => { // envia o token automaticamente no axios
//     const token = localStorage.getItem("token");
//     const authRequestToken = token ? `Bearer ${token}` : "";
//     config.headers['Authorization'] = authRequestToken;
//     return config;
// })

var botaoLogin = document.getElementById("login");
var botaoAuthenticate = document.getElementById("authenticateToken");
var profile = document.getElementById("profile");
var t = localStorage.getItem("token");
var playlistid;

// profile.addEventListener("click", (e) => {  //metodo para pegar oId
//     e.preventDefault();

//     axios.get(`http://localhost:3000/user/id`,
//         {
//             headers: {
//                 "Authorization": `Bearer ${t}`
//             }
//         }).then(response => {
//             playlistid = response.data;
//             window.location = "../Pages/profile.html";
//         }).catch(err => {
//             console.log(err);
//             window.location = "../Pages/login.html";
//         });
// });


//Adicionando a lista de Musica, Artistas e Generos
var listaMusicas = document.getElementById("listaMusicas");
var listaArtistas = document.getElementById("listaArtistas");
var listaGeneros = document.getElementById("listaGeneros");

axios.get("http://localhost:3000/music").then(response => { //Musicas
    var musicas = response.data;

    musicas.forEach(musica => {
        var item = document.createElement("li");
        item.innerText = musica.name;
        listaMusicas.appendChild(item);
    });
}).catch(err => console.log(err));

axios.get("http://localhost:3000/artist").then(response => { //Artistas
    var artistas = response.data;

    artistas.forEach(artista => {
        var item = document.createElement("li");
        item.innerHTML = `<li><a href="../Pages/artist.html?id=${artista.id}">${artista.name}</a> <br> ${artista.id}</li>`;
        listaArtistas.appendChild(item);
    });
}).catch(err => console.log(err));


axios.get("http://localhost:3000/musicalgenre").then(response => { //Generos
    var generos = response.data;

    generos.forEach(genero => {
        var item = document.createElement("li");
        item.innerHTML = `${genero.name} <br> id: ${genero.id}`;
        listaGeneros.appendChild(item);
    });
}).catch(err => console.log(err));





