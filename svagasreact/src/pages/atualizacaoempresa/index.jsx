import React, { useEffect, useState } from 'react';
import './style.css';
import '../../assets/styles/global.css';
import Header from '../../components/header/index';
import { Button, Form, Image } from 'react-bootstrap';
import imgPerfil from '../../assets/icones/perfil.svg';
import { atualizarDadosEmpresaService, atualizarEmpresaService, buscarEmpresaService } from '../../services/empresaService';
import EnderecoEdicao from '../../components/enderecoedicao';

function AtualizacaoEmpresa() {
  const [empresa, setEmpresa] = useState({ idDadoEmpresaNavigation : ''})

  useEffect(() => {
    let id = localStorage.getItem('identificador-usuario')
    buscarEmpresaService(id)
      .then(dados => {
        setEmpresa(dados)
      })
  }, [])

  function callbackEnderecoAtualizado() {
    atualizarDadosEmpresa()
  }

  function atualizarDadosEmpresa() {
    let form = document.getElementById("dadosEmpresaForm")
    let dadosEmpresa = getDadosEmpresa(form.elements)
    let idDadosEmpresa = form.elements.idDadosEmpresa.value
    console.log(dadosEmpresa)
    atualizarDadosEmpresaService(idDadosEmpresa, dadosEmpresa)
      .then(() => {
        atualizarEmpresa()
      })
  }

  function atualizarEmpresa() {
    let form = document.getElementById("contaAcessoForm")
    let dadosEmpresa = getContaEmpresaDados(form.elements)
    let idEmpresa = form.elements.idEmpresa.value
    atualizarEmpresaService(idEmpresa, dadosEmpresa)
      .then(() => {alert('Empresa atualizada com sucesso')})
  }

  function getContaEmpresaDados(campos) {
    return {
      "email": campos.email.value,
      "cnpj": campos.cnpj.value,
      "senha": campos.senha.value,
      "idDadoEmpresa": campos.idDadoEmpresa.value
    }
  }
  
  function getDadosEmpresa(campos) {
    return {
      "nomeEmpresa": campos.nome.value,
      "areaDeAtuacao": campos.areaAtuacao.value,
      "linkSite": campos.website.value,
      "descricao": campos.descricao.value,
      "fundada": campos.fundada.value,
      "telefone": campos.telefone.value,
      "tipoEmpresa": campos.tipoEmpresa.value,
      "foto": campos.foto.value,
      "idEndereco": campos.idEndereco.value
    }
  }

  return (
    <>
      <Header />
      {empresa ? 
        <section className="cadastro-empresa">
            <Form id="contaAcessoForm">
              <input type="hidden" name='idEmpresa' value={empresa.idEmpresa} />
              <input type="hidden" name='idDadoEmpresa' value={empresa.idDadoEmpresa} />
              <h1>Conta de Acesso</h1>
              <Form.Row>
                <Form.Group controlId="formGridEmail">
                    <Form.Label>E-mail</Form.Label>
                    <Form.Control type="email" placeholder="empresa@empresa.com" name="email" defaultValue={empresa.email}/>
                </Form.Group>
                <Form.Group controlId="formGridCNPJ">
                    <Form.Label>CPNJ</Form.Label>
                    <Form.Control name="cnpj" defaultValue={empresa.cnpj}/>
                </Form.Group>
                <Form.Group controlId="formGridSenha">
                    <Form.Label>Senha</Form.Label>
                    <Form.Control type="password" name="senha" defaultValue={empresa.senha}/>
                </Form.Group>
              </Form.Row>
            </Form>

            <Form id="dadosEmpresaForm">
              <h1>Dados da Empresa</h1>
              <Form.Row>
                <input type="hidden" name='idDadosEmpresa' value={empresa.idDadoEmpresa} />
                <input type="hidden" name='idEndereco' value={empresa.idDadoEmpresaNavigation.idEndereco} />
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
                        <Form.Control placeholder="Ex: Fernando Moneteiro" name="nome" defaultValue={empresa.idDadoEmpresaNavigation.nomeEmpresa}/>
                    </Form.Group>
                  </Form.Row>
                  <Form.Row>
                    <Form.Group controlId="formGridNome">
                        <Form.Label>Fundada Em</Form.Label>
                        <Form.Control type="number" name="fundada" defaultValue={empresa.idDadoEmpresaNavigation.fundada}/>
                    </Form.Group>
                    <Form.Group controlId="formGridAreaAtuacao">
                        <Form.Label>Area de Atuacao</Form.Label>
                        <Form.Control name="areaAtuacao" defaultValue={empresa.idDadoEmpresaNavigation.areaDeAtuacao}/>
                    </Form.Group>
                  </Form.Row>
                  <Form.Row>
                    <Form.Group controlId="formGridTelefone">
                        <Form.Label>Numero de Telefone</Form.Label>
                        <Form.Control placeholder="(XX) XXXX-XXXX " name="telefone" defaultValue={empresa.idDadoEmpresaNavigation.telefone}/>
                    </Form.Group>
                    <Form.Group controlId="formGridWebsite">
                        <Form.Label>Website</Form.Label>
                        <Form.Control name="website" placeholder="https://www.senai.com.br" defaultValue={empresa.idDadoEmpresaNavigation.linkSite}/>
                    </Form.Group>
                  </Form.Row>
                  <Form.Row>
                    <Form.Group controlId="formGridTipoEmpresa">
                        <Form.Label>Tipo de Empresa</Form.Label>
                        <Form.Check type="radio" label="Startup" name="tipoEmpresa" value="Startup" defaultChecked={empresa.idDadoEmpresaNavigation.tipoEmpresa === 'Startup' ? 'true' : 'false'}/>
                        <Form.Check type="radio" label="Pequena ou Média Empresa" name="tipoEmpresa" value="Pequeno/Medio Porte" defaultChecked={empresa.idDadoEmpresaNavigation.tipoEmpresa === 'Pequeno/Medio Porte' ? 'true' : 'false'}/>
                        <Form.Check type="radio" label="Grande Empresa" name="tipoEmpresa" value="Grande Porte" defaultChecked={empresa.idDadoEmpresaNavigation.tipoEmpresa === 'Grande Porte' ? 'true' : 'false'}/>
                    </Form.Group>
                  </Form.Row>
                  <Form.Row>
                    <Form.Group controlId="formGridDescricao">
                        <Form.Label>Descrição sobre a Empresa</Form.Label>
                        <Form.Control placeholder="Conte um pouco sobre sua empresa para que os cadidatos saibam mais sobre vocês" name="descricao" as="textarea" defaultValue={empresa.idDadoEmpresaNavigation.descricao} />
                    </Form.Group>
                  </Form.Row>
                </Form.Group>
              </Form.Row>
            </Form>
            <EnderecoEdicao callbackEnderecoAtualizado={callbackEnderecoAtualizado} idEndereco={empresa.idDadoEmpresaNavigation.idEndereco}/>
        </section>
      : 'Nenhuma empresa encontrada' }
      
    </>
  );
}

export default AtualizacaoEmpresa;