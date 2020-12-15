import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgFotoCandidato from '../../assets/images/fotohomecandidato.svg';

import './style.css';
import '../../assets/styles/global.css';
import Cardcandidato from '../../components/cardhomes/candidato.jsx';
import { Link } from 'react-router-dom';


function HomeCandidato() {
  return (
    <div className="home-candi">
      <Header />
      <body>
        <div className="container-homecandi">
          <h1>Encontre aqui a vaga que vai alavancar sua carreira profissional</h1>
          <h2>Uma plataforma exclusiva para alunos do senai.</h2>

          <img src={imgFotoCandidato} alt="" />

          <div className="buttons-homecandi">
            <Link to="/cadastrocandidato">Faça o seu cadastro</Link>
            <Link to="/passoapasso">Veja como fazer</Link>
 </div>
        </div>

        <h1 id="titulo-home">Facilitamos todo o processo de contratação para você</h1>
      </body>

      <Cardcandidato/>

      <Footer />
    </div>
  )
}

export default HomeCandidato;