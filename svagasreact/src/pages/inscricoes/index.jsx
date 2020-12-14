import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import Footer from '../../components/footer'
import Header from '../../components/header'
import { buscarInscricoesPorCandidatoLogado, deletarInscricaoPorID } from '../../services/inscricaoService'

function Inscricoes() {
    const [inscricoes, setInscricoes] = useState([])

    useEffect(() => {
        buscarInscricoesPorCandidatoLogado()
            .then(dados => dados.map(item => getInscricaoFormatada(item)))
            .then(inscricoes => {setInscricoes(inscricoes)})
            .catch(erro => {
                alert('Ocorreu um erro ao buscar as vagas deste candidato')
                console.log(erro)
            })
    }, [])

    function removeInscricao(id) {
        deletarInscricaoPorID(id)
            .then(() => {
                alert('Inscrição foi deletada com sucesso')
                removetInscricaoDaLista(id)
            }).catch(erro => {
                alert('Ocorreu um erro ao deletar inscrição')
                console.log(erro)
            })
    }

    function removetInscricaoDaLista(id) {
        setInscricoes(inscricoes.filter(inscricao => inscricao.idInscricao !== id))
    }

    function getInscricaoFormatada(dados) {
        return {
            'idInscricao': dados.idInscricao,
            'titulo': dados.idVagaNavigation.tituloVaga,
            'dataInicio': dados.idVagaNavigation.dataInicio,
            'dataTermino': dados.idVagaNavigation.dataTermino,
            'salario': dados.idVagaNavigation.salario,
            'localTrabalho': dados.idVagaNavigation.localTrabalho,
            'tipoContratacao': dados.idVagaNavigation.tipoContratacao,
        }
    }

    return (
        <>
            <Header />
                <table>
                    <thead>
                        <tr>
                            <th>Data de Inscrição</th>
                            <th>Titulo da Vaga</th>
                            <th>Data de Inicio</th>
                            <th>Data de Termino</th>
                            <th>Salário</th>
                            <th>Local de Trabalho</th>
                            <th>Tipo de Contratação</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    {console.log(inscricoes)}
                    { inscricoes.length > 0 ? 
                    <tbody>
                        {inscricoes.map(inscricao => 
                            <tr key={inscricao.idInscricao}>
                                <td>{inscricao.titulo}</td>
                                <td>{inscricao.dataInicio}</td>
                                <td>{inscricao.dataTermino}</td>
                                <td>{inscricao.salario}</td>
                                <td>{inscricao.localTrabalho}</td>
                                <td><button type='button' onClick={() => removeInscricao(inscricao.idInscricao)}>Remover</button></td>
                            </tr>
                        )}
                    </tbody>
                    : <tbody><tr><td colSpan='8'>Nenhuma vaga inscrita</td></tr></tbody>}

                </table>
            <Footer />
        </>
    )

}

export default Inscricoes