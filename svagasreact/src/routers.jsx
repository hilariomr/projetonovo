import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Home from './pages/home/index';
import LoginCandidato from './pages/logincandidato/index';
import LoginEmpresa from './pages/loginempresa/index';
import LoginAdmin from './pages/loginadmin/index';
import PerfilCandidato from './pages/perfilcandidato/index';
import PerfilEmpresa from './pages/perfilempresa/index';
import Admin from './pages/administrador/index';
import HomeCandidato from './pages/homecandidato/index';
import HomeEmpresa from './pages/homeempresa/index';
import Duvidas from './pages/duvidas/index';
import VagasCadastrar from './pages/vagascadastrar';
import VagasListar from './pages/vagaslistar';
import CadastroEmpresa from './pages/cadastroempresa/index';
import CadastroCandidato from './pages/cadastrocandidato/index';
import AtualizaCandidato from './pages/atualizacaocandidato';



function Routers() {
    return (
            
            <BrowserRouter>
                <Route path="/" exact component={Home} />
                <Route path="/login/candidato" exact component={LoginCandidato} />
                <Route path="/login/empresa" exact component={LoginEmpresa} />
                <Route path="/login/admin" exact component={LoginAdmin} />
                <Route path="/perfil/candidato" exact component={PerfilCandidato} />
                <Route path="/perfil/empresa" exact component={PerfilEmpresa} />
                <Route path="/home/candidato" exact component={HomeCandidato} />
                <Route path="/home/empresa" exact component={HomeEmpresa} />
                <Route path="/duvidas" exact component={Duvidas} />
                <Route path="/admin" exact component={Admin}/>
                <Route path="/vagas/cadastro" exact component={VagasCadastrar}/>
                <Route path="/vagas" exact component={VagasListar}/>
                <Route path="/cadastroempresa" exact component={CadastroEmpresa} />
                <Route path="/cadastrocandidato" exact component={CadastroCandidato} />

                <Route path="/perfil/candidato/editar" exact component={AtualizaCandidato} />
            </BrowserRouter>
        

    )
}

export default Routers;