import React from 'react';
import './style.css';
import '../../assets/styles/global.css';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import astronauta from '../../assets/images/astronauta1.svg';
import tarefa from '../../assets/images/tarefa1.svg';
import programador from '../../assets/images/programador1.svg';
import line from '../../assets/images/Line.svg';

function Passo() {
  return (
    <>
      <Header />
      <div className="container_func">
        <div className="container_engloba">
          <div className="container_passo">
            <h3>Como Funciona para os candidatos</h3>
            <p>
              Se você é ou já foi aluno SENAI , é esta aqui em busca de novas
              oportunidades, veio ao lugar certo. Veja dicas é como se cadastrar
              na plataforma sem poblemas:{' '}
            </p>
          </div>
          <img src={astronauta} alt="Astronauta" />
        </div>
      </div>
      <h3 className="passo1">Passo a passo do cadastro até a vaga</h3>
      <div className="container_engloba2">
        <div className="pega_img">
          <img src={tarefa} alt="Tarefa" />
        </div>
        <div className="pega_conteudo1">
          <div className="cont_passo1">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}>01.</strong> Crie seu perfil
            </h3>
            <p id="cont_passo">
              É rapido e fácil. Preencha todo o{' '}
              <strong style={{ color: '#FF0000' }}>
                formulario de cadastro
              </strong>
              . Você tambem podera importar sua foto é conectar seu linkedIn.
            </p>
          </div>
          <div className="cont_passo2">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}> 02.</strong>Selecione suas
              habilidades
            </h3>
            <p id="cont_passo">
              As empresas teram acesso a suas habilidades, selecione com atenção
              e cautela, não se esqueça de nada!
            </p>
          </div>
        </div>
      </div>
      <div className="container_engloba2">
        <div className="pega_conteudo1">
          <div className="cont_passo1">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}>03.</strong> Personalize o seu
              Perfil
            </h3>
            <p id="cont_passo">
              Você pode deixar seu perfil com a sua cara , coloque sua foto, uma
              breve descricao sobre voce é seus principais objetivos.
            </p>
          </div>
          <div className="cont_passo2">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}>04.</strong> Coloque seus
              projetos
            </h3>
            <p id="cont_passo">
              Coloque o seus projetos e trabalhos realizados no seu perfil. Com
              uma aba destinada para seus projetos sera muito mais fácil de
              visualizar e demonstrar suas habilidades
            </p>
          </div>
        </div>
        <div className="pega_img2">
          <img src={programador} alt="Tarefa" />
        </div>
      </div>
      <div className="container_engloba2">
        <div className="pega_img">
          <img src={line} alt="Tarefa" />
        </div>
        <div className="pega_conteudo1">
          <div className="cont_passo1">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}>05.</strong> Procurando uma Vaga
            </h3>
            <p id="cont_passo">
              Na tela principal após o seu cadastro voce poderá ver todas as
              vagas em aberto, clicando no botão “Canditar-se“ voce ja estara
              participando do processo seletivo da empresa.
            </p>
          </div>
          <div className="cont_passo2">
            <h3 id="titulo_passo">
              <strong style={{ color: 'blue' }}> 06.</strong> Conseguindo uma
              Vaga
            </h3>
            <p id="cont_passo">
              Após se candidatar a uma vaga, fique atento a o seu telefone e
              email, a empresa entrara em contato para informar como será
              continuado o processo seletivo.
            </p>
          </div>
        </div>
      </div>
      <div className="com_duvida">
        <p>
          Sua duvida não foi respondida nessa pagina? Quer fazer alguma
          pergunta? Veja mais em nossa aba de{' '}
          <strong style={{ color: '#ff0000' }}>Dúvidas</strong> !
        </p>
      </div>
      <Footer />
    </>
  );
}

export default Passo;
