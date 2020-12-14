import React from 'react'
import { useState } from 'react'
import MinhasFormacoesCard from '../minhasformacoescard'

export default function FormacoesLista({formacoes, callbackFormacaoDeletada}) {
    return (
        <>
            <h1>Lista de Formações</h1>
          
            {formacoes.map(formacao => 
                <MinhasFormacoesCard idFormacao={formacao.idFormacao} curso={formacao.curso} 
                    instituicao={formacao.instituicao} dataInicio={formacao.dataInicio} dataConclusao={formacao.dataConclusao} callbackFormacaoDeletada={callbackFormacaoDeletada}
                />)}
        </>
    )
}