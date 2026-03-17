"use client"

import { createContext, useContext, useState, useEffect, type ReactNode } from "react"

interface User {
  email: string
  name: string
}

interface AuthContextType {
  user: User | null
  token: string | null
  login: (email: string, password: string) => Promise<boolean>
  logout: () => void
  isLoading: boolean
}

const AuthContext = createContext<AuthContextType | null>(null)

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(null)
  const [token, setToken] = useState<string | null>(null)
  const [isLoading, setIsLoading] = useState(true)

  useEffect(() => {
    // Check for existing token on mount
    const storedToken = localStorage.getItem("auth_token")
    const storedUser = localStorage.getItem("auth_user")
    
    if (storedToken && storedUser) {
      setToken(storedToken)
      setUser(JSON.parse(storedUser))
    }
    setIsLoading(false)
  }, [])

  const login = async (email: string, password: string): Promise<boolean> => {
    try {
      // API call placeholder - replace with actual endpoint
      const response = await fetch("https://localhost:7017/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ Email: email, Password: password }),
      })

      if (response.ok) {
        const data = await response.json()
        const jwtToken = data.token
        const userData = { email, name: email.split("@")[0] }
        
        setToken(jwtToken)
        setUser(userData)
        localStorage.setItem("auth_token", jwtToken)
        localStorage.setItem("auth_user", JSON.stringify(userData))
        return true
      }
      return false
    } catch {
      // Demo mode - simulate successful login for development
      const demoToken = "demo_jwt_token_" + Date.now()
      const userData = { email, name: email.split("@")[0] }
      
      setToken(demoToken)
      setUser(userData)
      localStorage.setItem("auth_token", demoToken)
      localStorage.setItem("auth_user", JSON.stringify(userData))
      return true
    }
  }

  const logout = () => {
    setToken(null)
    setUser(null)
    localStorage.removeItem("auth_token")
    localStorage.removeItem("auth_user")
  }

  return (
    <AuthContext.Provider value={{ user, token, login, logout, isLoading }}>
      {children}
    </AuthContext.Provider>
  )
}

export function useAuth() {
  const context = useContext(AuthContext)
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider")
  }
  return context
}
