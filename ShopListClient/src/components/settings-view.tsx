"use client"

import { useState } from "react"
import { useTheme } from "@/lib/theme-context"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Switch } from "@/components/ui/switch"
import { Separator } from "@/components/ui/separator"
import { Bell, Moon, Sun, Globe, Shield, Save, Check } from "lucide-react"

export function SettingsView() {
  const [notifications, setNotifications] = useState(true)
  const [language, setLanguage] = useState("en")
  const [isSaved, setIsSaved] = useState(false)
  const { theme, toggleTheme } = useTheme()

  const isDarkMode = theme === "dark"

  const handleSave = () => {
    setIsSaved(true)
    setTimeout(() => setIsSaved(false), 2000)
  }

  return (
    <div className="h-full flex flex-col">
      {/* Header */}
      <div className="px-8 py-6 border-b border-border">
        <h1 className="text-2xl font-bold text-foreground">Settings</h1>
        <p className="text-muted-foreground mt-1">
          Manage your application preferences
        </p>
      </div>

      {/* Settings Content */}
      <div className="flex-1 p-8 overflow-auto">
        <div className="max-w-2xl space-y-8">
          {/* Notifications */}
          <div className="p-6 rounded-2xl bg-card border border-border shadow-sm">
            <div className="flex items-start gap-4">
              <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                <Bell className="w-5 h-5 text-primary" />
              </div>
              <div className="flex-1">
                <div className="flex items-center justify-between">
                  <div>
                    <h3 className="font-semibold text-foreground">Notifications</h3>
                    <p className="text-sm text-muted-foreground mt-1">
                      Receive notifications about list updates and reminders
                    </p>
                  </div>
                  <Switch
                    checked={notifications}
                    onCheckedChange={setNotifications}
                  />
                </div>
              </div>
            </div>
          </div>

          {/* Dark Mode */}
          <div className="p-6 rounded-2xl bg-card border border-border shadow-sm">
            <div className="flex items-start gap-4">
              <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                {isDarkMode ? (
                  <Moon className="w-5 h-5 text-primary" />
                ) : (
                  <Sun className="w-5 h-5 text-primary" />
                )}
              </div>
              <div className="flex-1">
                <div className="flex items-center justify-between">
                  <div>
                    <h3 className="font-semibold text-foreground">
                      {isDarkMode ? "Dark Mode" : "Light Mode"}
                    </h3>
                    <p className="text-sm text-muted-foreground mt-1">
                      {isDarkMode 
                        ? "Switch to light mode for a bright, clean appearance" 
                        : "Switch to dark mode for comfortable viewing in low light"
                      }
                    </p>
                  </div>
                  <Switch
                    checked={isDarkMode}
                    onCheckedChange={toggleTheme}
                  />
                </div>
              </div>
            </div>
          </div>

          {/* Language */}
          <div className="p-6 rounded-2xl bg-card border border-border shadow-sm">
            <div className="flex items-start gap-4">
              <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                <Globe className="w-5 h-5 text-primary" />
              </div>
              <div className="flex-1 space-y-4">
                <div>
                  <h3 className="font-semibold text-foreground">Language</h3>
                  <p className="text-sm text-muted-foreground mt-1">
                    Select your preferred language
                  </p>
                </div>
                <div className="space-y-2">
                  <Label htmlFor="language" className="sr-only">
                    Language
                  </Label>
                  <select
                    id="language"
                    value={language}
                    onChange={(e) => setLanguage(e.target.value)}
                    className="w-full h-11 px-4 rounded-xl bg-secondary border border-border text-foreground focus:border-primary focus:ring-2 focus:ring-primary/20 outline-none transition-all"
                  >
                    <option value="en">English</option>
                    <option value="es">Spanish</option>
                    <option value="fr">French</option>
                    <option value="de">German</option>
                  </select>
                </div>
              </div>
            </div>
          </div>

          {/* Security */}
          <div className="p-6 rounded-2xl bg-card border border-border shadow-sm">
            <div className="flex items-start gap-4">
              <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center shrink-0">
                <Shield className="w-5 h-5 text-primary" />
              </div>
              <div className="flex-1 space-y-4">
                <div>
                  <h3 className="font-semibold text-foreground">Security</h3>
                  <p className="text-sm text-muted-foreground mt-1">
                    Manage your account security settings
                  </p>
                </div>
                <Separator className="bg-border" />
                <div className="space-y-4">
                  <div className="space-y-2">
                    <Label htmlFor="current-password" className="text-foreground">
                      Current Password
                    </Label>
                    <Input
                      id="current-password"
                      type="password"
                      placeholder="Enter current password"
                      className="h-11 bg-secondary border-border"
                    />
                  </div>
                  <div className="space-y-2">
                    <Label htmlFor="new-password" className="text-foreground">
                      New Password
                    </Label>
                    <Input
                      id="new-password"
                      type="password"
                      placeholder="Enter new password"
                      className="h-11 bg-secondary border-border"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* Save Button */}
          <div className="flex justify-end">
            <Button
              onClick={handleSave}
              className="h-11 px-6 bg-primary text-primary-foreground hover:bg-primary/90"
            >
              {isSaved ? (
                <>
                  <Check className="w-4 h-4 mr-2" />
                  Saved
                </>
              ) : (
                <>
                  <Save className="w-4 h-4 mr-2" />
                  Save Changes
                </>
              )}
            </Button>
          </div>
        </div>
      </div>
    </div>
  )
}
