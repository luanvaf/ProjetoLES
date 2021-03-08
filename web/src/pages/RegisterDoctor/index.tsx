import React, { FormEvent, useState, ChangeEvent } from 'react';
import api from '../../services/api';
import { useHistory } from 'react-router-dom'

import './styles.css';

const RegisterDoctor: React.FC = () => {
    const [selectedDoctorType, setSelectedDoctorType] = useState('0');
    const [doctorsType] = useState<string[]>(['Residente', 'Professor', 'Profissional']);

    const [formData, setFormData] = useState({
        nome: '',
        crm: '',
        titulacao: '',
        anosResidencia: '',
        senha: '',
        senhaConfirmar: ''
    });

    const history = useHistory();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    }

    function handleSelectType(event: ChangeEvent<HTMLSelectElement>) {
        const type = event.target.value;
        setSelectedDoctorType(type);
    }

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const { nome, crm, titulacao, anosResidencia, senha, senhaConfirmar } = formData;
        const data = new FormData();

        switch (selectedDoctorType) {
            case 'Residente':
                data.append('CompleteName', nome);
                data.append('Crm', crm);
                data.append('ResidenceYear', anosResidencia);
                data.append('Password', senha);
                data.append('ConfirmPassword', senhaConfirmar);
                await api.post('/api/User/resident', data)
                    .then((response) => {
                        console.log(response);
                    })
                    .catch(function (error) {
                        if (error.response) {
                            console.log(error.response);
                        }
                    });
                return history.push('/');

            case 'Professor':
                data.append('CompleteName', nome);
                data.append('Crm', crm);
                data.append('Titulation', titulacao);
                data.append('Password', senha);
                data.append('ConfirmPassword', senhaConfirmar);
                await api.post('/api/User/professor', data)
                    .then((response) => {
                        alert(response.data)
                    })
                    .catch(function (error) {
                        if (error.response) {
                            alert(error.response.data)
                        }
                    });
                return history.push('/');

            default:
                data.append('CompleteName', nome);
                data.append('Crm', crm);
                data.append('Password', senha);
                data.append('ConfirmPassword', senhaConfirmar);
                await api.post('/api/User/doctor', data)
                    .then((response) => {
                        alert(response.data)
                    })
                    .catch(function (error) {
                        if (error.response) {
                            alert(error.response.data)
                        }
                    });
                return history.push('/');
        }
    }


    return (
        <div id="page-register-doctor">
            <header></header>

            <form onSubmit={handleSubmit}>
                <h1>Cadastro dos Médicos</h1>
                <fieldset>
                    <div className="field-group">
                        <div className="field">
                            <label htmlFor="nome">Nome</label>
                            <input
                                type="text"
                                name="nome"
                                id="name"
                                onChange={handleInputChange}
                            />
                        </div>
                        <div className="field">
                            <label htmlFor="crm">CRM</label>
                            <input
                                type="number"
                                name="crm"
                                id="crm"
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>
                    <div className="field">
                        <label htmlFor="tipo">Tipo</label>
                        <select
                            name="tipo"
                            id="tipo"
                            value={selectedDoctorType}
                            onChange={handleSelectType}
                        >
                            <option value="0">Selecione um tipo</option>
                            {doctorsType.map(doctor => (
                                <option key={doctor} value={doctor}>{doctor}</option>
                            ))}
                        </select>
                    </div>
                    {selectedDoctorType === 'Professor' ? (
                        <div className="field">
                            <label htmlFor="titulacao">Titutalação</label>
                            <input
                                type="text"
                                name="titulacao"
                                id="titulacao"
                                onChange={handleInputChange}
                            />
                        </div>
                    ) : (
                        null
                    )}
                    {selectedDoctorType === 'Residente' ? (
                        <div className="field">
                            <label htmlFor="anosResidencia">Anos de Residência</label>
                            <input
                                type="number"
                                name="anosResidencia"
                                id="anosResidencia"
                                onChange={handleInputChange}
                            />
                        </div>
                    ) : (
                        null
                    )}
                    <div className="field-group">
                        <div className="field">
                            <label htmlFor="senha">Senha</label>
                            <input
                                type="password"
                                name="senha"
                                id="senha"
                                onChange={handleInputChange}
                            />
                        </div>
                        <div className="field">
                            <label htmlFor="senhaConfirmar">Confirmar Senha</label>
                            <input
                                type="password"
                                name="senhaConfirmar"
                                id="senhaConfirmar"
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>
                </fieldset>

                <button type="submit">
                    Cadastrar Médico
                </button>
            </form>
        </div>
    );
}

export default RegisterDoctor;