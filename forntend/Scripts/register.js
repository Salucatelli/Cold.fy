var button = document.getElementById('create');

button.addEventListener('click', function (event) {
    event.preventDefault();

    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var rePassword = document.getElementById("rePassword").value;

    if (password !== rePassword) {
        alert("As senhas não coincidem.");
        return;
    }

    var data = {
        username: username,
        password: password,
        rePassword: rePassword
    };

    axios.post('http://localhost:3000/user/register', data)
        .then(response => {

            delete data.rePassword;

            axios.post("http://localhost:3000/user/login", data) //Faz login na api
                .then((response) => {
                    token = response.data
                    localStorage.setItem("token", token);

                    window.location = "./profile.html";
                })
                .catch(err => {
                    console.log(err);
                    p.innerText = "Login ou senha inválidos.";
                });

        })
        .catch(error => {
            console.error(error);
            alert("Falha ao criar o usuário.");
        });
});