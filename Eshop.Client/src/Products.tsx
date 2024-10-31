import { useEffect, useState } from "react";

import { CategoryType } from "./Categories";
import "./Products.css";

type ProductType = {
  id: number;
  title: string;
  description: string;
  price: number;
  category: CategoryType;
};

type Props = {
  activeCategoryId: number;
};
const Products = ({ activeCategoryId }: Props) => {
  const [products, setProducts] = useState<ProductType[]>([]);

  useEffect(() => {
    const loadProducts = async () => {
      const productResult = await (
        await fetch("https://localhost:7203/Product")
      ).json();

      setProducts(
        productResult?.filter(
          (x: { category: { id: number } }) =>
            x.category?.id === activeCategoryId
        )
      );
    };

    loadProducts();
  }, [activeCategoryId]);

  return (
    <div className="products">
      {products.map((product) => {
        return (
          <div key={product.id} className="product-box">
            <div>Name: {product.title}</div>
            <div>Price: {product.price}</div>
            <div>Desc.:{product.description}</div>
          </div>
        );
      })}
    </div>
  );
};

export default Products;
