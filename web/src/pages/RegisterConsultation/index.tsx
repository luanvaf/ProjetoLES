import React, {FormEvent, ChangeEvent, useState, useEffect}from "react";
import api from '../../services/api';
import {useHistory} from 'react-router-dom';
import Swal from 'sweetalert2';
import './styles.css'
import { MedicalConsultation } from "../../interfaces/medicalConsultation";

interface PatientModel{
    id: number
    name: string
    addressId: number
    birthDate: Date
    phone: string
    sex:number
}

const RegisterConsultation: React.FC = () => {
    const[patients, setPatients] = useState<PatientModel[]>([])
    const[selectedPatient, setSelectedPatient] = useState('0')
    const[formMedicalConsultation, setMedicalConsultation] = useState<MedicalConsultation>({
        PatientId: 0
    });
    
    async function loadPatients(){
        var response = await api.get('api/Patient')
        console.log(response)
        setPatients(response.data)
    }
    
    useEffect(() => {loadPatients()}, [])

    const history = useHistory();

    function handleSelectPatient(event: ChangeEvent<HTMLSelectElement>){
        const type = event.target.value;
        const{name, value} = event.target;
        setMedicalConsultation({...formMedicalConsultation, [name]: value});
        setSelectedPatient(type);
    }

    async function handleSubmit(event:FormEvent) {
        event.preventDefault();

        await api.post('api/MedicalConsultation/consultation', formMedicalConsultation).then(() => {
            Swal.fire({
                icon: 'success',
                title: 'Consulta Cadastrada com sucesso!'
            })
            history.push('/');
        }).catch(() => {
            Swal.fire({
                icon:'error',
                title: 'Consulta não cadastrada!',
                text: 'Tente novamente mais tarde!'
            })
        });
    }
    return(
        <div className="background-register">
            <div id="page-register-consultation">
                <header></header>

                <form onSubmit={handleSubmit}>
                    <h1>Cadastro das Consultas</h1>
                    <fieldset>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="PatientId">Paciente</label>
                                <select 
                                    name="PatientId" 
                                    id="PatientId" 
                                    value={selectedPatient} 
                                    onChange={handleSelectPatient}
                                    required
                                    >
                                    <option value="">Selecione o paciente</option>
                                    {patients.map(patient =>(
                                        <option key = {patient.id} value={patient.id}>{patient.name}</option>
                                    ))}
                                </select>
                            </div>
                        </div>
                    </fieldset>
                    <button type="submit">Cadastrar Consulta</button>
                </form>
            </div>
        </div>
    )
}

export default RegisterConsultation;