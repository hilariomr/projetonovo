import React from 'react';
import './style.css';
import '../../assets/styles/global.css';
import Card from './Card';

import cadastro from '../../assets/icones/cadastro.png';
import procurar from '../../assets/icones/procurar.png';
import entrevista from '../../assets/icones/entrevista.png';





const CardsHome = () => {

    const cardshome = [
        { imagem: <img src={cadastro} alt="Cadastro"/>, titulo: '100% Gratuito', descricao: 'Realize seu cadastro no site gratuitamente.' },
        { imagem: <img src={procurar} alt="Procurar"/>, titulo: 'Procure por Vagas', descricao: 'Encontre pelo seu emprego ideal com nossos parceiros' },
        { imagem: <img src={entrevista} alt="Entrevista"/>, titulo: 'Encontre Candidatos', descricao: 'Encontre talentos para trabalhar na sua empresa.' },
        
    ];

    return (
        
        <div className='cardhome'>
            {cardshome.map( (card) => (
                <Card key={card.titulo} {...card} />
            ))}

        </div>
        
        

        
    );
    
};



export default CardsHome;