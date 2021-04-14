import React, { FormEvent, ChangeEvent, useState } from 'react';
import { useHistory } from 'react-router-dom';
import Swal from 'sweetalert2';
import { useAuth } from '../../contexts/auth';
import Auth from '../../interfaces/auth';

import './styles.css';

const Login: React.FC = () => {
    const contextAuth = useAuth();

    const [formAuth, setAuth] = useState<Auth>({
        Login: '',
        Password: ''
    });

    const history = useHistory();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setAuth({ ...formAuth, [name]: value });
    }

    async function handleSignIn(event: FormEvent) {
        event.preventDefault();

        contextAuth.Login(formAuth.Login, formAuth.Password)
            .catch(() => {
                Swal.fire({
                    icon: 'error',
                    title: 'Cmr ou Senha inválido!',
                    text: 'Tente novamente'
                })
            });
        history.push('/');
    }

    return (
        <div className="background">
            <div id="page-login">
                <header></header>

                <form onSubmit={handleSignIn}>
                    <h1>Login</h1>
                    <fieldset>
                        <div className="field">
                            <label htmlFor="Login">Crm</label>
                            <input
                                type="number"
                                name="Login"
                                id="Login"
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="field">
                            <label htmlFor="Password">Senha</label>
                            <input
                                type="password"
                                name="Password"
                                id="Password"
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    </fieldset>

                    <button type="submit">
                        Entrar
                </button>
                </form>
            </div>
        </div>
    )
}

export default Login;