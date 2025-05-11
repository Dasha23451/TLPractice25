function getCurrentUser() {
  return localStorage.getItem("currentUser");
}

function login(username) {
  if (!username) {
    return false;
  }
  localStorage.setItem("currentUser", username);
  return true;
}

function logout() {
  localStorage.removeItem("currentUser");
}

function isAuthenticated() {
  return !!getCurrentUser();
}

export { getCurrentUser, login, logout, isAuthenticated };
