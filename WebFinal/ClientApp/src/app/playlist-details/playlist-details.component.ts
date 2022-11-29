import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { PlaylistComponent } from '../playlist/playlist.component';

@Component({
  templateUrl: './playlist-details.component.html'
})
export class PlaylistDetailComponent implements OnInit {
  public playlist!: Playlist;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    
  }


  ngOnInit(): void {
    const playlistId = Number(this.route.snapshot.paramMap.get('playlistId'));

    this.http.get<Playlist>(this.baseUrl + 'api/playlist/' + playlistId + '?incluyecanciones=true').subscribe(result => {
      this.playlist = result;
      console.log(result);
    }, error => console.error(error));

    
  }

}

interface Playlist {
  id: number;
  name: number;
  descripcion: string;
  canciones: Cancion[];
}

interface Cancion {
  id: number;
  name: number;
  descripcion: number;
}
