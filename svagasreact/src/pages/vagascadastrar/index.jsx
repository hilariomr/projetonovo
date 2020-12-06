import React from 'react'
import Header from '../../components/header';
import Form from 'react-bootstrap/Form';
import Footer from '../../components/footer';
import './style.css';
import '../../assets/styles/global.css';

function VagasCadastrar() {
    function cadastrar(event) {
        event.preventDefault();

        let campos = event.target.elements;
        let idEmpresa = localStorage.getItem("identificador-usuario")
        let dados = getDados(campos, idEmpresa)

        enviarDados(dados);
        event.target.reset();
    }

    function getDados(campos, idEmpresa) {
        return {
            "TituloVaga": campos.titulo.value,
            "descricao": campos.descricao.value,
            "quanVagas": campos.quantidadeVagas.value,
            "dataInicio": campos.dataInicio.value,
            "dataTermino": campos.dataTermino.value,
            "salario": campos.salario.value,
            "requisitos": campos.requisitos.value,
            "localTrabalho": campos.localTrabalho.value,
            "tipoContratacao": campos.tipoContratacao.value,
            "entradaDoTrabalho": campos.horarioEntrada.value,
            "terminoDoTrabalho": campos.horarioSaida.value,
            "idDadoEmpresa": idEmpresa,
            "inscricao": []
        }
    }

    function enviarDados(dados) {
        let token = localStorage.getItem("token-usuario")

        let info = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'authorization': 'bearer ' + token
            },
            body: JSON.stringify(dados)
        }

        fetch("http://localhost:5000/api/Vaga", info)
            .then(response => {
                if (response.status === 201) {
                    alert('Vaga cadastrada com sucesso')
                } else {
                    alert('Erro')
                    console.log(response)
                }
            })
    }

    return (
        <div className='vagas'>
            <Header />
            <div className="formulariovaga">
                <h1>Cadastrar Vagas</h1>
                <hr></hr>
                <div className="formulario">
                    <Form onSubmit={cadastrar}>
                        <Form.Row>
                            <Form.Group controlId="formGridTitulo">
                                <Form.Label>Titulo</Form.Label>
                                <Form.Control placeholder="Ex: Programador Front-End" name="titulo" />
                            </Form.Group>

                            <Form.Group controlId="formGridDescricao">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control as="textarea" name="descricao" />
                            </Form.Group>

                            <Form.Group controlId="formGridRequisitos">
                                <Form.Label>Requisitos</Form.Label>
                                <Form.Control as="textarea" name="requisitos" />
                            </Form.Group>
                        </Form.Row>

                        <Form.Row>
                            <Form.Group controlId="formGridLocalDeTrabalho">
                                <Form.Label>Local de trabalho</Form.Label>
                                <Form.Control as="select" name="localTrabalho">
                                    <option value="Sao Paulo">São Paulo</option>
                                    <option value="Guarulhos">Guarulhos</option>
                                    <option value="Osasco">Osasco</option>
                                    <option value="São Bernardo do Campo">São Bernardo do Campo</option>
                                    <option value="São Caetano">São Caetano</option>
                                    <option value="Santo Andre">Santo André</option>
                                    <option value="Diadema">Diadema</option>
                                    <option value="Suzano">Suzano</option>
                                </Form.Control>
                            </Form.Group>

                            <Form.Group controlId="formGridTipoContratacao">
                                <Form.Label>Tipo de contratacao</Form.Label>
                                <Form.Control as="select" name="tipoContratacao">
                                    <option value="CLT">CLT</option>
                                    <option value="PJ">PJ</option>
                                    <option value="Estagio">Estágio</option>
                                </Form.Control>
                            </Form.Group>

                            <Form.Group controlId="formGridQuantidade">
                                <Form.Label>Quantidade de vagas</Form.Label>
                                <Form.Control type="number" name="quantidadeVagas" />
                            </Form.Group>

                        </Form.Row>

                        <Form.Row>

                            <Form.Group controlId="formGridDataInicio">
                                <Form.Label>Data de inicio</Form.Label>
                                <Form.Control type="date" name="dataInicio" />
                            </Form.Group>

                            <Form.Group controlId="formGridNumeroDataTermino">
                                <Form.Label>Data de Término</Form.Label>
                                <Form.Control type="date" name="dataTermino" />
                            </Form.Group>

                            <Form.Group controlId="formGridSalario">
                                <Form.Label>Salario</Form.Label>
                                <Form.Control type="number" step="0.01" name="salario" />
                            </Form.Group>

                        </Form.Row>

                        <Form.Row>
                            <Form.Group controlId="formGridHorarioEntrada">
                                <Form.Label>Horário de entrada</Form.Label>
                                <Form.Control type="time" name="horarioEntrada" />
                            </Form.Group>

                            <Form.Group controlId="formGridHorarioSaida">
                                <Form.Label >Horario de saída</Form.Label>
                                <Form.Control type="time" name="horarioSaida" />
                            </Form.Group>
                        </Form.Row>

                        <button id="cadastrar" type="submit">Cadastrar</button>
                    </Form>

                </div>
            </div>
            <Footer />
        </div>
    )
}

export default VagasCadastrar;