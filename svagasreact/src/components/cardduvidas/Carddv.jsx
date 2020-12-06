import React from 'react';
import './style.css';

const Carddv = ({ titulo, info }) => {
  const [ativo, setAtivo] = React.useState(true);

  if (ativo === false)
    return (
      <div className="ifcarddv">  
        <div className="conteudo2dv">
          <h3>{titulo}</h3>
          <button className="botao1" onClick={() => setAtivo(!ativo)}>
            {ativo ? '+' : '-'}
          </button>
        </div>
        <div className="info">
          <p>{info}</p>
        </div>
      </div>
    );

  return (
    <div className="carddv">
      <div className="conteudodv">
        <h3>{titulo}</h3>
        <button className="botao2" onClick={() => setAtivo(!ativo)}>
          {ativo ? '+' : '-'}
        </button>
      </div>
    </div>
  );
};

export default Carddv;
