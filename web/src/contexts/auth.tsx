import React, { createContext, useContext, useState } from 'react';

import api from '../services/api';

interface AuthContextData {
    signed: boolean;
    user: object | null;
    Login(Crm: string, Password: string): Promise<void>;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({ children }) => {
    const [user, setUser] = useState<object | null>(null);
    async function Login(Login: string, Password: string) {
        // const response = await api.post('/api/Auth', {
        //     Crm: Login,
        //     Password: Password,
        // });

        // setUser(response.data.User);
        // api.defaults.headers.Authorization = `Bearer ${response.data.Token}`;
        
        // Login Mockado
        if  (Login === 'admin' && Password === 'admin') {
            interface User {
                CompleteName: string;
                Crm: string;
            }
            const user: User = {
                CompleteName: "admin",
                Crm: "cmrAdmin"
            }
            setUser(user);
        }
    }

    return (
        <AuthContext.Provider value={{ signed: Boolean(user), user, Login }}>
            {children}
        </AuthContext.Provider>
    );
};

export function useAuth() {
    const context = useContext(AuthContext);
    
    return context;
}