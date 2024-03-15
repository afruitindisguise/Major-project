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
const SignIn = evt => {
    // get user entries from text boxes
    const password = $("#Password").value;
    const passwordV = $("#PasswordV").value;
    const username = $("#Username").value;

    //series of checks to verify user
    var U = false;
    var P = false;
    try {
        if (username == "") {
            $("#SignIn_error").textContent = "Username is required.";
            return;
        }
        // checks if username is in database
        if (username != "") {
            const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "GET", mode: "cors", headers: { "Accept": "text/json", "Origin": "sign.html" } });
            fetchPromise.then(response => {
                if (response.status == 204) {
                    $("#SignIn_error").textContent = "UserName does not exist";
                    U = true;
                    CEonFail(U, P);
                    throw new UserNameNotFoundError("Username does not exist", response.status);
                }
            })
        }
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
            CEonFail(U,P);
            return;
        }
    } catch (error) {
        console.error("There was an issue while processing");
        $("#SignIn_error").textContent = "There was an issue while processing Sign In";
      return;
    }
    finally {
        if ($("#SignIn_error").value == "") {
            $("#SignIn_error").textContent = "";
            alert("Sign In sucessfull");
        };
    }
};
    document.addEventListener("DOMContentLoaded", () => {
        $("#Sign_In").addEventListener("click", SignIn);
        $("#Username").focus();
    });