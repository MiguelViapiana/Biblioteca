import { useContext, useEffect, useState } from "react";
import { Usuario } from "../../../models/Usuario";
import "../../../styles/listagem.css";
import axios from "axios";
import { AuthContext } from "../login/AuthContext";
import { useNavigate } from "react-router-dom";

function ListarUsuarios() {
    const authContext = useContext(AuthContext);
    const navigate = useNavigate();
    const [usuarios, setUsuarios] = useState<Usuario[]>([]);

    useEffect(() => {
        console.log("Carregou lista");
        listagemUsuarios();
    }, []);

    if (!authContext) {
        return <p>Carregando...</p>;
    }

    const { permissao } = authContext;

    function listagemUsuarios() {
        fetch("http://localhost:5162/usuario/listar/")
            .then((resposta) => resposta.json())
            .then((usuarios: Usuario[]) => {
                setUsuarios(usuarios);
                console.table(usuarios);
            })
            .catch((erro) => {
                console.log("Erro ao carregar lista de usuários:", erro);
            });
    }


    return (
        <div className="listagem-container">
            <h1>Lista de usuários cadastrados</h1>
            <table className="listagem-tabela">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>E-mail</th>
                        <th>Senha</th>
                        <th>Permissão</th>
                    </tr>
                </thead>
                <tbody>
                    {usuarios.map((usuario) => (
                        <tr key={usuario.id}>
                            <td>{usuario.nome}</td>
                            <td>{usuario.email}</td>
                            <td>{usuario.senha}</td>
                            <td>{usuario.permissao ? 'Administrador' : 'Comum'}</td>

                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default ListarUsuarios;
