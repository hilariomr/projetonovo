import React from 'react'

function getFecthInfo(type, dados) {
    let token = localStorage.getItem("token-usuario")
    let info = {
        method: type,
        headers: {
            'Content-Type': 'application/json',
            'authorization': 'bearer ' + token
        },
        body: JSON.stringify(dados)
    }

    return info
}

export function buscarCEPAPI(cep) {
    if (cep.length === 8) {
        let apiURL = `https://api.pagar.me/1/zipcodes/${cep}`
        let fetchInfo = {
            method: 'GET',
            hearders: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        }

        return fetch(apiURL, fetchInfo)
            .then(response => {
                if (response.ok) return response.json()
                throw new Error('cep não encontrado')
            }).then(data => {
                return data
            }).catch(error => {
                console.log(error)
                alert('CEP Não Encontrado')
            })
    }
}

export function atualizarEnderecoAPI(id, dados) {
    let info = getFecthInfo("PUT", dados)
    return fetch(`http://localhost:5000/api/Endereco/${id}`, info)
        .then(response => {
            console.log(response)
            if (response.status === 204) {
                return true
            } else {
                console.log(response)
                return false
            }
        }).catch(erro => { console.log(erro) })
}

export function buscarEnderecoAPI(id) {
    let info = getFecthInfo("GET")
    return fetch(`http://localhost:5000/api/Endereco/${id}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                throw new Error('Endereço Nâo Encontrado')
            }
        }).then(dados => {
            return dados
        })
        .catch(erro => { console.log(erro) })
}