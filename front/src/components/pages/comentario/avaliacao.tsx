import React, { useState, useContext } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { AuthContext } from '../login/AuthContext';
import "../../../styles/comentario.css";

const LivroAvaliar: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [estrelas, setEstrela] = useState(0);
    const authContext = useContext(AuthContext);
    const [avaliarResponse, setAvaliar] = useState<{ success: boolean, message: string } | null>(null);
    const navigate = useNavigate();

    if (!authContext) {
        return <p>Carregando...</p>;
    }
    
    const { usuario } = authContext;

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post(`http://localhost:5162/livro/${id}/avaliar/`, {
                estrelas,
                usuario,
            });

            const data = response.data;
            console.log(response.data);
            setAvaliar(data);

            if (data.success) {
                setEstrela(0);
                alert("Comentário adicionado com sucesso");
                navigate('/pages/listar');
            }

        } catch (error) {
            console.error('Erro ao adicionar comentário: ', error);
        }
    };

    return (
        <div id="comentarioContainer">
            <h1>Novo Comentário</h1>
            <form onSubmit={handleSubmit}>
                <label>Estrelas: </label>
                <input
                    type="number"
                    value={estrelas}
                    onChange={(e) => setEstrela(Number(e.target.value))}
                    min="0"
                    max="5"
                    required
                />
                <button type="submit">Comentar</button>

                {avaliarResponse && (
                    <p className={avaliarResponse.success ? "success" : "error"}>
                        {avaliarResponse.message}
                    </p>
                )}
            </form>
        </div>
    );
};

export default LivroAvaliar;


