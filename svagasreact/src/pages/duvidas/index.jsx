import React from 'react';
import './style.css';
import '../../assets/styles/global.css';
import pergunta from '../../assets/images/pergunta1.svg';
import Header from '../../components/header/index';
import CardsDv from '../../components/cardduvidas/index.jsx';
import Footer from '../../components/footer/index';

function Duvidas() {
  return (
    <>
      <Header />
      <div className="duvidas">
      <div className="container_banner">
        <div className="container_cont">
          <h1>Dúvidas?</h1>
          <img src={pergunta} alt="Duvidas" />
        </div>
      </div>
      <h3 className="topico">Tópicos</h3>
      <div className="container_topc">
        <ul style={{marginBottom:'20px'}}>
          <li style={{paddingBottom:'15px', color:'#FF0000'}}>Sobre o site</li>
          <li style={{paddingBottom:'15px', color:'#FF0000'}}>Sobre o candidato</li>
          <li style={{paddingBottom:'15px', color:'#FF0000'}}>Sobre a empresa</li>
          <li style={{paddingBottom:'15px', color:'#FF0000'}}>Sobre a vaga</li>
        </ul>
      </div>
      <div className="container_cards">
        <h3 id="h3">Sobre o site</h3>
        <CardsDv />
        <CardsDv />
        <CardsDv />
      </div>
      <div className="container_card2">
        <h3 id="h3">Sobre o candidato</h3>
        <CardsDv />
        <CardsDv />
        <CardsDv />
      </div>
      <div className="container_card2">
        <h3 id="h3">Sobre a empresa</h3>
        <CardsDv />
        <CardsDv />
        <CardsDv />
      </div>
      <div className="container_card2">
        <h3 id="h3">Sobre a vaga</h3>
        <CardsDv />
        <CardsDv />
        <CardsDv />
      </div>
      <div className="com_duvida">
        <p>
          Ainda possui alguma duvida? Mande para o nosso email 
          <strong style={{ color: '#ff0000' }}>
          senai.vagas@sp.senai.br
          </strong>!
        </p>
      </div>
      </div>
      <Footer />
    </>
  );
}

export default Duvidas;
