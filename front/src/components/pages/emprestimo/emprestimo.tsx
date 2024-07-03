import { useContext, useState, useEffect } from "react";
import { AuthContext } from "../login/AuthContext";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";

const RealizarEmprestimo: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [emprestimoResponse, setEmprestimo] = useState<{ success: boolean, message: string } | null>(null);
    const authContext = useContext(AuthContext);
    const navigate = useNavigate();

    useEffect(() => {
        if (!authContext) {
            return;
        }

        const { usuarioId } = authContext;

        const realizarEmprestimo = async () => {

            const Emprestimo = {
                usuarioId,
                livroId: id,
            }
            try {
                console.log(usuarioId);
                console.log(id);
                const response = await axios.post(`http://localhost:5162/emprestimo/registrar/true/${id}`, Emprestimo);

                const data = response.data;
                setEmprestimo(data);

                if (data.success) {
                    alert("Empréstimo realizado com sucesso");
                    navigate('/pages/listar');
                }
            } catch (error) {
                console.error('Erro ao realizar o empréstimo', error);
            }
        };

        realizarEmprestimo();
    }, [authContext, id, navigate]);

    if (!authContext) {
        return <p>Carregando...</p>;
    }

    return (
        <div>
            {emprestimoResponse && (
                <p className={emprestimoResponse.success ? "success" : "error"}>
                    {emprestimoResponse.message}
                </p>
            )}
        </div>
    );
};

export default RealizarEmprestimo;