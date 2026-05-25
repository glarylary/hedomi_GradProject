// ==========================
// Password Eye Toggle
// ==========================
const togglePassword = document.getElementById("togglePassword");
const passwordInput = document.getElementById("password");

togglePassword.addEventListener("click", () => {
  const isPassword = passwordInput.type === "password";

  passwordInput.type = isPassword ? "text" : "password";

  togglePassword.classList.toggle("fa-eye");
  togglePassword.classList.toggle("fa-eye-slash");
});

// ==========================
// Login Form Submit
// ==========================
async function login(email, password) {
    const response = await fetch('https://localhost:7131/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    });

    if (!response.ok) {
        alert('Invalid credentials');
        return;
    }

    const data = await response.json();
    localStorage.setItem('token', data.token);
    localStorage.setItem('name', data.name);
    localStorage.setItem('email', data.email);
    
    window.location.href = "index.html"; // redirect after login
}
