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

export function atualizarDadosCandidato(id, dados) {
    let info = getFecthInfo("PUT", dados)
    fetch(`http://localhost:5000/api/DadoCandidato/${id}`, info)
        .then(response => {
            if (response.status === 200) {
                console.log("Dados Candidato Atualizado")
            } else {
                alert('Erro')
                console.log(response)
            }
        })
}

export function buscarDadosCandidato(id) {
    let info = getFecthInfo("GET")
    return fetch(`http://localhost:5000/api/DadoCandidato/${id}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                alert('Erro')
                console.log(response)
            }
        })
}