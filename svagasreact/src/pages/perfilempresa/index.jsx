import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgSpacePerfil from '../../assets/images/spaceneedle-perfil.svg';
import { Link } from 'react-router-dom';
import './style.css';
import '../../assets/styles/global.css';

function PerfilEmpresa() {

    return (
        <div className="perfil-empresa">
            <Header/>
            <div className="header-perfil">
        <div className="capa-candi">
        </div>
        <img id="foto-perfil" src={imgSpacePerfil} alt="" />
        <h1>Space Needle</h1>
        <h2>Empresa</h2>
        <section id="buttons-perfis">
        <button>Editar Perfil</button>
        < Link id="botaocadastro"  to="/vagas/cadastro">
        <button>Cadastrar Vagas</button>
        </Link>
        </section>
      </div>

      <body>
      <div className="container-perfilcandi">
     
        <div className="sobre-perfil">
          <h3>Informações</h3>
         
          <table>
            <thead>
              <tr>
                <th>Local</th>
                <th>Área</th>
                <th>Fundada em</th>
                
                
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>São Paulo, SP</td>
                <td>Tecnologia</td>
                <td>2011</td>
                
                
              </tr>
            </tbody>

            <thead id="thead">
              <tr>
                <th>Site</th>
                <th>Descrição</th>
                
               
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>www.spaceneedle.com</td>
                <td>No mundo da lua mas com os pés no chão</td>
                
              </tr>
            </tbody>
          </table>
          
        </div>

        <hr/>

        <div className="contato-perfil">
          <h3>Contato</h3> 
          <table>
            <thead>
              <tr>
                <th>E-mail</th>
                <th>Telefone</th>
                
                
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>spaceneedle@email.com</td>
                <td>11 4922-2193</td>
                
              </tr>
            </tbody>
          </table>
          
        </div>
        
        
        <hr/>
        </div>

      </body>
            <Footer/>
        </div>
    )
}

export default PerfilEmpresa;