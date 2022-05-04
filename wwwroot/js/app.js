const preloader = document.querySelector(".preload"); // declara e pega o preload

//get rid of preloader after specific time
 setTimeout(function () { // seta uma função de tempo para acabar
    FetchData();
}, 7000);
function FetchData() {

    preloader.classList.add("finish"); // adiciona o finish no lugar do preload
    //window.location.href = "/Controllers/Pokemon/Home1"
    window.location.href="/Pokemon/Home1";
}
