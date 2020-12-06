import React from 'react';
import './style.css';

const Cardvg = ({ titulo, info }) => {
  const [ativo, setAtivo] = React.useState(true);

  if (ativo === false)
    return (
      <div className="ifcardvg">
        <div className="conteudo2vg">
        <h3>{titulo}</h3>
        <button className="botao1" onClick={() => setAtivo(!ativo)}>
          {ativo ? 'Abrir' : 'Fechar'}
        </button>
        <p>{info}</p>
        </div>
      </div>
    );

  return (
    <div className="cardvg">
      <div className="conteudovg">
        <h3>{titulo}</h3>
        <button className="botao2" onClick={() => setAtivo(!ativo)}>
          {ativo ? 'Abrir' : 'Fechar'}
        </button>
      </div>
    </div>
  );
};

export default Cardvg;
