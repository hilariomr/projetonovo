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

export function buscarCandidatoPorID(id, callback) {
    fetch(`http://localhost:5000/api/Candidato/${id}`, getFecthInfo("GET"))
        .then(response => {
            if (response.ok) return response.json()
        }).then(dados => {
            callback({
                idCandidato: id,
                email: dados.email,
                cpf: dados.cpf,
                senha: dados.senha,
                dadosCandidato: {
                    idDadoCandidato: dados.idDadoCandidato,
                    foto: dados.idDadoCandidatoNavigation.foto,
                    nomeCompleto: dados.idDadoCandidatoNavigation.nomeCompleto,
                    telefone: dados.idDadoCandidatoNavigation.telefone,
                    tipoCarreira: dados.idDadoCandidatoNavigation.tipoCarreira,
                    modeloContratacao: dados.idDadoCandidatoNavigation.modeloContratacao,
                    tipoTrabalho: dados.idDadoCandidatoNavigation.tipoTrabalho,
                    pretencaoSalarial: dados.idDadoCandidatoNavigation.pretencaoSalarial,
                    linkCurriculo: dados.idDadoCandidatoNavigation.curriculo,
                    linkedin: dados.idDadoCandidatoNavigation.linkLinkedin,
                    portifolio: dados.idDadoCandidatoNavigation.linkPortifolio,
                    git: dados.idDadoCandidatoNavigation.linkGit,
                    idEndereco: dados.idDadoCandidatoNavigation.idEndereco
                }
            })
        })
}


export function atualizarCandidato(id, dados) {
    let info = getFecthInfo("PUT", dados)

    fetch(`http://localhost:5000/api/Candidato/${id}`, info)
        .then(response => {
            console.log(response)
            if (response.status === 200) {
                console.log("Candidato atualizado")
            } else {
                alert('Erro')
                console.log(response)
            }
        })
}