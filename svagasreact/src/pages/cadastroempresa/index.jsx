import React, { useEffect, useState } from 'react';
import './style.css';
import '../../assets/styles/global.css';
import Header from '../../components/header/index';
import { Form, Image } from 'react-bootstrap';
import imgPerfil from '../../assets/icones/perfil.svg';
import Endereco from '../../components/formendereco';

function CadastroEmpresa() {
  function getFecthInfo(dados) {
    let token = localStorage.getItem("token-usuario")
    let info = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'authorization': 'bearer ' + token
        },
        body: JSON.stringify(dados)
    }
  
    return info
  }

  function onCadastrarEndereco(idEndereco) {
    cadastrarDadosEmpresa(idEndereco)
  }

  function cadastrarDadosEmpresa(idEndereco) {
    let form = document.getElementById("dadosEmpresaForm")
    let dados = getDadosEmpresa(form.elements, idEndereco)
    let info = getFecthInfo(dados)
    fetch("http://localhost:5000/api/DadoEmpresa", info)
            .then(response => {
                if (response.status === 201) {
                    console.log("Dados Empresa cadastrado")
                    response.json().then(dados => cadastrarEmpresa(dados.idDadoEmpresa))
                } else {
                    alert('Erro')
                    console.log(response)
                }
            })
  }

  function cadastrarEmpresa(idDadoEmpresa) {
    let form = document.getElementById("contaAcessoForm")
    let dados = getContaEmpresaDados(form.elements, idDadoEmpresa)
    let info = getFecthInfo(dados)
    fetch("http://localhost:5000/api/Empresa", info)
            .then(response => {
                if (response.status === 201) {
                    console.log("Empresa cadastrada")
                    alert("Empresa Cadastrada com Sucesso")
                } else {
                    alert('Erro')
                    console.log(response)
                }
            })
  }

  function getContaEmpresaDados(campos, idDadoEmpresa) {
    return {
      "email": campos.email.value,
      "cnpj": campos.cnpj.value,
      "senha": campos.senha.value,
      "idDadoEmpresa": idDadoEmpresa
    }
  }
  
  function getDadosEmpresa(campos, idEndereco) {
    return {
      "nomeEmpresa": campos.nome.value,
      "areaDeAtuacao": campos.areaAtuacao.value,
      "linkSite": campos.website.value,
      "descricao": campos.descricao.value,
      "fundada": campos.fundada.value,
      "telefone": campos.telefone.value,
      "tipoEmpresa": campos.tipoEmpresa.value,
      "foto": campos.foto.value,
      "idEndereco": idEndereco
    }
  }

  return (
    <>
      <Header />
      <section className="cadastro-empresa">
          <Form id="contaAcessoForm">
            <h1>Conta de Acesso</h1>
            <Form.Row>
              <Form.Group controlId="formGridEmail">
                  <Form.Label>E-mail</Form.Label>
                  <Form.Control type="email" placeholder="empresa@empresa.com" name="email"/>
              </Form.Group>
              <Form.Group controlId="formGridCNPJ">
                  <Form.Label>CPNJ</Form.Label>
                  <Form.Control name="cnpj" />
              </Form.Group>
              <Form.Group controlId="formGridSenha">
                  <Form.Label>Senha</Form.Label>
                  <Form.Control type="password" name="senha" />
              </Form.Group>
            </Form.Row>
          </Form>
          <Form id="dadosEmpresaForm">
            <h1>Dados da Empresa</h1>
            <Form.Row>
              <Form.Group controlId="cadastroEmpresaFoto" className="empresa-foto">
                <Image src={imgPerfil} roundedCircle className="cadastro-empresa_icone-perfil" />
                <Form.File
                  name="foto"
                />
              </Form.Group>
              <Form.Group>
                <Form.Row>
                  <Form.Group controlId="formGridNome">
                      <Form.Label>Nome</Form.Label>
                      <Form.Control placeholder="Ex: Fernando Moneteiro" name="nome" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridNome">
                      <Form.Label>Fundada Em</Form.Label>
                      <Form.Control type="number" name="fundada" />
                  </Form.Group>
                  <Form.Group controlId="formGridAreaAtuacao">
                      <Form.Label>Area de Atuacao</Form.Label>
                      <Form.Control name="areaAtuacao" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridTelefone">
                      <Form.Label>Numero de Telefone</Form.Label>
                      <Form.Control placeholder="(XX) XXXX-XXXX " name="telefone" />
                  </Form.Group>
                  <Form.Group controlId="formGridWebsite">
                      <Form.Label>Website</Form.Label>
                      <Form.Control name="website" placeholder="https://www.senai.com.br" />
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridTipoEmpresa">
                      <Form.Label>Tipo de Empresa</Form.Label>
                      <Form.Check type="radio" label="Startup" name="tipoEmpresa" value="Startup"/>
                      <Form.Check type="radio" label="Pequena ou Média Empresa" name="tipoEmpresa" value="Pequeno/Medio Porte"/>
                      <Form.Check type="radio" label="Grande Empresa" name="tipoEmpresa" value="Grande Porte"/>
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group controlId="formGridDescricao">
                      <Form.Label>Descrição sobre a Empresa</Form.Label>
                      <Form.Control placeholder="Conte um pouco sobre sua empresa para que os cadidatos saibam mais sobre vocês" name="descricao" as="textarea" />
                  </Form.Group>
                </Form.Row>
              </Form.Group>
            </Form.Row>
          </Form>
          <Endereco enderecoCallBack={onCadastrarEndereco} />
      </section>
      
    </>
  );
}

export default CadastroEmpresa;