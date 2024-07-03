import { createContext } from "react";
import React, { useState, ReactNode } from 'react';

interface AuthContextType {
    permissao: number;
    setPermissao: (permissao: number) => void;
    usuario: string;
    setUsuario: (usuario: string) => void;
    usuarioId: string
    setUsuarioId: (usuario: string) => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [permissao, setPermissao] = useState<number>(2); // 0 representando COMUM
    const [usuario, setUsuario] = useState<string>("");
    const [usuarioId, setUsuarioId] = useState<string>("");

    return (
        <AuthContext.Provider value={{ permissao, setPermissao, usuario, setUsuario, usuarioId, setUsuarioId}}>
            {children}
        </AuthContext.Provider>
    );
};

export { AuthContext, AuthProvider };

