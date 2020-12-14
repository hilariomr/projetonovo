import React from 'react'
import { Button, Card } from 'react-bootstrap'
import { deletarFormacao } from '../../services/formacaoService'


export default function MinhasFormacoesCard({idFormacao, curso, instituicao, dataInicio, dataConclusao, callbackFormacaoDeletada}) {

    function removeFormacao(event) {
        let idFormacao = event.target.getAttribute('data-formacaoid')
        deletarFormacao(idFormacao)
            .then(() => {
                alert('formação deletada')
                callbackFormacaoDeletada(idFormacao)
            }).catch(erro => {
                alert('não foi possivel deletar formação')
                console.log(erro)
            })
    } 
    return (
        <div>
            <h1>{curso}</h1>
            <h3>{instituicao}</h3>
            <p><strong>Data de Inicio:</strong>{dataInicio}</p>
            <p><strong>Data de Conclusão:</strong>{dataConclusao}</p>
            <Button variant="danger" data-formacaoId={idFormacao} onClick={removeFormacao}>Deletar</Button>
        </div>
    )
}