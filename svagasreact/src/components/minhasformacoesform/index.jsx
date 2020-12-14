import React from 'react'
import { Button, Form } from 'react-bootstrap'
import { cadastarNovaFormacao } from '../../services/formacaoService'

export default function MinhasFormacoesForm({idDadoCandidato, callbackFormacaoCadastrada}) {

    function cadastraFormacao(event) {
        event.preventDefault()

        let form = event.target
        let dados = getFormacaoDados(form.elements)
        cadastarNovaFormacao(dados)
            .then(formacaoCadastrada => {
                alert('Formação cadastrada com sucesso')
                if(callbackFormacaoCadastrada)
                    callbackFormacaoCadastrada(formacaoCadastrada)
            }).catch(erro => {
                alert('Erro encontrado na tentatica de cadastro de uma nova formação')
                console.log(erro)
            })
    }

    function getFormacaoDados(campos) {
        return {
            'curso': campos.curso.value,
            'instituicao': campos.instituicao.value,
            'dataInicio': campos.dataInicio.value,
            'dataConclusao': campos.dataConclusao.value,
            'minhasFormacoes': [{
                'IdDadoCandidato': idDadoCandidato
            }]
        }
    }

    return (
        <>
            <h1>Cadastrar Nova Formação</h1>
            <Form className='minhas-formacoes-form' onSubmit={cadastraFormacao}>
                <Form.Row>
                    <Form.Group controlId="formGridInstituicao">
                        <Form.Label>Instituição</Form.Label>
                        <Form.Control placeholder="Ex: Senai Informatica" name="instituicao" />
                    </Form.Group>

                    <Form.Group controlId="formGridCurso">
                        <Form.Label>Curso</Form.Label>
                        <Form.Control as="textarea" name="curso" />
                    </Form.Group>
                </Form.Row>
                <Form.Row>
                    <Form.Group controlId="formGridDataInicio">
                        <Form.Label>Data Inicio</Form.Label>
                        <Form.Control type='date' name="dataInicio" />
                    </Form.Group>

                    <Form.Group controlId="formGridDataConclusao">
                        <Form.Label>Data de Conclusão</Form.Label>
                        <Form.Control type='date' name="dataConclusao" />
                    </Form.Group>
                </Form.Row>

                <Button className='primary' type='submit'>Cadastrar Nova Formação</Button>
            </Form>

        </>
    )
}