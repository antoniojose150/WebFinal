import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  templateUrl: './canciones.component.html'
})
export class CancionesComponent implements OnInit {

  public canciones: Cancion[] = [];
  public playlistId: number | undefined;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {}


  ngOnInit(): void {
    this.playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));

    this.http.get<Cancion[]>(this.baseUrl + 'api/playlist/' + this.playlistId + '/cancion').subscribe(result => {
      this.canciones = result;
      console.log(result);
    }, error => console.error(error));

  }



}



interface Cancion {
  id: number;
  name: number;
  descripcion: string;
  playlistId: number;
}
