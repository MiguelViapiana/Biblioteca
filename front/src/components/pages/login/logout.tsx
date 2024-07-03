import { useContext } from "react";
import { AuthContext } from "./AuthContext";
import { useNavigate } from "react-router-dom";

function Logout(){
    const navigate = useNavigate();
    const authContext = useContext(AuthContext);
    const handleLogout = () => {
        if (authContext) {
            authContext.setPermissao(2);
            localStorage.removeItem('authToken'); 
            navigate('/pages/login');
            window.location.reload();
        }
    };

    return(
        <p></p>

    );
}
export default Logout;