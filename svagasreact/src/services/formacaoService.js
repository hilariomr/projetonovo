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

export async function buscarFormacaoAPI(id) {
    let info = getFecthInfo("GET")
    const response = await fetch(`http://localhost:5000/api/Formacao/${id}`, info)
    if (response.status === 200) {
        return response.json()
    } else {
        throw new Error('Endereço Nâo Encontrado')
    }
    const dados = undefined
    return dados
}

export function buscarFormacoesPorDadoCandidato(id) {
    let info = getFecthInfo("GET")
    return fetch(`http://localhost:5000/api/MinhasFormacoes/dadocandidato/${id}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                throw new Error('formações não encontrada')
            }
        })
}


export function cadastarNovaFormacao(dados) {
    let info = getFecthInfo("POST", dados)
    return fetch('http://localhost:5000/api/Formacao', info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                throw new Error('Endereço Ao Cadastrar Formação')
            }
        })
}

export function deletarFormacao(id) {
    let info = getFecthInfo("DELETE")
    return fetch(`http://localhost:5000/api/Formacao/${id}`, info)
        .then(response => {
            if (response.status !== 200) {
                throw new Error('Não foi possivel deletar a formação')
            }

        })
}