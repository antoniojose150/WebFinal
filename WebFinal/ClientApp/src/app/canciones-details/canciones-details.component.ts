import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { style } from '@angular/animations';
import { DataService } from '../Interface/Cancion.service';
import { CancionForm } from '../Interface/cancion';

@Component({
  templateUrl: './canciones-details.component.html'
})
export class CancionesDetailsComponent implements OnInit {

  public cancion!: Cancion;
  public cancionId: number | undefined;
  public playlistId: number | undefined;

  cancionUpdate: CancionForm = {

    name:"",
    descripcion:""

  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute
    , private cancionForm: DataService) { }


  ngOnInit(): void {
    this.playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));
    this.cancionId = Number(this.route.snapshot.paramMap.get('cancionId'));

    this.http.get<Cancion>(this.baseUrl + 'api/playlist/' + this.playlistId + '/cancion/' + this.cancionId).subscribe(result => {
      this.cancion = result;
      console.log(result);
    }, error => console.error(error));


  }

  onSubmit(form: NgForm) {
    console.log('in onSubmit: ', form.valid);
    console.log(form.name);
    this.cancionForm.postCancionForm(this.cancionUpdate).subscribe(
      result => console.log('success: ', result),
      error => console.log('error ',error)
    );
    var mensaje;
    var mensajejson;
    if (this.cancionUpdate.name != "" && this.cancionUpdate.descripcion == "") {
      mensaje = [
        {
          "op": "replace",
          "path": "/name",
          "value": this.cancionUpdate.name
        }
      ];
    } else if (this.cancionUpdate.descripcion != "" && this.cancionUpdate.name == "") {
      mensaje = [
        {
          "op": "replace",
          "path": "/descripcion",
          "value": this.cancionUpdate.descripcion
        }
      ];
    } else if (this.cancionUpdate.descripcion != "" && this.cancionUpdate.name != "") {
      mensajejson = 
      {
        "name": this.cancionUpdate.name,
        "descripcion": this.cancionUpdate.descripcion
        }
    }

    if ((this.cancionUpdate.descripcion != "" && this.cancionUpdate.name == "") || (this.cancionUpdate.descripcion == "" && this.cancionUpdate.name != "")) {
      this.http.patch(this.baseUrl + 'api/playlist/' + this.playlistId + '/cancion/' + this.cancionId, mensaje).subscribe(response => {
        console.log(response);
      }, error => console.error(error));
    }
    else if (this.cancionUpdate.descripcion != "" && this.cancionUpdate.name != "") {
      this.http.put<any>(this.baseUrl + 'api/playlist/' + this.playlistId + '/cancion/' + this.cancionId, mensajejson).subscribe(response => {
        console.log(response);
      }, error => console.error(error));
    }

    

  }

  clickmodificar(): void {
    const form = document.getElementById('formulario');
    if (form != null) {
      form.style.visibility = "visible";
    }
    

  }



}



interface Cancion {
  id: number;
  name: string;
  descripcion: string;
  playlistId: number;
}
