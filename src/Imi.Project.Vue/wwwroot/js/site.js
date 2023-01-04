// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const baseUrl = "https://localhost:5001/api/";

const roleClaimKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
const nameIdentifierClaimKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
const nameClaimKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
const emailClaimKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
const dateOfBirthClaimKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth";
const approveTermClaimKey = "approved";

const adminRoleClaimValue = "Admin";

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
    return decodedToken[nameClaimKey];
}

function readUserIdFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameIdentifierClaimKey];
}

function readUserBirthDayFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[dateOfBirthClaimKey];
}

function readUserRoleFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[roleClaimKey];
}

function hasUserAdminRole() {
    if (readUserRoleFromToken() === adminRoleClaimValue) {
        return true;
    }
    else {
        return false;
    }
}