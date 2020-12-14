import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgSpacePerfil from '../../assets/images/spaceneedle-perfil.svg';
import { Link } from 'react-router-dom';
import './style.css';
import '../../assets/styles/global.css';
import { useState } from 'react';
import { useEffect } from 'react';
import { buscarEmpresaService } from '../../services/empresaService';

function PerfilEmpresa() {
    const [empresa, setEmpresa] = useState({})

    useEffect(() => {
      let idEmpresa = localStorage.getItem("identificador-usuario")
      buscarEmpresaService(idEmpresa).then(dados => {
        console.log(dados)
        setEmpresa(converteDados(dados))
      })
    }, [])

    function converteDados(dados) {
      return {
        nome: dados.idDadoEmpresaNavigation.nomeEmpresa,
        email: dados.email,
        telefone: dados.idDadoEmpresaNavigation.telefone,
        areaAtuacao: dados.idDadoEmpresaNavigation.areaDeAtuacao,
        fundada: dados.idDadoEmpresaNavigation.fundada,
        site: dados.idDadoEmpresaNavigation.linkSite,
        descricao: dados.idDadoEmpresaNavigation.descricao,
        tipoEmpresa: dados.idDadoEmpresaNavigation.tipoEmpresa
      }
    }

    return (
        <div className="perfil-empresa">
            <Header/>
            <div className="header-perfil">
        <div className="capa-candi">
        </div>
        <img id="foto-perfil" src={imgSpacePerfil} alt="" />
        <h1>{empresa.nome}</h1>
        <h2>Empresa de {empresa.tipoEmpresa}</h2>
        <section id="buttons-perfis">
        < Link id="botaocadastro"  to="/atualizacaoempresa">
        <button>Editar Perfil</button>
        </Link>
        < Link id="botaocadastro"  to="/vagas/cadastro">
        <button>Cadastrar Vagas</button>
        </Link>
        < Link id="botaocadastro"  to="/vagas/empresa">
        <button>Ver Minhas Vagas</button>
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
                <td>{empresa.areaAtuacao}</td>
                <td>{empresa.fundada}</td>
                
                
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
                <td>{empresa.site}</td>
                <td>{empresa.descricao}</td>
                
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
                <td>{empresa.email}</td>
                <td>{empresa.telefone}</td>
                
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