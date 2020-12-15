import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import Footer from '../../components/footer'
import Header from '../../components/header'
import { buscarInscricoesPorCandidatoLogado, deletarInscricaoPorID } from '../../services/inscricaoService'
import './style.css';
import '../../assets/styles/global.css';

function Inscricoes() {
    const [inscricoes, setInscricoes] = useState([])

    useEffect(() => {
        buscarInscricoesPorCandidatoLogado()
            .then(dados => dados.map(item => getInscricaoFormatada(item)))
            .then(inscricoes => { setInscricoes(inscricoes) })
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
            'salario': dados.idVagaNavigation.salario,
            'localTrabalho': dados.idVagaNavigation.localTrabalho,
            'tipoContratacao': dados.idVagaNavigation.tipoContratacao,
           
        }
    }

    inscricoes.sort(function(a, b) {
        return  b.idInscricao - a.idInscricao;
    });

    return (
        <>
            <Header />
            <div className="capa-inscricao">
        </div>
            <table>
                <thead className="tituloInscricao">
                    <tr>
                        
                        <th>Titulo da Vaga</th>
                        <th>Salário</th>
                        <th>Local de Trabalho</th>
                        <th>Tipo de Contratação</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                {console.log(inscricoes)}
                {inscricoes.length > 0 ?
                    <tbody className="minhaInscricao">
                        
                        {inscricoes.map(inscricao =>
                            <tr key={inscricao.idInscricao}>
                                
                                <td>{inscricao.titulo}</td>                                
                                <td>{"R$ " + inscricao.salario}</td>
                                <td>{inscricao.localTrabalho}</td>
                                <td>{inscricao.tipoContratacao}</td>
                                <td><button type='button' className="inscricao" onClick={() => removeInscricao(inscricao.idInscricao)}>Excluir</button></td>
                                
                            </tr>
                            
                        )}
                        
                    </tbody>
                    : <tbody className="semInscricao"><tr><td colSpan='8'>Você não possui nenhuma inscrição</td></tr></tbody>}

            </table>
            <Footer />
        </>
    )

}

export default Inscricoes