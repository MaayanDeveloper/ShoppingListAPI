"use client"

import { useState } from "react"
import { useAuth } from "@/lib/auth-context"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Avatar, AvatarFallback } from "@/components/ui/avatar"
import { Separator } from "@/components/ui/separator"
import { Camera, Mail, User, Calendar, Edit3, Save, Check } from "lucide-react"

export function ProfileView() {
  const { user } = useAuth()
  const [isEditing, setIsEditing] = useState(false)
  const [name, setName] = useState(user?.name || "")
  const [email, setEmail] = useState(user?.email || "")
  const [isSaved, setIsSaved] = useState(false)

  const initials = name
    ? name
        .split(" ")
        .map((n) => n[0])
        .join("")
        .toUpperCase()
        .slice(0, 2)
    : "U"

  const handleSave = () => {
    setIsEditing(false)
    setIsSaved(true)
    setTimeout(() => setIsSaved(false), 2000)
  }

  return (
    <div className="h-full flex flex-col">
      {/* Header */}
      <div className="px-8 py-6 border-b border-border">
        <h1 className="text-2xl font-bold text-foreground">Profile</h1>
        <p className="text-muted-foreground mt-1">
          Manage your account information
        </p>
      </div>

      {/* Profile Content */}
      <div className="flex-1 p-8 overflow-auto">
        <div className="max-w-2xl">
          {/* Avatar Section */}
          <div className="flex flex-col sm:flex-row items-center gap-6 p-6 rounded-2xl bg-card border border-border">
            <div className="relative">
              <Avatar className="w-24 h-24 border-4 border-primary/20">
                <AvatarFallback className="bg-primary/10 text-primary text-2xl font-semibold">
                  {initials}
                </AvatarFallback>
              </Avatar>
              <button className="absolute bottom-0 right-0 w-8 h-8 rounded-full bg-primary flex items-center justify-center border-2 border-card hover:bg-primary/90 transition-colors">
                <Camera className="w-4 h-4 text-primary-foreground" />
              </button>
            </div>
            <div className="text-center sm:text-left">
              <h2 className="text-xl font-semibold text-foreground">{name || "User"}</h2>
              <p className="text-muted-foreground mt-1">{email || "user@example.com"}</p>
              <div className="mt-3 flex items-center justify-center sm:justify-start gap-2 text-sm text-muted-foreground">
                <Calendar className="w-4 h-4" />
                <span>Member since March 2026</span>
              </div>
            </div>
          </div>

          {/* Profile Information */}
          <div className="mt-6 p-6 rounded-2xl bg-card border border-border">
            <div className="flex items-center justify-between mb-6">
              <h3 className="text-lg font-semibold text-foreground">
                Personal Information
              </h3>
              {!isEditing ? (
                <Button
                  variant="ghost"
                  onClick={() => setIsEditing(true)}
                  className="text-primary hover:text-primary hover:bg-primary/10"
                >
                  <Edit3 className="w-4 h-4 mr-2" />
                  Edit
                </Button>
              ) : (
                <Button
                  onClick={handleSave}
                  className="bg-primary text-primary-foreground hover:bg-primary/90"
                >
                  {isSaved ? (
                    <>
                      <Check className="w-4 h-4 mr-2" />
                      Saved
                    </>
                  ) : (
                    <>
                      <Save className="w-4 h-4 mr-2" />
                      Save
                    </>
                  )}
                </Button>
              )}
            </div>

            <div className="space-y-6">
              <div className="flex items-start gap-4">
                <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                  <User className="w-5 h-5 text-primary" />
                </div>
                <div className="flex-1 space-y-2">
                  <Label htmlFor="name" className="text-foreground">
                    Full Name
                  </Label>
                  {isEditing ? (
                    <Input
                      id="name"
                      value={name}
                      onChange={(e) => setName(e.target.value)}
                      className="h-11 bg-secondary border-border"
                    />
                  ) : (
                    <p className="text-foreground py-2">{name || "Not set"}</p>
                  )}
                </div>
              </div>

              <Separator className="bg-border" />

              <div className="flex items-start gap-4">
                <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                  <Mail className="w-5 h-5 text-primary" />
                </div>
                <div className="flex-1 space-y-2">
                  <Label htmlFor="email" className="text-foreground">
                    Email Address
                  </Label>
                  {isEditing ? (
                    <Input
                      id="email"
                      type="email"
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      className="h-11 bg-secondary border-border"
                    />
                  ) : (
                    <p className="text-foreground py-2">{email || "Not set"}</p>
                  )}
                </div>
              </div>
            </div>
          </div>

          {/* Stats */}
          <div className="mt-6 grid grid-cols-1 sm:grid-cols-3 gap-4">
            <div className="p-5 rounded-2xl bg-card border border-border text-center">
              <p className="text-3xl font-bold text-primary">12</p>
              <p className="text-sm text-muted-foreground mt-1">Total Lists</p>
            </div>
            <div className="p-5 rounded-2xl bg-card border border-border text-center">
              <p className="text-3xl font-bold text-primary">47</p>
              <p className="text-sm text-muted-foreground mt-1">Products Added</p>
            </div>
            <div className="p-5 rounded-2xl bg-card border border-border text-center">
              <p className="text-3xl font-bold text-primary">8</p>
              <p className="text-sm text-muted-foreground mt-1">This Month</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
