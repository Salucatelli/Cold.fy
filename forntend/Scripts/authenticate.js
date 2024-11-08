var h2 = document.getElementById("tokenStatus");

token = localStorage.getItem("token");

axios.get("http://localhost:3000/access", // endpoint para verificar se está logado
    {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    }).then(response => {
        h2.innerText = response.data;

        // if(response.)
        console.log(response);
    })
    .catch(err => {
        console.log(err);
        h2.innerText = "Token inválido ou expirado.";
    });