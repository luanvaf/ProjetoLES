import React from 'react';
import { BrowserRouter, Route } from "react-router-dom";

import Home from '../pages/Home';
import RegisterDoctor from '../pages/RegisterDoctor';

const OtherRoutes: React.FC = () => {
    return (
      <BrowserRouter>
        <Route component={Home} path="/" exact />
        <Route component={RegisterDoctor} path="/CadastroMedico" />
      </BrowserRouter>
    );
  }
  
  export default OtherRoutes;