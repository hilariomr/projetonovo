import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import CardVaga from '../../components/cardvaga/cardvaga';
import Footer from '../../components/footer';
import Header from '../../components/header';

function VagasListar() {
    const [vagas, setVagas] = useState([])

    useEffect(() => {
        let token = localStorage.getItem("token-usuario")
        let info = {
            headers: {
                'Content-Type': 'application/json',
                'authorization': 'bearer ' + token 
            }
        }
        fetch('http://localhost:5000/api/Vaga', info).then(response => response.json())
            .then(dados => {
                setVagas(dados);
            });
    }, []);

    vagas.sort(function(a, b) {
        return  b.idVaga - a.idVaga;
    });

    return (
        <div>
            <Header />
            {vagas.map(item => <CardVaga item={item}/>)}
            <Footer />
        </div>
    )
}

export default VagasListar