import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import imgSenaiLogo from '../../assets/images/senaivagaslogo.svg';
import './style.css';
import '../../assets/styles/global.css';

function Header() {
    let identificador = localStorage.getItem("identificador-usuario")
    let history = useHistory();

    const deslogar = () => {
        localStorage.removeItem("token-usuario")
        localStorage.removeItem("identificador-usuario")
        localStorage.removeItem("tipo-usuario")

        history.push('/login/candidato');
    }

    return (
        <header>
            
            <nav>
                <img src={imgSenaiLogo} alt="" />
                <ul>
                    <Link to="/"><li>Home</li></Link>
                    <Link to="/home/empresa"><li>Empresa</li></Link>
                    <Link to="/home/candidato"><li>Candidato</li></Link>
                    <Link to="/duvidas"><li>Dúvidas</li></Link>
                </ul>
                {identificador ?  
                    <>
                    <Link to={localStorage.getItem("tipo-usuario") == 1 ? '/perfil/candidato' : '/perfil/empresa'}>
                        <button className='button-nav' >Meu Perfil</button>
                    </Link>
                    <button className='button-nav' onClick={deslogar}>Logout</button>
                    </>
                : <Link to="/login/candidato"><button id="button-nav">Login/Cadastro</button></Link>}
                
            </nav>
        </header>
    )
}

export default Header;