import React, { createContext, useContext, useState } from 'react';

import api from '../services/api';

interface AuthContextData {
    signed: boolean;
    user: object | null;
    role: string;
    Login(Crm: string, Password: string): Promise<void>;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

export const AuthProvider: React.FC = ({ children }) => {
    const [user, setUser] = useState<object | null>(null);
    const [role, setRole] = useState<string>('');
    async function Login(crm: string, password: string) {
        const response = await api.post('/api/Auth', {
            Crm: crm,
            Password: password,
        })

        setUser(response.data.user);
        setRole(response.data.role);
        api.defaults.headers.Authorization = `Bearer ${response.data.token}`;
    }

    return (
        <AuthContext.Provider value={{ signed: Boolean(user), user, role, Login }}>
            {children}
        </AuthContext.Provider>
    );
};

export function useAuth() {
    const context = useContext(AuthContext);

    return context;
}