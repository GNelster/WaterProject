import './App.css';
import { CartProvider } from './context/CartContext';
import AdminProjectsPage from './pages/AdminProjectsPage';
import CartPage from './pages/CartPage';
import DonatePage from './pages/DonatePage';
import ProjectsPage from './pages/ProjectsPage';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {
  return (
    <>
      <CartProvider>
        <Router>
          <Routes>
            <Route path="/" element={<ProjectsPage />} />
            <Route
              path="/donate/:projectName/:projectId"
              element={<DonatePage />}
            />
            <Route path="/projects" element={<ProjectsPage />} />
            <Route path="/cart" element={<CartPage />} />
            <Route path="/adminprojects" element={<AdminProjectsPage />} />
          </Routes>
          {/* All routes within CartProvider are considered children of the CartProvider, in line with our CartContext. */}
        </Router>
      </CartProvider>
    </>
  );
}

export default App;
