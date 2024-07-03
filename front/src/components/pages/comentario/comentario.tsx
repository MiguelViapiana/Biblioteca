import React, { useState, useContext } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { AuthContext } from '../login/AuthContext';
import "../../../styles/comentario.css";

const LivroComentar: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [texto, setTexto] = useState('');
    const authContext = useContext(AuthContext);
    
    const [comentarioResponse, setComentario] = useState<{ success: boolean, message: string } | null>(null);
    const navigate = useNavigate();

    if (!authContext) {
        return <p>Carregando...</p>;
    }
    const { usuario } = authContext;
    

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post(`http://localhost:5162/livro/${id}/comentar/`, {
                texto,
                usuario,
            });

            const data = response.data;
            console.log(response.data);
            setComentario(data);

            if (data.success) {
                setTexto('');
                alert("Comentário adicionado com sucesso");
                
            }
            navigate('/pages/listar');

        } catch (error) {
            console.error('Livro não encontrado para comentar ', error);
        }
    };

    return (
      <div id="comentarioContainer">
      <h1>Novo Comentário</h1>
      <form onSubmit={handleSubmit}>
          <label>Comentário: </label>
          <input
              type="text"
              value={texto}
              onChange={(e) => setTexto(e.target.value)}
              required
          />
          <button type="submit">Comentar</button>

          {comentarioResponse && (
              <p className={comentarioResponse.success ? "success" : "error"}>
                  {comentarioResponse.message}
              </p>
          )}
      </form>
  </div>
    );
};

export default LivroComentar;

