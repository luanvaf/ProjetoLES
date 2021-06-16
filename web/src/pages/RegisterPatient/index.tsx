import React, { FormEvent, useState, ChangeEvent } from 'react';
import api from '../../services/api';
import { useHistory } from 'react-router-dom';
import Swal from 'sweetalert2';

import './styles.css';
import Patient from '../../interfaces/patient';
import { SexTypeEnum } from '../../interfaces/helps/sexTypeEnum';

const RegisterPatient: React.FC = () => {
    const [selectedSexType, setSelectedSexType] = useState('0');
    const [sexType] = useState<string[]>(['M', 'F']);
    const [formPatient, setPatient] = useState<Patient>({
        Name: '',
        Cpf: '',
        BirthDate: new Date(''),
        Phone: '',
        Sex: selectedSexType as SexTypeEnum,
        Address: {
            City: '',
            District: '',
            Street: '',
            ZipCode: ''
        }
    });

    const history = useHistory();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setPatient({ ...formPatient, [name]: value });
    }

    function handleSelectType(event: ChangeEvent<HTMLSelectElement>) {
        const type = event.target.value;
        setSelectedSexType(type);
    }

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();
        console.log(formPatient);
        await api.post('/api/Patient', formPatient)
            .then(() => {                
                Swal.fire({
                    icon: 'success',
                    title: 'Paciente Cadastrado com Sucesso!'
                })
                history.push('/');
            })
            .catch(() => {
                Swal.fire({
                    icon: 'error',
                    title: 'Paciente não Cadastrado!',
                    text: 'Tente novamente mais tarde'
                })
            });
    }

    return (
        <div className="background-register">
            <div id="page-register-patient">
                <header></header>

                <form onSubmit={handleSubmit}>
                    <h1>Cadastro do Paciente</h1>
                    <fieldset>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="Name">Nome</label>
                                <input
                                    type="text"
                                    name="Name"
                                    id="Name"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="Cpf">CPF</label>
                                <input
                                    type="text"
                                    name="Cpf"
                                    id="Cpf"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                        </div>
                        <div className="field">
                            <label htmlFor="BirthDate">Data de Nascimento</label>
                            <input
                                type="date"
                                name="BirthDate"
                                id="BirthDate"
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="Sex">Sexo</label>
                                <select
                                    name="Sex"
                                    id="Sex"
                                    value={selectedSexType}
                                    onChange={handleSelectType}
                                    required
                                >
                                    <option value="">Selecione um tipo</option>
                                    {sexType.map(sex => (
                                        <option key={sex} value={sex}>{sex}</option>
                                    ))}
                                </select>
                            </div>
                            <div className="field">
                                <label htmlFor="Phone">Celular</label>
                                <input
                                    type="text"
                                    name="Phone"
                                    id="Phone"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                        </div>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="ZipCode">Código Postal</label>
                                <input
                                    type="text"
                                    name="ZipCode"
                                    id="ZipCode"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="City">Cidade</label>
                                <input
                                    type="text"
                                    name="City"
                                    id="City"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                        </div>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="District">Estado</label>
                                <input
                                    type="text"
                                    name="District"
                                    id="District"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="Street">Rua</label>
                                <input
                                    type="text"
                                    name="Street"
                                    id="Street"
                                    onChange={handleInputChange}
                                    required
                                />
                            </div>
                        </div>

                    </fieldset>

                    <button type="submit">
                        Cadastrar Paciente
                    </button>
                </form>
            </div>
        </div>
    );
}

export default RegisterPatient;