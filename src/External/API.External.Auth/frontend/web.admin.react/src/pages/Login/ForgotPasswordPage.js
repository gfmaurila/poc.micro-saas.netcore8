import React from 'react';

const ForgotPasswordPage = () => {
  return (
    <div className="wrapper">
      <form action="#">
        <h2 className='h2-login'>Forgot password</h2>
          <div className="input-field">
          <input type="text" required/>
          <label>Enter your email</label>
        </div>
        <button type="submit" className='bt-login'>Enviar</button>
        <div className="register">
          <p>Voltar ao <a href="/login">Login</a></p>
        </div>
      </form>
    </div>
  );
};

export default ForgotPasswordPage;
