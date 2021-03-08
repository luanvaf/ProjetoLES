import React, { FormEvent, ChangeEvent, useState } from 'react';
import { useHistory } from 'react-router-dom';

import { useAuth } from '../../contexts/auth';

import './styles.css';

const Login: React.FC = () => {
    const contextAuth = useAuth();

    const [formData, setFormData] = useState({
        login: '',
        senha: '',
    });

    const history = useHistory();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    }

    async function handleSignIn(event: FormEvent) {
        event.preventDefault();

        const { login, senha } = formData;
        const data = new FormData();

        data.append('Crm', login);
        data.append('Password', senha);

        contextAuth.Login(login, senha);
        history.push('/');
    }

    return (
        <div id="page-login">
            <header></header>

            <form onSubmit={handleSignIn}>
                <h1>Cadastro dos Médicos</h1>
                <fieldset>
                    <div className="field">
                        <label htmlFor="login">Login</label>
                        <input
                            type="text"
                            name="login"
                            id="login"
                            onChange={handleInputChange}
                        />
                    </div>
                    <div className="field">
                        <label htmlFor="senha">Senha</label>
                        <input
                            type="password"
                            name="senha"
                            id="senha"
                            onChange={handleInputChange}
                        />
                    </div>
                </fieldset>
                
                <button type="submit">
                    Entrar
                </button>
            </form>
        </div>
    )
}

export default Login;