const $ = selector => document.querySelector(selector);

document.addEventListener("DOMContentLoaded", () => {
    setInterval((check) => {
        if (localStorage.getItem("Signed In") == "false") {
            document.location = "title.html";
           clearInterval(check);
        }
    }, 1);
    $("#Welcome").textContent += localStorage.getItem("Username");
    $("#Sign_out").addEventListener("click", () => {
        localStorage.setItem("Signed In", "false");
        localStorage.removeItem("Username");
        document.location = "sign.html";
    })
})