import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import CardsHome from '../../components/cardhome/index';
import { Link } from 'react-router-dom';

import imgHome1 from '../../assets/images/vectorhome1.svg';
import imgHome2 from '../../assets/images/vectorhome2.svg';
import imgPerfilCarrossa from '../../assets/images/fotoperfil-candi.svg';
import imgSpaceNeedle from '../../assets/images/spaceneedle-logo.svg';
import imgAvanade from '../../assets/images/avanade-logo.svg';
import imgFacebook from '../../assets/images/facebook-logo.svg';
import './style.css';
import '../../assets/styles/global.css';

function Home() {
    return (
        <div className="home">
            <Header />
            <body>
                <div className="container-home">
                    <div className="content-home1">
                        <img src={imgHome1} alt="" />
                        <p>
                            No Senai Vagas você vai encontrar a
                            pessoa ideal para a sua empresa.
                        </p>
                        <Link to="/home/empresa">
                        <button name="button-home">Sou Empresa</button>
                        </Link>
                    </div>
                    <div className="content-home2">
                        <img src={imgHome2} alt="" />
                        <p>
                            O emprego que você tanto sonha está na
                            nossa plataforma Senai Vagas.
                        </p>
                        <Link to="/home/candidato">
                        <button name="button-home">Sou Candidato</button>
                        </Link>
                    </div>
                </div>
                <h1>A plataforma de empregos exclusiva do Senai</h1>
                <CardsHome />

                <div className="container-carrossa">
                    <div className="texts-carrosa">
                        <h2>Cristiano foi um aluno do curso de desenvolvimento de sistemas no Senai de informática SP</h2>
                        <h3>“O Senai Vagas facilita esse contato de empresa e aluno do senai, me ajudou muito a conseguir meu primeiro estágio.” </h3>
                    </div>

                    <div className="infos-carrosa">
                        <img src={imgPerfilCarrossa} alt="" />
                        <h3>Cristiano Ronaldo</h3>
                        <h4>Desenvolvedor</h4>
                    </div>
                </div>

                <h1>Algumas das empresas parceiras do Senai</h1>
                <div className="empresas-parca">
                    <img src={imgSpaceNeedle} alt=""/>
                    <img src={imgAvanade} alt=""/>
                    <img src={imgFacebook} alt=""/>
                </div>
            </body>
            <Footer />
        </div>
    )
}

export default Home;