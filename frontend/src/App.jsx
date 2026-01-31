import React, { useState } from 'react';
import axios from 'axios';
import Header from './components/Header';

function App() {
  const [ingredients, setIngredients] = useState('');
  const [recipes, setRecipes] = useState([]);
  const [error, setError] = useState(null);

  const API_URL = 'http://localhost:5000/recipes';

  const handleSearch = async () => {
    try {
      const response = await axios.get(`${API_URL}?ingredients=${ingredients}`);
      setRecipes(response.data);
      setError(null);
    } catch (err) {
      setError('Failed to fetch recipes.');
      setRecipes([]);
      console.error(err);
    }
  };

  return (
    <div className="App">
      <Header />
      <div>
        <input
          type="text"
          placeholder="Enter ingredients"
          value={ingredients}
          onChange={(e) => setIngredients(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <ul>
        {recipes.map((recipe) => (
          <li key={recipe.id}>
            <h3>{recipe.name}</h3>
            <p>Ingredients: {recipe.ingredients}</p>
            <p>Instructions: {recipe.instructions}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;