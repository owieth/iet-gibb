import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {PhotoGalleryComponent} from './photo-gallery/photo-gallery.component';
import {ErrorComponent} from './error/error.component';
import {PersonalportfolioComponent} from './personalportfolio/personalportfolio.component';
import {VideoComponent} from './video/video.component';
import jsonData from './text.json';

const routes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'gallery', component: PhotoGalleryComponent},
    {path: 'video', component: VideoComponent},
    {path: 'gallery/domenico', component: PersonalportfolioComponent, data: jsonData.domenico },
    {path: 'gallery/nils', component: PersonalportfolioComponent, data: jsonData.nils },
    {path: 'gallery/remy', component: PersonalportfolioComponent, data: jsonData.remy },
    {path: 'gallery/olivier', component: PersonalportfolioComponent, data: jsonData.olivier },
    {path: '**', component: ErrorComponent},
];

@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
