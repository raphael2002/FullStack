import { useEffect, useState } from "react";
import { fetchInventory } from "../api/inventoryApi";

export default function InventoryList() {
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    let mounted = true;
    fetchInventory()
      .then((data) => {
        if (mounted) {
          setItems(data.data);
          setLoading(false);
        }
      })
      .catch(() => setLoading(false));
    return () => { mounted = false; };
  }, []);

  if (loading) return <p>Loading...</p>;

  return (
    <table>
      <thead>
        <tr>
          <th>SKU</th>
          <th>Name</th>
          <th>Qty</th>
          <th>Location</th>
        </tr>
      </thead>
      <tbody>
        {items.map((i) => (
          <tr key={i.id}>
            <td>{i.sku}</td>
            <td>{i.name}</td>
            <td>{i.quantity}</td>
            <td>{i.location}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
