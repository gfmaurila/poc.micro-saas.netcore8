import React from 'react';
import { Link, useLocation } from 'react-router-dom';

const Navigation = () => {
  const location = useLocation();
  
  if (location.pathname === '/login') {
    return null;
  }

  if (location.pathname === '/forgotpassword') {
    return null;
  }

  if (location.pathname === '/register') {
    return null;
  }

  return (
    


    <div className="sidebar">
{/* <nav>
      <ul>
      <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/dashboard">Dashboard</Link>
        </li>
        <li>
          <Link to="/login">Login</Link>
        </li>
      </ul>
    </nav> */}

        <div className="logo-details">
          <i className="bx bxl-c-plus-plus"></i>
          <span className="logo_name">GFMAURILA</span>
        </div>

        <ul className="nav-links">
          <li>
            <a href="/" className="active">
              <i className="bx bx-grid-alt"></i>
              <span className="links_name">Dashboard</span>
            </a>
          </li>

          <li>
            <a href="/article">
              <i className="bx bx-pie-chart-alt-2"></i>
              <span className="links_name">Artigos</span>
            </a>
          </li>
          
          <li>
            <a href="#">
              <i className="bx bx-box"></i>
              <span className="links_name">Product</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-list-ul"></i>
              <span className="links_name">Order list</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-pie-chart-alt-2"></i>
              <span className="links_name">Analytics</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-coin-stack"></i>
              <span className="links_name">Stock</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-book-alt"></i>
              <span className="links_name">Total order</span>
            </a>
          </li>
          <li>
            <a href="/team">
              <i className="bx bx-user"></i>
              <span className="links_name">Team</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-message"></i>
              <span className="links_name">Messages</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-heart"></i>
              <span className="links_name">Favrorites</span>
            </a>
          </li>
          <li>
            <a href="#">
              <i className="bx bx-cog"></i>
              <span className="links_name">Setting</span>
            </a>
          </li>
          
          <li className="log_out">
            <a href="/login">
              <i className="bx bx-log-out"></i>
              <span className="links_name">Log out</span>
            </a>
          </li>
        </ul>
        
    </div>
  );
};

export default Navigation;

