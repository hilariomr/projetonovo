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

export function buscarVagasPorEmpresaService(idDadoEmpresa) {
    let info = getFecthInfo("GET")
    return fetch(`http://localhost:5000/api/Vaga/dadoEmpresa/${idDadoEmpresa}`, info)
        .then(response => {
            if (response.status === 200) {
                return response.json()
            }
        })

}