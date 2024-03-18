"use client"
import { useState, useEffect } from 'react';

interface Order {
    id: number;
    product: string;
    quantity: number;
  }


export default function Home() {
  const [orders, setOrders] = useState<Order[]>([]);
  const [product, setProduct] = useState('');
  const [quantity, setQuantity] = useState('');

  useEffect(() => {
    fetch('/api/orders')
      .then((response) => response.json())
      .then(setOrders);
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const res = await fetch('/api/orders', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ product, quantity: parseInt(quantity, 10) }),
    });

    if (res.ok) {
      const newOrder : Order = await res.json();
      setOrders([...orders, newOrder]);
      setProduct('');
      setQuantity('');
    }
  };

  return (
    <div>
      <h1>Siparişler</h1>
      <ul>
        {orders.map((order) => (
          <li key={order.id}>{order.product} - Miktar: {order.quantity}</li>
        ))}
      </ul>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={product}
          onChange={(e) => setProduct(e.target.value)}
          placeholder="Ürün adı"
          required
        />
        <input
          type="number"
          value={quantity}
          onChange={(e) => setQuantity(e.target.value)}
          placeholder="Miktar"
          required
        />
        <button type="submit">Sipariş Ekle</button>
      </form>
    </div>
  );
}
