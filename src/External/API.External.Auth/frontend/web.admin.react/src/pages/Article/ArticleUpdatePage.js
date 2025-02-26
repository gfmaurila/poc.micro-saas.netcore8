import React from 'react';
import Profile from '../../components/Profile';

const ArticleUpdatePage = () => {

  return (
    <section className="home-section">

    <nav>

      <div className="sidebar-button">
        <i className="bx bx-menu sidebarBtn"></i>
        <span className="dashboard">Artigo - Editar</span>
      </div>
      
      <Profile/>
    </nav>

    <div className="home-content">
        <div className="overview-boxes">
          
          <div className="box-filter">          
            <a href='/team' className="button button-default br-link">Voltar</a>
          </div>

        </div>

        <div className="sales-boxes">
          
          <div className="recent-sales-list box">

            <div id="records-section">
              
              <div className="list-container">
                
                <div className="form-container">
                  <div className="form-group">
                    <label htmlFor="title">Nome de usuário</label>
                    <input type="text" id="title" name="title" placeholder="Digite o titulo"/>
                  </div>

                  <div className="form-group">
                    <label htmlFor="title">Descrição</label>
                    <input type="text" id="description" name="description" placeholder="Digite a descrição"/>
                  </div>
                
                  <div className="action-buttons">
                    <button type="submit" className="button button-cadastrar">Cadastrar</button>
                    <button type="button" className="button button-cancelar">Cancelar</button>
                    <a href='/article' className="button button-voltar br-link">Voltar</a>
                  </div>

                </div>

                
              </div>
              
            </div>
          </div>
          
        </div>
      </div>
    
  </section>  
  );
};

export default ArticleUpdatePage;
