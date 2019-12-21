import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/modelo/usuario';
import { UsuariosService } from 'src/app/servicos/usuarios/usuarios.service';

@Component({
  selector: 'app-cadastro.usuario',
  templateUrl: './cadastro.usuario.component.html',
  styleUrls: ['./cadastro.usuario.component.css']
})
export class CadastroUsuarioComponent implements OnInit {

  public usuario: Usuario;
  public mensagem: string;
  public ativar_spinner: boolean = false;
  public usuario_cadastrado: boolean = false;

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuario = new Usuario();
  }

  public cadastrar() {
    this.ativar_spinner = true;
    this.mensagem = '';
    this.usuario_cadastrado = false;

    this.usuariosService.cadastrarUsuario(this.usuario).subscribe(
      usuarioRetorno => {
        this.usuario_cadastrado = true;
        this.ativar_spinner = false;
      },
      err => {
        this.mensagem = err.error;
        this.ativar_spinner = false;
      }
    );

  }

}
