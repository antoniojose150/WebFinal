import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html'
})
export class PlaylistComponent {
  public playlists: Playlist[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Playlist[]>(baseUrl + 'api/playlist').subscribe(result => {
      this.playlists = result;
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
  playlistId: number;
  playlist: Playlist;
}
