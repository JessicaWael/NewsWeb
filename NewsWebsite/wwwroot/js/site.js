function validate(form) {
    var returnValue = true;
    var username = frmRegister.Username.value;
    var email = frmRegister.Email.value;
    var password1 = frmRegister.Password.value;
    if (username.length < 8) {
        returnValue = false;
        alert("Your username must be at least\n6 characters long.\nPlease try again.");
        frmRegister.Username.focus();
    }
    if (email.length < 8) {
        returnValue = false;
        alert("Your email must be at least\n6 characters long.\nPlease try again.");
        frmRegister.Email.focus();
    }
    if (password1.length < 8) {
        returnValue = false;
        alert("Your password must be at least\n6 characters long.\nPlease try again.");
        frmRegister.Password.value = "";
        frmRegister.Password.focus();
    }

    return returnValue;
}

