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
const loginForm = document.getElementById("loginForm");

loginForm.addEventListener("submit", async (e) => {
  e.preventDefault();

  const email = document.getElementById("email").value;
  const password = passwordInput.value;

  try {
    const response = await fetch("https://your-backend-url/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        email,
        password,
      }),
    });

    const data = await response.json();

    if (response.ok) {
      alert("Login Successful ✅");

      // مثال تخزين التوكن
      localStorage.setItem("token", data.token);

      // تحويل صفحة
      window.location.href = "home.html";
    } else {
      alert(data.message || "Login Failed ");
    }
  } catch (error) {
    console.error(error);
    alert("Server Error ");
  }
});
