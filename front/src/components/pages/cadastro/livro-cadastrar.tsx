import React, { useContext, useState } from 'react';
import { Livro } from '../../../models/Livro';
import axios from 'axios';
import "../../../styles/cadastro-livro.css";

const CadastroLivro = () => {
  const [titulo, setTitulo] = useState('');
  const [autor, setAutor] = useState('');
  const [editora, setEditora] = useState('');
  const [categoria, setCategoria] = useState('');
  const [cadastroResponse, setCadastroResponse] = useState<{ success: boolean, message: string } | null>(null);

  const cadastrarLivro = async (e: React.FormEvent) => {
      e.preventDefault();

      const livro = {
          titulo: titulo,
          autor: autor,
          editora: editora,
          categoria: categoria,
      };

      try {
          const response = await axios.post('http://localhost:5162/livro/cadastrar', livro);

          const data = response.data;
          setCadastroResponse(data);

          if (data.success) {
              // Limpar campos após cadastro bem-sucedido, se necessário
              setTitulo('');
              setAutor('');
              setEditora('');
              setCategoria('');
          }

      } catch (error) {
          console.error('Erro ao cadastrar livro:', error);
      }
  };

  return (
      <div id="cadastroLivroContainer">
          <h1>Cadastrar Livro</h1>
          <form onSubmit={cadastrarLivro}>
              <label>Título:</label>
              <input
                  type="text"
                  value={titulo}
                  onChange={(e) => setTitulo(e.target.value)}
                  required
              />
              <label>Autor:</label>
              <input
                  type="text"
                  value={autor}
                  onChange={(e) => setAutor(e.target.value)}
                  required
              />
              <label>Editora:</label>
              <input
                  type="text"
                  value={editora}
                  onChange={(e) => setEditora(e.target.value)}
                  required
              />
              <label>Categoria:</label>
              <input
                  type="text"
                  value={categoria}
                  onChange={(e) => setCategoria(e.target.value)}
                  required
              />
              <button type="submit">Cadastrar Livro</button>
          </form>

          {cadastroResponse && (
              <p className={cadastroResponse.success ? 'success' : ''}>{cadastroResponse.message}</p>
          )}
      </div>
  );
};

export default CadastroLivro;
