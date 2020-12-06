import React from 'react';
import Cardvg from './Cardvg';
import './style.css'

const Cardvagas = () => {
  const cards = [
    { 
      titulo: 'Como ser um candidato?',
      info: 'Engajamento efetivo de 9 entre 10 candidatos.',
    },
    {
      titulo: 'Talentos Interessados',
      info: 'Engajamento efetivo de 9 entre 10 candidatos',
    },
  ];

  return (
    <div>
      {cards.map((card) => (
        <Cardvg key={card.titulo} {...card} />
      ))}
    </div>
  );
};

export default Cardvagas;
