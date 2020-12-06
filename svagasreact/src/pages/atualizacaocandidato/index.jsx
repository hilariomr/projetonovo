import React from 'react';
import Header from '../../components/header/index';
import './style.css';
import '../../assets/styles/global.css';
import { Form, Image } from 'react-bootstrap';
import imgPerfil from '../../assets/icones/perfil.svg';
import { useEffect } from 'react';
import {buscarCandidatoPorID, atualizarCandidato} from '../../services/candidatoService';
import { atualizarDadosCandidato } from '../../services/dadosCandidatoService';



function AtualizaCandidato() {
  useEffect(() => {
    let idUsuario = localStorage.getItem("identificador-usuario")
    buscarCandidatoPorID(idUsuario, preencherContaAcessoForm)
  }, [])

  function preencherContaAcessoForm(dados) {
    let form = document.getElementById('contaAcessoForm')
    form.elements.idCandidato.value = dados.idCandidato
    form.elements.email.value = dados.email
    form.elements.cpf.value = dados.cpf
    form.elements.senha.value = dados.senha
    preencherDadosCandidato(dados.dadosCandidato)

  }

  function preencherDadosCandidato(dados) {
    let form = document.getElementById('dadosCandidatoForm')
    form.elements.idDadoCandidato.value = dados.idDadoCandidato
    form.elements.tipoCarreira.value = dados.tipoCarreira
    form.elements.pretencaoSalarial.value = dados.pretencaoSalarial
    form.elements.modeloContratacao.value = dados.modeloContratacao
    form.elements.tipoTrabalho.value = dados.tipoTrabalho
    form.elements.linkCurriculo.value = dados.linkCurriculo
    form.elements.nomeCompleto.value = dados.nomeCompleto
    form.elements.linkedin.value = dados.linkedin
    form.elements.git.value = dados.git
    form.elements.portifolio.value = dados.portifolio
    form.elements.telefone.value = dados.telefone
  }


  // function onEnderecoCadastrado(idEndereco) {
  //   cadastrarDadosCandidato(idEndereco)
  // }

  // function cadastrarDadosCandidato(idEndereco) {
  //   let form = document.getElementById("dadosCandidatoForm")
  //   let dados = getDadoCandidato(form.elements, idEndereco)
  //   let info = getFecthInfo(dados)
  //   fetch("http://localhost:5000/api/DadoCandidato", info)
  //           .then(response => {
  //               if (response.status === 201) {
  //                   console.log("Dados Candidato cadastrado")
  //                   response.json().then(dados => cadastrarCandidato(dados.idDadoCandidato))
  //               } else {
  //                   alert('Erro')
  //                   console.log(response)
  //               }
  //           })
  // }

  function submitContaAcessoForm(event) {
    event.preventDefault()

    let form = event.target
    let dados = getCandidatoDados(form.elements)
    atualizarCandidato(form.elements.idCandidato.value, dados)
    alert('Dados da conta foram atualizados')
  }

  function submitDadosCandidatoForm(event) {
    event.preventDefault()

    let form = event.target
    let dados = getDadoCandidato(form.elements)
    atualizarDadosCandidato(form.elements.idDadoCandidato.value, dados)

    alert('Dados do Candidato foram atualizados')

  }

  function getDadoCandidato(campos) {
    return {
      "TipoCarreira": campos.tipoCarreira.value,
      "PretencaoSalarial" : campos.pretencaoSalarial.value,
      "ModeloContratacao" : campos.modeloContratacao.value,
      "TipoTrabalho" : campos.tipoTrabalho.value,
      "Curriculo" : campos.linkCurriculo.value,
      "NomeCompleto" : campos.nomeCompleto.value,
      "LinkLinkedin" : campos.linkedin.value,
      "LinkGit" : campos.git.value,
      "LinkPortifolio" : campos.portifolio.value,
      "Foto" : campos.foto.value,
      "Telefone" : campos.telefone.value
    }
  }

  function getCandidatoDados(campos, idDadoCandidato) {
    return {
        "Email": campos.email.value,
        "CPF" : campos.cpf.value,
        "Senha" : campos.senha.value
    }
  }

  return (
    <>
      <Header />
      <section className="cadastro-candidato">
        <Form id="contaAcessoForm" onSubmit={submitContaAcessoForm}>
          <input type="hidden" name="idCandidato"/>
          <h1>Conta de Acesso</h1>
          <Form.Row>
            <Form.Group controlId="formGridEmail">
                <Form.Label>E-mail</Form.Label>
                <Form.Control type="email" placeholder="Candidato@Candidato.com" name="email"/>
            </Form.Group>
            <Form.Group controlId="formGridCPF">
                <Form.Label>CPF</Form.Label>
                <Form.Control name="cpf"/>
            </Form.Group>
            <Form.Group controlId="formGridSenha">
                <Form.Label>Senha</Form.Label>
                <Form.Control type="password" name="senha"/>
            </Form.Group>
          </Form.Row>

          <button type='submit'>Atualizar dados de Acesso</button>
        </Form>

        <Form id="dadosCandidatoForm" onSubmit={submitDadosCandidatoForm}>
            <h1>Dados do Candidato</h1>
            <input type="hidden" name="idDadoCandidato" />
            <Form.Row>
              <Form.Group controlId="cadastroCandidatoFoto" className="candidato-foto">
                <Image src={imgPerfil} roundedCircle className="cadastro-candidato_icone-perfil" />
                <Form.File
                  name="foto"
                />
              </Form.Group>
              <Form.Group>
                <Form.Row>
                  <Form.Group controlId="formGridNomeCompleto">
                      <Form.Label>Nome</Form.Label>
                      <Form.Control placeholder="Ex: Fernando Moneteiro" name="nomeCompleto" />
                  </Form.Group>
                  <Form.Group controlId="formGridTelefone">
                      <Form.Label>Telefone</Form.Label>
                      <Form.Control placeholder="(11) 9999-9999" name="telefone" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridTipoCarreira">
                      <Form.Label>Tipo de Carreira</Form.Label>
                      <Form.Control name="tipoCarreira" />
                  </Form.Group>
                  <Form.Group controlId="formGridModeloContratacao">
                      <Form.Label>Modelo de Contratação</Form.Label>
                      <Form.Control name="modeloContratacao" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridTipoTrabalho">
                      <Form.Label>Tipo de Trabalho</Form.Label>
                      <Form.Control name="tipoTrabalho" />
                  </Form.Group>
                  <Form.Group controlId="formGridPretensaoSalarial">
                      <Form.Label>Pretenção Salarial</Form.Label>
                      <Form.Control type="number" name="pretencaoSalarial" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridLinkCurriculo">
                      <Form.Label>Link do Curriculo</Form.Label>
                      <Form.Control name="linkCurriculo"/>
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridLinkedin">
                      <Form.Label>Linkedin</Form.Label>
                      <Form.Control name="linkedin"/>
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridGit">
                      <Form.Label>Git</Form.Label>
                      <Form.Control name="git"/>
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridPortifolio">
                      <Form.Label>Portifolio</Form.Label>
                      <Form.Control name="portifolio"/>
                  </Form.Group>
                </Form.Row>
              </Form.Group>
            </Form.Row>


            <button type='submit'>Atualizar dados do Candidato</button>
          </Form>
        
        {/* <Endereco enderecoCallBack={onEnderecoCadastrado} /> */}
     
      </section>
    </>
  );
}

export default AtualizaCandidato;