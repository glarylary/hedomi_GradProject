async function register(name, email, password, passwordConfirmed) {
    const response = await fetch('https://localhost:7131/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, email, password, passwordConfirmed })
    });

    if (!response.ok) {
        alert('Registration failed');
        return;
    }

    const data = await response.json();
    localStorage.setItem('token', data.token);
    localStorage.setItem('name', data.fullName);
    localStorage.setItem('email', data.email);

    window.location.href = 'g:\\programs\\HEDOMI\\Shopy-main\\index.html'; // redirect after register
}