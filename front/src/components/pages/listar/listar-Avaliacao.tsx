import { useContext, useEffect, useState } from "react";
import { Livro, Comentario } from "../../../models/Livro";
import { AuthContext } from "../login/AuthContext";
import axios from "axios";
import "../../../styles/listagem.css";
import { useNavigate, useParams } from 'react-router-dom';
import "../../../styles/listagemComentarios.css";

const ListarAvaliacao: React.FC = () => {
    const { id } = useParams<{ id: string }>();
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
        <h1>Listagem de Livros e Comentários</h1>
        <table className="listagem-tabela">
            <thead>
                <tr>
                    <th>Título</th>
                    <th>Autor</th>
                    <th>Editora</th>
                    <th>Categoria</th>
                    <th>Situação do empréstimo</th>
                    {/* <th>Deletar</th> */}
                    {permissao === 0 && <th>Comentários</th>}
                </tr>
            </thead>
            <tbody>
                {Array.isArray(livros) && livros.map((livro) => (
                    <>
                        {livro.livroId == id &&(
                        <tr key={livro.livroId}>
                            <td>{livro.titulo}</td>
                            <td>{livro.autor}</td>
                            <td>{livro.editora}</td>
                            <td>{livro.categoria}</td>
                            <td>{livro.emprestado ? 'Emprestado' : 'Disponível'}</td>
                            {/* <td>
                                <button onClick={() => deletar(livro.livroId!)} id="botao">Deletar</button>
                            </td> */}
                        </tr>
                        )}
                        {livro.avaliacoes && livro.avaliacoes.length > 0 && livro.livroId == id && (
                            <tr>
                                <td colSpan={6}>
                                    <table className="comentarios-tabela">
                                        <thead>
                                            <tr>
                                                <th>Estrelas</th>
                                                <th>Usuário</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {livro.avaliacoes?.map((avaliacao) => (
                                                <tr key={avaliacao.id}>
                                                    <td>{avaliacao.estrelas}</td>
                                                    <td>{avaliacao.usuario}</td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        )}
                    
                    </>
                    
                ))}
            </tbody>
        </table>
    </div>
    );
}

export default ListarAvaliacao;