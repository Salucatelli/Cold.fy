var botaoLogin = document.getElementById("login");
var errorMessage = document.getElementById("loginErrorMessage");
var data;
let token;

//Send token button
botaoLogin.addEventListener("click", async function (event) {
    event.preventDefault();

    var nome = document.getElementById("username").value;
    var senha = document.getElementById("password").value;

    var data = {
        username: nome,
        password: senha
    }

    await axios.post("http://localhost:3000/user/login", data) //Faz login na api
        .then((response) => {
            token = response.data
            localStorage.setItem("token", token);

            window.location = "./profile.html";
        })
        .catch(err => {
            console.log(err);
            errorMessage.innerText = "Login ou senha inválidos.";
        });
});