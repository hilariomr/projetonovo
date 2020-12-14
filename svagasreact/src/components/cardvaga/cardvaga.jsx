import React from 'react';
import VagasListar from '../../pages/vagaslistar';
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import './style.css';
import '../../assets/styles/global.css';
import { Link, Route } from 'react-router-dom';
import VagasInscricoes from '../../pages/vagasinscricoes';

function CardVaga(props) {
    let vaga = props.item

    function inscrever(event) {
        let idVaga = event.target.getAttribute("data-idvaga");
        let idCandidato = localStorage.getItem("identificador-usuario");

        let token = localStorage.getItem("token-usuario")

        let info = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'authorization': 'bearer ' + token
            },
            body: JSON.stringify({
                "idCandidato": idCandidato,
                "idVaga": idVaga
            })
        }

        fetch('http://localhost:5000/api/Inscricao', info)
            .then(response => {
                if (response.status == 201) {
                    alert('Inscrição efetuada com sucesso')
                } else {
                    alert('Erro ao efetuar inscrição')
                    console.log(response)
                }
            })

    }
    

    return (
        <Card className="cardlista">
            <Card.Body>
                <Card.Text>
                    <h3>{vaga.tituloVaga}</h3>
                    <h4>Empresa: {vaga.idDadoEmpresaNavigation.nomeEmpresa}</h4>
                    <p className="itenslista">{vaga.quanVagas}  Vagas</p>
                    <p className="itenslista">Descrição: {vaga.descricao}</p>
                    <p className="itenslista">Local de Trabalho: {vaga.localTrabalho}</p>                  
                    <p className="itenslista">Data inicio: {vaga.dataInicio}</p>
                    <p className="itenslista">Data término: {vaga.dataTermino}</p>
                    <p className="itenslista">Salário: {vaga.salario}</p>
                    <p className="itenslista">Requisitos: {vaga.requisitos}</p>  
                    <p className="itenslista">Tipo de Contratação: {vaga.tipoContratacao}</p>
                    <p className="itenslista">Horário de entrada: {vaga.entradaDoTrabalho}</p>
                    <p className="itenslista">Horário de saída: {vaga.terminoDoTrabalho}</p>                    
                </Card.Text>
                {props.empresaVisualizacao ? 
                    <a href={'/vagas/inscricoes?id=' + vaga.idVaga + '&titulo=' + vaga.tituloVaga} >
                        <Button variant="primary">Ver Inscrições</Button>
                    </a>
                    : <Button variant="primary" data-idvaga={vaga.idVaga} onClick={inscrever}>Me Inscrever</Button>
                }
            </Card.Body>
        </Card>
    )
}

export default CardVaga