import React from 'react';
import { BrowserRouter, Route } from "react-router-dom";

import Home from '../pages/Home';
import RegisterDoctor from '../pages/RegisterDoctor';
import RegisterEquipament from '../pages/RegisterEquipament';
import RegisterPatient from '../pages/RegisterPatient';

const OtherRoutes: React.FC = () => {
    return (
      <BrowserRouter>
        <Route component={Home} path="/" exact />
        <Route component={RegisterDoctor} path="/CadastroMedico" />
        <Route component={RegisterPatient} path="/CadastrarPaciente"/>
        <Route component={RegisterEquipament} path="/CadastrarEquipamento"/>
      </BrowserRouter>
    );
  }
  
  export default OtherRoutes;