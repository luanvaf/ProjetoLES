import React from 'react';
import { Link } from 'react-router-dom'

import './styles.css';

const Home: React.FC = () => {
    return (
        <div className="background-home">
            <div id="page-home">
                <header></header>
                <h1>Sistema de Gestão de Laudos</h1>
                <Link to='/CadastroMedico'>
                    <button>
                        Cadastrar Novo Médico
                </button>
                </Link>                
            </div>
        </div>
    )
}

export default Home;