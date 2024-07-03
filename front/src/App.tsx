import React, { useContext } from 'react';
import './App.css';
import ProdutoCadastar from "./components/pages/cadastro/livro-cadastrar";
import { BrowserRouter, Route, Routes, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import CadastrarLivro from './components/pages/cadastro/livro-cadastrar';
import ListarLivro from './components/pages/listar/listar-livro';
import CadastarUsuario from './components/pages/cadastro/cadastrar-usuario';
import Logar from './components/pages/login/login-usuario';
import ListarUsuarios from './components/pages/listar/listar-usuarios';
import { AuthContext } from './components/pages/login/AuthContext';
import Logout from './components/pages/login/logout';
import Home from './components/pages/home/home';
import LivroComentar from './components/pages/comentario/comentario';
import ListarComentario from './components/pages/listar/listar-comentario';
import LivroAvaliar from './components/pages/comentario/avaliacao';
import ListarAvaliacao from './components/pages/listar/listar-Avaliacao';
import RealizarEmprestimo from './components/pages/emprestimo/emprestimo';
import RealizarDevolucao from './components/pages/devolucao/devolucao';


function App() {
  const authContext = useContext(AuthContext);

  if (!authContext) {
    return <p>Carregando...</p>;
  }

  const { permissao } = authContext;

  return (
    <div className="App">
      <BrowserRouter>
        <nav id='header'>
          <div id='divHeader'>
            <h1 id='h1Header'>BIBLIOTECA</h1>
          </div>
          <div id='navLinks'>
            
            <Link to={"/"} id='botao'>Home</Link>

            {permissao == 1 || permissao == 2 && <Link to={"/pages/cadastro-usuario"} id='botao'>Novo usuário</Link>}

            { permissao === 2 && <Link to={"/pages/login"} id='botao'>Login</Link>}

            {(permissao === 0 || permissao === 1) && <Link to={"/pages/login/logout"} id='botao'>Logout</Link>}

            {permissao == 1 && <Link to={"/pages/cadastro-livro"} id='botao'>Cadastrar Livro</Link>}

            <Link to={"/pages/listar"} id='botao'>Listar Livros</Link>

            {permissao == 1 && <Link to={"/pages/listar-usuario"} id='botao'>Listar Usuários</Link>}
          </div>

        </nav>
        <Routes>
          <Route path='/' element={<Home/>}/>
          {permissao == 1 && <Route path="/pages/cadastro-livro" element={<CadastrarLivro />} />}
          {permissao == 1 || permissao == 2 && <Route path="/pages/cadastro-usuario" element={<CadastarUsuario />} />}
          <Route path='/pages/listar' element={<ListarLivro />} />
          {permissao == 1 && <Route path='/pages/listar-usuario' element={<ListarUsuarios />} />}
          <Route path='/pages/login' element={<Logar />} />
          <Route path='/pages/login/logout' element={<Logout/>}/>
          <Route path="/livro/:id/comentar" element={<LivroComentar />} />
          <Route path="/listar/comentario/:id" element={<ListarComentario />} />
          <Route path='/livro/:id/avaliar' element={<LivroAvaliar/>}/>
          <Route path='/listar/avaliar/:id' element={<ListarAvaliacao/>} />
          <Route path='/pages/emprestimo/:id' element={<RealizarEmprestimo/>} />
          <Route path='/pages/devolucao/:id'element={<RealizarDevolucao/>} />
        </Routes>
        <footer>
          <p>Desenvolvido por:</p>
          <p>Arnaldo dos Santos Junior</p>
          <p>Marcel Felipe Lell Flores</p>
          <p>Miguel Viapiana Jung</p>
          <p>Rafael Gutowskii</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}


export default App;
