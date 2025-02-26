import React from 'react';

const LoginPage = () => {

  return (
    <div className="wrapper">
      <form action="#">
        <h2 className='h2-login'>Login</h2>
        <div className="input-field">
          <input type="text" required />
          <label>Enter your email</label>
        </div>
        <div className="input-field">
          <input type="password" required />
          <label>Enter your password</label>
        </div>
        <div className="forget">
          <label htmlFor="remember">
            <input type="checkbox" id="remember" />
            <p>Remember me</p>
          </label>
          <a href="/forgotpassword">Forgot password?</a>
        </div>
        <button type="submit" className='bt-login'>Log In</button>
        <div className="register">
          <p>Don't have an account? <a href="/register">Register</a></p>
        </div>
      </form>
    </div>  
  );
};

export default LoginPage;
