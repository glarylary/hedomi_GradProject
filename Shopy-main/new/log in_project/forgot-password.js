// ==========================
// Eye Toggle Function
// ==========================
document.addEventListener("DOMContentLoaded", () => {

  function togglePassword(inputId, iconId) {
    const input = document.getElementById(inputId);
    const icon = document.getElementById(iconId);

    if (!input || !icon) return;

    icon.addEventListener("click", () => {
      const isPassword = input.type === "password";

      input.type = isPassword ? "text" : "password";

      icon.classList.toggle("fa-eye");
      icon.classList.toggle("fa-eye-slash");
    });
  }

  togglePassword("newPassword", "toggleNewPassword");
  togglePassword("confirmPassword", "toggleConfirmPassword");

});

// ==========================
// Reset Password Submit
// ==========================
const resetForm = document.getElementById("resetForm");
const passwordError = document.getElementById("passwordError");

resetForm.addEventListener("submit", async (e) => {
  e.preventDefault();

  const email = document.getElementById("email").value;
  const phone = document.getElementById("phone").value;
  const newPassword = document.getElementById("newPassword").value;
  const confirmPassword = document.getElementById("confirmPassword").value;

  // Reset error
  passwordError.style.display = "none";
  passwordError.textContent = "";

  if (newPassword !== confirmPassword) {
    passwordError.textContent = "Passwords do not match";
    passwordError.style.display = "block";
    return;
  }

  try {
    const response = await fetch("https://your-backend-url/reset-password", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        email,
        phone,
        newPassword,
      }),
    });

    const data = await response.json();

    if (response.ok) {
      window.location.href = "login.html";
    } else {
      passwordError.textContent = data.message || "Something went wrong";
      passwordError.style.display = "block";
    }
  } catch (error) {
    console.error(error);
    passwordError.textContent = "Server error";
    passwordError.style.display = "block";
  }
});
document.getElementById("confirmPassword").addEventListener("input", () => {
  passwordError.style.display = "none";
});

