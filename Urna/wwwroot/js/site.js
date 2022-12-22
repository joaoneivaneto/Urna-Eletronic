const url = "https://localhost:7064/api/RegistroCandidatos"
const digito1 = document.getElementById("digito1")
const digito2 = document.getElementById("digito2")

function RetornaLegenda(numero1, numero2) {
    var result = numero1 + numero2;
    var legenda = parseInt(result);

    return legenda
}
console.log(fetch('https://localhost:7064/api/RegistroCandidatos').then(response))
// async function getPost() {
//     const response = await fetch(url);



//     const data = await response.json();

//     console.log(data);


//   }
// getPost();

