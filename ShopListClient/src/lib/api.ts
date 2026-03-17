const API_BASE = "https://localhost:7017/api"

export interface ShoppingList {
  Key: string
  Name: string
  Date: string
}

export interface ProductInListDTO {
  key: string
  ProductName: string
  Quantity: number
}

// Demo data for development
const demoLists: ShoppingList[] = [
  { Key: "1", Name: "Weekly Groceries", Date: "2026-03-15" },
  { Key: "2", Name: "Party Supplies", Date: "2026-03-14" },
  { Key: "3", Name: "Home Essentials", Date: "2026-03-12" },
  { Key: "4", Name: "Office Supplies", Date: "2026-03-10" },
]

const demoProducts: Record<string, ProductInListDTO[]> = {
  "1": [
    { key: "p1", ProductName: "Organic Milk", Quantity: 2 },
    { key: "p2", ProductName: "Whole Grain Bread", Quantity: 1 },
    { key: "p3", ProductName: "Fresh Salmon", Quantity: 1 },
    { key: "p4", ProductName: "Avocados", Quantity: 4 },
    { key: "p5", ProductName: "Greek Yogurt", Quantity: 3 },
  ],
  "2": [
    { key: "p6", ProductName: "Champagne", Quantity: 3 },
    { key: "p7", ProductName: "Party Plates", Quantity: 50 },
    { key: "p8", ProductName: "Napkins", Quantity: 100 },
    { key: "p9", ProductName: "Decorations", Quantity: 1 },
  ],
  "3": [
    { key: "p10", ProductName: "Laundry Detergent", Quantity: 1 },
    { key: "p11", ProductName: "Paper Towels", Quantity: 4 },
    { key: "p12", ProductName: "Dish Soap", Quantity: 2 },
  ],
  "4": [
    { key: "p13", ProductName: "Notebooks", Quantity: 5 },
    { key: "p14", ProductName: "Pens", Quantity: 10 },
    { key: "p15", ProductName: "Sticky Notes", Quantity: 3 },
  ],
}

export async function fetchShoppingLists(token: string): Promise<ShoppingList[]> {
  try {
    const response = await fetch(`${API_BASE}/shopping-lists`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    if (response.ok) {
      return response.json()
    }
    return demoLists
  } catch {
    return demoLists
  }
}

export async function fetchListProducts(
  token: string,
  listKey: string
): Promise<ProductInListDTO[]> {
  try {
    const response = await fetch(`${API_BASE}/shopping-lists/${listKey}/products`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    if (response.ok) {
      return response.json()
    }
    return demoProducts[listKey] || []
  } catch {
    return demoProducts[listKey] || []
  }
}

export async function createShoppingList(
  token: string,
  name: string
): Promise<ShoppingList | null> {
  try {
    const response = await fetch(`${API_BASE}/shopping-lists`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify({ Name: name }),
    })
    if (response.ok) {
      return response.json()
    }
    // Demo fallback
    const newList: ShoppingList = {
      Key: `demo_${Date.now()}`,
      Name: name,
      Date: new Date().toISOString().split("T")[0],
    }
    demoLists.unshift(newList)
    demoProducts[newList.Key] = []
    return newList
  } catch {
    const newList: ShoppingList = {
      Key: `demo_${Date.now()}`,
      Name: name,
      Date: new Date().toISOString().split("T")[0],
    }
    demoLists.unshift(newList)
    demoProducts[newList.Key] = []
    return newList
  }
}

export async function addProductToList(
  token: string,
  listKey: string,
  productName: string,
  quantity: number
): Promise<ProductInListDTO | null> {
  try {
    const response = await fetch(`${API_BASE}/shopping-lists/${listKey}/products`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify({ ProductName: productName, Quantity: quantity }),
    })
    if (response.ok) {
      return response.json()
    }
    // Demo fallback
    const newProduct: ProductInListDTO = {
      key: `demo_p_${Date.now()}`,
      ProductName: productName,
      Quantity: quantity,
    }
    if (!demoProducts[listKey]) {
      demoProducts[listKey] = []
    }
    demoProducts[listKey].push(newProduct)
    return newProduct
  } catch {
    const newProduct: ProductInListDTO = {
      key: `demo_p_${Date.now()}`,
      ProductName: productName,
      Quantity: quantity,
    }
    if (!demoProducts[listKey]) {
      demoProducts[listKey] = []
    }
    demoProducts[listKey].push(newProduct)
    return newProduct
  }
}

export async function deleteProduct(
  token: string,
  listKey: string,
  productKey: string
): Promise<boolean> {
  try {
    const response = await fetch(
      `${API_BASE}/shopping-lists/${listKey}/products/${productKey}`,
      {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    )
    if (response.ok) {
      return true
    }
    // Demo fallback
    if (demoProducts[listKey]) {
      demoProducts[listKey] = demoProducts[listKey].filter((p) => p.key !== productKey)
    }
    return true
  } catch {
    if (demoProducts[listKey]) {
      demoProducts[listKey] = demoProducts[listKey].filter((p) => p.key !== productKey)
    }
    return true
  }
}
