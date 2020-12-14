import React, { useState } from 'react'
import { useEffect } from 'react'
import { buscarFormacoesPorDadoCandidato } from '../../services/formacaoService'
import MinhasFormacoesForm from '../minhasformacoesform'
import FormacoesLista from '../formacoeslista'


export default function MinhasFormacoes(props) {
    const [dadoCandidatoId, setDadoCandidato] = useState(0)
    const [formacaoLista, setFormacaoLista] = useState([])

    if (props.candidatoId && props.candidatoId > 0 && props.candidatoId !== dadoCandidatoId)
        setDadoCandidato(props.candidatoId)

    useEffect(() => {
        if(dadoCandidatoId && dadoCandidatoId !== 0) {
            buscarFormacoesPorDadoCandidato(dadoCandidatoId)
                .then(formacoes => {
                    setFormacaoLista(formacoes.map(formacao => getFormacaoFormatada(formacao)))
                })
        }
    }, [dadoCandidatoId])


    function getFormacaoFormatada(formacao) {
        return {
            "idFormacao": formacao.idFormacaoNavigation.idFormacao,
            "instituicao": formacao.idFormacaoNavigation.instituicao,
            "curso": formacao.idFormacaoNavigation.curso,
            "dataInicio": formacao.idFormacaoNavigation.dataInicio.slice(0,10),
            "dataConclusao": formacao.idFormacaoNavigation.dataConclusao.slice(0,10)
        }
    }

    function callbackFormacaoCadastrada(dados) {
        let formacao = {
            "idFormacao": dados.idFormacao,
            "instituicao": dados.instituicao,
            "curso": dados.curso,
            "dataInicio": dados.dataInicio.slice(0,10),
            "dataConclusao": dados.dataConclusao.slice(0,10)
        }

        console.log(formacao)

        setFormacaoLista([...formacaoLista, formacao])
    }

    function callbackFormacaoDeletada(id) {
        setFormacaoLista(formacaoLista.filter(formacao => formacao.idFormacao !== id))
    }
    

    return (
        <>
            <h1>Formações</h1>
            <MinhasFormacoesForm idDadoCandidato={dadoCandidatoId} callbackFormacaoCadastrada={callbackFormacaoCadastrada}/>
            <FormacoesLista formacoes={formacaoLista} callbackFormacaoDeletada={callbackFormacaoDeletada}/>
        </>
    )

}