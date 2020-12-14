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


export function cadastarDadosEmpresaService(dados) {
    let info = getFecthInfo("POST", dados)
    return fetch('http://localhost:5000/api/DadoEmpresa', info)
        .then(response => {
            if (response.status === 201) {
                return response.json()
            } else {
                throw new Error('Não foi possivel cadastrar os dados da empresa')
            }
        })
}

export function cadastarEmpresaService(dados) {
    let info = getFecthInfo("POST", dados)
    return fetch('http://localhost:5000/api/Empresa', info)
        .then(response => {
            if (response.status === 201) {
                return true
            } else {
                throw new Error('Não foi possivel cadastrar os dados da empresa')
            }
        })
}

export function buscarEmpresaService(id) {
    let info = getFecthInfo("GET")
    return fetch(`http://localhost:5000/api/Empresa/${id}`, info)
        .then(response => {
            console.log(response)
            if (response.status === 200) {
                return response.json()
            } else {
                throw new Error('Não foi possivel encontrar os dados da empresa')
            }
        })
}

export function atualizarEmpresaService(id, dados) {
    let info = getFecthInfo("PUT", dados)
    return fetch(`http://localhost:5000/api/Empresa/${id}`, info)
        .then(response => {
            console.log(response)
            if (response.status === 204) {
                return true
            } else {
                throw new Error('Não foi possivel cadastrar os dados da empresa')
            }
        })
}

export function atualizarDadosEmpresaService(id, dados) {
    let info = getFecthInfo("PUT", dados)
    return fetch(`http://localhost:5000/api/DadoEmpresa/${id}`, info)
        .then(response => {
            if (response.status === 204) {
                return true
            } else {
                throw new Error('Não foi possivel cadastrar os dados da empresa')
            }
        })
}