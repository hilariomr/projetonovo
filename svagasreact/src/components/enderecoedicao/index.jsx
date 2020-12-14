import React, { useEffect, useState } from 'react'
import { Form } from 'react-bootstrap'
import { atualizarEnderecoAPI, buscarCEPAPI, buscarEnderecoAPI } from '../../services/enderecoService'

function EnderecoEdicao({callbackEnderecoAtualizado, idEndereco}) {
    const [endereco, setEndereco] = useState({})
    const [idEnderecoCampo, setIdEnderecoCampo] = useState(0)

    if (idEndereco && idEndereco > 0 && idEnderecoCampo !== idEndereco) {
        setIdEnderecoCampo(idEndereco)
    }

    useEffect(() => {
        if(idEndereco && idEndereco > 0) {
            buscarEnderecoAPI(idEndereco)
                .then(dados => setEndereco(dados))
        }
    }, [idEnderecoCampo])


    function buscarCEP(event) {
        let cep = event.target.value
        if (cep.length === 8) {
            buscarCEPAPI(cep).then(dados => {prencherEndereco(dados)})
        }
    }

    function prencherEndereco(dados) {
        let form = document.getElementById("enderecoForm")
        form.elements.rua.value = dados.street
        form.elements.cidade.value = dados.city
        form.elements.uf.value = dados.state
    }

    function atualizarEndereco() {
        let form = document.getElementById("enderecoForm")
        let dados = getEnderecoDados(form.elements)
        let id = form.elements.enderecoId.value;
        atualizarEnderecoAPI(id, dados).then(resultado => {
            if (resultado) {
                if(callbackEnderecoAtualizado)
                    callbackEnderecoAtualizado()
                alert('Endereço atualizado com sucesso')
            } else {
                alert('Ocorreu um erro, tente deslogar e logar novamente')
            }
        })
    }

    function getEnderecoDados(campos) {
        return {
            "cep": campos.cep.value,
            "cidade": campos.cidade.value,
            "uf": campos.uf.value,
            "rua": campos.rua.value,
            "numero": campos.numero.value,
        }
    }

    return (
    <>
        <Form id="enderecoForm">
            <h1>Endereço</h1>
            <Form.Row>
                <input type="hidden" name="enderecoId" defaultValue={endereco.idEndereco}/>
                <Form.Group>
                <Form.Row>
                    <Form.Group controlId="formGridCEP">
                        <Form.Label>CEP</Form.Label>
                        <Form.Control type="number" max={8} min={8} placeholder="00000000" name="cep" onKeyUp={buscarCEP} defaultValue={endereco.cep}/>
                    </Form.Group>
                </Form.Row>
                <Form.Row>
                    <Form.Group controlId="formGridRua">
                        <Form.Label>Rua</Form.Label>
                        <Form.Control name="rua" readOnly={true} defaultValue={endereco.rua}/>
                    </Form.Group>
                    <Form.Group controlId="Numero">
                        <Form.Label>Numero</Form.Label>
                        <Form.Control name="numero" defaultValue={endereco.numero}/>
                    </Form.Group>
                </Form.Row>
                <Form.Row>
                    <Form.Group controlId="formGridCidade">
                        <Form.Label>Cidade</Form.Label>
                        <Form.Control name="cidade" readonly={true} defaultValue={endereco.cidade}/>
                    </Form.Group>
                    <Form.Group controlId="formGridUf">
                        <Form.Label>UF</Form.Label>
                        <Form.Control name="uf" readonly={true} defaultValue={endereco.uf}/>
                    </Form.Group>
                </Form.Row>
                </Form.Group>
            </Form.Row>
        </Form>

        <button id="cadastrar" onClick={atualizarEndereco}>Cadastrar</button>
    </>
    )
}

export default EnderecoEdicao;