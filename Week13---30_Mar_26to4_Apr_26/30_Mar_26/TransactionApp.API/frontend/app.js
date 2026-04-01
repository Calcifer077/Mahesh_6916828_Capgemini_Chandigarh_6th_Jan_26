const API = "http://localhost:5283/api";

async function login() {
  const username = document.getElementById("username").value;
  const password = document.getElementById("password").value;

  if (!username || !password) {
    alert("Fill all fields");
    return;
  }

  const res = await fetch(`${API}/Auth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password }),
  });

  if (!res.ok) {
    alert("Invalid login");
    return;
  }

  const data = await res.json();
  localStorage.setItem("token", data.token);

  window.location = "dashboard.html";
}

async function loadTransactions() {
  const token = localStorage.getItem("token");

  const res = await fetch(`${API}/transactions`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

  const data = await res.json();

  const table = document.getElementById("data");

  data.forEach((t) => {
    table.innerHTML += `
            <tr>
                <td>${t.amount}</td>
                <td>${new Date(t.date).toLocaleDateString()}</td>
                <td>${t.type}</td>
            </tr>
        `;
  });
}
