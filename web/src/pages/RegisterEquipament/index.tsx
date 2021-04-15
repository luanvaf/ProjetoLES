import React, {FormEvent, ChangeEvent, useState} from 'react';
import api from '../../services/api';
import {useHistory} from 'react-router-dom';
import Swal from 'sweetalert2';

import './styles.css';
import MedicalEquipament from '../../interfaces/medicalEquipament';

const RegisterEquipament: React.FC = () => {
    const[formMedicalEquipament, setMedicalEquipament] = useState<MedicalEquipament>({
        Name: '',
        AcquisitionDate: new Date(''),
        CreatedAt: new Date()
    });

    const history = useHistory();

        function handleInputChange(event: ChangeEvent<HTMLInputElement>){
            const{name, value} = event.target;
            setMedicalEquipament({...formMedicalEquipament, [name]: value});
        }

        async function handleSubmit(event:FormEvent) {
            event.preventDefault();

            await api.post('api/MedicalEquipament', formMedicalEquipament).then(() => {
                Swal.fire({
                    icon: 'success',
                    title: 'Equipamento cadastrado com sucesso!'
                })
                history.push('/');
            }).catch(() => {
                Swal.fire({
                    icon: 'error',
                    title: 'Equipamento não cadastrado!',
                    text: 'Tente novamente mais tarde'
                })
            });
        }

    return (
        <div className="background">
            <div id="page-register-equipament">
                <header></header>

                <form onSubmit={handleSubmit}>
                    <h1>Cadastro dos Equipamentos</h1>
                    <fieldset>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="Name">Nome do Equipamento: </label>
                                <input type="text"
                                   name="Name"
                                   id="Name"
                                   onChange={handleInputChange}
                                   required
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="AcquisitionDate">Data de Aquisição: </label>
                                <input type="date"
                                   name="AcquisitionDate"
                                   id="AcquisitionDate"
                                   onChange={handleInputChange}
                                   required
                                />
                            </div>
                        </div>
                    </fieldset>
                    <button type="submit">Cadastrar Equipamento</button>
                </form>
            </div>
        </div>
    );
}

export default RegisterEquipament;