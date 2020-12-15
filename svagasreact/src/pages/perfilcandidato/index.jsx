import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgPerfilCandi from '../../assets/images/fotoperfil-candi.svg'
import { Link } from 'react-router-dom';


import './style.css';
import '../../assets/styles/global.css';
import { useEffect, useState } from 'react';
import { buscarCandidatoPorID } from '../../services/candidatoService';
import { buscarFormacoesPorDadoCandidato } from '../../services/formacaoService';

function PerfilCandidato() {
  const [candidato, setCandidato] = useState({})
  const [formacoes, setFormacoes] = useState([])

  useEffect(() => {
    let idUsuario = localStorage.getItem("identificador-usuario")
    buscarCandidatoPorID(idUsuario, (dados) => {
      console.log(dados)
      let candidato = converterDados(dados)
      buscarFormacoesPorDadoCandidato(candidato.idDadoCandidato)
        .then(dados => {
          let formacoes = converterFormacoes(dados)
          setFormacoes(formacoes)
          setCandidato(candidato)
        })
    })
  
  }, [])

  function converterFormacoes(dados) {
    return dados.map(item => {
      return {
        curso: item.idFormacaoNavigation.curso,
        instituicao: item.idFormacaoNavigation.instituicao,
        dataInicio: item.idFormacaoNavigation.dataInicio.slice(0,4),
        dataConclusao: item.idFormacaoNavigation.dataConclusao.slice(0,4)
      }
    })
  }

  function converterDados(dados) {
    return {
      idCandidato: dados.idCandidato,
      nomeCompleto: dados.dadosCandidato.nomeCompleto,
      email: dados.email,
      tipoCarreira: dados.dadosCandidato.tipoCarreira,
      modeloContratacao: dados.dadosCandidato.modeloContratacao,
      pretensaoSalarial: dados.dadosCandidato.pretencaoSalarial,
      linkedin: dados.dadosCandidato.linkedin,
      git: dados.dadosCandidato.git,
      portifolio: dados.dadosCandidato.portifolio,
      telefone: dados.dadosCandidato.telefone,
      idDadoCandidato: dados.dadosCandidato.idDadoCandidato
    }
  }
  
  return (
    <div className="perfil-candidato">
      <Header />

      <div className="header-perfil">
        <div className="capa-candi">
        </div>
        <img id="foto-perfil" src={imgPerfilCandi} alt="" />
        <h1>{candidato.nomeCompleto}</h1>
        <h2>{candidato.tipoCarreira}</h2>
        <section id="buttons-perfis">
          <Link to="/perfil/candidato/editar">
            <button>Editar Perfil</button>
          </Link>
          < Link to="/vagas">
            <button>Buscar Vagas</button>
          </Link>
          < Link to="/inscricoes">
            <button>Minhas Inscrições</button>
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
                <td>{candidato.tipoTrabalho}</td>
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
          <ul>
            {formacoes.map(formacao => 
              <li>
                <h4>{formacao.curso}</h4>
                <p>{formacao.instituicao}</p>
                <p>{formacao.dataInicio} - {formacao.dataConclusao}</p>
              </li>
            )}  
          </ul>
          
          
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

      <Footer />
    </div>
  )
}

export default PerfilCandidato;