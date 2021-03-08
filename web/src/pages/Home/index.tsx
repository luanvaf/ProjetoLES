import React from 'react';
import { Link } from 'react-router-dom'

import './styles.css';

const Home: React.FC = () => {
    return (
        <div id="page-home">
            <header></header>
            
            <h1>Sistema de Gestão</h1>
            
            <Link to='/CadastroMedico'>
                <button>
                    Cadastrar Novo Médico
                </button>
            </Link>
        </div>
    )
}

export default Home;