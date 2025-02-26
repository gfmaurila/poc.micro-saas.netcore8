import React from 'react';
import Profile from '../../components/Profile';

const UserUpdatePage = () => {

  return (
    <section className="home-section">

    <nav>

      <div className="sidebar-button">
        <i className="bx bx-menu sidebarBtn"></i>
        <span className="dashboard">Usuários - Editar</span>
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
                    <label htmlFor="username">Nome de usuário</label>
                    <input type="text" id="username" name="username" placeholder="Digite o nome do usuário"/>
                  </div>
                
                  <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input type="email" id="email" name="email" placeholder="Digite o email do usuário"/>
                  </div>
                
                  <div className="form-group">
                    <label htmlFor="password">Senha</label>
                    <input type="password" id="password" name="password" placeholder="Digite a senha"/>
                  </div>
                
                  <div className="form-group">
                    <label htmlFor="status">Status</label>
                    <select id="status" name="status">
                      <option value="user">User</option>
                      <option value="admin">Admin</option>
                    </select>
                  </div>
                
                  <div className="permissions-container">
                    <div className="permissions-title">Permissões</div>


                    <div className="permissions-container">
                      <div className="permissions-title">Usuários</div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="user-all-access" name="user_permission" value="all-access"/>
                        <label htmlFor="user-all-access" className="checkbox-label">Todos acessos</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="user-insert" name="user_permission" value="insert"/>
                        <label htmlFor="user-insert" className="checkbox-label">Insert</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="user-update" name="user_permission" value="update"/>
                        <label htmlFor="user-update" className="checkbox-label">Update</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="user-delete" name="user_permission" value="delete"/>
                        <label htmlFor="user-delete" className="checkbox-label">Delete</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="user-list" name="user_permission" value="list"/>
                        <label htmlFor="user-list" className="checkbox-label">List</label>
                      </div>
                    </div>
                    
                    <div className="permissions-container">
                      <div className="permissions-title">Notificações</div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="notifications-all-access" name="notifications_permission" value="all-access"/>
                        <label htmlFor="notifications-all-access" className="checkbox-label">Todos acessos</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="notifications-insert" name="notifications_permission" value="insert"/>
                        <label htmlFor="notifications-insert" className="checkbox-label">Insert</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="notifications-update" name="notifications_permission" value="update"/>
                        <label htmlFor="notifications-update" className="checkbox-label">Update</label>
                      </div>
                    </div>
                    
                    <div className="permissions-container">
                      <div className="permissions-title">Grupos</div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="groups-all-access" name="groups_permission" value="all-access"/>
                        <label htmlFor="groups-all-access" className="checkbox-label">Todos acessos</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="groups-insert" name="groups_permission" value="insert"/>
                        <label htmlFor="groups-insert" className="checkbox-label">Insert</label>
                      </div>
                      <div className="checkbox-group">
                        <input type="checkbox" id="groups-delete" name="groups_permission" value="delete"/>
                        <label htmlFor="groups-delete" className="checkbox-label">Delete</label>
                      </div>
                    </div>

                  </div>
                  
                
                  <div className="action-buttons">
                    <button type="submit" className="button button-cadastrar">Cadastrar</button>
                    <button type="button" className="button button-cancelar">Cancelar</button>
                    <a href='/team' className="button button-voltar br-link">Voltar</a>
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

export default UserUpdatePage;
