"use client"

import { useState, useEffect } from "react"
import { useAuth } from "@/lib/auth-context"
import { fetchShoppingLists, createShoppingList, type ShoppingList } from "@/lib/api"
import { ListDetails } from "@/components/list-details"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Spinner } from "@/components/ui/spinner"
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog"
import {
  Plus,
  Calendar,
  ChevronRight,
  ShoppingBag,
  Search,
  ArrowLeft,
} from "lucide-react"

export function ShoppingLists() {
  const { token } = useAuth()
  const [lists, setLists] = useState<ShoppingList[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [selectedList, setSelectedList] = useState<ShoppingList | null>(null)
  const [searchQuery, setSearchQuery] = useState("")
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false)
  const [newListName, setNewListName] = useState("")
  const [isCreating, setIsCreating] = useState(false)

  useEffect(() => {
    if (token) {
      loadLists()
    }
  }, [token])

  const loadLists = async () => {
    if (!token) return
    setIsLoading(true)
    const data = await fetchShoppingLists(token)
    setLists(data)
    setIsLoading(false)
  }

  const handleCreateList = async () => {
    if (!token || !newListName.trim()) return
    setIsCreating(true)
    const newList = await createShoppingList(token, newListName.trim())
    if (newList) {
      setLists((prev) => [newList, ...prev])
      setNewListName("")
      setIsCreateDialogOpen(false)
    }
    setIsCreating(false)
  }

  const filteredLists = lists.filter((list) =>
    list.Name.toLowerCase().includes(searchQuery.toLowerCase())
  )

  const formatDate = (dateString: string) => {
    const date = new Date(dateString)
    return date.toLocaleDateString("en-US", {
      month: "short",
      day: "numeric",
      year: "numeric",
    })
  }

  if (selectedList) {
    return (
      <div className="h-full">
        <div className="px-8 py-6 border-b border-border">
          <button
            onClick={() => setSelectedList(null)}
            className="flex items-center gap-2 text-muted-foreground hover:text-foreground transition-colors mb-4"
          >
            <ArrowLeft className="w-4 h-4" />
            <span className="text-sm font-medium">Back to Lists</span>
          </button>
          <h1 className="text-2xl font-bold text-foreground">{selectedList.Name}</h1>
          <p className="text-muted-foreground mt-1">
            Created on {formatDate(selectedList.Date)}
          </p>
        </div>
        <ListDetails listKey={selectedList.Key} onBack={() => setSelectedList(null)} />
      </div>
    )
  }

  return (
    <div className="h-full flex flex-col">
      {/* Header */}
      <div className="px-8 py-6 border-b border-border">
        <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4">
          <div>
            <h1 className="text-2xl font-bold text-foreground">My Shopping Lists</h1>
            <p className="text-muted-foreground mt-1">
              Manage and organize your shopping
            </p>
          </div>

          <Dialog open={isCreateDialogOpen} onOpenChange={setIsCreateDialogOpen}>
            <DialogTrigger asChild>
              <Button className="bg-primary text-primary-foreground hover:bg-primary/90 h-11 px-5">
                <Plus className="w-4 h-4 mr-2" />
                New List
              </Button>
            </DialogTrigger>
            <DialogContent className="bg-card border-border">
              <DialogHeader>
                <DialogTitle className="text-foreground">Create New List</DialogTitle>
                <DialogDescription className="text-muted-foreground">
                  Give your shopping list a name to get started.
                </DialogDescription>
              </DialogHeader>
              <div className="py-4">
                <Label htmlFor="list-name" className="text-foreground">
                  List Name
                </Label>
                <Input
                  id="list-name"
                  placeholder="e.g., Weekly Groceries"
                  value={newListName}
                  onChange={(e) => setNewListName(e.target.value)}
                  className="mt-2 h-11 bg-secondary border-border"
                  onKeyDown={(e) => e.key === "Enter" && handleCreateList()}
                />
              </div>
              <DialogFooter>
                <Button
                  variant="ghost"
                  onClick={() => setIsCreateDialogOpen(false)}
                  className="text-muted-foreground hover:text-foreground"
                >
                  Cancel
                </Button>
                <Button
                  onClick={handleCreateList}
                  disabled={isCreating || !newListName.trim()}
                  className="bg-primary text-primary-foreground hover:bg-primary/90"
                >
                  {isCreating ? <Spinner className="w-4 h-4" /> : "Create List"}
                </Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>
        </div>

        {/* Search */}
        <div className="mt-6 relative max-w-md">
          <Search className="absolute left-4 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
          <Input
            placeholder="Search lists..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="h-11 pl-11 bg-secondary border-border"
          />
        </div>
      </div>

      {/* Lists Grid */}
      <div className="flex-1 p-8 overflow-auto">
        {isLoading ? (
          <div className="flex items-center justify-center h-64">
            <Spinner className="w-8 h-8 text-primary" />
          </div>
        ) : filteredLists.length === 0 ? (
          <div className="flex flex-col items-center justify-center h-64 text-center">
            <div className="w-16 h-16 rounded-2xl bg-secondary flex items-center justify-center mb-4">
              <ShoppingBag className="w-8 h-8 text-muted-foreground" />
            </div>
            <h3 className="text-lg font-semibold text-foreground">No lists found</h3>
            <p className="text-muted-foreground mt-1 max-w-sm">
              {searchQuery
                ? "Try a different search term"
                : "Create your first shopping list to get started"}
            </p>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-4">
            {filteredLists.map((list) => (
              <button
                key={list.Key}
                onClick={() => setSelectedList(list)}
                className="group p-6 rounded-2xl bg-card border border-border hover:border-primary/50 transition-all duration-200 text-left"
              >
                <div className="flex items-start justify-between">
                  <div className="w-12 h-12 rounded-xl bg-primary/10 flex items-center justify-center">
                    <ShoppingBag className="w-6 h-6 text-primary" />
                  </div>
                  <ChevronRight className="w-5 h-5 text-muted-foreground group-hover:text-primary transition-colors" />
                </div>
                <h3 className="mt-4 text-lg font-semibold text-foreground group-hover:text-primary transition-colors">
                  {list.Name}
                </h3>
                <div className="mt-2 flex items-center gap-2 text-sm text-muted-foreground">
                  <Calendar className="w-4 h-4" />
                  <span>{formatDate(list.Date)}</span>
                </div>
              </button>
            ))}
          </div>
        )}
      </div>
    </div>
  )
}
