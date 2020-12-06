import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import imgFotoEmpresa from '../../assets/images/fotohomeempresa.svg';

import './style.css';
import '../../assets/styles/global.css';
import Cardempresa from '../../components/cardhomes/empresa.jsx';
import { Link } from 'react-router-dom';

function HomeEmpresa() {
  return (
    <div className="home-empresa">
      <Header />
      <body>
        <div className="container-homeempresa">
          <h1>Busque talentos de um jeito simples</h1>
          <h2>Menos processo mais seletivo</h2>
          <h3>Você indica as características que procura e nossa plataforma seleciona os melhores candidatos. Experimente abaixo.</h3>

          <img src={imgFotoEmpresa} alt="" />

          <div className="buttons-homeempresa">
            <Link to="/cadastroempresa">Faça o seu cadastro</Link>
          </div>
        </div>

        <h1 id="titulo-home">Simplifique o processo seletivo para você encontrar 
                            talentos mais rápido </h1>
      </body>

      <Cardempresa/>
      <Footer />
    </div>
  )
}

export default HomeEmpresa;