const url = "http://localhost:3000/";

// Iniciating token on Axios
// axios.interceptors.request.use((config) => { // envia o token automaticamente no axios
//     const token = localStorage.getItem("token");
//     const authRequestToken = token ? `Bearer ${token}` : "";
//     config.headers['Authorization'] = authRequestToken;
//     return config;
// })

var botaoLogin = document.getElementById("login");
var botaoAuthenticate = document.getElementById("authenticateToken");
var data;
let token;

//Send token button
botaoLogin.addEventListener("click", async function (event) {
    event.preventDefault();

    var nome = document.getElementById("username").value;
    var senha = document.getElementById("password").value;
    var p = document.getElementById("token-text");

    var data = {
        username: nome,
        password: senha
    }

    await axios.post("http://localhost:3000/user/login", data) //Faz login na api
        .then((response) => {
            token = response.data
            localStorage.setItem("token", token);

            window.location = "../profile.html";
            //p.innerText = token;
        })
        .catch(err => {
            console.log(err);
            p.innerText = "Login ou senha inválidos.";
        });
});

//Authenticate button
botaoAuthenticate.addEventListener("click", async function (e) {
    e.preventDefault();

    var t = document.getElementById("token").value;
    var p = document.getElementById("TokenResponse");

    await axios.get("http://localhost:3000/access", // endpoint para verificar se está logado
        {
            headers: {
                "Authorization": `Bearer ${t}`
            }
        }).then(response => {
            p.innerText = response.data.token; token;
            console.log(response);
        })
        .catch(err => console.log(err));
})



