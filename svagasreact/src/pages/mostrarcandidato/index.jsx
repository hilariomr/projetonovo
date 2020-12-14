import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgPerfilCandi from '../../assets/images/fotoperfil-candi.svg'
import { Link } from 'react-router-dom';


import './style.css';
import '../../assets/styles/global.css';
import { useEffect, useState } from 'react';

function MostrarCandidato() {
  const [candidato, setCandidato] = useState({})

  function getFecthInfo() {
    let token = localStorage.getItem("token-usuario")
    let info = {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'authorization': 'bearer ' + token
        }
    }
  
    return info
  }

  useEffect(() => {
    const queryString = window.location.search
    const urlParams = new URLSearchParams(queryString);
    let id = urlParams.get('id')
    
    fetch(`http://localhost:5000/api/Candidato/${id}`, getFecthInfo())
      .then(response => {
        console.log(response)
        if(response.ok) return response.json()
      }).then(dados => {
        setCandidato(getCandidatoFormatado(dados))
      })

  }, [])

  function getCandidatoFormatado(dados) {
    if (!dados) return null
    return {
      nome: dados.idDadoCandidatoNavigation.nomeCompleto,
      tipoCarreira: dados.idDadoCandidatoNavigation.tipoCarreira,
      modeloContratacao: dados.idDadoCandidatoNavigation.modeloContratacao,
      pretensaoSalarial: dados.idDadoCandidatoNavigation.pretencaoSalarial,
      linkedin: dados.idDadoCandidatoNavigation.linkLinkedin,
      git: dados.idDadoCandidatoNavigation.linkGit,
      portifolio: dados.idDadoCandidatoNavigation.linkPortifolio,
      curriculo: dados.idDadoCandidatoNavigation.curriculo,
      tipoTrabalho: dados.idDadoCandidatoNavigation.tipoTrabalho,
      telefone: dados.idDadoCandidatoNavigation.telefone,
      email: dados.email,
  
    }
  }
  
  return (

    <div className="perfil-candidato">
      <Header />
      { candidato ? 
      <>
      <div className="header-perfil">
        <div className="capa-candi">
        </div>
        <img id="foto-perfil" src={imgPerfilCandi} alt="" />
        <h1>{candidato.nome}</h1>
        <h2>{candidato.tipoCarreira}</h2>
      </div>
    
      <body>
      <div className="container-perfilcandi">
     
        <div className="sobre-perfil">
          <h3>Informações</h3>
         
          <table>
            <thead>
              <tr>
                <th>Cidade onde mora</th>
                <th>Aceita propostas</th>
                <th>Pretensão salarial</th>
                <th>Experiência na área</th>
                
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>São Paulo, SP</td>
                <td>{candidato.modeloContratacao}</td>
                <td>{candidato.pretensaoSalarial}</td>
                <td>Quero começar!</td>
                
              </tr>
            </tbody>

            <thead id="thead">
              <tr>
                <th>Disposição para trabalhar</th>
                <th>LinkedIn</th>
                <th>Git Hub</th>
                <th>Portfólio</th>
               
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>São Paulo</td>
                <td>{candidato.linkedin}</td>
                <td>{candidato.git}</td>
                <td>{candidato.portifolio}</td>
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
                <td>{candidato.email}</td>
                <td>{candidato.telefone}</td>
                
              </tr>
            </tbody>
          </table>
          
        </div>

        <hr/>


        <div className="formacao-perfil">
          <h3>Formação acadêmica</h3>
          <table>
            <thead>
              <tr>
                <th>Desenvolvimento de Sistemas</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Senai Informática</td>
                <td>2017 - 2019</td>
              </tr>
            </tbody>

            <thead id="thead">
              <tr>
                <th>Desenvolvimento de Sistemas</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Senai Informática</td>
                <td>2017 - 2019</td>
              </tr>
            </tbody>
          </table>
        </div>
       
        <hr/>

        <div className="idioma-perfil">
          <h3>Idiomas</h3>
          <table>
            <thead>
              <tr>
                <th>Francês</th>
                
              </tr>
            </thead>

            <tbody>
              <tr>
                <td>Básico</td>
                
              </tr>
            </tbody>

            <thead id="thead">
              <tr>
               
                <th>Inglês</th>
              </tr>
            </thead>
            <tbody>
            
              <tr>
                
                <td>Intermediário</td>
              </tr>
            </tbody>
          </table>

        </div>
        <hr/>
        </div>

      </body>
      </>
: <p>Não Encontrado</p>}
      <Footer />
    </div>
  )
}

export default MostrarCandidato;