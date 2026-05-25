document.getElementById("registerForm").addEventListener("submit", function(e){
    e.preventDefault();

    const data = {
        fullName: document.getElementById("name").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };
    
    fetch("/*API*/", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    })
    .then(res => res.json())
    .then(result => {
        document.getElementById("msg").innerHTML = 
          "<span class='text-success'>" + result.message + "</span>";
    })
    .catch(err=>{
        document.getElementById("msg").innerHTML = 
          "<span class='text-danger'>Server error</span>";
    });
});
