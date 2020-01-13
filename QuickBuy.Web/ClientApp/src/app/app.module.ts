import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { TruncateModule } from 'ng2-truncate';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProdutoComponent } from './produto/produto.component';
import { LoginComponent } from './usuario/login/login.component';
import { GuardaRotasGuard } from './Autorizacao/guarda-rotas.guard';
import { UsuariosService } from './servicos/usuarios/usuarios.service';
import { CadastroUsuarioComponent } from './usuario/cadastro.usuario/cadastro.usuario.component';
import { ProdutosService } from './servicos/produtos/produtos.service';
import { ProdutoPesquisaComponent } from './produto-pesquisa/produto-pesquisa.component';
import { LojaPesquisaComponent } from './Loja/loja-pesquisa/loja-pesquisa.component';
import { ModalPerguntaComponent } from './modal-pergunta/ModalPergunta.component';
import { ModalProcessandoComponent } from './modal-processando/modal-processando.component';
import { ModalPerguntaService } from './servicos/Componentes/modal-pergunta.service';
import { LojaProdutoComponent } from './Loja/loja-produto/loja-produto.component';
import { LojaEfetivarComponent } from './Loja/loja-efetivar/loja-efetivar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdutoComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    ProdutoPesquisaComponent,
    LojaPesquisaComponent,
    ModalPerguntaComponent,
    ModalProcessandoComponent,
    LojaProdutoComponent,
    LojaEfetivarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    TruncateModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'novo-produto', component: ProdutoComponent, canActivate: [GuardaRotasGuard] },
      { path: 'produto', component: ProdutoPesquisaComponent, canActivate: [GuardaRotasGuard] },
      { path: 'entrar', component: LoginComponent },
      { path: 'loja-produto', component: LojaProdutoComponent },
      { path: 'loja-efetivar', component: LojaEfetivarComponent, canActivate: [GuardaRotasGuard] },
      { path: 'novo-usuario', component: CadastroUsuarioComponent }
    ],
      { useHash: true })
  ],
  providers: [UsuariosService, ProdutosService, ModalPerguntaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
