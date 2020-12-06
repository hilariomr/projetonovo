import React from 'react';
import Conteudo from './conteudo';
import './style.css';
import comment from '../../assets/images/comment.svg';
import filter from '../../assets/images/filter.svg';
import build from '../../assets/images/build.svg';
import person from '../../assets/images/person.svg';
import where from '../../assets/images/where.svg';

const Cardcandidato= () => {  
  const cards = [
    {
      imagem: <img src={comment} alt="Relogio" />,
      titulo: 'Vamos deixar você inteirado',
      descricoes:
        'Assim que uma vaga do seu interesse for publicada te notificamos por email',
    },
    {
      imagem: <img src={filter} alt="Relogio" />,
      titulo: 'Filtramos as vagas',
      descricoes: 'As melhores oportunidades de acordo com o seu conhecimento',
    },
    {
      imagem: <img src={build} alt="Relogio" />,
      titulo: 'Todos os parceiros Senai',
      descricoes:
        'Aqui todos os nossos principais parceiros divulgam as suas vagas',
    },
    {
      imagem: <img src={person} alt="Relogio" />,
      titulo: 'Seu perfil completo',
      descricoes:
        'Vamos ajuda-lo a deixar seu perfil completo, para ficar cada vez mais atrativo, para as empresas',
    },
    {
      imagem: <img src={where} alt="Relogio" />, 
      titulo: 'Escolha no que vai trabalha',
      descricoes:
        'Você podera escolher com qual tecnologia tem mais preferência',
    },
  ];

  return (
    <div className="cardcandidato">
      {cards.map((card) => (
        <Conteudo key={card.titulo} {...card} />
      ))}
    </div>
  );
};

export default Cardcandidato;