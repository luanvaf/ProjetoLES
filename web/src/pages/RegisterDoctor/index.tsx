import React, { FormEvent, useState, ChangeEvent } from 'react';
import api from '../../services/api';
import { useHistory } from 'react-router-dom';
import Swal from 'sweetalert2';

import './styles.css';
import Professor from '../../interfaces/professor';
import Resident from '../../interfaces/resident';
import Doctor from '../../interfaces/doctor';

const RegisterDoctor: React.FC = () => {
    const [selectedDoctorType, setSelectedDoctorType] = useState('0');
    const [doctorsType] = useState<string[]>(['Residente', 'Professor', 'Profissional']);
    const [formProfessor, setProfessor] = useState<Professor>({
        CompleteName: '',
        ConfirmPassword: '',
        Crm: '',
        Password: '',
        Titulation: ''
    });
    const [formResident, setResident] = useState<Resident>({
        CompleteName: '',
        ConfirmPassword: '',
        Crm: '',
        Password: '',
        ResidenceYear: 0
    });
    const [formDoctor, setDoctor] = useState<Doctor>({
        CompleteName: '',
        ConfirmPassword: '',
        Crm: '',
        Password: ''
    });

    const history = useHistory();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setResident({ ...formResident, [name]: value });
        setDoctor({ ...formDoctor, [name]: value });
        setProfessor({ ...formProfessor, [name]: value });
    }

    function handleSelectType(event: ChangeEvent<HTMLSelectElement>) {
        const type = event.target.value;
        setSelectedDoctorType(type);
    }

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        switch (selectedDoctorType) {
            case 'Residente':
                await api.post('/api/User/resident', formResident)
                    .then(() => {
                        Swal.fire({
                            icon: 'success',
                            title: 'Médico Cadastrado com Sucesso!'
                        })
                        history.push('/');
                    })
                    .catch(() => {
                        Swal.fire({
                            icon: 'error',
                            title: 'Médico não Cadastrado!',
                            text: 'Tente novamente mais tarde'
                        })
                    });
                break;

            case 'Professor':
                await api.post('/api/User/professor', formProfessor)
                    .then(() => {
                        Swal.fire({
                            icon: 'success',
                            title: 'Médico Cadastrado com Sucesso!'
                        })
                        history.push('/');
                    })
                    .catch(() => {
                        Swal.fire({
                            icon: 'error',
                            title: 'Médico não Cadastrado!',
                            text: 'Tente novamente mais tarde'
                        })
                    });
                break;

            default:
                await api.post('/api/User/doctor', formDoctor)
                    .then(() => {
                        Swal.fire({
                            icon: 'success',
                            title: 'Médico Cadastrado com Sucesso!'
                        })
                        history.push('/');
                    })
                    .catch(() => {
                        Swal.fire({
                            icon: 'error',
                            title: 'Médico não Cadastrado!',
                            text: 'Tente novamente mais tarde'
                        })
                    });
                break;
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
                            <label htmlFor="CompleteName">Nome</label>
                            <input
                                type="text"
                                name="CompleteName"
                                id="CompleteName"
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="field">
                            <label htmlFor="Crm">CRM</label>
                            <input
                                type="number"
                                name="Crm"
                                id="Crm"
                                onChange={handleInputChange}
                                required
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
                            required
                        >
                            <option value="">Selecione um tipo</option>
                            {doctorsType.map(doctor => (
                                <option key={doctor} value={doctor}>{doctor}</option>
                            ))}
                        </select>
                    </div>
                    {selectedDoctorType === 'Professor' ? (
                        <div className="field">
                            <label htmlFor="Titulation">Titutalação</label>
                            <input
                                type="text"
                                name="Titulation"
                                id="Titulation"
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    ) : (
                        null
                    )}
                    {selectedDoctorType === 'Residente' ? (
                        <div className="field">
                            <label htmlFor="ResidenceYear">Anos de Residência</label>
                            <input
                                type="number"
                                name="ResidenceYear"
                                id="ResidenceYear"
                                onChange={handleInputChange}
                                required min={1} max={4}
                            />
                        </div>
                    ) : (
                        null
                    )}
                    <div className="field-group">
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
                        <div className="field">
                            <label htmlFor="ConfirmPassword">Confirmar Senha</label>
                            <input
                                type="password"
                                name="ConfirmPassword"
                                id="ConfirmPassword"
                                onChange={handleInputChange}
                                required
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