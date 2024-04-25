import { useEffect, useState } from 'react'

type CategoryType = {
  id: number
  name: string
}

function App() {
  const [categories, setCategories] = useState<CategoryType[]>([])
  useEffect(()=>{
    const loadCategories = async() =>{
      const result = await (await fetch('https://localhost:7203/Category')).json()

      setCategories(result)
    }

    loadCategories();
  }, [])

  return (
    <ul>
      {categories.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.name}
          </li>
      )
      })}
    </ul>
  );

 
}

export default App;
