import { useContext, useEffect, useState } from "react";
import { Livro } from "../../../models/Livro";
import { AuthContext } from "../login/AuthContext";
import Button from 'react-bootstrap/Button';
import "../../../styles/listagem.css";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function ListarLivro() {
    const [livros, setLivros] = useState<Livro[]>([]);
    const authContext = useContext(AuthContext);
    const navigate = useNavigate();
    useEffect(() => {
        console.log("Carregou lista de Livros");
        carregarLivros();
    }, []);
    if (!authContext) {
        return <p>Carregando...</p>;
    }

    const { permissao } = authContext;



    function carregarLivros() {
        fetch("http://localhost:5162/livro/listar/")
            .then((resposta) => resposta.json())
            .then((data) => {
                if (Array.isArray(data)) {
                    setLivros(data); // Atualiza o estado com os livros recebidos
                } else {
                    console.error("Resposta da API não é um array:", data);
                }
            })
            .catch((erro) => {
                console.log("Erro ao carregar livros:", erro);
            });
    }

    function deletar(id: string) {
        setLivros(livros.filter(livro => livro.livroId !== id));

        axios.delete(`http://localhost:5162/livro/deletar/${id}`)
            .then((resposta) => {
                if (Array.isArray(resposta.data)) {
                } else {
                    console.error("Resposta de deleção da API não é um array:", resposta.data);
                }
            })
            .catch((erro) => {
                console.log("Erro ao deletar livro:", erro);
            });
    }

    return (
        <div className="listagem-container">
            <h1>Listagem de Livros</h1>
            <table className="listagem-tabela">
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Editora</th>
                        <th>Categoria</th>
                        <th>Situação do empréstimo</th>
                        <th>Comentarios</th>
                        <th>Avaliações</th>
                        {permissao == 0 && <th>Empréstimo</th>}
                        {permissao == 0 && <th>Devolução</th>}
                        {permissao == 1 && <th>Deletar</th>}
                        
                    </tr>
                </thead>
                <tbody>
                    {Array.isArray(livros) && livros.map((livro) => (
                        <tr key={livro.livroId}>
                            <td>{livro.titulo}</td>
                            <td>{livro.autor}</td>
                            <td>{livro.editora}</td>
                            <td>{livro.categoria}</td>
                            <td>{livro.emprestado ? 'Emprestado' : 'Disponível'}</td>

                            <td>
                                {permissao == 0 && <button onClick={() => navigate(`/livro/${livro.livroId}/comentar`)} id="botao">Comentar</button>}
                                <button onClick={() => navigate(`/listar/comentario/${livro.livroId}`)} id="botao">Listar</button>
                            </td>
                            <td>
                                {permissao == 0 && <button onClick={() => navigate(`/livro/${livro.livroId}/avaliar`)} id="botao">Avaliar</button>}
                                <button onClick={() => navigate(`/listar/avaliar/${livro.livroId}`)} id="botao">Listar</button>
                            </td>
                            {permissao == 0 &&<td>
                                 <button onClick={() => navigate(`/pages/emprestimo/${livro.livroId}`)} id="botao">Emprestar</button>
                            </td>}
                            {permissao == 0 &&<td>
                                 <button onClick={() => navigate(`/pages/devolucao/${livro.livroId}`)} id="botao">Devolver</button>
                            </td>}
                            {permissao == 1 &&<td>
                                 <button onClick={() => deletar(livro.livroId!)} id="botao">Deletar</button>
                            </td>}
                            
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}



export default ListarLivro;