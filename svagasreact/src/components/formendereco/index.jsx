import React from 'react'
import { Form } from 'react-bootstrap'

function Endereco({enderecoCallBack}) {
    function buscaCep(event) {
        let cep = event.target.value;
        console.log(cep)
        if (cep.length === 8) {
            let apiURL = `https://api.pagar.me/1/zipcodes/${cep}`
            let fetchInfo =  {
                method: 'GET',
                hearders: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            }

            fetch(apiURL, fetchInfo)
                .then(response => {
                    if (response.ok) return response.json()
                    throw new Error('cep não encontrado')
                }).then(data => {
                    prencherEndereco(data)
                }).catch(error => {
                    console.log(error)
                    alert('CEP Não Encontrado')
                })
        }
    }

    function prencherEndereco(dados) {
        let form = document.getElementById("enderecoForm")
        form.elements.rua.value = dados.street
        form.elements.cidade.value = dados.city
        form.elements.uf.value = dados.state
    }

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

    function cadastrarEndereco() {
        let form = document.getElementById("enderecoForm")
        let dados = getEnderecoDados(form.elements)
        let info = getFecthInfo(dados)
        fetch("http://localhost:5000/api/Endereco", info)
            .then(response => {
                if (response.status === 201) {
                    console.log("Endereço cadastrado")
                    response.json().then(dados => enderecoCallBack(dados.idEndereco))
                } else {
                    alert('Erro')
                    console.log(response)
                }
            }).catch(erro => {console.log(erro)})
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
                <Form.Group>
                <Form.Row>
                    <Form.Group controlId="formGridCEP">
                        <Form.Label>CEP</Form.Label>
                        <Form.Control type="number" max={8} min={8} placeholder="00000000" name="cep" onKeyUp={buscaCep}/>
                    </Form.Group>
                </Form.Row>
                <Form.Row>
                    <Form.Group controlId="formGridRua">
                        <Form.Label>Rua</Form.Label>
                        <Form.Control name="rua" readOnly={true} />
                    </Form.Group>
                    <Form.Group controlId="Numero">
                        <Form.Label>Numero</Form.Label>
                        <Form.Control name="numero" />
                    </Form.Group>
                </Form.Row>
                <Form.Row>
                    <Form.Group controlId="formGridCidade">
                        <Form.Label>Cidade</Form.Label>
                        <Form.Control name="cidade" readonly={true}/>
                    </Form.Group>
                    <Form.Group controlId="formGridUf">
                        <Form.Label>UF</Form.Label>
                        <Form.Control name="uf" readonly={true}/>
                    </Form.Group>
                </Form.Row>
                </Form.Group>
            </Form.Row>
        </Form>

        <button id="cadastrar" onClick={cadastrarEndereco}>Cadastrar</button>
    </>
    )
}

export default Endereco;