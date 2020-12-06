import React from 'react';
import Carddv from './Carddv';
import './style.css'

const CardsDv = () => {
  const cardsdv = [
    { 
      titulo: 'Como ser um candidato?',
      info: 'Engajamento efetivo de 9 entre 10 candidatos.'
    }
  ];

  return (
    <div>
      {cardsdv.map((carddv) => (
        <Carddv key={carddv.titulo} {...carddv} />
      ))}
    </div>
  );
};

export default CardsDv;
