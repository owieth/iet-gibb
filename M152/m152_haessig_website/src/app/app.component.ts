import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  sites: Array<any> = [
    {site: 'home', image: '../../assets/landscape.png', title: 'Home'},
    {site: 'gallery', image: '../../assets/camera.jpg', title: 'Fotos'},
    {site: 'video', image: '../../assets/video.jpg', title: 'Video'}
  ];
}
