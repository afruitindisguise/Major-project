const $ = selector => document.querySelector(selector);


const SignIn = evt => {
    // get user entries from text boxes
    const password = $("#Password").value;
    const passwordV = $("#PasswordV").value;
    const username = $("#Username").value;
    
    // checks if username is in database 
    if (username == "") {
        $("#SignIn_error").textContent = "Username is required.";
        return;
    }
   try {
       const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "GET", mode: "cors", headers: {"Accept": "text/json", "Origin": "sign.html"}});
        fetchPromise.then(response => {
            if (response.status == 204) {
                $("SignIn_error").textContent = "UserName does not exist";
                return;
            } else {
                alert(response.json());
            }
        });
    } catch (error) {
      $("SignIn_error").textContent = "There was a problem with finding Username"
      return;
    }
    if (password == "") {
        $("SignIn_error").textContent = "password required";
        return;
    } else if (password != passwordV) {
        $("SignIn_error")
        return;
    } else {
       $("#SignIn_error").textContent = ""; 
    };
};
    document.addEventListener("DOMContentLoaded", () => {
        // 
        $("#Sign_In").addEventListener("click", SignIn);
        // sets focus on first text box after the form loads
        $("#Username").focus();
    });