import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import { useParams } from 'react-router-dom';
import CardVaga from '../../components/cardvaga/cardvaga';
import Footer from '../../components/footer';
import Header from '../../components/header';
import { buscarInscricoesPorVaga } from '../../services/inscricaoService';
import './style.css';
import '../../assets/styles/global.css';

function VagasInscricoes(props) {
    const [idVaga, setIdVaga] = useState(0)
    const [inscricoes, setInscricoes] = useState([])
    
    
    const queryString = window.location.search
    const urlParams = new URLSearchParams(queryString);
    let id = urlParams.get('id')
    const vagaTitulo = urlParams.get('titulo')

    if (id && id > 0 && id !== idVaga) {
        setIdVaga(id)
    }

    useEffect(() => {
        buscarInscricoesPorVaga(id)
            .then(dados => {
                setInscricoes(dados)
            })
    }, [idVaga]);

    return (
        <div>
            <Header />
            <div className="capa-inscricao">
        </div>
            <h1 className="tituloVaga">Inscrições da vaga {vagaTitulo}</h1>
            <table>
                <thead className="vagaInscrito">
                    <tr>
                        <th>Data da Inscrição</th>
                        <th>Email do Candidato</th>
                        <th>CPF</th>
                        <th>Ver Candidato</th>
                    </tr>
                </thead>
                { inscricoes ? 
                <tbody className="infoInscrito">
                    {inscricoes.map(inscricao => 
                        <tr>
                            <td>{inscricao.dataInscricao}</td>
                            <td>{inscricao.idCandidatoNavigation.email}</td>
                            <td>{inscricao.idCandidatoNavigation.cpf}</td>
                            <td><a href={'/mostrarcandidato?id=' + inscricao.idCandidato}>Ver</a></td>
                        </tr>    
                    )}
                </tbody>
                : 
                <tbody className="semInscrito"><tr><td colSpan='4'>Nenhuma inscrição encontrada para esta vaga</td></tr></tbody>
                }
            </table>
            <Footer />
        </div>
    )
}

export default VagasInscricoes