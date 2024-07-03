import React, { useState } from 'react';
import { Usuario } from '../../../models/Usuario';
import axios from 'axios';
import "../../../styles/cadastro.css";
import { useNavigate } from 'react-router-dom';

const CadastroUsuario = () => {
  const navigate = useNavigate();
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [cadastroResponse, setCadastroResponse] = useState<{ success: boolean, message: string } | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const usuario = {
      nome: nome,
      email: email,
      senha: senha,
    };

    try {
      const response = await axios.post('http://localhost:5162/usuario/cadastrar', usuario);

      const data = response.data;
      setCadastroResponse(data);

      if (data.success) {
        setNome('');
        setEmail('');
        setSenha('');
      }

      navigate('/pages/login');

    } catch (error) {
      console.error('Erro ao cadastrar usuário:', error);
    }
  };

  return (
    <div id="cadastroContainer">
      <h1>Novo Usuário</h1>
      <form onSubmit={handleSubmit}>
        <label>Nome:</label>
        <input
          type="text"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
          required
        />
        <label>E-mail:</label>
        <input
          type="text"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <label>Senha:</label>
        <input
          type="password"
          value={senha}
          onChange={(e) => setSenha(e.target.value)}
          required
        />
        <button type="submit">Cadastrar</button>
      </form>

      {cadastroResponse && (
        <p className={cadastroResponse.success ? 'success' : ''}>{cadastroResponse.message}</p>
      )}
    </div>
  );
};

export default CadastroUsuario;