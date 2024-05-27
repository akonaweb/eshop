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
  category: CategoryType;
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
      {categories.map((category) => {
        const filteredProducts = products.filter(
          (product) => product.category.id === category.id
        );

        return (
          <div key={category.id}>
            <h2>
              {category.id} - {category.name}
            </h2>

            <ul>
              {filteredProducts.length ? (
                filteredProducts.map((product) => (
                  <li key={product.id}>
                    {product.id} - {product.title} - {product.description} - $
                    {product.price}
                  </li>
                ))
              ) : (
                <li>No products available for this category</li>
              )}
            </ul>
          </div>
        );
      })}
    </div>
  );
};

export default App;
