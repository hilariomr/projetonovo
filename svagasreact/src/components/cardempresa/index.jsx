import React from 'react';
import Conteudo from './conteudo';
import './style.css';
import frame from '../../assets/images/Frame.svg';
import mensagem from '../../assets/images/mensagem.svg';
import grafico from '../../assets/images/grafico.svg';
import controle from '../../assets/images/controle.svg';
import filtro from '../../assets/images/filtro.svg';

const Cardhome = () => {  
  const cards = [
    {
      imagem: <img src={frame} alt="Relogio" />,
      titulo: '3x Mais Rapido',
      descricoes:
        'Da selecao a contratacao, tornamos todo o processo mais eficiente.',
    },
    {
      imagem: <img src={mensagem} alt="Relogio" />,
      titulo: 'Talentos Interessados',
      descricoes: 'Engajamento efetivo de 9 entre 10 candidatos.',
    },
    {
      imagem: <img src={grafico} alt="Relogio" />,
      titulo: 'Economize tempo e dinheiro',
      descricoes:
        'Nossa ferramenta seleciona apenas perfis compatíveis com as suas necessidades.',
    },
    {
      imagem: <img src={controle} alt="Relogio" />,
      titulo: 'Controle total',
      descricoes:
        'Nossa ferramenta seleciona apenas perfis compatíveis com as suas necessidades.',
    },
    {
      imagem: <img src={filtro} alt="Relogio" />, 
      titulo: 'Filtros e shortlist',
      descricoes:
        'Encontre candidatos por habilidades ou experiência. Adaptamos as sugestões com base nas vagas que criar.',
    },
  ];

  return (
    <div className="cardempresa">
      {cards.map((card) => (
        <Conteudo key={card.titulo} {...card} />
      ))}
    </div>
  );
};

export default Cardhome;
