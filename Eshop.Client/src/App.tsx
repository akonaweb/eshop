import { useEffect, useState } from "react";

type CategoryType = {
  id: number;
  name: string;
};

type ProductType = {
  id: number;
  title: string;
  description: string;
  price: number;
};

const App = () => {
  const [categories, setCategories] = useState<CategoryType[]>([]);
  const [products, setProducts] = useState<ProductType[]>([]);

  useEffect(() => {
    const loadCategories = async () => {
      const categoryResult = await (
        await fetch("https://localhost:7203/Category")
      ).json();
      setCategories(categoryResult);
    };

    const loadProducts = async () => {
      const productResult = await (
        await fetch("https://localhost:7203/Product")
      ).json();
      setProducts(productResult);
    };

    loadCategories();
    loadProducts();
  }, []);

  return (
    <div>
      {categories.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.name}
          </li>
        );
      })}

      {products.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.title} - {x.description} - {x.price}
          </li>
        );
      })}
    </div>
  );
};

export default App;
