"use client"

import { useState, useEffect } from "react"
import { useAuth } from "@/lib/auth-context"
import {
  fetchListProducts,
  addProductToList,
  deleteProduct,
  type ProductInListDTO,
} from "@/lib/api"
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
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger,
} from "@/components/ui/alert-dialog"
import { Plus, Trash2, Package, Hash } from "lucide-react"

interface ListDetailsProps {
  listKey: string
  onBack: () => void
}

export function ListDetails({ listKey }: ListDetailsProps) {
  const { token } = useAuth()
  const [products, setProducts] = useState<ProductInListDTO[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [isAddDialogOpen, setIsAddDialogOpen] = useState(false)
  const [newProductName, setNewProductName] = useState("")
  const [newProductQuantity, setNewProductQuantity] = useState(1)
  const [isAdding, setIsAdding] = useState(false)
  const [deletingKey, setDeletingKey] = useState<string | null>(null)

  useEffect(() => {
    if (token) {
      loadProducts()
    }
  }, [token, listKey])

  const loadProducts = async () => {
    if (!token) return
    setIsLoading(true)
    const data = await fetchListProducts(token, listKey)
    setProducts(data)
    setIsLoading(false)
  }

  const handleAddProduct = async () => {
    if (!token || !newProductName.trim()) return
    setIsAdding(true)
    const newProduct = await addProductToList(
      token,
      listKey,
      newProductName.trim(),
      newProductQuantity
    )
    if (newProduct) {
      setProducts((prev) => [...prev, newProduct])
      setNewProductName("")
      setNewProductQuantity(1)
      setIsAddDialogOpen(false)
    }
    setIsAdding(false)
  }

  const handleDeleteProduct = async (productKey: string) => {
    if (!token) return
    setDeletingKey(productKey)
    const success = await deleteProduct(token, listKey, productKey)
    if (success) {
      setProducts((prev) => prev.filter((p) => p.key !== productKey))
    }
    setDeletingKey(null)
  }

  return (
    <div className="p-8">
      {/* Actions */}
      <div className="mb-6">
        <Dialog open={isAddDialogOpen} onOpenChange={setIsAddDialogOpen}>
          <DialogTrigger asChild>
            <Button className="bg-primary text-primary-foreground hover:bg-primary/90 h-11 px-5">
              <Plus className="w-4 h-4 mr-2" />
              Add Product
            </Button>
          </DialogTrigger>
          <DialogContent className="bg-card border-border">
            <DialogHeader>
              <DialogTitle className="text-foreground">Add Product</DialogTitle>
              <DialogDescription className="text-muted-foreground">
                Add a new item to your shopping list.
              </DialogDescription>
            </DialogHeader>
            <div className="space-y-4 py-4">
              <div className="space-y-2">
                <Label htmlFor="product-name" className="text-foreground">
                  Product Name
                </Label>
                <Input
                  id="product-name"
                  placeholder="e.g., Organic Milk"
                  value={newProductName}
                  onChange={(e) => setNewProductName(e.target.value)}
                  className="h-11 bg-secondary border-border"
                />
              </div>
              <div className="space-y-2">
                <Label htmlFor="product-quantity" className="text-foreground">
                  Quantity
                </Label>
                <Input
                  id="product-quantity"
                  type="number"
                  min={1}
                  value={newProductQuantity}
                  onChange={(e) => setNewProductQuantity(parseInt(e.target.value) || 1)}
                  className="h-11 bg-secondary border-border"
                />
              </div>
            </div>
            <DialogFooter>
              <Button
                variant="ghost"
                onClick={() => setIsAddDialogOpen(false)}
                className="text-muted-foreground hover:text-foreground"
              >
                Cancel
              </Button>
              <Button
                onClick={handleAddProduct}
                disabled={isAdding || !newProductName.trim()}
                className="bg-primary text-primary-foreground hover:bg-primary/90"
              >
                {isAdding ? <Spinner className="w-4 h-4" /> : "Add Product"}
              </Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
      </div>

      {/* Products List */}
      {isLoading ? (
        <div className="flex items-center justify-center h-64">
          <Spinner className="w-8 h-8 text-primary" />
        </div>
      ) : products.length === 0 ? (
        <div className="flex flex-col items-center justify-center h-64 text-center">
          <div className="w-16 h-16 rounded-2xl bg-secondary flex items-center justify-center mb-4">
            <Package className="w-8 h-8 text-muted-foreground" />
          </div>
          <h3 className="text-lg font-semibold text-foreground">No products yet</h3>
          <p className="text-muted-foreground mt-1 max-w-sm">
            Add your first product to this list
          </p>
        </div>
      ) : (
        <div className="space-y-3">
          {products.map((product) => (
            <div
              key={product.key}
              className="group flex items-center justify-between p-5 rounded-xl bg-card border border-border hover:border-primary/30 transition-all duration-200"
            >
              <div className="flex items-center gap-4">
                <div className="w-11 h-11 rounded-xl bg-primary/10 flex items-center justify-center">
                  <Package className="w-5 h-5 text-primary" />
                </div>
                <div>
                  <h4 className="font-medium text-foreground">{product.ProductName}</h4>
                  <div className="flex items-center gap-1.5 mt-1 text-sm text-muted-foreground">
                    <Hash className="w-3.5 h-3.5" />
                    <span>Quantity: {product.Quantity}</span>
                  </div>
                </div>
              </div>

              <AlertDialog>
                <AlertDialogTrigger asChild>
                  <Button
                    variant="ghost"
                    size="icon"
                    className="opacity-0 group-hover:opacity-100 transition-opacity text-muted-foreground hover:text-destructive hover:bg-destructive/10"
                  >
                    {deletingKey === product.key ? (
                      <Spinner className="w-4 h-4" />
                    ) : (
                      <Trash2 className="w-4 h-4" />
                    )}
                  </Button>
                </AlertDialogTrigger>
                <AlertDialogContent className="bg-card border-border">
                  <AlertDialogHeader>
                    <AlertDialogTitle className="text-foreground">
                      Delete Product
                    </AlertDialogTitle>
                    <AlertDialogDescription className="text-muted-foreground">
                      Are you sure you want to remove {`"${product.ProductName}"`} from this
                      list? This action cannot be undone.
                    </AlertDialogDescription>
                  </AlertDialogHeader>
                  <AlertDialogFooter>
                    <AlertDialogCancel className="text-foreground border-border hover:bg-secondary">
                      Cancel
                    </AlertDialogCancel>
                    <AlertDialogAction
                      onClick={() => handleDeleteProduct(product.key)}
                      className="bg-destructive text-destructive-foreground hover:bg-destructive/90"
                    >
                      Delete
                    </AlertDialogAction>
                  </AlertDialogFooter>
                </AlertDialogContent>
              </AlertDialog>
            </div>
          ))}
        </div>
      )}
    </div>
  )
}
