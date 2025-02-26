import React from 'react';

const RegisterPage = () => {
  return (
    <div className="wrapper">
      <form action="#">
        <h2 className='h2-login'>Register</h2>
        
        <div className="input-field">
          <input type="text" required/>
          <label>Name</label>
        </div>


        <div className="input-field">
          <input type="text" required/>
          <label>Enter your email</label>
        </div>

        <div className="input-field">
          <input type="text" required/>
          <label>Phone</label>
        </div>

        <div className="input-field">
          <input type="password" required/>
          <label>Enter your password</label>
        </div>

        <div className="input-field">
          <input type="password" required/>
          <label>Confirm your password</label>
        </div>

        <button type="submit" className='bt-login'>Register</button>
        
        <div className="register">
          <p>Voltar ao <a href="/login">Login</a></p>
        </div>
      </form>
    </div>
  );
};

export default RegisterPage;
