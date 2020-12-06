import React from 'react';
import './style.css';
import '../../assets/styles/global.css';

import imgPhone from '../../assets/images/phone.svg';
import imgMail from '../../assets/images/mail.svg';
import imgMap from '../../assets/images/map-pin.svg';
import imgTwitter from '../../assets/images/twitter.svg';
import imgFace from '../../assets/images/facebook.svg';
import imgLinkedin from '../../assets/images/linkedin.svg';
import imgInstagram from '../../assets/images/instagram.svg';


function Footer() {
    return (
    <footer>
        <div className="footer">
            <div className="contatos">
                <h2>Contatos</h2>
                <div>
                    <img src={imgPhone} alt=""/>
                    <p>(11) 3273 - 5000</p>
                </div>
                
                <div>
                <img src={imgMail} alt=""/>
                    <p>informatica@sp.senai.br</p>
                </div>
            </div>

            <div className="endereco">
                    <h2>Endereço</h2>
                <div>
                    <img src={imgMap} alt=""/>
                    <p>Av. Alameda Barão de Limeira, 539, Santa Cecília - SP</p>               
                </div>
                    <p>© Copyright Senai Tecnologia 2020, Senai Vagas - Todos os direitos Reservados.</p>
            </div>

            <div className="container-midias">
                <h3>FAQ</h3>
                <h3>Quem somos</h3>
                <div className="midias">
                    <h2>Redes Sociais</h2>
                    <img src={imgTwitter} alt="" id="twitter"/>
                    <img src={imgFace} alt=""/>
                    <img src={imgLinkedin} alt="" id="linkedin"/>
                    <img src={imgInstagram} alt=""/>
                </div>
            </div>
            </div>
    </footer>
    );
}

export default Footer;