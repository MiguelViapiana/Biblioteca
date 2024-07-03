import { useContext, useState, useEffect } from "react";
import { AuthContext } from "../login/AuthContext";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

const RealizarDevolucao: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [devolucaoResponse, setDevolucaoResponse] = useState<{ success: boolean, message: string } | null>(null);
    const authContext = useContext(AuthContext);
    const navigate = useNavigate();

    useEffect(() => {
        if (!authContext) {
            return;
        }

        const { usuarioId } = authContext;

        const Devolucao = {
            usuarioId,
            livroId: id,
        }

        const realizarDevolucao = async () => {
            try {
                console.log(usuarioId);
                console.log(id);
                const response = await axios.post(`http://localhost:5162/devolucao/registrar/${id}`, Devolucao);
                    
                const data = response.data;
                setDevolucaoResponse(data);

                if (data.success) {
                    alert("Devolução realizada com sucesso");
                    
                }
                
            } catch (error) {
                console.error('Erro ao realizar a devolução', error);
            }
            navigate('/pages/listar');
        };

        realizarDevolucao();
    }, [authContext, id, navigate]);

    if (!authContext) {
        return <p>Carregando...</p>;
    }

    return (
        <div>
            {devolucaoResponse && (
                <p className={devolucaoResponse.success ? "success" : "error"}>
                    {devolucaoResponse.message}
                </p>
            )}
        </div>
    );
};

export default RealizarDevolucao;
