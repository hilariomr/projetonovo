import React from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import imgAdmFoto from '../../assets/images/admfoto.svg';

import './style.css';
import '../../assets/styles/global.css';

function Admin() {
    return (
        <div className="admin">
            <Header />
            <div className="header-perfil">
        <div className="capa-candi">
        </div>
        <img id="foto-perfil" src={imgAdmFoto} alt="" />
        <h1>Roberto Possarle</h1>
        <h2>Professor</h2>
        <button>Editar Perfil</button>
      </div>
                <body>

                <main>
                    <div class="meio">
                        

                        

                        <section id="lista-adm">
                            <h3>Lista de Vagas</h3>
                            <table>
                                <thead>
                                    <tr>
                                        <th>Empresa</th>
                                        <th>Vaga</th>
                                        <th>Nº de Vagas</th>
                                        <th>E-mail</th>
                                        <th>Data</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <td colspan="6">
                                            <p>Pedidos atualizados em 11/09/2019 às 16:07</p>
                                        </td>
                                    </tr>
                                </tfoot>
                                <tbody>
                                    <tr>
                                        <td>Space Needle</td>
                                        <td>Desenvolvedor de Sistemas</td>
                                        <td>32</td>
                                        <td>spaceneedle@email.com</td>
                                        <td>30/02/2020</td>
                                        <td>Aprovado</td>
                                    </tr>


                                    <tr>
                                        <td>Google</td>
                                        <td>Redes de Computadores</td>
                                        <td>26</td>
                                        <td>google@gmail.com</td>
                                        <td>15/03/2020</td>
                                        <td>Pendente</td>
                                    </tr>


                                    <tr>
                                        <td>Facebook</td>
                                        <td>Design gráfico</td>
                                        <td>30</td>
                                        <td>facebook@gmail.com</td>
                                        <td>27/01/2020</td>
                                        <td>Aprovado</td>
                                    </tr>

                                </tbody>
                            </table>
                        </section>
                    </div>
                </main>
            </body>
            <Footer />
        </div>
    )
}

export default Admin;
