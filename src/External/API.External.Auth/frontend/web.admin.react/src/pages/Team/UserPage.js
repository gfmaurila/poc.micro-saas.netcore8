import React from 'react';
import Profile from '../../components/Profile';

const UserPage = () => {

  return (
    <section className="home-section">

    <nav>
      <div className="sidebar-button">
        <i className="bx bx-menu sidebarBtn"></i>
        <span className="dashboard">Usuários - Lista</span>
      </div>
      {/* <div className="search-box">
        <input type="text" placeholder="Search..." />
        <i className="bx bx-search"></i>
      </div> */}
      <Profile/>
    </nav>

    <div className="home-content">
        <div className="overview-boxes">
          
          <div className="box-filter">
          
            <div className="search-actions-container">
              <input type="text" id="filter-input" placeholder="Nome usuário..."/>
              <button className="button button-primary">Buscar</button>
              <button className="button button-secondary">Cancelar</button>
              <a href='/team/usuario/novo' className="button button-default br-link">Novo</a>
            </div>
            

          </div>
        </div>

        <div className="sales-boxes">
          
          <div className="recent-sales-list box">
            <div id="records-section">
              
              <div className="list-container">

                <div className="list-header">
                  <div className="list-head">ID</div>
                  <div className="list-head">Nome</div>
                  <div className="list-head">Email</div>
                  <div className="list-head">Status</div>
                  <div className="list-head">&nbsp;</div>
                </div>

                <div className="list-item">

                  <div className="list-cell">01</div>
                  <div className="list-cell">Fulano de tal</div>
                  <div className="list-cell">fulano-de-tal@gmail.com</div>
                  <div className="list-cell">Liberado</div>
                  
                  <div className="list-cell">
                    
                    <div className="actions-container">

                      <a href='/team/usuario/editar' className="action-button edit-button br-link">
                        <i className="fa fa-edit"></i>Editar
                      </a>

                      <a href='/team/usuario/remover' className="action-button remove-button br-link">
                        <i className="fa fa-trash"></i>Remover
                      </a>

                    </div>
                    
                  </div>
                </div>


                <div className="list-item">

                  <div className="list-cell">02</div>
                  <div className="list-cell">Fulano de tal</div>
                  <div className="list-cell">fulano-de-tal@gmail.com</div>
                  <div className="list-cell">Bloqueado</div>
                  
                  <div className="list-cell">
                    <div className="actions-container">

                      <a href='/team/usuario/editar' className="action-button edit-button br-link">
                        <i className="fa fa-edit"></i>Editar
                      </a>

                      <a href='/team/usuario/remover' className="action-button remove-button br-link">
                        <i className="fa fa-trash"></i>Remover
                      </a>

                    </div>
                    
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

export default UserPage;
