import React from 'react';
import './style.css';

const Conteudo = ({ imagem, titulo, descricoes }) => {
  return (
    <div className="card">
      {imagem}
      <h3 className="titulo">{titulo} </h3>
      <p>{descricoes}</p>
    </div>
  );
};

export default Conteudo;
