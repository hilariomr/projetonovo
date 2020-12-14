import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import CardVaga from '../../components/cardvaga/cardvaga';
import Footer from '../../components/footer';
import Header from '../../components/header';
import { buscarEmpresaService } from '../../services/empresaService';
import { buscarVagasPorEmpresaService } from '../../services/vagasService';

function VagasEmpresa() {
    const [vagas, setVagas] = useState([])

    useEffect(() => {
        let idDadoEmpresa = localStorage.getItem('identificador-usuario')
        buscarEmpresaService(idDadoEmpresa).then(empresa => {
            buscarVagasPorEmpresaService(empresa.idDadoEmpresa)
                .then(items => {
                    console.log(items)
                    setVagas(items)
                })
        })
    }, []);

    return (
        <div>
            <Header />
            <h1>Vagas da Empresa</h1>
            {vagas.map(item => <CardVaga item={item} empresaVisualizacao={true}/>)}
            <Footer />
        </div>
    )
}

export default VagasEmpresa