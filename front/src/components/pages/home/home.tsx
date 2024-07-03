import React from 'react';
import '../../../styles/home.css';

const Home = () => {
    return (
        <div id='home'>
            <h1>Bem-vindo à Biblioteca</h1>
            <p>Explore nossa coleção de livros, cadastre novos usuários, e muito mais!</p>
            <div id='homeContent'>
                <p>Aqui você pode encontrar uma vasta seleção de livros em diversas categorias. Utilize a nossa plataforma para gerenciar empréstimos e manter um registro dos usuários. Navegue pelas diferentes seções para acessar as funcionalidades disponíveis.</p>
            </div>
        </div>
    );
};

export default Home;