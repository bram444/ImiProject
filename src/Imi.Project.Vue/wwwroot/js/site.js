// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const baseUrl = "https://localhost:5001/api/";

const roleKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
const nameIdentifierKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
const nameKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
const emailKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
const dateOfBirthKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth";
const approveTermKey = "approved";

const adminRoleValue = "Admin";

// Axios configuration
let axiosConfig = {
    headers: { Authorization: `Bearer ${sessionStorage.getItem("token")}` }
};

//Methods
function getDecodedToken() {
    const token = sessionStorage.getItem("token");
    if (token == null) {
        return "";
    }
    else {
        const decodedToken = jwt_decode(token);
        return decodedToken;
    }
}

function readUserNameFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameKey];
}

function readUserIdFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameIdentifierKey];
}

function readUserBirthDayFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[dateOfBirthKey];
}

function readUserRoleFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[roleKey];
}

function hasUserAdminRole() {
    if (readUserRoleFromToken() === adminRoleValue) {
        return true;
    }
    else {
        return false;
    }
}