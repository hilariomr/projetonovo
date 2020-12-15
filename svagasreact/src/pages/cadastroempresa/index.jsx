import React, { useEffect, useState } from 'react';
import './style.css';
import '../../assets/styles/global.css';
import Header from '../../components/header/index';
import { Form, Image } from 'react-bootstrap';
import Endereco from '../../components/formendereco';
import {
  cadastarDadosEmpresaService,
  cadastarEmpresaService,
} from '../../services/empresaService';

function CadastroEmpresa() {
  function onCadastrarEndereco(idEndereco) {
    cadastrarDadosEmpresa(idEndereco);
  }

  function cadastrarDadosEmpresa(idEndereco) {
    let form = document.getElementById('dadosEmpresaForm');
    let dadosEmpresa = getDadosEmpresa(form.elements, idEndereco);
    cadastarDadosEmpresaService(dadosEmpresa)
      .then((dados) => {
        console.log('Dados da empresa cadastradas');
        cadastrarEmpresa(dados.idDadoEmpresa);
      })
      .catch((erro) => {
        alert('Erro ao cadastrar dados da empresa');
        console.log(erro);
      });
  }

  function cadastrarEmpresa(idDadoEmpresa) {
    let form = document.getElementById('contaAcessoForm');
    let dadosEmpresa = getContaEmpresaDados(form.elements, idDadoEmpresa);
    cadastarEmpresaService(dadosEmpresa)
      .then(() => {
        console.log('Empresa cadastrada');
        alert('Empresa Cadastrada com Sucesso');
      })
      .catch((erro) => {
        alert('Erro ao cadastrar dados da empresa');
        console.log(erro);
      });
  }

  function getContaEmpresaDados(campos, idDadoEmpresa) {
    return {
      email: campos.email.value,
      cnpj: campos.cnpj.value,
      senha: campos.senha.value,
      idDadoEmpresa: idDadoEmpresa,
    };
  }

  function getDadosEmpresa(campos, idEndereco) {
    return {
      nomeEmpresa: campos.nome.value,
      areaDeAtuacao: campos.areaAtuacao.value,
      linkSite: campos.website.value,
      descricao: campos.descricao.value,
      fundada: campos.fundada.value,
      telefone: campos.telefone.value,
      tipoEmpresa: campos.tipoEmpresa.value,
      idEndereco: idEndereco,
    };
  }

  return (
    <>
      <Header />
      <section className="cadastro-empresa">
        <Form id="contaAcessoForm" className="acesso">
          <h1>Conta de Acesso</h1>
          <Form.Row>
            <Form.Group controlId="formGridEmail">
              <Form.Label>E-mail</Form.Label>
              <Form.Control
                type="email"
                placeholder="empresa@empresa.com"
                name="email"
                className="inputCad"
              />
            </Form.Group>
            <Form.Group controlId="formGridCNPJ">
              <Form.Label>CPNJ</Form.Label>
              <Form.Control
                name="cnpj"
                placeholder="010101010-10"
                className="inputCad"
              />
            </Form.Group>
            <Form.Group controlId="formGridSenha">
              <Form.Label>Senha</Form.Label>
              <Form.Control type="password" name="senha" className="inputCad" />
            </Form.Group>
          </Form.Row>
        </Form>
        <Form id="dadosEmpresaForm">
          <h1>Dados da Empresa</h1>
          <Form.Row className="dados-empresa">
            <Form.Group
              className="empresa-foto"
            >
              <div className="etapa_empresa">
                <p>1</p>
              </div>
              <div className="linha"></div>
            </Form.Group>
            <Form.Group>
              <Form.Row>
                <Form.Group controlId="formGridNome">
                  <Form.Label>Nome</Form.Label>
                  <Form.Control
                    placeholder="Ex: Fernando Monteiro"
                    name="nome"
                    className="inputCad"
                  />
                </Form.Group>
              </Form.Row>
              <Form.Row>
                <Form.Group controlId="formGridNome">
                  <Form.Label>Fundada Em</Form.Label>
                  <Form.Control type="number" name="fundada" className="inputCad"/>
                </Form.Group>
                <Form.Group controlId="formGridAreaAtuacao">
                  <Form.Label>Area de Atuacao</Form.Label>
                  <Form.Control name="areaAtuacao" className="inputCad"/>
                </Form.Group>
              </Form.Row>
              <Form.Row>
                <Form.Group controlId="formGridTelefone">
                  <Form.Label>Numero de Telefone</Form.Label>
                  <Form.Control placeholder="(XX) XXXX-XXXX " name="telefone" className="inputCad"/>
                </Form.Group>
                <Form.Group controlId="formGridWebsite">
                  <Form.Label>Website</Form.Label>
                  <Form.Control
                    name="website"
                    placeholder="https://www.senai.com.br"
                    className="inputCad"
                  />
                </Form.Group>
              </Form.Row>
              <Form.Row className="tipo_empresa">
                <Form.Group controlId="formGridTipoEmpresa">
                  <Form.Label>Tipo de Empresa</Form.Label>
                  <Form.Check
                    label="Startup"
                    name="tipoEmpresa"
                    value="Startup"
                    type="radio"
                    className="check"
                  />
                  <Form.Check
                    type="radio"
                    label="Pequena ou Média Empresa"
                    name="tipoEmpresa"
                    value="Pequeno/Medio Porte"
                    className="check"
                  />
                  <Form.Check
                    type="radio"
                    label="Grande Empresa"
                    name="tipoEmpresa"
                    value="Grande Porte"
                    className="check"
                  />
                </Form.Group>
              </Form.Row>
              <Form.Row>
                <Form.Group controlId="formGridDescricao">
                  <Form.Label>Descrição sobre a Empresa</Form.Label>
                  <Form.Control
                    placeholder="Conte um pouco sobre sua empresa para que os cadidatos saibam mais sobre vocês"
                    name="descricao"
                    as="textarea"
                    className="descricao_empresa"
                    className="inputCad"
                  />
                </Form.Group>
              </Form.Row>
            </Form.Group>
          </Form.Row>
        </Form>
        <Endereco enderecoCallBack={onCadastrarEndereco} className="button button1"/>
      </section>
    </>
  );
}

export default CadastroEmpresa;
