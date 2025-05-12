import { JsonDiff } from "./json-diff.js";
import { login, isAuthenticated as checkAuth, getCurrentUser } from "./auth.js";

const routes = {
  promo: renderPromo,
  login: renderLogin,
  diff: renderDiff,
};

function navigate(route) {
  window.history.pushState({}, "", `#${route}`);
  loadRoute(route);
}

function loadRoute(route) {
  if (route.startsWith("diff")) {
    renderDiff();
    return;
  }

  const renderFunction = routes[route] || routes["promo"];
  renderFunction();
}

function renderPromo() {
  const authStatus = checkAuth();
  const currentUser = getCurrentUser();

  console.log("User authenticated:", authStatus);
  console.log("Current user:", currentUser);

  let promoHTML = `
    <div class="promo-container">
      <p>Compare 
        <span style="color: red; font-weight: bold;">two JSON objects</span> 
          and see the 
        <span style="color: orange; font-weight: bold;">differences</span>
      </p>
  `;

  if (authStatus) {
    promoHTML += `
      <a href="#diff" class="start-button">Start</a>
    `;
  }

  document.getElementById("app-content").innerHTML = promoHTML + `</div>`;
}

function renderLogin() {
  const loginHTML = `
    <div class="login-form">
      <h2>Login Form</h2>
      <form id="login-form">
        <div class="form-group">
          <label for="username" style="margin-right: 1rem;">LOGIN</label>
          <input type="text" id="username" name="username" required>
          <div id="login-error" class="error-message"></div>
        </div>
        <div class="form-actions">
          <button type="submit" class="login-button">SIGN IN</button>
        </div>
      </form>
    </div>
  `;

  document.getElementById("app-content").innerHTML = loginHTML;

  const form = document.getElementById("login-form");
  const usernameInput = document.getElementById("username");
  const errorElement = document.getElementById("login-error");

  usernameInput.addEventListener("input", () => {
    errorElement.textContent = "";
  });

  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const username = usernameInput.value.trim();

    console.log(errorElement);
    if (!username) {
      errorElement.textContent = "Обязательное поле";
      usernameInput.focus();
      return;
    }

    if (login(username)) {
      updateAuthUI();
      navigate("promo");
    }
  });
}

function renderDiff() {
  if (!checkAuth()) {
    navigate("promo");
    return;
  }

  const diffHTML = `
    <div class="json-diff-container">
      <form id="json-diff-form" class="json-diff-form">
        <div class="json-textareas">
          <div class="json-textarea-container">
            <label for="old-json">OLD JSON</label>
            <textarea id="old-json" class="json-textarea"></textarea>
            <div id="old-json-error" class="json-error"></div>
          </div>
          <div class="json-textarea-container">
            <label for="new-json">NEW JSON</label>
            <textarea id="new-json" class="json-textarea"></textarea>
            <div id="new-json-error" class="json-error"></div>
          </div>
        </div>
        <button type="submit" class="diff-button">SHOW DIFFERENCE</button>
      </form>
      <div id="diff-result" class="diff-result"></div>
    </div>
  `;

  document.getElementById("app-content").innerHTML = diffHTML;

  const form = document.getElementById("json-diff-form");
  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const oldJson = document.getElementById("old-json").value.trim();
    const newJson = document.getElementById("new-json").value.trim();
    const oldError = document.getElementById("old-json-error");
    const newError = document.getElementById("new-json-error");
    const resultDiv = document.getElementById("diff-result");

    oldError.textContent = "";
    newError.textContent = "";
    resultDiv.innerHTML = "";

    let hasErrors = false;

    if (!oldJson) {
      oldError.textContent = "Некорректный JSON";
      hasErrors = true;
    } else {
      try {
        JSON.parse(oldJson);
      } catch (e) {
        oldError.textContent = "Некорректный JSON";
        hasErrors = true;
      }
    }

    if (!newJson) {
      newError.textContent = "Обязательное поле";
      hasErrors = true;
    } else {
      try {
        JSON.parse(newJson);
      } catch (e) {
        newError.textContent = "Некорректный JSON";
        hasErrors = true;
      }
    }

    if (hasErrors) {
      return;
    }

    try {
      const result = JsonDiff.create(oldJson, newJson);
      resultDiv.innerHTML = `
      <h2>DIFFERENCE</h2>
      <pre>${JSON.stringify(result, null, 2)}</pre>
    `;
    } catch (error) {
      oldError.textContent = "Ошибка при сравнении JSON";
      newError.textContent = "Ошибка при сравнении JSON";
    }
  });
}

function updateAuthUI() {
  const authLink = document.getElementById("auth-link");
  const welcomeMessage = document.getElementById("welcome-message");

  if (checkAuth()) {
    authLink.textContent = "Log out";
    welcomeMessage.textContent = `Hello, ${getCurrentUser()}!`;
  } else {
    authLink.textContent = "Log in";
    welcomeMessage.textContent = "";
  }
}

export { navigate, loadRoute, updateAuthUI };
