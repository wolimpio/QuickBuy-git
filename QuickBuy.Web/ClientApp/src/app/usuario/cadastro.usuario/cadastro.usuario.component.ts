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

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuario = new Usuario();
  }

  public Cadastrar() {
    this.usuariosService.cadastrarUsuario(this.usuario).subscribe(
      usuarioRetorno => {

      },
      err => {

      }
    );
  }

}
