import React from 'react';
import './App.css'; 
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';

import UserPage from './pages/Team/UserPage';
import CreateUserPage from './pages/Team/CreateUserPage';
import UserUpdatePage from './pages/Team/UserUpdatePage';

import ArticlePage from './pages/Article/ArticlePage';
import ArticleCreatePage from './pages/Article/ArticleCreatePage';
import ArticleUpdatePage from './pages/Article/ArticleUpdatePage';

import LoginPage from './pages/Login/LoginPage';
import ForgotPasswordPage from './pages/Login/ForgotPasswordPage';
import RegisterPage from './pages/Login/RegisterPage';
import Navigation from './components/Navigation';

function App() {

  return (
    <Router>
        <Navigation  />
        <Routes>
            <Route path="/" element={<HomePage />} />
            {/* <Route path="/dashboard" element={<MainLayout />} /> */}
            <Route path="/login" element={<LoginPage />} />
            <Route path="/forgotpassword" element={<ForgotPasswordPage />} />
            <Route path="/register" element={<RegisterPage />} />


            <Route path="/team" element={<UserPage />} />
            <Route path="/team/usuario/novo" element={<CreateUserPage />} />
            <Route path="/team/usuario/editar" element={<UserUpdatePage />} />

            <Route path="/article" element={<ArticlePage />} />
            <Route path="/article/novo" element={<ArticleCreatePage />} />
            <Route path="/article/editar" element={<ArticleUpdatePage />} />

          </Routes>        
      </Router>
  );
}

export default App;
