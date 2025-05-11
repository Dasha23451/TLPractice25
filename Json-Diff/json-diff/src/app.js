import { logout, isAuthenticated } from "./auth.js";
import { navigate, loadRoute, updateAuthUI } from "./router.js";

document.addEventListener("DOMContentLoaded", () => {
  updateAuthUI();

  document.getElementById("logo").addEventListener("click", (e) => {
    e.preventDefault();
    navigate("promo");
  });

  document.getElementById("auth-link").addEventListener("click", (e) => {
    e.preventDefault();
    if (isAuthenticated()) {
      logout();
      updateAuthUI();
      navigate("promo");
    } else {
      navigate("login");
    }
  });

  const initialRoute = window.location.hash.substring(1) || "promo";
  loadRoute(initialRoute);

  window.addEventListener("popstate", () => {
    const route = window.location.hash.substring(1) || "promo";
    loadRoute(route);
  });
});
