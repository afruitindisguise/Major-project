const $ = selector => document.querySelector(selector);
//clears failed entries in input
function CEonFail(U, P) {
    if (U == true) {
        $("#Username").value = "";
        $("#Username").focus();
    } if (P == true) {
        $("#Password").value = "";
        $("#PasswordV").value = "";
        $("#Password").focus();
    }
}
async function CheckAll() {
    const password = $("#Password").value;
    const passwordV = $("#PasswordV").value;
    const username = $("#Username").value;
    var U = false;
    var P = false;
    if (username == "") {
        $("#SignIn_error").textContent = "Username is required.";
        return false;
    }
    else {
        const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "GET", mode: "cors", headers: { "Accept": "text/json", "Origin": "sign.html" } });
        fetchPromise.then(response => {
            if (response.status == 204) {
                $("#SignIn_error").textContent = "UserName does not exist";
                U = true;
                CEonFail(U, P);
                $("#Password").disabled = true;
                $("#PasswordV").disabled = true;
                $("#Sign_In").textContent = "Check Username";
                return;
            }if (response.status == 200) {
                $("#Password").disabled = false;
                $("#PasswordV").disabled = false;
                $("#Sign_In").textContent = "Sign In";
                //will work on implementing Passwords later (dont understand how to protect them yet) 
                if (password == "") {
                    $("#SignIn_error").textContent = "password required";
                    return;
                    }
                    else if (passwordV == "") {
                    $("#SignIn_error").textContent = "Please verify password";
                    return;
                    }else if (password != passwordV) {
                    $("#SignIn_error").textContent = "Passwords must be the same";
                    P = true;
                    CEonFail(U, P);
                    return;
                    }else{
                    $("#SignIn_error").textContent = "";
                    alert("signed in");
                    localStorage.setItem("Username", username)
                    localStorage.setItem("Signed In", "true");
                    document.location = "menu.html";
                        return;
                    }
            }
        })
    }
}
const SignIn = evt => {
    CheckAll();
};
document.addEventListener("DOMContentLoaded", () => {
    if (localStorage.getItem("Signed In") == "true") {
        document.location = "menu.html";
    }
        $("#Sign_In").addEventListener("click", SignIn);
        $("#Username").addEventListener("input", () => {
            $("#Password").textContent = "";
            $("#PasswordV").textContent = "";
        })
        $("#Username").focus();
    });