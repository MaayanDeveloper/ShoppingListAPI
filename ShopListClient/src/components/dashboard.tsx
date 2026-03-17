"use client"

import { useState } from "react"
import { SidebarProvider, SidebarInset, SidebarTrigger } from "@/components/ui/sidebar"
import { AppSidebar } from "@/components/app-sidebar"
import { ShoppingLists } from "@/components/shopping-lists"
import { SettingsView } from "@/components/settings-view"
import { ProfileView } from "@/components/profile-view"
import { Separator } from "@/components/ui/separator"

export function Dashboard() {
  const [activeView, setActiveView] = useState<"lists" | "settings" | "profile">("lists")

  return (
    <SidebarProvider>
      <AppSidebar activeView={activeView} onViewChange={setActiveView} />
      <SidebarInset className="bg-background">
        {/* Top bar for mobile */}
        <header className="flex h-14 shrink-0 items-center gap-2 border-b border-border px-4 md:hidden">
          <SidebarTrigger className="-ml-1" />
          <Separator orientation="vertical" className="h-4 bg-border" />
          <span className="text-sm font-medium text-foreground">
            {activeView === "lists" && "My Lists"}
            {activeView === "settings" && "Settings"}
            {activeView === "profile" && "Profile"}
          </span>
        </header>

        {/* Main Content */}
        <div className="flex-1 overflow-hidden">
          {activeView === "lists" && <ShoppingLists />}
          {activeView === "settings" && <SettingsView />}
          {activeView === "profile" && <ProfileView />}
        </div>
      </SidebarInset>
    </SidebarProvider>
  )
}
