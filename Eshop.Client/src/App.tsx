import React from 'react'
import { useEffect, useState } from 'react'

type CategoryType = {
  id: number
  name: string
}

type ProductType = {
  id: number
  title: string
  description: string
  price: number
}



function App() {
  const [categories, setCategories] = useState<CategoryType[]>([])
  useEffect(()=>{
    const loadCategories = async() =>{
      const categoryResult = await (await fetch('https://localhost:7203/Category')).json()

      setCategories(categoryResult)
    }

    loadCategories();
  }, [])

  const [products, setProducts] = useState<ProductType[]>([])
  useEffect(()=>{
    const loadProducts = async() =>{
      const productResult = await (await fetch('https://localhost:7203/Product')).json()

      setProducts(productResult)
    }

    loadProducts();
  }, [])



  return (
    <div>
      {categories.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.name}
          </li>
      )
      })}

      {products.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.title} - {x.description} - {x.price}
          </li>
      )
      })}
    </div>

  );

 
}

export default App;
