import React from 'react';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import { Link } from 'react-router-dom';
import { useHistory } from 'react-router-dom';

import './style.css';
import '../../assets/styles/global.css';
import { useState } from 'react';

function LoginCandidato() {
  let history = useHistory();

  const [email, setEmail]= useState("");
  const [senha, setSenha] = useState("");

  const login = () => {
    const login = {
      email: email,
      senha: senha,
      tipoUsuario: 1
    };

    const init = {
      method: 'post',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(login)
    }

    fetch('http://localhost:5000/api/Login', init)
      .then(resp => resp.json())
      .then(data => {
        // Verifica se a propriedade token é diferente de indefinida (se a propriedade existe no retorno do json)
        if (data.token !== undefined) {
          localStorage.setItem('token-usuario', data.token)
          
          localStorage.setItem('identificador-usuario', data.idUsuario)
          localStorage.setItem('tipo-usuario', data.tipoUsuario)

          // Envia (empurra) pra uma página específica
          history.push('/perfil/candidato');
        }
        else {
          // Erro caso email ou senha sejam inválidos-
          alert(data)
        }
      })
      .catch(erro => console.log(erro))
  }

  return (
    <div className="login">
      <Header />
      <body>

        <div class="content-login">
          {/* <!--FORMULÁRIO DE LOGIN CANDIDATO--> */}
          <div id="login">
            <div className="retangus">
              <div className="retangu1">
                <a href="">Candidatos</a>
                <div className="triangulo"></div>
              </div>
              <div className="retangu2">
                <Link to="/login/empresa">Empresas</Link>
              </div>
            </div>
            <form onSubmit={ event => {
            // Padrão de comportamento (prevenindo o comportamento padrão de eventos)
            event.preventDefault()
            login()
          }
        }>
              <div className="form-login">
                <p>
                  <label for="email_login">Email</label>
                  <input id="email_login" name="email_login" required="required" type="email" onChange={e => setEmail(e.target.value)} />
                </p>

                <p className="senha-login">
                  <label for="senha_login">Senha</label>
                  <input id="senha_login" name="senha_login" required="required" type="password" onChange={e => setSenha(e.target.value)} />
                </p>

                <div className="infos">
                  <div className="remember">
                    <input type="checkbox" name="manterlogado" id="manterlogado" value="" />
                    <p for="manterlogado">Lembrar senha</p>

                  </div>
                  <p>Esqueceu sua senha? <a>Clique aqui</a></p>
                </div>

               <button name="submit1">Login</button>
              </div>

              <div className="ou">
                <hr />
                <p>OU</p>
                <hr />
              </div>

              <Link to="/cadastrocandidato"><button name="submit2">Cadastre-se</button></Link>

            </form>
          </div>
        </div>
      </body>
      <Footer />
    </div>
  )
}

export default LoginCandidato;