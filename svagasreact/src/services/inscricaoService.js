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

function getCandidatoLogadoId() {
    return localStorage.getItem("identificador-usuario")
}

export function buscarInscricoesPorCandidatoLogado() {
    let idCandidato = getCandidatoLogadoId()
    let info = getFecthInfo("GET")

    return fetch(`http://localhost:5000/api/Inscricao/InscricoesCandidato/${idCandidato}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()

            } else if (response.status === 404) {
                return []
            } else {
                throw new Error('Não foi possivel encontrar inscrições para este candidato')
            }
        })
}

export function buscarInscricoesPorVaga(id) {
    let info = getFecthInfo("GET")

    return fetch(`http://localhost:5000/api/Inscricao/InscricoesVaga/${id}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else if (response.status === 404) {
                return null
            } else {
                throw new Error('Não foi possivel encontrar inscrições para este candidato')
            }
        })
}

export function deletarInscricaoPorID(id) {
    let info = getFecthInfo("DELETE")
    return fetch(`http://localhost:5000/api/Inscricao/${id}`, info)
        .then(response => {
            console.log(response)
            if (response.status === 200) {
                console.log('Inscrição deletado com sucesso')
            } else {
                console.log(response.text())
                throw new Error('Não foi possivel deletar inscrição')
            }
        })
}