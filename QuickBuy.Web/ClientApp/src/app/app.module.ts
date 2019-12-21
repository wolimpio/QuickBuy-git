import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdutoComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    ProdutoPesquisaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'novo-produto', component: ProdutoComponent/*, canActivate: [GuardaRotasGuard]*/ },
      { path: 'produto', component: ProdutoPesquisaComponent /*, canActivate: [GuardaRotasGuard]*/ },
      { path: 'entrar', component: LoginComponent },
      { path: 'novo-usuario', component: CadastroUsuarioComponent }
    ])
  ],
  providers: [UsuariosService, ProdutosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
