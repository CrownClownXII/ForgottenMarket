import { UserManager } from "oidc-client";

const userManager = new UserManager({
  authority: "https://localhost:5001/",
  client_id: "reactapp",
  redirect_uri: "http://localhost:3000/",
  response_type: "id_token token",
  scope: "scope1 openid scope2",
  automaticSilentRenew: true,
  silent_redirect_uri: "http://localhost:3000/",
  post_logout_redirect_uri: "http://localhost:3000/",
});

export const login = async () => {
  const user = await completeAuth();

  if (user) {
    return user;
  }

  userManager.signinRedirect();
};

export const logout = () => {
  userManager.signoutRedirect();
};

export const completeAuth = async () => {
  try {
    return await userManager.signinRedirectCallback();
  } catch (e) {
    console.log(e);
  }

  return null;
};

export const getUser = () => {
  const user = localStorage.getItem("user");

  if (user) {
    try {
      return JSON.parse(user);
    } catch (e) {
      console.log(e);
    }
  }

  return null;
};

export const authOnAppInit = async () => {
  let user = await userManager.getUser();

  if (user) {
    return user;
  }

  user = await completeAuth();

  if (user) {
    return user;
  }

  return null;
};
