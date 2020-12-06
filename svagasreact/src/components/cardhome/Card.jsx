import React from 'react'


const Card = ({ imagem, titulo, descricao}) => {
    return (
        <div className='card'>
            {imagem}
            <h3>{titulo}</h3>
            <h5>{descricao}</h5>
        </div>
        
    )
};

export default Card;