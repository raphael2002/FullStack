const API_BASE = "https://localhost:5001/api/inventory";

export async function fetchInventory(page = 1, pageSize = 20) {
  const res = await fetch(`${API_BASE}?page=${page}&pageSize=${pageSize}`);
  if (!res.ok) throw new Error("Failed to load inventory");
  return res.json();
}

export async function createItem(item) {
  const res = await fetch(API_BASE, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  if (!res.ok) throw new Error("Failed to create item");
  return res.json();
}

export async function updateItem(id, item) {
  const res = await fetch(`${API_BASE}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item),
  });
  if (!res.ok) throw new Error("Failed to update item");
}

export async function deleteItem(id) {
  const res = await fetch(`${API_BASE}/${id}`, { method: "DELETE" });
  if (!res.ok) throw new Error("Failed to delete item");
}
